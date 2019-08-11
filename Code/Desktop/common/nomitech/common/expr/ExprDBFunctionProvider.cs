using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Desktop.common.nomitech.common.expr
{
	using FunctionTable = nomitech.common.db.local.FunctionTable;
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprFunction = org.boris.expr.ExprFunction;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using IExprFunction = org.boris.expr.IExprFunction;
	using IFunctionProvider = org.boris.expr.function.IFunctionProvider;
	using Session = org.hibernate.Session;

	public class ExprDBFunctionProvider : IFunctionProvider
	{
	  private static ExprDBFunctionProvider functionProvider;

	  private IDictionary<string, IExprFunction> functions = new ConcurrentDictionary();

	  private IDictionary<string, ExprFunctionDefinition> definitions = new ConcurrentDictionary();

	  private void reload(Session paramSession)
	  {
		this.functions.Clear();
		this.definitions.Clear();
		if (paramSession == null)
		{
		  if (DatabaseDBUtil.LocalCommunication)
		  {
			bool @bool = !DatabaseDBUtil.hasOpenedSession() ? 1 : 0;
			paramSession = DatabaseDBUtil.currentSession();
			foreach (FunctionTable functionTable1 in paramSession.createQuery("from FunctionTable o left join fetch o.functionArgumentList").list())
			{
			  FunctionTable functionTable2 = functionTable1.copyWithVariables();
			  this.functions[functionTable1.Name] = new ExprDBFunction(functionTable2);
			  this.definitions[functionTable1.Name] = new ExprFunctionDefinition(functionTable2);
			}
			if (@bool)
			{
			  DatabaseDBUtil.closeSession();
			}
		  }
		  else
		  {
			try
			{
			  foreach (FunctionTable functionTable in DatabaseDBUtil.loadAllDeepCopy(typeof(FunctionTable)))
			  {
				this.functions[functionTable.Name] = new ExprDBFunction(functionTable);
				this.definitions[functionTable.Name] = new ExprFunctionDefinition(functionTable);
			  }
			}
			catch (Exception exception)
			{
			  Console.WriteLine(exception.ToString());
			  Console.Write(exception.StackTrace);
			}
		  }
		}
		else
		{
		  foreach (FunctionTable functionTable1 in paramSession.createQuery("from FunctionTable o left join fetch o.functionArgumentList").list())
		  {
			FunctionTable functionTable2 = functionTable1.copyWithVariables();
			this.functions[functionTable1.Name] = new ExprDBFunction(functionTable2);
			this.definitions[functionTable1.Name] = new ExprFunctionDefinition(functionTable2);
		  }
		}
	  }

	  public virtual void addOrUpdateFunction(FunctionTable paramFunctionTable)
	  {
		FunctionTable functionTable = paramFunctionTable.copyWithVariables();
		this.functions[paramFunctionTable.Name] = new ExprDBFunction(functionTable);
		this.definitions[paramFunctionTable.Name] = new ExprFunctionDefinition(functionTable);
	  }

	  public virtual bool hasFunctionName(string paramString)
	  {
		  return this.functions.ContainsKey(paramString.ToUpper());
	  }

	  public virtual bool hasFunction(ExprFunction paramExprFunction)
	  {
		  return this.functions.ContainsKey(paramExprFunction.Name.ToUpper());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.ExprFunction paramExprFunction) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, ExprFunction paramExprFunction)
	  {
		IExprFunction iExprFunction = (IExprFunction)this.functions[paramExprFunction.Name.ToUpper()];
		return (iExprFunction != null) ? iExprFunction.evaluate(paramIEvaluationContext, paramExprFunction.Args) : null;
	  }

	  public virtual IDictionary<string, IExprFunction> Functions
	  {
		  get
		  {
			  return this.functions;
		  }
	  }

	  public virtual IDictionary<string, ExprFunctionDefinition> Definitions
	  {
		  get
		  {
			  return this.definitions;
		  }
	  }

	  public static ExprDBFunctionProvider getInstance(bool paramBoolean)
	  {
		if (functionProvider == null)
		{
		  functionProvider = new ExprDBFunctionProvider();
		  functionProvider.reload(null);
		}
		else if (paramBoolean)
		{
		  functionProvider.reload(null);
		}
		return functionProvider;
	  }

	  public static ExprDBFunctionProvider getInstance(Session paramSession, bool paramBoolean)
	  {
		if (functionProvider == null)
		{
		  functionProvider = new ExprDBFunctionProvider();
		  functionProvider.reload(paramSession);
		}
		else if (paramBoolean)
		{
		  functionProvider.reload(paramSession);
		}
		return functionProvider;
	  }

	  public virtual IList<string> AvailableGroupings
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (string str1 in this.functions.Keys)
			{
			  ExprDBFunction exprDBFunction = (ExprDBFunction)this.functions[str1];
			  string str2 = exprDBFunction.FunctionTable.Grouping;
			  if (!arrayList.Contains(str2))
			  {
				arrayList.Add(str2);
			  }
			}
			return arrayList;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\ExprDBFunctionProvider.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
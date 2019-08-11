using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr.localVars
{
	using BaseEntity = Desktop.common.nomitech.common.@base.BaseEntity;
	using ParamItemInputTable = Models.local.ParamItemInputTable;
	using BoqItemFormulaEvaluator = nomitech.common.expr.boqitem.BoqItemFormulaEvaluator;
	using StringUtils = Desktop.common.nomitech.common.util.StringUtils;
	using Expr = Desktop.common.org.boris.expr.Expr;
	using ExprDouble = Desktop.common.org.boris.expr.ExprDouble;
	using ExprException = Desktop.common.org.boris.expr.ExprException;
	using ExprFunction = Desktop.common.org.boris.expr.ExprFunction;
	using ExprVariable = Desktop.common.org.boris.expr.ExprVariable;

	public class LocalVariablesEvaluationContext : ExprAbstractEvaluationContext
	{
	  public IDictionary<string, decimal> localVariableMap = new SortedDictionary(string.CASE_INSENSITIVE_ORDER);

	  private string currentVariableName = "";

	  private IDictionary<string, string> localVariablesFormulaMap = new Hashtable();

	  private ISet<string> usedLocalVariablesInFormula = new HashSet<object>();

	  private bool circularError = false;

	  public LocalVariablesEvaluationContext(IDictionary<string, decimal> paramMap)
	  {
		this.localVariableMap = paramMap;
		this.usedLocalVariablesInFormula = new HashSet<object>();
	  }

	  public virtual void initCircularRefernceChecker(string paramString, IDictionary<string, string> paramMap)
	  {
		this.circularError = false;
		this.currentVariableName = paramString;
		this.localVariablesFormulaMap = paramMap;
	  }

	  public virtual ISet<string> UsedLocalVariablesInFormula
	  {
		  get
		  {
			  return this.usedLocalVariablesInFormula;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr parseStatement(String paramString) throws org.boris.expr.ExprException
	  public override Expr parseStatement(string paramString)
	  {
		  return base.parseStatement(paramString);
	  }

	  private string variableFromField(string paramString)
	  {
		  return BoqItemFormulaEvaluator.variableFromField(paramString);
	  }

	  private object getFieldValue(BaseEntity paramBaseEntity, string paramString)
	  {
		if (paramBaseEntity == null || string.ReferenceEquals(paramString, null))
		{
		  return null;
		}
		try
		{
		  string str1 = "" + paramString[0];
		  string str2 = "get" + str1.ToUpper() + paramString.Substring(1);
		  System.Reflection.MethodInfo method = paramBaseEntity.GetType().GetMethod(str2, new Type[0]);
		  return method.invoke(paramBaseEntity, new object[0]);
		}
		catch (Exception)
		{
		  return null;
		}
	  }

	  private Type getReturnType(BaseEntity paramBaseEntity, string paramString)
	  {
		if (paramBaseEntity == null || string.ReferenceEquals(paramString, null))
		{
		  return null;
		}
		try
		{
		  string str1 = "" + paramString[0];
		  string str2 = "get" + str1.ToUpper() + paramString.Substring(1);
		  System.Reflection.MethodInfo method = paramBaseEntity.GetType().GetMethod(str2, new Type[0]);
		  return method.ReturnType;
		}
		catch (Exception)
		{
		  return null;
		}
	  }

	  public override ExprWithDefinition[] VariablesArray
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (string str in this.localVariableMap.Keys)
			{
			  ParamItemInputTable paramItemInputTable = new ParamItemInputTable();
			  paramItemInputTable.Name = str;
			  paramItemInputTable.DataType = "datatype.decimal";
			  ExprDefinition exprDefinition = new ExprDefinition(str, "number", "");
			  ExprWithDefinition exprWithDefinition = new ExprWithDefinition(paramItemInputTable, exprDefinition);
			  arrayList.Add(exprWithDefinition);
			}
			ExprWithDefinition[] arrayOfExprWithDefinition = (ExprWithDefinition[])arrayList.ToArray(typeof(ExprWithDefinition));
			Arrays.sort(arrayOfExprWithDefinition);
			return arrayOfExprWithDefinition;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluateFunction(org.boris.expr.ExprFunction paramExprFunction) throws org.boris.expr.ExprException
	  public virtual Expr evaluateFunction(ExprFunction paramExprFunction)
	  {
		if (this.exfp.hasFunction(paramExprFunction))
		{
		  return this.exfp.evaluate(this, paramExprFunction);
		}
		if (this.dbfp.hasFunction(paramExprFunction))
		{
		  return this.dbfp.evaluate(this, paramExprFunction);
		}
		throw new ExprException("Function " + paramExprFunction + " not supported");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluateVariable(org.boris.expr.ExprVariable paramExprVariable) throws org.boris.expr.ExprException
	  public virtual Expr evaluateVariable(ExprVariable paramExprVariable)
	  {
		string str = paramExprVariable.Name.ToUpper();
		if (!this.circularError)
		{
		  if (StringUtils.checkEquality(this.currentVariableName.ToUpper(), str))
		  {
			throw new CircularExprException(this, "Circullar reference.Invalid variable " + str);
		  }
		  if (!string.ReferenceEquals(this.localVariablesFormulaMap[str], null))
		  {
			string str1 = ((string)this.localVariablesFormulaMap[str]).ToString();
			if (str1.Length > 0)
			{
			  parseStatement(str1);
			}
		  }
		  this.usedLocalVariablesInFormula.Add(paramExprVariable.Name);
		}
		return evaluateVariable(str);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluateVariable(String paramString) throws org.boris.expr.ExprException
	  public virtual Expr evaluateVariable(string paramString)
	  {
		if (hasAdditionalVariable(paramString))
		{
		  return getAdditionalVariableValue(paramString);
		}
		if (this.localVariableMap.ContainsKey(paramString))
		{
		  return new ExprDouble(((decimal)this.localVariableMap[paramString]).doubleValue());
		}
		throw new ExprException("Variable " + paramString + " not found");
	  }

	  public class CircularExprException : ExprException
	  {
		  private readonly LocalVariablesEvaluationContext outerInstance;

		public CircularExprException(LocalVariablesEvaluationContext outerInstance, string param1String) : base(param1String)
		{
			this.outerInstance = outerInstance;
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\localVars\LocalVariablesEvaluationContext.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
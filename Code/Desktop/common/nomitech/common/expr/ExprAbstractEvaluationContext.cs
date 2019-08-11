using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Desktop.common.nomitech.common.expr
{
	using ParamItemInputTable = nomitech.common.db.local.ParamItemInputTable;
	using ProjectUrlTable = nomitech.common.db.local.ProjectUrlTable;
	using ProjectVariableTable = nomitech.common.db.project.ProjectVariableTable;
	using StringUtils = nomitech.common.util.StringUtils;
	using Expr = org.boris.expr.Expr;
	using ExprEvaluatable = org.boris.expr.ExprEvaluatable;
	using ExprException = org.boris.expr.ExprException;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using ExprLexer = org.boris.expr.parser.ExprLexer;
	using ExprParser = org.boris.expr.parser.ExprParser;
	using Exprs = org.boris.expr.util.Exprs;
	using Session = org.hibernate.Session;

	public abstract class ExprAbstractEvaluationContext : IEvaluationContext
	{
	  private int? loopIndex = null;

	  private decimal globalQuantity = null;

	  private object[] currentRow = null;

	  protected internal IDictionary<string, Expr> expandedValues = new Hashtable();

	  protected internal ExprExcelFunctionProvider exfp;

	  protected internal ExprDBFunctionProvider dbfp = null;

	  private Session databaseSession = null;

	  private Session projectSession = null;

	  private ProjectUrlTable urlTable = null;

	  private IDictionary<string, object> projectVariableNameValueMap = new Hashtable();

	  private ISet<string> varNames = new HashSet<object>();

	  private string fieldName;

	  private string pvVars;

	  protected internal StringBuilder pvVarsCalled;

	  public virtual string CurrentField
	  {
		  set
		  {
			this.fieldName = value;
			this.pvVars = null;
			this.varNames.Clear();
		  }
	  }

	  public virtual void addVariable(string paramString)
	  {
		if (string.ReferenceEquals(this.pvVars, null))
		{
		  this.pvVars = this.fieldName + ":" + paramString;
		  this.varNames.Add(paramString);
		}
		else if (!this.varNames.Contains(paramString))
		{
		  this.pvVars += "," + paramString;
		  this.varNames.Add(paramString);
		}
	  }

	  public virtual string PvVars
	  {
		  get
		  {
			this.fieldName = null;
			this.varNames.Clear();
			return this.pvVars;
		  }
	  }

	  public ExprAbstractEvaluationContext()
	  {
		this.dbfp = ExprDBFunctionProvider.getInstance(false);
		this.exfp = new ExprExcelFunctionProvider();
	  }

	  public ExprAbstractEvaluationContext(Session paramSession)
	  {
		this.dbfp = ExprDBFunctionProvider.getInstance(paramSession, false);
		this.exfp = new ExprExcelFunctionProvider();
	  }

	  public virtual Session MasterDatabaseSession
	  {
		  get
		  {
			  return this.databaseSession;
		  }
		  set
		  {
			  this.databaseSession = value;
		  }
	  }

	  public virtual ProjectUrlTable ProjectUrlTable
	  {
		  get
		  {
			  return this.urlTable;
		  }
	  }

	  public virtual Session ProjectDatabaseSession
	  {
		  get
		  {
			  return this.projectSession;
		  }
	  }

	  public virtual object getProjectVariableValue(string paramString)
	  {
		  return this.projectVariableNameValueMap[paramString];
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int sheetRowAt(String paramString1, int paramInt, String paramString2) throws org.boris.expr.ExprException
	  public virtual int sheetRowAt(string paramString1, int paramInt, string paramString2)
	  {
		  return -1;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public String sheetValueAt(String paramString1, int paramInt1, int paramInt2, String paramString2) throws org.boris.expr.ExprException
	  public virtual string sheetValueAt(string paramString1, int paramInt1, int paramInt2, string paramString2)
	  {
		  return paramString2;
	  }

	  public virtual IList<long> SelectedBoqItemIds
	  {
		  get
		  {
			  return new List<object>();
		  }
	  }

	  protected internal virtual void setProjectDatabaseSession(Session paramSession, ProjectUrlTable paramProjectUrlTable)
	  {
		this.projectSession = paramSession;
		this.urlTable = paramProjectUrlTable;
		if (paramSession == null)
		{
		  return;
		}
		System.Collections.IList list = paramSession.createQuery("from ProjectVariableTable as o where o.projectId = :projectId").setLong("projectId", paramProjectUrlTable.ProjectUrlId.Value).list();
		foreach (ProjectVariableTable projectVariableTable in list)
		{
		  string str1 = projectVariableTable.Name;
		  string str2 = null;
		  if (projectVariableTable.Number.Value)
		  {
			str2 = projectVariableTable.StoredValueNum;
		  }
		  else
		  {
			str2 = projectVariableTable.StoredValue;
		  }
		  if (string.ReferenceEquals(str2, null))
		  {
			continue;
		  }
		  this.projectVariableNameValueMap[str1] = str2;
		}
	  }

	  public virtual IDictionary<string, object> ProjectVariableNameValueMap
	  {
		  set
		  {
			  this.projectVariableNameValueMap = value;
		  }
	  }


	  public virtual int? LoopIndex
	  {
		  get
		  {
			  return this.loopIndex;
		  }
		  set
		  {
			  this.loopIndex = value;
		  }
	  }


	  public virtual decimal GlobalQuantity
	  {
		  get
		  {
			  return this.globalQuantity;
		  }
		  set
		  {
			  this.globalQuantity = value;
		  }
	  }


	  public virtual object[] CurrentRow
	  {
		  get
		  {
			  return this.currentRow;
		  }
		  set
		  {
			  this.currentRow = value;
		  }
	  }


	  public virtual void addAdditionalVariable(string paramString, Expr paramExpr)
	  {
		  this.expandedValues[paramString.ToUpper()] = paramExpr;
	  }

	  public virtual void removeAdditionalVariable(string paramString)
	  {
		  this.expandedValues.Remove(paramString.ToUpper());
	  }

	  public virtual bool hasAdditionalVariable(string paramString)
	  {
		  return this.expandedValues.ContainsKey(paramString.ToUpper());
	  }

	  public virtual Expr getAdditionalVariableValue(string paramString)
	  {
		  return (Expr)this.expandedValues[paramString.ToUpper()];
	  }

	  public virtual IDictionary<string, Expr> AdditionalVariablesMap
	  {
		  get
		  {
			  return this.expandedValues;
		  }
	  }

	  public virtual ExprExcelFunctionProvider ExprExcelFunctionProvider
	  {
		  get
		  {
			  return this.exfp;
		  }
	  }

	  public virtual ExprDBFunctionProvider ExprDBFunctionProvider
	  {
		  get
		  {
			  return this.dbfp;
		  }
	  }

	  public virtual Expr parseStatement(string paramString)
	  {
		paramString = StringUtils.escapeParametricExpression(paramString);
		ExprParser exprParser = new ExprParser();
		try
		{
		  exprParser.parse(new ExprLexer(paramString));
		}
		catch (IOException iOException)
		{
		  Console.WriteLine(iOException.ToString());
		  Console.Write(iOException.StackTrace);
		  throw new ExprException(iOException.Message);
		}
		Expr expr = exprParser.get();
		Exprs.ToUpper(expr);
		if (expr is ExprEvaluatable)
		{
		  expr = ((ExprEvaluatable)expr).evaluate(this);
		}
		else
		{
		  throw new ExprException("Not Evaluatable result for: " + paramString);
		}
		return expr;
	  }

	  public virtual bool isVariableShowing(string paramString)
	  {
		  return hasAdditionalVariable(paramString.ToUpper()) ? true : true;
	  }

	  public virtual bool isVariableValid(string paramString)
	  {
		  return hasAdditionalVariable(paramString.ToUpper()) ? true : true;
	  }

	  public virtual ExprWithDefinition[] VariablesArray
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			ParamItemInputTable paramItemInputTable = new ParamItemInputTable();
			paramItemInputTable.Name = "TEST_VAR";
			paramItemInputTable.DataType = "datatype.decimal";
			ExprDefinition exprDefinition = new ExprDefinition(paramItemInputTable.Name, "number", "");
			ExprWithDefinition exprWithDefinition = new ExprWithDefinition(paramItemInputTable, exprDefinition);
			arrayList.Add(exprWithDefinition);
			ExprWithDefinition[] arrayOfExprWithDefinition = (ExprWithDefinition[])arrayList.ToArray(typeof(ExprWithDefinition));
			Arrays.sort(arrayOfExprWithDefinition);
			return arrayOfExprWithDefinition;
		  }
	  }

	  public virtual ExprWithDefinition[] VariablesArrayWithoutPV
	  {
		  get
		  {
			  return VariablesArray;
		  }
	  }

	  public virtual long? UserObject
	  {
		  get
		  {
			  return null;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\ExprAbstractEvaluationContext.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
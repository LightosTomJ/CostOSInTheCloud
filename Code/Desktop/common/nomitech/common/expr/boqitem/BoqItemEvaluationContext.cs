using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr.boqitem
{
	using BaseEntity = nomitech.common.@base.BaseEntity;
	using ParamItemInputTable = nomitech.common.db.local.ParamItemInputTable;
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using LocalVariablesDatabaseUtil = nomitech.common.db.util.LocalVariablesDatabaseUtil;
	using Expr = org.boris.expr.Expr;
	using ExprBoolean = org.boris.expr.ExprBoolean;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using ExprFunction = org.boris.expr.ExprFunction;
	using ExprString = org.boris.expr.ExprString;
	using ExprVariable = org.boris.expr.ExprVariable;
	using ExcelDate = org.boris.expr.util.ExcelDate;

	public class BoqItemEvaluationContext : ExprAbstractEvaluationContext
	{
	  private IDictionary<string, decimal> decimalVariableMap = new Hashtable();

	  private IDictionary<string, string> textVariableMap = new Hashtable();

	  private IDictionary<string, DateTime> dateVariableMap = new Hashtable();

	  private IDictionary<string, bool> booleanVariableMap = new Hashtable();

	  private IDictionary<string, decimal> localVariableMap = new Hashtable();

	  private ISet<string> usedLocalVariablesInFormula = new HashSet<object>();

	  private string currentField;

	  private BoqItemTable boqTable;

	  public BoqItemEvaluationContext(BoqItemTable paramBoqItemTable, string paramString)
	  {
		this.currentField = paramString;
		this.boqTable = paramBoqItemTable;
		reloadVariables();
	  }

	  public virtual BoqItemTable BoqTable
	  {
		  get
		  {
			  return this.boqTable;
		  }
	  }

	  private string variableFromField(string paramString)
	  {
		  return BoqItemFormulaEvaluator.variableFromField(paramString);
	  }

	  public override object getProjectVariableValue(string paramString)
	  {
		  return ProjectDBUtil.currentProjectDBUtil().ProjectVariableCache.ProjectVariableMap[paramString];
	  }

	  public virtual IDictionary<string, decimal> LocalVariableMap
	  {
		  get
		  {
			  return this.localVariableMap;
		  }
	  }

	  public virtual void reloadVariables()
	  {
		foreach (string str in BoqItemTable.VIEWABLE_FIELDS)
		{
		  if (!this.currentField.Equals(str))
		  {
			object @object = getFieldValue(this.boqTable, str);
			if (@object is Number)
			{
			  if (@object is decimal)
			  {
				this.decimalVariableMap[variableFromField(str)] = (decimal)@object;
			  }
			  else
			  {
				this.decimalVariableMap[variableFromField(str)] = new BigDecimalFixed(@object.ToString());
			  }
			}
			else if (@object is string)
			{
			  this.textVariableMap[variableFromField(str)] = (string)@object;
			}
			else if (@object is DateTime)
			{
			  this.dateVariableMap[variableFromField(str)] = (DateTime)@object;
			}
			else if (@object is bool?)
			{
			  this.booleanVariableMap[variableFromField(str)] = (bool?)@object;
			}
			else if (@object == null)
			{
			  this.textVariableMap[variableFromField(str)] = "";
			}
		  }
		}
		this.localVariableMap = LocalVariablesDatabaseUtil.getLocalVariables(this.boqTable.Vars);
	  }

	  public virtual object getFieldValue(BaseEntity paramBaseEntity, string paramString)
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
		  return evaluateVariable(paramExprVariable.Name);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluateVariable(String paramString) throws org.boris.expr.ExprException
	  public virtual Expr evaluateVariable(string paramString)
	  {
		string str = paramString;
		paramString = paramString.ToUpper();
		if (hasAdditionalVariable(paramString))
		{
		  return getAdditionalVariableValue(paramString);
		}
		if (this.decimalVariableMap.ContainsKey(paramString))
		{
		  return new ExprDouble(((decimal)this.decimalVariableMap[paramString]).doubleValue());
		}
		if (this.localVariableMap.ContainsKey(paramString))
		{
		  this.usedLocalVariablesInFormula.Add(paramString);
		  return new ExprDouble(((decimal)this.localVariableMap[paramString]).doubleValue());
		}
		if (this.textVariableMap.ContainsKey(paramString))
		{
		  return new ExprString(((string)this.textVariableMap[paramString]).ToString());
		}
		if (this.dateVariableMap.ContainsKey(paramString))
		{
		  DateTime date = (DateTime)this.dateVariableMap[paramString];
		  return (date == null) ? new ExprDouble(0.0D) : new ExprDouble(ExcelDate.toExcelDate(date.Ticks));
		}
		if (this.booleanVariableMap.ContainsKey(paramString))
		{
		  return new ExprBoolean(((bool?)this.booleanVariableMap[paramString]).Value);
		}
		throw new ExprException("Variable " + str + " not found");
	  }

	  public virtual ISet<string> UsedLocalVariablesInFormula
	  {
		  get
		  {
			  return this.usedLocalVariablesInFormula;
		  }
	  }

	  public virtual ExprWithDefinition[] LocalVariablesArray
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			null = this.decimalVariableMap.Keys.GetEnumerator();
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

	  public override ExprWithDefinition[] VariablesArray
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (string str in this.decimalVariableMap.Keys)
			{
			  ParamItemInputTable paramItemInputTable = new ParamItemInputTable();
			  paramItemInputTable.Name = str;
			  paramItemInputTable.DataType = "datatype.decimal";
			  ExprDefinition exprDefinition = new ExprDefinition(str, "number", "");
			  ExprWithDefinition exprWithDefinition = new ExprWithDefinition(paramItemInputTable, exprDefinition);
			  arrayList.Add(exprWithDefinition);
			}
			foreach (string str in this.textVariableMap.Keys)
			{
			  ParamItemInputTable paramItemInputTable = new ParamItemInputTable();
			  paramItemInputTable.Name = str;
			  paramItemInputTable.DataType = "datatype.list";
			  ExprDefinition exprDefinition = new ExprDefinition(str, "text", "");
			  ExprWithDefinition exprWithDefinition = new ExprWithDefinition(paramItemInputTable, exprDefinition);
			  arrayList.Add(exprWithDefinition);
			}
			foreach (string str in this.dateVariableMap.Keys)
			{
			  ParamItemInputTable paramItemInputTable = new ParamItemInputTable();
			  paramItemInputTable.Name = str;
			  paramItemInputTable.DataType = "datatype.decimal";
			  ExprDefinition exprDefinition = new ExprDefinition(str, "date", "");
			  ExprWithDefinition exprWithDefinition = new ExprWithDefinition(paramItemInputTable, exprDefinition);
			  arrayList.Add(exprWithDefinition);
			}
			if (ProjectDBUtil.currentProjectDBUtil() != null)
			{
			  foreach (string str in ProjectDBUtil.currentProjectDBUtil().ProjectVariableCache.ProjectVariableMap.Keys)
			  {
				if (this.localVariableMap[str] != null)
				{
				  continue;
				}
				ParamItemInputTable paramItemInputTable = new ParamItemInputTable();
				paramItemInputTable.Name = str;
				paramItemInputTable.DataType = "datatype.decimal";
				ExprDefinition exprDefinition = new ExprDefinition(str, "number", "");
				ExprWithDefinition exprWithDefinition = new ExprWithDefinition(paramItemInputTable, exprDefinition);
				arrayList.Add(exprWithDefinition);
			  }
			}
			ExprWithDefinition[] arrayOfExprWithDefinition = (ExprWithDefinition[])arrayList.ToArray(typeof(ExprWithDefinition));
			Arrays.sort(arrayOfExprWithDefinition);
			return arrayOfExprWithDefinition;
		  }
	  }

	  public override ExprWithDefinition[] VariablesArrayWithoutPV
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (string str in this.decimalVariableMap.Keys)
			{
			  ParamItemInputTable paramItemInputTable = new ParamItemInputTable();
			  paramItemInputTable.Name = str;
			  paramItemInputTable.DataType = "datatype.decimal";
			  ExprDefinition exprDefinition = new ExprDefinition(str, "number", "");
			  ExprWithDefinition exprWithDefinition = new ExprWithDefinition(paramItemInputTable, exprDefinition);
			  arrayList.Add(exprWithDefinition);
			}
			foreach (string str in this.textVariableMap.Keys)
			{
			  ParamItemInputTable paramItemInputTable = new ParamItemInputTable();
			  paramItemInputTable.Name = str;
			  paramItemInputTable.DataType = "datatype.list";
			  ExprDefinition exprDefinition = new ExprDefinition(str, "text", "");
			  ExprWithDefinition exprWithDefinition = new ExprWithDefinition(paramItemInputTable, exprDefinition);
			  arrayList.Add(exprWithDefinition);
			}
			foreach (string str in this.dateVariableMap.Keys)
			{
			  ParamItemInputTable paramItemInputTable = new ParamItemInputTable();
			  paramItemInputTable.Name = str;
			  paramItemInputTable.DataType = "datatype.decimal";
			  ExprDefinition exprDefinition = new ExprDefinition(str, "date", "");
			  ExprWithDefinition exprWithDefinition = new ExprWithDefinition(paramItemInputTable, exprDefinition);
			  arrayList.Add(exprWithDefinition);
			}
			ExprWithDefinition[] arrayOfExprWithDefinition = (ExprWithDefinition[])arrayList.ToArray(typeof(ExprWithDefinition));
			Arrays.sort(arrayOfExprWithDefinition);
			return arrayOfExprWithDefinition;
		  }
	  }

	  public virtual void setDecimalValue(string paramString, decimal paramBigDecimal)
	  {
		  this.decimalVariableMap[paramString] = paramBigDecimal;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\boqitem\BoqItemEvaluationContext.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
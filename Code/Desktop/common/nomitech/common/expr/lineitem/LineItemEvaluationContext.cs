using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr.lineitem
{
	using BaseEntity = Desktop.common.nomitech.common.@base.BaseEntity;
	using AssemblyTable = Models.local.AssemblyTable;
	using ParamItemInputTable = Models.local.ParamItemInputTable;
	using BoqItemTable = Models.proj.BoqItemTable;
	using BigDecimalFixed = Models.types.BigDecimalFixed;
	using LocalVariablesDatabaseUtil = Models.util.LocalVariablesDatabaseUtil;
	using BlankResourceInitializer = Desktop.common.nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BoqItemFormulaEvaluator = Desktop.common.nomitech.common.expr.boqitem.BoqItemFormulaEvaluator;
	using Expr = Desktop.common.org.boris.expr.Expr;
	using ExprBoolean = Desktop.common.org.boris.expr.ExprBoolean;
	using ExprDouble = Desktop.common.org.boris.expr.ExprDouble;
	using ExprException = Desktop.common.org.boris.expr.ExprException;
	using ExprFunction = Desktop.common.org.boris.expr.ExprFunction;
	using ExprString = Desktop.common.org.boris.expr.ExprString;
	using ExprVariable = Desktop.common.org.boris.expr.ExprVariable;
	using ExcelDate = Desktop.common.org.boris.expr.util.ExcelDate;

	public class LineItemEvaluationContext : ExprAbstractEvaluationContext
	{
	  private IDictionary<string, decimal> decimalVariableMap = new Hashtable();

	  private IDictionary<string, string> textVariableMap = new Hashtable();

	  private IDictionary<string, DateTime> dateVariableMap = new Hashtable();

	  private IDictionary<string, bool> booleanVariableMap = new Hashtable();

	  private IDictionary<string, decimal> localVariableMap = new Hashtable();

	  private ISet<string> usedLocalVariablesInFormula = new HashSet<object>();

	  private AssemblyTable assemblyTable;

	  private BoqItemTable boqItemTable;

	  private IList<string> lineItemFields = Arrays.asList(AssemblyTable.VIEWABLE_FIELDS);

	  public LineItemEvaluationContext(AssemblyTable paramAssemblyTable)
	  {
		this.assemblyTable = paramAssemblyTable;
		this.boqItemTable = BlankResourceInitializer.createBlankBoqItem(null, null, null, false);
		reloadVariables();
	  }

	  public virtual AssemblyTable AssemblyTable
	  {
		  get
		  {
			  return this.assemblyTable;
		  }
	  }

	  public override object getProjectVariableValue(string paramString)
	  {
		  return ProjectDBUtil.currentProjectDBUtil().ProjectVariableCache.ProjectVariableMap[paramString];
	  }

	  public virtual void reloadVariables()
	  {
		foreach (string str in BoqItemTable.VIEWABLE_FIELDS)
		{
		  object @object = getFieldValue(this.assemblyTable, str);
		  if (@object == null && !this.lineItemFields.Contains(str))
		  {
			BigDecimalFixed bigDecimalFixed = new BigDecimalFixed(0);
			DateTime date = DateTime.Now;
			bool? @bool = false;
			Type clazz = getReturnType(this.boqItemTable, str);
			if (clazz != null)
			{
			  if (clazz.Equals(typeof(decimal)))
			  {
				this.decimalVariableMap[BoqItemFormulaEvaluator.variableFromField(str)] = bigDecimalFixed;
			  }
			  else if (clazz.Equals(typeof(string)))
			  {
				this.textVariableMap[BoqItemFormulaEvaluator.variableFromField(str)] = "";
			  }
			  else if (clazz.Equals(typeof(DateTime)))
			  {
				this.dateVariableMap[BoqItemFormulaEvaluator.variableFromField(str)] = date;
			  }
			  else if (clazz.Equals(typeof(Boolean)))
			  {
				this.booleanVariableMap[BoqItemFormulaEvaluator.variableFromField(str)] = @bool.Value;
			  }
			}
		  }
		  else if (@object is Number)
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
		this.localVariableMap = LocalVariablesDatabaseUtil.getLocalVariables(this.assemblyTable.Vars);
	  }

	  public virtual ISet<string> UsedLocalVariablesInFormula
	  {
		  get
		  {
			  return this.usedLocalVariablesInFormula;
		  }
		  set
		  {
			  this.usedLocalVariablesInFormula = value;
		  }
	  }


	  public virtual IDictionary<string, decimal> LocalVariableMap
	  {
		  get
		  {
			  return this.localVariableMap;
		  }
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
		if (this.localVariableMap[paramString] != null)
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
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\lineitem\LineItemEvaluationContext.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
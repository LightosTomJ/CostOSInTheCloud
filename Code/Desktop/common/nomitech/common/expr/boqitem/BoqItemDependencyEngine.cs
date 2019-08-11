using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Desktop.common.nomitech.common.expr.boqitem
{
	using BaseEntity = nomitech.common.@base.BaseEntity;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = nomitech.common.@base.ResourceWithAssignmentsTable;
	using AssemblyAssemblyTable = nomitech.common.db.local.AssemblyAssemblyTable;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using BoqItemAssemblyTable = nomitech.common.db.project.BoqItemAssemblyTable;
	using BoqItemTable = nomitech.common.db.project.BoqItemTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using LocalVariablesDatabaseUtil = nomitech.common.db.util.LocalVariablesDatabaseUtil;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using StringUtils = nomitech.common.util.StringUtils;
	using Expr = org.boris.expr.Expr;
	using ExprBoolean = org.boris.expr.ExprBoolean;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprEvaluatable = org.boris.expr.ExprEvaluatable;
	using ExprException = org.boris.expr.ExprException;
	using ExprFunction = org.boris.expr.ExprFunction;
	using ExprInteger = org.boris.expr.ExprInteger;
	using ExprNumber = org.boris.expr.ExprNumber;
	using ExprString = org.boris.expr.ExprString;
	using ExprVariable = org.boris.expr.ExprVariable;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using ExcelDate = org.boris.expr.util.ExcelDate;

	public class BoqItemDependencyEngine : ExprDependencyEngine
	{
	  private string currentField;

	  private BoqItemTable boqTable;

	  private static readonly ISet<string> formulaFields = new HashSet<object>(Arrays.asList(BoqItemTable.FORMULA_FIELDS));

	  private static readonly IDictionary<string, System.Reflection.MethodInfo> methodFields = new Hashtable();

	  private IDictionary<string, ResourceToAssignmentTable> assignmentsWithFormulasMap = new Hashtable();

	  private ISet<ResourceToAssignmentTable> updatedResourceToAssignmentQtyPerUnitSet = new HashSet<object>();

	  private bool someAssignemntFormulaValueChanged = false;

	  private Dictionary<string, decimal> localVariablesMap = new Hashtable();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public BoqItemDependencyEngine(nomitech.common.db.project.BoqItemTable paramBoqItemTable, String paramString) throws org.boris.expr.ExprException
	  public BoqItemDependencyEngine(BoqItemTable paramBoqItemTable, string paramString)
	  {
		this.currentField = paramString;
		this.boqTable = paramBoqItemTable;
		this.provider = new BoqItemEngineProvider(this);
		AutoCalculate = false;
		reloadVariables();
	  }

	  public virtual object valueFromExpression(string paramString)
	  {
		try
		{
		  Expr expr = parseStatement(paramString);
		  return ((BoqItemEngineProvider)this.provider).valueFromExpression(expr);
		}
		catch (ExprException exprException)
		{
		  Console.WriteLine(exprException.ToString());
		  Console.Write(exprException.StackTrace);
		  return null;
		}
	  }

	  public virtual bool SomeAssignemntFormulaValueChanged
	  {
		  get
		  {
			  return this.someAssignemntFormulaValueChanged;
		  }
	  }

	  public override object getProjectVariableValue(string paramString)
	  {
		  return ProjectDBUtil.currentProjectDBUtil().ProjectVariableCache.ProjectVariableMap[paramString];
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void calculate(boolean paramBoolean) throws org.boris.expr.ExprException
	  public override void calculate(bool paramBoolean)
	  {
		if (this.autoCalculate && !paramBoolean)
		{
		  return;
		}
		this.graph.sort();
		IDictionary<string, ResourceToAssignmentTable>.KeyCollection hashSet = new HashSet<object>(this.assignmentsWithFormulasMap.Keys);
		foreach (Range range in this.graph)
		{
		  string str = range.Dimension1Name;
		  bool @bool = hashSet.contains(str);
		  if (@bool)
		  {
			hashSet.remove(str);
		  }
		  Expr expr = (Expr)this.inputs[range];
		  if (expr is ExprEvaluatable)
		  {
			if (@bool)
			{
			  CurrentField = "QTYPUNITFORM";
			  ResourceToAssignmentTable resourceToAssignmentTable = (ResourceToAssignmentTable)this.assignmentsWithFormulasMap[str];
			  if (resourceToAssignmentTable.getResourceTable() is AssemblyTable)
			  {
				AssemblyTable assemblyTable = (AssemblyTable)resourceToAssignmentTable.getResourceTable();
				loadLocalVariables(assemblyTable.Vars);
			  }
			  else if (resourceToAssignmentTable.getResourceTable() is BoqItemTable)
			  {
				BoqItemTable boqItemTable = (BoqItemTable)resourceToAssignmentTable.getResourceTable();
				loadLocalVariables(boqItemTable.Vars);
			  }
			}
			Expr expr1 = ((ExprEvaluatable)expr).evaluate(this);
			this.provider.valueChanged(range, expr1);
			if (@bool)
			{
			  ((ResourceToAssignmentTable)this.assignmentsWithFormulasMap[str]).PvVars = (string.ReferenceEquals(PvVars, null)) ? "" : PvVars;
			}
			this.values[range] = expr1;
		  }
		}
		foreach (string str in hashSet)
		{
		  CurrentField = "QTYPUNITFORM";
		  ResourceToAssignmentTable resourceToAssignmentTable = (ResourceToAssignmentTable)this.assignmentsWithFormulasMap[str];
		  Expr expr = parseStatement(resourceToAssignmentTable.QuantityPerUnitFormula);
		  Range range = new Range(str);
		  this.provider.valueChanged(range, expr);
		  this.values[range] = expr;
		  resourceToAssignmentTable.PvVars = (string.ReferenceEquals(PvVars, null)) ? "" : PvVars;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void set(String paramString1, String paramString2, org.boris.expr.Expr paramExpr) throws org.boris.expr.ExprException
	  public virtual void set(string paramString1, string paramString2, Expr paramExpr)
	  {
		Range range = Range.valueOf(paramString1);
		validateRange(range);
		if (string.ReferenceEquals(paramString2, null))
		{
		  this.rawInputs.Remove(range);
		  this.values.Remove(range);
		  this.inputs.Remove(range);
		  updateDependencies(range, null);
		  return;
		}
		this.rawInputs[range] = paramString2;
		Expr expr = parseExpression(paramString2);
		updateDependencies(range, expr);
		this.provider.inputChanged(range, expr);
		this.inputs[range] = expr;
		if (expr.evaluatable)
		{
		  Expr expr1 = ((ExprEvaluatable)expr).evaluate(this);
		  this.provider.valueChanged(range, expr1);
		  this.values[range] = expr1;
		}
		else
		{
		  this.values[range] = paramExpr;
		}
		if (this.autoCalculate)
		{
		  this.graph.traverse(range, this);
		}
	  }

	  private string variableFromField(string paramString)
	  {
		  return BoqItemFormulaEvaluator.variableFromField(paramString);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void setFieldValue(String paramString, Object paramObject) throws org.boris.expr.ExprException
	  public virtual void setFieldValue(string paramString, object paramObject)
	  {
		  setExprValue(variableFromField(paramString), paramObject);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void setExprValue(String paramString, Object paramObject) throws org.boris.expr.ExprException
	  private void setExprValue(string paramString, object paramObject)
	  {
		if (paramObject == null)
		{
		  paramObject = "";
		}
		if (paramObject is Number)
		{
		  if (paramObject is decimal)
		  {
			set(paramString, ((decimal)paramObject).ToString(), new ExprDouble(((decimal)paramObject).doubleValue()));
		  }
		  else if (paramObject is long?)
		  {
			set(paramString, ((long?)paramObject).ToString(), new ExprInteger(((Number)paramObject).intValue()));
		  }
		  else
		  {
			set(paramString, ((Number)paramObject).ToString(), new ExprDouble(((Number)paramObject).doubleValue()));
		  }
		}
		else if (paramObject is string)
		{
		  set(paramString, paramObject.ToString(), new ExprString(paramObject.ToString()));
		}
		else if (paramObject is DateTime)
		{
		  set(paramString, "" + ExcelDate.toExcelDate(((DateTime)paramObject).Ticks), new ExprDouble(ExcelDate.toExcelDate(((DateTime)paramObject).Ticks)));
		}
		else if (paramObject is bool?)
		{
		  if (paramObject.Equals(true))
		  {
			set(paramString, "=TRUE()", new ExprBoolean(true));
		  }
		  else
		  {
			set(paramString, "=FALSE()", new ExprBoolean(false));
		  }
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void reloadVariables() throws org.boris.expr.ExprException
	  private void reloadVariables()
	  {
		this.assignmentsWithFormulasMap.Clear();
		this.updatedResourceToAssignmentQtyPerUnitSet.Clear();
		this.pvVarsCalled = new StringBuilder();
		foreach (string str in BoqItemTable.VIEWABLE_FIELDS)
		{
		  if (!this.currentField.Equals(str))
		  {
			object @object = getFieldFormulaValue(this.boqTable, str + "Formula");
			string str1 = variableFromField(str);
			if (@object != null)
			{
			  set(str1, "=" + @object.ToString());
			}
			else if (BoqItemTable.isFieldEditable(str))
			{
			  object object1 = getFieldValue(this.boqTable, str);
			  if (BoqItemTable.isFieldDate(str))
			  {
				object1 = Convert.ToDouble(0.0D);
			  }
			  else
			  {
				object1 = "";
			  }
			  setExprValue(str1, object1);
			}
		  }
		}
		this.boqTable.PvVars = (this.pvVarsCalled == null) ? "" : this.pvVarsCalled.ToString();
		this.boqTable.HasPVFormula = Convert.ToBoolean((this.pvVarsCalled != null && this.pvVarsCalled.ToString().Length > 0));
		foreach (object @object in this.boqTable.ResourceAssignmentsList)
		{
		  ResourceToAssignmentTable resourceToAssignmentTable = (ResourceToAssignmentTable)@object;
		  resourceToAssignmentTable.PvVars = "";
		  ResourceWithAssignmentsTable resourceWithAssignmentsTable = resourceToAssignmentTable.getResourceTable();
		  if (resourceToAssignmentTable.getResourceTable() is AssemblyTable)
		  {
			AssemblyTable assemblyTable = (AssemblyTable)resourceToAssignmentTable.getResourceTable();
			loadLocalVariables(assemblyTable.Vars);
		  }
		  else if (resourceToAssignmentTable.getResourceTable() is BoqItemTable)
		  {
			BoqItemTable boqItemTable = (BoqItemTable)resourceToAssignmentTable.getResourceTable();
			loadLocalVariables(boqItemTable.Vars);
		  }
		  if (resourceToAssignmentTable.QuantityPerUnitFormulaState == ResourceToAssignmentTable.QTYPUFORM_NOFORMULA)
		  {
			continue;
		  }
		  string str = resourceToAssignmentTable.QuantityPerUnitFormula;
		  if (!StringUtils.isNullOrBlank(str))
		  {
			string str1 = System.Guid.randomUUID().ToString();
			set(str1, "=" + str.ToString());
			this.assignmentsWithFormulasMap[str1] = resourceToAssignmentTable;
		  }
		}
		if (this.boqTable.BoqItemAssemblySet != null)
		{
		  foreach (BoqItemAssemblyTable boqItemAssemblyTable in this.boqTable.BoqItemAssemblySet)
		  {
			AssemblyTable assemblyTable = boqItemAssemblyTable.AssemblyTable;
			loadLocalVariables(assemblyTable.Vars);
			QuantityPerUnitFieldFormula = assemblyTable;
		  }
		}
	  }

	  private void loadLocalVariables(string paramString)
	  {
		this.localVariablesMap.Clear();
		this.localVariablesMap = LocalVariablesDatabaseUtil.getLocalVariables(paramString);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void setQuantityPerUnitFieldFormula(nomitech.common.db.local.AssemblyTable paramAssemblyTable) throws org.boris.expr.ExprException
	  private AssemblyTable QuantityPerUnitFieldFormula
	  {
		  set
		  {
			foreach (object @object in value.ResourceAssignmentsList)
			{
			  ResourceToAssignmentTable resourceToAssignmentTable = (ResourceToAssignmentTable)@object;
			  loadLocalVariables(value.Vars);
			  resourceToAssignmentTable.PvVars = "";
			  if (resourceToAssignmentTable.QuantityPerUnitFormulaState != ResourceToAssignmentTable.QTYPUFORM_NOFORMULA)
			  {
				string str = resourceToAssignmentTable.QuantityPerUnitFormula;
				if (!StringUtils.isNullOrBlank(str))
				{
				  string str1 = System.Guid.randomUUID().ToString();
				  set(str1, "=" + str.ToString());
				  this.assignmentsWithFormulasMap[str1] = resourceToAssignmentTable;
				}
			  }
			  if (resourceToAssignmentTable is AssemblyAssemblyTable)
			  {
				QuantityPerUnitFieldFormula = ((AssemblyAssemblyTable)resourceToAssignmentTable).ChildTable;
			  }
			}
		  }
	  }

	  public virtual ISet<ResourceToAssignmentTable> UpdatedFromFormulaAssignments
	  {
		  get
		  {
			  return this.updatedResourceToAssignmentQtyPerUnitSet;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private Method getGetMethodFromField(nomitech.common.base.BaseEntity paramBaseEntity, String paramString) throws Exception
	  private System.Reflection.MethodInfo getGetMethodFromField(BaseEntity paramBaseEntity, string paramString)
	  {
		if (methodFields.ContainsKey(paramString))
		{
		  return (System.Reflection.MethodInfo)methodFields[paramString];
		}
		string str1 = "" + paramString[0];
		string str2 = "get" + str1.ToUpper() + paramString.Substring(1);
		System.Reflection.MethodInfo method = paramBaseEntity.GetType().GetMethod(str2, new Type[0]);
		methodFields[paramString] = method;
		return method;
	  }

	  public virtual object getFieldValue(BaseEntity paramBaseEntity, string paramString)
	  {
		if (paramBaseEntity == null || string.ReferenceEquals(paramString, null))
		{
		  return null;
		}
		try
		{
		  return getGetMethodFromField(paramBaseEntity, paramString).invoke(paramBaseEntity, new object[0]);
		}
		catch (Exception)
		{
		  return null;
		}
	  }

	  private object getFieldFormulaValue(BoqItemTable paramBoqItemTable, string paramString)
	  {
		  return formulaFields.Contains(paramString) ? getFieldValue(paramBoqItemTable, paramString) : null;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected void validateRange(Range paramRange) throws org.boris.expr.ExprException
	  protected internal override void validateRange(Range paramRange)
	  {
	  }

	  public class BoqItemEngineProvider : EngineProvider
	  {
		  private readonly BoqItemDependencyEngine outerInstance;

		  public BoqItemEngineProvider(BoqItemDependencyEngine outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluateFunction(org.boris.expr.IEvaluationContext param1IEvaluationContext, org.boris.expr.ExprFunction param1ExprFunction) throws org.boris.expr.ExprException
		public virtual Expr evaluateFunction(IEvaluationContext param1IEvaluationContext, ExprFunction param1ExprFunction)
		{
		  if (outerInstance.exfp.hasFunction(param1ExprFunction))
		  {
			return outerInstance.exfp.evaluate(param1IEvaluationContext, param1ExprFunction);
		  }
		  if (outerInstance.dbfp.hasFunction(param1ExprFunction))
		  {
			return outerInstance.dbfp.evaluate(param1IEvaluationContext, param1ExprFunction);
		  }
		  throw new ExprException("Function " + param1ExprFunction + " not supported");
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluateVariable(org.boris.expr.IEvaluationContext param1IEvaluationContext, org.boris.expr.ExprVariable param1ExprVariable) throws org.boris.expr.ExprException
		public virtual Expr evaluateVariable(IEvaluationContext param1IEvaluationContext, ExprVariable param1ExprVariable)
		{
		  string str1 = param1ExprVariable.Name.ToUpper();
		  if (outerInstance.hasAdditionalVariable(str1))
		  {
			return outerInstance.getAdditionalVariableValue(str1);
		  }
		  if (outerInstance.localVariablesMap.ContainsKey(str1))
		  {
			return new ExprDouble(((decimal)outerInstance.localVariablesMap[str1]).doubleValue());
		  }
		  string str2 = BoqItemFormulaEvaluator.fieldFromVariable(str1);
		  if (string.ReferenceEquals(str2, null))
		  {
			throw new ExprException("Variable " + str1 + " not found");
		  }
		  object @object = outerInstance.getFieldValue(outerInstance.boqTable, str2);
		  if (@object == null)
		  {
			if (BoqItemTable.isFieldDate(str2))
			{
			  @object = Convert.ToDouble(0.0D);
			}
			else
			{
			  @object = "";
			}
		  }
		  ExprBoolean exprBoolean = null;
		  if (@object is Number)
		  {
			exprBoolean = new ExprDouble(((Number)@object).doubleValue());
		  }
		  else if (@object is string)
		  {
			ExprString exprString = new ExprString(@object.ToString());
		  }
		  else if (@object is DateTime)
		  {
			exprBoolean = new ExprDouble(ExcelDate.toExcelDate(((DateTime)@object).Ticks));
		  }
		  else if (@object is bool?)
		  {
			exprBoolean = new ExprBoolean(((bool?)@object).Value);
		  }
		  return exprBoolean;
		}

		public virtual void inputChanged(Range param1Range, Expr param1Expr)
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void validate(org.boris.expr.ExprVariable param1ExprVariable) throws org.boris.expr.ExprException
		public virtual void validate(ExprVariable param1ExprVariable)
		{
		}

		public virtual void valueChanged(Range param1Range, Expr param1Expr)
		{
		  string str = BoqItemFormulaEvaluator.fieldFromVariable(param1Range.Dimension1Name);
		  if (!string.ReferenceEquals(str, null) && formulaFields.Contains(str + "Formula"))
		  {
			try
			{
			  object @object = valueFromExpression(param1Expr);
			  if (@object is decimal)
			  {
				@object = ((decimal)@object).setScale(10, 4);
			  }
			  BlankResourceInitializer.setFieldValue(outerInstance.boqTable, str, @object);
			}
			catch (Exception exception)
			{
			  Console.WriteLine("CAN NOT EVALUATE: " + str + " = " + param1Expr + " = " + valueFromExpression(param1Expr));
			  Console.WriteLine(exception.ToString());
			  Console.Write(exception.StackTrace);
			}
		  }
		  else
		  {
			ResourceToAssignmentTable resourceToAssignmentTable = (ResourceToAssignmentTable)outerInstance.assignmentsWithFormulasMap[param1Range.Dimension1Name];
			if (resourceToAssignmentTable != null)
			{
			  decimal bigDecimal = resourceToAssignmentTable.QuantityPerUnit.setScale(10, 4);
			  object @object = valueFromExpression(param1Expr);
			  if (@object is decimal)
			  {
				decimal bigDecimal1 = (decimal)@object;
				if (resourceToAssignmentTable.AssignmentResourceTable is nomitech.common.db.local.LaborTable || resourceToAssignmentTable.AssignmentResourceTable is nomitech.common.db.local.EquipmentTable)
				{
				  bigDecimal1 = bigDecimal1 * (ProjectDBUtil.currentProjectDBUtil().Properties.getHoursFromUnit(resourceToAssignmentTable.AssignmentResourceTable.Unit));
				}
				bigDecimal1.setScale(10, 4);
				if (BigDecimalMath.cmpCheckNulls(bigDecimal, bigDecimal1) != 0)
				{
				  resourceToAssignmentTable.QuantityPerUnit = bigDecimal1;
				  outerInstance.updatedResourceToAssignmentQtyPerUnitSet.Add(resourceToAssignmentTable);
				  outerInstance.someAssignemntFormulaValueChanged = true;
				}
			  }
			}
		  }
		}

		internal virtual object valueFromExpression(Expr param1Expr)
		{
		  if (param1Expr is ExprNumber)
		  {
			return new BigDecimalFixed(((ExprNumber)param1Expr).doubleValue());
		  }
		  if (param1Expr.evaluatable)
		  {
			try
			{
			  return ((ExprEvaluatable)param1Expr).evaluate(outerInstance);
			}
			catch (ExprException exprException)
			{
			  Console.WriteLine(exprException.ToString());
			  Console.Write(exprException.StackTrace);
			}
		  }
		  return param1Expr.ToString();
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\boqitem\BoqItemDependencyEngine.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
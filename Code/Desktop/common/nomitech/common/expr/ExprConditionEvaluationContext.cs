using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr
{
	using ParamItemInputTable = nomitech.common.db.local.ParamItemInputTable;
	using DummyExprArray = Desktop.common.nomitech.common.expr.arrays.DummyExprArray;
	using StringUtils = nomitech.common.util.StringUtils;
	using Expr = org.boris.expr.Expr;
	using ExprBoolean = org.boris.expr.ExprBoolean;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using ExprFunction = org.boris.expr.ExprFunction;
	using ExprInteger = org.boris.expr.ExprInteger;
	using ExprString = org.boris.expr.ExprString;
	using ExprVariable = org.boris.expr.ExprVariable;
	using ExprLexer = org.boris.expr.parser.ExprLexer;
	using ExprParser = org.boris.expr.parser.ExprParser;
	using IParserVisitor = org.boris.expr.parser.IParserVisitor;
	using ExcelDate = org.boris.expr.util.ExcelDate;
	using Exprs = org.boris.expr.util.Exprs;

	public class ExprConditionEvaluationContext : ExprAbstractEvaluationContext, IParserVisitor
	{
	  private readonly string PRODUCTIVITY = "PRODUCTIVITY";

	  private readonly string FACTOR = "FACTOR";

	  private IDictionary<string, ParamItemInputTable> variableMap = new Hashtable();

	  private bool acceptProductivity = false;

	  private bool acceptFactorRate = false;

	  private bool acceptBoqColumns = false;

	  private IList<string> varNames;

	  private IList<Type> varClasses;

	  private double numberCounter = 1.0D;

	  private IList<ParamItemInputTable> refArgsIns = null;

	  public ExprConditionEvaluationContext(ISet<ParamItemInputTable> paramSet)
	  {
		addAdditionalVariable("TRUE", new ExprBoolean(true));
		addAdditionalVariable("FALSE", new ExprBoolean(false));
		foreach (ParamItemInputTable paramItemInputTable in paramSet)
		{
		  this.variableMap[paramItemInputTable.Name.ToUpper()] = paramItemInputTable;
		}
	  }

	  public override ExprWithDefinition[] VariablesArray
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (string str in this.variableMap.Keys)
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

	  public virtual bool AcceptProductivity
	  {
		  set
		  {
			  this.acceptProductivity = value;
		  }
	  }

	  public virtual bool AcceptFactorRate
	  {
		  set
		  {
			  this.acceptFactorRate = value;
		  }
	  }

	  public virtual void setAcceptVariables(bool paramBoolean, IList<string> paramList1, IList<Type> paramList2)
	  {
		this.acceptBoqColumns = paramBoolean;
		this.varNames = paramList1;
		this.varClasses = paramList2;
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

	  public virtual double nextDouble()
	  {
		if (this.numberCounter > 9999999.0D)
		{
		  this.numberCounter = 0.0D;
		}
		return this.numberCounter++;
	  }

	  public virtual int nextInt()
	  {
		if (this.numberCounter > 9999999.0D)
		{
		  this.numberCounter = 0.0D;
		}
		return (int)this.numberCounter++;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluateVariable(org.boris.expr.ExprVariable paramExprVariable) throws org.boris.expr.ExprException
	  public virtual Expr evaluateVariable(ExprVariable paramExprVariable)
	  {
		string str = paramExprVariable.Name.ToUpper();
		if (hasAdditionalVariable(str))
		{
		  return getAdditionalVariableValue(paramExprVariable.Name.ToUpper());
		}
		if (this.variableMap.ContainsKey(str))
		{
		  ParamItemInputTable paramItemInputTable = (ParamItemInputTable)this.variableMap[paramExprVariable.Name.ToUpper()];
		  return expressionFromVariable(paramItemInputTable, paramExprVariable);
		}
		if (str.Equals("PRODUCTIVITY") && this.acceptProductivity)
		{
		  return new ExprDouble(nextDouble());
		}
		if (str.Equals("FACTOR") && this.acceptFactorRate)
		{
		  return new ExprDouble(nextDouble());
		}
		if (this.acceptBoqColumns)
		{
		  int i = this.varNames.IndexOf(str);
		  if (i == -1)
		  {
			throw new ExprException("Variable " + paramExprVariable + " not found");
		  }
		  Type clazz = (Type)this.varClasses[i];
		  return clazz.Equals(typeof(decimal)) ? new ExprDouble(nextDouble()) : (clazz.Equals(typeof(Long)) ? new ExprInteger(nextInt()) : (clazz.Equals(typeof(DateTime)) ? new ExprDouble(ExcelDate.toExcelDate(DateTimeHelper.CurrentUnixTimeMillis())) : (clazz.Equals(typeof(Boolean)) ? new ExprBoolean(false) : new ExprString(str))));
		}
		throw new ExprException("Variable " + paramExprVariable + " not found");
	  }

	  private Expr expressionFromVariable(ParamItemInputTable paramParamItemInputTable, ExprVariable paramExprVariable)
	  {
		if (paramParamItemInputTable.DataType.Equals("datatype.decimal"))
		{
		  return new ExprDouble(nextDouble());
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.takeoff"))
		{
		  return new ExprDouble(nextDouble());
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.array"))
		{
		  return new DummyExprArray();
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.integer"))
		{
		  return new ExprInteger(nextInt());
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.list"))
		{
		  return new ExprString("1");
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.country"))
		{
		  return new ExprString("US");
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.text"))
		{
		  return new ExprString("");
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.image"))
		{
		  return new ExprString("");
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.notes"))
		{
		  return new ExprString("");
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.bimmodel"))
		{
		  return new ExprString("");
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.locfactor"))
		{
		  return new ExprLocation("US");
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.calcvalue"))
		{
		  return new ExprDouble(nextDouble());
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.calcarray"))
		{
		  return new DummyExprArray();
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.calclist"))
		{
		  return new ExprString("1");
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.date"))
		{
		  return new ExprDouble(nextDouble());
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.boolean"))
		{
		  return new ExprBoolean(false);
		}
		if (paramParamItemInputTable.DataType.Equals("datatype.formula"))
		{
		  return new ExprString("");
		}
		paramExprVariable.Name = paramExprVariable.Name.ToUpper();
		return paramExprVariable;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void annotateFunction(org.boris.expr.ExprFunction paramExprFunction) throws org.boris.expr.ExprException
	  public virtual void annotateFunction(ExprFunction paramExprFunction)
	  {
		if (!this.exfp.hasFunction(paramExprFunction) && !this.dbfp.hasFunction(paramExprFunction))
		{
		  throw new ExprException("Function " + paramExprFunction + " not supported");
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void annotateVariable(org.boris.expr.ExprVariable paramExprVariable) throws org.boris.expr.ExprException
	  public virtual void annotateVariable(ExprVariable paramExprVariable)
	  {
		string str = paramExprVariable.Name.ToUpper();
		if (this.refArgsIns != null)
		{
		  if (this.variableMap.ContainsKey(str))
		  {
			ParamItemInputTable paramItemInputTable = (ParamItemInputTable)this.variableMap[str];
			if (!this.refArgsIns.Contains(paramItemInputTable))
			{
			  this.refArgsIns.Add(paramItemInputTable);
			}
		  }
		}
		else if ((!this.acceptProductivity || !str.Equals("PRODUCTIVITY")) && (!this.acceptFactorRate || !str.Equals("FACTOR")) && (!this.acceptBoqColumns || this.varNames.IndexOf(str) == -1) && !this.variableMap.ContainsKey(str))
		{
		  throw new ExprException("Variable " + paramExprVariable + " not found");
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr parseAndValidate(String paramString) throws java.io.IOException, org.boris.expr.ExprException
	  public virtual Expr parseAndValidate(string paramString)
	  {
		ExprParser exprParser = new ExprParser();
		exprParser.ParserVisitor = this;
		exprParser.parse(new ExprLexer(paramString));
		Expr expr = exprParser.get();
		Exprs.ToUpper(expr);
		return expr;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List<nomitech.common.db.local.ParamItemInputTable> getReferringVariablesForStatement(String paramString) throws java.io.IOException, org.boris.expr.ExprException
	  public virtual IList<ParamItemInputTable> getReferringVariablesForStatement(string paramString)
	  {
		this.refArgsIns = new List<object>();
		if (StringUtils.isNullOrBlank(paramString))
		{
		  return this.refArgsIns;
		}
		ExprParser exprParser = new ExprParser();
		exprParser.ParserVisitor = this;
		exprParser.parse(new ExprLexer(paramString));
		System.Collections.IList list = this.refArgsIns;
		this.refArgsIns = null;
		List<object> arrayList1 = new List<object>();
		List<object> arrayList2 = new List<object>();
		foreach (ParamItemInputTable paramItemInputTable in list)
		{
		  arrayList1.Add(paramItemInputTable);
		  if (paramItemInputTable.DataType.Equals("datatype.calcvalue") && !arrayList2.Contains(paramItemInputTable.ValidationStatement))
		  {
			arrayList2.Add(paramItemInputTable.ValidationStatement);
		  }
		}
		foreach (string str in arrayList2)
		{
		  list = getReferringVariablesForStatement(str);
		  foreach (ParamItemInputTable paramItemInputTable in list)
		  {
			if (!arrayList1.Contains(paramItemInputTable))
			{
			  arrayList1.Add(paramItemInputTable);
			}
		  }
		}
		return arrayList1;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public java.util.List<nomitech.common.db.local.ParamItemInputTable> getReferringVariablesForStatements(String[] paramArrayOfString) throws java.io.IOException, org.boris.expr.ExprException
	  public virtual IList<ParamItemInputTable> getReferringVariablesForStatements(string[] paramArrayOfString)
	  {
		LinkedList linkedList = new LinkedList();
		foreach (string str in paramArrayOfString)
		{
		  System.Collections.IList list = getReferringVariablesForStatement(str);
		  foreach (ParamItemInputTable paramItemInputTable in list)
		  {
			if (!linkedList.Contains(paramItemInputTable))
			{
			  linkedList.AddLast(paramItemInputTable);
			}
		  }
		}
		return linkedList;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\ExprConditionEvaluationContext.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
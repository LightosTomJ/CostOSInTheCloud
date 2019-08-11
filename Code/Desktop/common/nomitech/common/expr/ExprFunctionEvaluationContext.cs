using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr
{
	using FunctionArgumentTable = nomitech.common.db.local.FunctionArgumentTable;
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
	using Exprs = org.boris.expr.util.Exprs;

	public class ExprFunctionEvaluationContext : ExprAbstractEvaluationContext, IParserVisitor
	{
	  private IDictionary<string, FunctionArgumentTable> variableMap = new Hashtable();

	  private IList<FunctionArgumentTable> refArgsIns = null;

	  public ExprFunctionEvaluationContext(IList<FunctionArgumentTable> paramList)
	  {
		addAdditionalVariable("TRUE", new ExprBoolean(true));
		addAdditionalVariable("FALSE", new ExprBoolean(false));
		foreach (FunctionArgumentTable functionArgumentTable in paramList)
		{
		  this.variableMap[functionArgumentTable.Name.ToUpper()] = functionArgumentTable;
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
		if (hasAdditionalVariable(paramExprVariable.Name.ToUpper()))
		{
		  return getAdditionalVariableValue(paramExprVariable.Name.ToUpper());
		}
		if (this.variableMap.ContainsKey(paramExprVariable.Name.ToUpper()))
		{
		  FunctionArgumentTable functionArgumentTable = (FunctionArgumentTable)this.variableMap[paramExprVariable.Name.ToUpper()];
		  return expressionFromVariable(functionArgumentTable, paramExprVariable);
		}
		throw new ExprException("Variable " + paramExprVariable + " not found");
	  }

	  private Expr expressionFromVariable(FunctionArgumentTable paramFunctionArgumentTable, ExprVariable paramExprVariable)
	  {
		if (paramFunctionArgumentTable.Type.Equals("datatype.decimal"))
		{
		  return StringUtils.isDecimal(paramFunctionArgumentTable.DefaultValue) ? new ExprDouble(double.Parse(paramFunctionArgumentTable.DefaultValue)) : new ExprDouble(1.5D);
		}
		if (paramFunctionArgumentTable.Type.Equals("datatype.takeoff"))
		{
		  return StringUtils.isDecimal(paramFunctionArgumentTable.DefaultValue) ? new ExprDouble(double.Parse(paramFunctionArgumentTable.DefaultValue)) : new ExprDouble(1.5D);
		}
		if (paramFunctionArgumentTable.Type.Equals("datatype.integer"))
		{
		  return StringUtils.isInteger(paramFunctionArgumentTable.DefaultValue) ? new ExprInteger(int.Parse(paramFunctionArgumentTable.DefaultValue)) : new ExprInteger(1);
		}
		if (paramFunctionArgumentTable.Type.Equals("datatype.list"))
		{
		  if (!StringUtils.isNullOrBlank(paramFunctionArgumentTable.DefaultValue))
		  {
			return new ExprString(paramFunctionArgumentTable.DefaultValue);
		  }
		  string str = StringUtils.getFirstLine(paramFunctionArgumentTable.SelectionList);
		  return !StringUtils.isNullOrBlank(str) ? new ExprString(str) : new ExprString(paramExprVariable.Name);
		}
		if (paramFunctionArgumentTable.Type.Equals("datatype.country"))
		{
		  return new ExprString("US");
		}
		if (paramFunctionArgumentTable.Type.Equals("datatype.image"))
		{
		  return new ExprString("");
		}
		if (paramFunctionArgumentTable.Type.Equals("datatype.notes"))
		{
		  return !StringUtils.isNullOrBlank(paramFunctionArgumentTable.DefaultValue) ? new ExprString(paramFunctionArgumentTable.DefaultValue) : new ExprString("");
		}
		if (paramFunctionArgumentTable.Type.Equals("datatype.array"))
		{
		  return new DummyExprArray();
		}
		if (paramFunctionArgumentTable.Type.Equals("datatype.text"))
		{
		  return !StringUtils.isNullOrBlank(paramFunctionArgumentTable.DefaultValue) ? new ExprString(paramFunctionArgumentTable.DefaultValue) : new ExprString("");
		}
		if (paramFunctionArgumentTable.Type.Equals("datatype.locfactor"))
		{
		  return new ExprLocation("US");
		}
		if (paramFunctionArgumentTable.Type.Equals("datatype.calcvalue"))
		{
		  return new ExprDouble(1.5D);
		}
		if (paramFunctionArgumentTable.Type.Equals("datatype.date"))
		{
		  return new ExprDouble(1.5D);
		}
		if (paramFunctionArgumentTable.Type.Equals("datatype.boolean"))
		{
		  return StringUtils.isBoolean(paramFunctionArgumentTable.DefaultValue) ? new ExprBoolean(bool.Parse(paramFunctionArgumentTable.DefaultValue)) : new ExprBoolean(true);
		}
		Console.WriteLine("oops return variable cause type is: " + paramFunctionArgumentTable.Type);
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
		if (this.refArgsIns != null)
		{
		  if (this.variableMap.ContainsKey(paramExprVariable.Name.ToUpper()))
		  {
			FunctionArgumentTable functionArgumentTable = (FunctionArgumentTable)this.variableMap[paramExprVariable.Name.ToUpper()];
			if (!this.refArgsIns.Contains(functionArgumentTable))
			{
			  this.refArgsIns.Add(functionArgumentTable);
			}
		  }
		}
		else if (!this.variableMap.ContainsKey(paramExprVariable.Name.ToUpper()))
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
//ORIGINAL LINE: public java.util.List<nomitech.common.db.local.FunctionArgumentTable> getReferringVariablesForStatement(String paramString) throws java.io.IOException, org.boris.expr.ExprException
	  public virtual IList<FunctionArgumentTable> getReferringVariablesForStatement(string paramString)
	  {
		this.refArgsIns = new List<object>();
		ExprParser exprParser = new ExprParser();
		exprParser.ParserVisitor = this;
		exprParser.parse(new ExprLexer(paramString));
		System.Collections.IList list = this.refArgsIns;
		this.refArgsIns = null;
		List<object> arrayList1 = new List<object>();
		List<object> arrayList2 = new List<object>();
		foreach (FunctionArgumentTable functionArgumentTable in list)
		{
		  arrayList1.Add(functionArgumentTable);
		  if (functionArgumentTable.Type.Equals("datatype.calcvalue") && !arrayList2.Contains(functionArgumentTable.ValidationStatement))
		  {
			arrayList2.Add(functionArgumentTable.ValidationStatement);
		  }
		}
		foreach (string str in arrayList2)
		{
		  list = getReferringVariablesForStatement(str);
		  foreach (FunctionArgumentTable functionArgumentTable in list)
		  {
			if (!arrayList1.Contains(functionArgumentTable))
			{
			  arrayList1.Add(functionArgumentTable);
			}
		  }
		}
		return list;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\ExprFunctionEvaluationContext.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
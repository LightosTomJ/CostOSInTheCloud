using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr
{
	using FunctionArgumentTable = nomitech.common.db.local.FunctionArgumentTable;
	using FunctionTable = nomitech.common.db.local.FunctionTable;
	using ExprArrayUtil = Desktop.common.nomitech.common.expr.arrays.ExprArrayUtil;
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprBoolean = org.boris.expr.ExprBoolean;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprEvaluatable = org.boris.expr.ExprEvaluatable;
	using ExprException = org.boris.expr.ExprException;
	using ExprInteger = org.boris.expr.ExprInteger;
	using ExprString = org.boris.expr.ExprString;
	using ExprType = org.boris.expr.ExprType;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;
	using NativeArray = org.mozilla.javascript.NativeArray;

	public class ExprDBFunction : AbstractFunction
	{
	  private FunctionTable fTable;

	  private bool locked = false;

	  private IList<FunctionArgumentTable> inputArguments = new List<object>();

	  private IList<FunctionArgumentTable> constArguments = new List<object>();

	  private IDictionary<string, Expr> previousArgs = new Hashtable();

	  private bool jsLanguage = false;

	  private ScriptEngine engine = null;

	  public ExprDBFunction(FunctionTable paramFunctionTable)
	  {
		this.fTable = paramFunctionTable;
		if (!string.ReferenceEquals(paramFunctionTable.Language, null))
		{
		  this.jsLanguage = paramFunctionTable.Language.Equals("JS");
		}
		if (paramFunctionTable.FunctionArgumentList == null)
		{
		  paramFunctionTable.FunctionArgumentList = new List<object>();
		}
		foreach (FunctionArgumentTable functionArgumentTable in paramFunctionTable.FunctionArgumentList)
		{
		  if (functionArgumentTable.Type.Equals("datatype.image") || functionArgumentTable.Type.Equals("datatype.calcvalue"))
		  {
			this.constArguments.Add(functionArgumentTable);
			continue;
		  }
		  this.inputArguments.Add(functionArgumentTable);
		}
	  }

	  private IList<FunctionArgumentTable> InputArguments
	  {
		  get
		  {
			  return this.inputArguments;
		  }
	  }

	  public virtual FunctionTable FunctionTable
	  {
		  get
		  {
			  return this.fTable;
		  }
		  set
		  {
			this.fTable = value;
			if (!string.ReferenceEquals(value.Language, null))
			{
			  this.jsLanguage = value.Language.Equals("JS");
			}
			this.engine = null;
		  }
	  }


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		if (this.locked)
		{
		  throw new ExprException("Can not Invoke a Function from the same Function.");
		}
		if (!(paramIEvaluationContext is ExprAbstractEvaluationContext))
		{
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		  throw new ExprException("Invalid context class: " + paramIEvaluationContext.GetType().FullName);
		}
		ExprAbstractEvaluationContext exprAbstractEvaluationContext = (ExprAbstractEvaluationContext)paramIEvaluationContext;
		this.locked = true;
		try
		{
		  Expr expr = innerEvaluate(exprAbstractEvaluationContext, paramArrayOfExpr);
		  this.locked = false;
		  popVariables(exprAbstractEvaluationContext);
		  return expr;
		}
		catch (ExprException exprException)
		{
		  this.locked = false;
		  popVariables(exprAbstractEvaluationContext);
		  throw exprException;
		}
		catch (Exception exception)
		{
		  this.locked = false;
		  popVariables(exprAbstractEvaluationContext);
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw new ExprException(exception);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.Expr innerEvaluate(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  private Expr innerEvaluate(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, InputArguments.Count);
		ExprType[] arrayOfExprType = InputArgTypes;
		for (sbyte b = 0; b < paramArrayOfExpr.Length; b++)
		{
		  Expr expr = paramArrayOfExpr[b];
		  if (expr is ExprEvaluatable)
		  {
			paramArrayOfExpr[b] = ((ExprEvaluatable)expr).evaluate(paramExprAbstractEvaluationContext);
		  }
		  if (!(paramArrayOfExpr[b] is ExprEvaluatable) && (!(paramArrayOfExpr[b] is org.boris.expr.ExprNumber) || !arrayOfExprType[b].Equals(ExprType.String)))
		  {
			assertArgType(paramArrayOfExpr[b], arrayOfExprType[b]);
		  }
		}
		pushVariables(paramExprAbstractEvaluationContext, paramArrayOfExpr);
		if (this.fTable.ResultType.Equals("datatype.integer"))
		{
		  return (!string.ReferenceEquals(this.fTable.Language, null) && this.fTable.Language.Equals("JS")) ? evaluateIntegerJS(paramExprAbstractEvaluationContext) : evaluateInteger(paramExprAbstractEvaluationContext);
		}
		if (this.fTable.ResultType.Equals("datatype.decimal"))
		{
		  return (!string.ReferenceEquals(this.fTable.Language, null) && this.fTable.Language.Equals("JS")) ? evaluateDecimalJS(paramExprAbstractEvaluationContext) : evaluateDecimal(paramExprAbstractEvaluationContext);
		}
		if (this.fTable.ResultType.Equals("datatype.date"))
		{
		  return (!string.ReferenceEquals(this.fTable.Language, null) && this.fTable.Language.Equals("JS")) ? evaluateDecimalJS(paramExprAbstractEvaluationContext) : evaluateDecimal(paramExprAbstractEvaluationContext);
		}
		if (this.fTable.ResultType.Equals("datatype.list"))
		{
		  return (!string.ReferenceEquals(this.fTable.Language, null) && this.fTable.Language.Equals("JS")) ? evaluateStringJS(paramExprAbstractEvaluationContext) : evaluateString(paramExprAbstractEvaluationContext);
		}
		if (this.fTable.ResultType.Equals("datatype.boolean"))
		{
		  return (!string.ReferenceEquals(this.fTable.Language, null) && this.fTable.Language.Equals("JS")) ? evaluateBooleanJS(paramExprAbstractEvaluationContext) : evaluateBoolean(paramExprAbstractEvaluationContext);
		}
		if (this.fTable.ResultType.Equals("datatype.array"))
		{
		  return (!string.ReferenceEquals(this.fTable.Language, null) && this.fTable.Language.Equals("JS")) ? evaluateArrayJS(paramExprAbstractEvaluationContext) : evaluateArray(paramExprAbstractEvaluationContext);
		}
		throw new ExprException("Unknown function return type: " + this.fTable.ResultType);
	  }

	  private ScriptEngine Engine
	  {
		  get
		  {
			if (this.engine == null)
			{
			  ScriptEngineManager scriptEngineManager = new ScriptEngineManager();
			  this.engine = scriptEngineManager.getEngineByName("rhino");
			}
			return this.engine;
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void pushVariables(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual void pushVariables(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		bool @bool = false;
		if (this.jsLanguage && this.engine == null)
		{
		  @bool = true;
		}
		this.previousArgs.Clear();
		sbyte b = 0;
		foreach (FunctionArgumentTable functionArgumentTable in this.inputArguments)
		{
		  if (paramExprAbstractEvaluationContext.hasAdditionalVariable(this.fTable.Name.ToUpper()))
		  {
			this.previousArgs[functionArgumentTable.Name] = paramExprAbstractEvaluationContext.getAdditionalVariableValue(functionArgumentTable.Name);
		  }
		  paramExprAbstractEvaluationContext.addAdditionalVariable(functionArgumentTable.Name.ToUpper(), paramArrayOfExpr[b]);
		  if (this.jsLanguage)
		  {
			if (paramArrayOfExpr[b] is ExprDouble)
			{
			  Engine.put(functionArgumentTable.Name, Convert.ToDouble(((ExprDouble)paramArrayOfExpr[b]).doubleValue()));
			}
			else if (paramArrayOfExpr[b] is ExprInteger)
			{
			  Engine.put(functionArgumentTable.Name, Convert.ToInt32(((ExprInteger)paramArrayOfExpr[b]).intValue()));
			}
			else if (paramArrayOfExpr[b] is ExprBoolean)
			{
			  Engine.put(functionArgumentTable.Name, Convert.ToBoolean(((ExprBoolean)paramArrayOfExpr[b]).booleanValue()));
			}
			else if (paramArrayOfExpr[b] is ExprArray)
			{
			  Engine.put(functionArgumentTable.Name, ExprArrayUtil.toObjectArray((ExprArray)paramArrayOfExpr[b]));
			}
			else
			{
			  Engine.put(functionArgumentTable.Name, ((ExprString)paramArrayOfExpr[b]).str);
			}
		  }
		  b++;
		}
		foreach (FunctionArgumentTable functionArgumentTable in this.constArguments)
		{
		  if (paramExprAbstractEvaluationContext.hasAdditionalVariable(this.fTable.Name.ToUpper()))
		  {
			this.previousArgs[functionArgumentTable.Name] = paramExprAbstractEvaluationContext.getAdditionalVariableValue(functionArgumentTable.Name);
		  }
		  Expr expr = evaluateConstant(paramExprAbstractEvaluationContext, functionArgumentTable);
		  paramExprAbstractEvaluationContext.addAdditionalVariable(functionArgumentTable.Name.ToUpper(), expr);
		  if (this.jsLanguage)
		  {
			if (expr is ExprDouble)
			{
			  Engine.put(functionArgumentTable.Name, Convert.ToDouble(((ExprDouble)expr).doubleValue()));
			  continue;
			}
			if (expr is ExprInteger)
			{
			  Engine.put(functionArgumentTable.Name, Convert.ToInt32(((ExprInteger)expr).intValue()));
			  continue;
			}
			if (expr is ExprBoolean)
			{
			  Engine.put(functionArgumentTable.Name, Convert.ToInt32(((ExprBoolean)expr).intValue()));
			  continue;
			}
			if (paramArrayOfExpr[b] is ExprArray)
			{
			  Engine.put(functionArgumentTable.Name, ExprArrayUtil.toObjectArray((ExprArray)paramArrayOfExpr[b]));
			  continue;
			}
			Engine.put(functionArgumentTable.Name, ((ExprString)expr).str);
		  }
		}
		if (@bool)
		{
		  string str = "function " + this.fTable.Name + "() {" + this.fTable.Implementation + "\n}";
		  try
		  {
			Engine.eval(str);
		  }
		  catch (ScriptException scriptException)
		  {
			string str1 = scriptException.Message;
			if (scriptException.InnerException != null)
			{
			  str1 = scriptException.InnerException.Message;
			}
			if (str1.IndexOf(":", StringComparison.Ordinal) != -1)
			{
			  str1 = str1.Substring(str1.LastIndexOf(":", StringComparison.Ordinal));
			}
			throw new ExprException(str1);
		  }
		  catch (Exception exception)
		  {
			throw new ExprException(exception.Message);
		  }
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void popVariables(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext) throws org.boris.expr.ExprException
	  private void popVariables(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext)
	  {
		foreach (FunctionArgumentTable functionArgumentTable in this.inputArguments)
		{
		  paramExprAbstractEvaluationContext.removeAdditionalVariable(functionArgumentTable.Name.ToUpper());
		}
		foreach (FunctionArgumentTable functionArgumentTable in this.constArguments)
		{
		  paramExprAbstractEvaluationContext.removeAdditionalVariable(functionArgumentTable.Name.ToUpper());
		}
		foreach (string str in this.previousArgs.Keys)
		{
		  paramExprAbstractEvaluationContext.addAdditionalVariable(str, (Expr)this.previousArgs[str]);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.Expr evaluateString(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext) throws org.boris.expr.ExprException
	  private Expr evaluateString(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext)
	  {
		Expr expr = paramExprAbstractEvaluationContext.parseStatement(this.fTable.Implementation);
		if (!(expr is ExprString))
		{
		  throw new ExprException("Function " + this.fTable.Name + " does not return a String!");
		}
		return expr;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.Expr evaluateDecimal(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext) throws org.boris.expr.ExprException
	  private Expr evaluateDecimal(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext)
	  {
		Expr expr = paramExprAbstractEvaluationContext.parseStatement(this.fTable.Implementation);
		if (!(expr is org.boris.expr.ExprNumber))
		{
		  throw new ExprException("Function " + this.fTable.Name + " does not return a Number!");
		}
		return expr;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.Expr evaluateConstant(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext, nomitech.common.db.local.FunctionArgumentTable paramFunctionArgumentTable) throws org.boris.expr.ExprException
	  private Expr evaluateConstant(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext, FunctionArgumentTable paramFunctionArgumentTable)
	  {
		if (paramFunctionArgumentTable.Type.Equals("datatype.image"))
		{
		  return new ExprString(paramFunctionArgumentTable.DefaultValue);
		}
		if (paramFunctionArgumentTable.Type.Equals("datatype.calcvalue"))
		{
		  try
		  {
			return new ExprDouble((new double?(paramFunctionArgumentTable.ValidationStatement)));
		  }
		  catch (Exception)
		  {
		  }
		}
		Expr expr = paramExprAbstractEvaluationContext.parseStatement(paramFunctionArgumentTable.ValidationStatement);
		if (paramFunctionArgumentTable.Type.Equals("datatype.calcvalue") && !(expr is org.boris.expr.ExprNumber) && !(expr is ExprString))
		{
		  throw new ExprException("Function " + this.fTable.Name + " has constant " + paramFunctionArgumentTable.Name + " that does not return a Number or Text");
		}
		return expr;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.Expr evaluateInteger(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext) throws org.boris.expr.ExprException
	  private Expr evaluateInteger(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext)
	  {
		Expr expr = paramExprAbstractEvaluationContext.parseStatement(this.fTable.Implementation);
		if (!(expr is org.boris.expr.ExprNumber))
		{
		  throw new ExprException("Function " + this.fTable.Name + " does not return a Number!");
		}
		return expr;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.Expr evaluateBoolean(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext) throws org.boris.expr.ExprException
	  private Expr evaluateBoolean(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext)
	  {
		Expr expr = paramExprAbstractEvaluationContext.parseStatement(this.fTable.Implementation);
		if (!(expr is org.boris.expr.ExprNumber))
		{
		  throw new ExprException("Function " + this.fTable.Name + " does not return a Boolean!");
		}
		return expr;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.Expr evaluateArray(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext) throws org.boris.expr.ExprException
	  private Expr evaluateArray(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext)
	  {
		Expr expr = paramExprAbstractEvaluationContext.parseStatement(this.fTable.Implementation);
		if (!(expr is ExprArray))
		{
		  throw new ExprException("Function " + this.fTable.Name + " does not return a Array!");
		}
		return expr;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.Expr evaluateArrayJS(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext) throws org.boris.expr.ExprException
	  private Expr evaluateArrayJS(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext)
	  {
		try
		{
		  Invocable invocable = (Invocable)Engine;
		  object @object = invocable.invokeFunction(this.fTable.Name, new object[0]);
		  Console.WriteLine("RESULT IS: " + @object);
		  if (@object == null)
		  {
			throw new ScriptException("Function " + this.fTable.Name + " does not return an array value", this.fTable.Name, 2);
		  }
		  if (@object is NativeArray)
		  {
			return ExprArrayUtil.toExprArray((NativeArray)@object);
		  }
		  if (@object is object[])
		  {
			return ExprArrayUtil.toExprArray((object[])@object);
		  }
		  if (@object is object[][])
		  {
			return ExprArrayUtil.toExprArray((object[][])@object);
		  }
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		  Console.WriteLine("ARRAY IS OF TYPE: " + @object + " OR " + @object.GetType().FullName);
		  throw new ScriptException("Function " + this.fTable.Name + " does not return an array value", this.fTable.Name, 2);
		}
		catch (ScriptException scriptException)
		{
		  string str = scriptException.Message;
		  if (scriptException.InnerException != null)
		  {
			str = scriptException.InnerException.Message;
		  }
		  if (str.IndexOf(":", StringComparison.Ordinal) != -1)
		  {
			str = str.Substring(str.LastIndexOf(":", StringComparison.Ordinal) + 1);
		  }
		  throw new ExprException(str);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw new ExprException(exception.Message);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.Expr evaluateBooleanJS(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext) throws org.boris.expr.ExprException
	  private Expr evaluateBooleanJS(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext)
	  {
		try
		{
		  Invocable invocable = (Invocable)Engine;
		  object @object = invocable.invokeFunction(this.fTable.Name, new object[0]);
		  if (@object == null)
		  {
			throw new ScriptException("Function " + this.fTable.Name + " does not return a boolean value", this.fTable.Name, 2);
		  }
		  return new ExprBoolean(bool.Parse(@object.ToString()));
		}
		catch (ScriptException scriptException)
		{
		  string str = scriptException.Message;
		  if (scriptException.InnerException != null)
		  {
			str = scriptException.InnerException.Message;
		  }
		  if (str.IndexOf(":", StringComparison.Ordinal) != -1)
		  {
			str = str.Substring(str.LastIndexOf(":", StringComparison.Ordinal) + 1);
		  }
		  throw new ExprException(str);
		}
		catch (System.FormatException)
		{
		  throw new ExprException("Function " + this.fTable.Name + " does not return a boolean value");
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw new ExprException(exception.Message);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.Expr evaluateStringJS(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext) throws org.boris.expr.ExprException
	  private Expr evaluateStringJS(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext)
	  {
		try
		{
		  Invocable invocable = (Invocable)Engine;
		  object @object = invocable.invokeFunction(this.fTable.Name, new object[0]);
		  if (@object == null)
		  {
			throw new ScriptException("Function " + this.fTable.Name + " does not return a text value", this.fTable.Name, 2);
		  }
		  return new ExprString(@object.ToString());
		}
		catch (ScriptException scriptException)
		{
		  string str = scriptException.Message;
		  if (scriptException.InnerException != null)
		  {
			str = scriptException.InnerException.Message;
		  }
		  if (str.IndexOf(":", StringComparison.Ordinal) != -1)
		  {
			str = str.Substring(str.LastIndexOf(":", StringComparison.Ordinal) + 1);
		  }
		  throw new ExprException(str);
		}
		catch (System.FormatException)
		{
		  throw new ExprException("Function " + this.fTable.Name + " does not return a text value");
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw new ExprException(exception.Message);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.Expr evaluateDecimalJS(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext) throws org.boris.expr.ExprException
	  private Expr evaluateDecimalJS(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext)
	  {
		try
		{
		  Invocable invocable = (Invocable)Engine;
		  object @object = invocable.invokeFunction(this.fTable.Name, new object[0]);
		  if (@object == null)
		  {
			throw new ScriptException("Function " + this.fTable.Name + " does not return a decimal value", this.fTable.Name, 2);
		  }
		  return new ExprDouble(double.Parse(@object.ToString()));
		}
		catch (ScriptException scriptException)
		{
		  string str = scriptException.Message;
		  if (scriptException.InnerException != null)
		  {
			str = scriptException.InnerException.Message;
		  }
		  if (str.IndexOf(":", StringComparison.Ordinal) != -1)
		  {
			str = str.Substring(str.LastIndexOf(":", StringComparison.Ordinal) + 1);
		  }
		  throw new ExprException(str);
		}
		catch (System.FormatException)
		{
		  throw new ExprException("Function " + this.fTable.Name + " does not return a decimal value");
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw new ExprException(exception.Message);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private org.boris.expr.Expr evaluateIntegerJS(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext) throws org.boris.expr.ExprException
	  private Expr evaluateIntegerJS(ExprAbstractEvaluationContext paramExprAbstractEvaluationContext)
	  {
		try
		{
		  Invocable invocable = (Invocable)Engine;
		  object @object = invocable.invokeFunction(this.fTable.Name, new object[0]);
		  if (@object == null)
		  {
			throw new ScriptException("Function " + this.fTable.Name + " does not return an integer value", this.fTable.Name, 2);
		  }
		  return new ExprInteger(int.Parse(@object.ToString()));
		}
		catch (ScriptException scriptException)
		{
		  string str = scriptException.Message;
		  if (scriptException.InnerException != null)
		  {
			str = scriptException.InnerException.Message;
		  }
		  if (str.IndexOf(":", StringComparison.Ordinal) != -1)
		  {
			str = str.Substring(str.LastIndexOf(":", StringComparison.Ordinal) + 1);
		  }
		  throw new ExprException(str);
		}
		catch (System.FormatException)
		{
		  throw new ExprException("Function " + this.fTable.Name + " does not return an integer value");
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  throw new ExprException(exception.Message);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected void assertArgType(org.boris.expr.Expr paramExpr, org.boris.expr.ExprType paramExprType) throws org.boris.expr.ExprException
	  protected internal virtual void assertArgType(Expr paramExpr, ExprType paramExprType)
	  {
		if (paramExpr == null)
		{
		  if (paramExprType != null)
		  {
			throw new ExprException("Invalid empty argument for function " + ToString());
		  }
		}
		else if ((!paramExpr.type.Equals(ExprType.Integer) || !paramExprType.Equals(ExprType.Double)) && (!paramExpr.type.Equals(ExprType.Double) || !paramExprType.Equals(ExprType.Integer)) && (!paramExpr.type.Equals(ExprType.Boolean) || !paramExprType.Equals(ExprType.Double)) && (!paramExpr.type.Equals(ExprType.Double) || !paramExprType.Equals(ExprType.Boolean)) && (!paramExpr.type.Equals(ExprType.Integer) || !paramExprType.Equals(ExprType.Boolean)) && (!paramExpr.type.Equals(ExprType.Boolean) || !paramExprType.Equals(ExprType.Integer)) && !paramExpr.type.Equals(paramExprType))
		{
		  throw new ExprException("Invalid argument type (" + paramExpr.type + " <> " + paramExprType + ") for function " + ToString());
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected void assertArgCount(org.boris.expr.Expr[] paramArrayOfExpr, int paramInt) throws org.boris.expr.ExprException
	  protected internal virtual void assertArgCount(Expr[] paramArrayOfExpr, int paramInt)
	  {
		if (paramArrayOfExpr == null && paramInt != 0)
		{
		  throw new ExprException(ToString() + " function takes no arguments");
		}
		if (paramArrayOfExpr.Length != paramInt)
		{
		  throw new ExprException(ToString() + " function takes " + paramInt + " arguments");
		}
	  }

	  private ExprType[] InputArgTypes
	  {
		  get
		  {
			List<object> arrayList = new List<object>();
			foreach (FunctionArgumentTable functionArgumentTable in this.inputArguments)
			{
			  if (functionArgumentTable.Type.Equals("datatype.decimal") || functionArgumentTable.Type.Equals("datatype.takeoff") || functionArgumentTable.Type.Equals("datatype.calcvalue"))
			  {
				arrayList.Add(ExprType.Double);
				continue;
			  }
			  if (functionArgumentTable.Type.Equals("datatype.integer"))
			  {
				arrayList.Add(ExprType.Integer);
				continue;
			  }
			  if (functionArgumentTable.Type.Equals("datatype.boolean"))
			  {
				arrayList.Add(ExprType.Boolean);
				continue;
			  }
			  if (functionArgumentTable.Type.Equals("datatype.date"))
			  {
				arrayList.Add(ExprType.Double);
				continue;
			  }
			  if (functionArgumentTable.Type.Equals("datatype.array"))
			  {
				arrayList.Add(ExprType.Array);
				continue;
			  }
			  if (functionArgumentTable.Type.Equals("datatype.list") || functionArgumentTable.Type.Equals("datatype.image") || functionArgumentTable.Type.Equals("datatype.country") || functionArgumentTable.Type.Equals("datatype.notes") || functionArgumentTable.Type.Equals("datatype.text"))
			  {
				arrayList.Add(ExprType.String);
			  }
			}
			return (ExprType[])arrayList.ToArray(typeof(ExprType));
		  }
	  }

	  public override string ToString()
	  {
		  return this.fTable.Name;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\ExprDBFunction.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
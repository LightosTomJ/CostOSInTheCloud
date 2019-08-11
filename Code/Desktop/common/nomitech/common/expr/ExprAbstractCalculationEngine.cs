using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr
{
	using EngineProvider = Desktop.common.nomitech.common.expr.boqitem.EngineProvider;
	using GridMap = Desktop.common.nomitech.common.expr.boqitem.GridMap;
	using Range = Desktop.common.nomitech.common.expr.boqitem.Range;
	using Expr = org.boris.expr.Expr;
	using ExprException = org.boris.expr.ExprException;
	using ExprFunction = org.boris.expr.ExprFunction;
	using ExprMissing = org.boris.expr.ExprMissing;
	using ExprVariable = org.boris.expr.ExprVariable;
	using ExprLexer = org.boris.expr.parser.ExprLexer;
	using ExprParser = org.boris.expr.parser.ExprParser;
	using IParserVisitor = org.boris.expr.parser.IParserVisitor;
	using Exprs = org.boris.expr.util.Exprs;

	public abstract class ExprAbstractCalculationEngine : ExprAbstractEvaluationContext, IParserVisitor
	{
	  protected internal EngineProvider provider;

	  protected internal IDictionary<Range, string> rawInputs = new Hashtable();

	  protected internal GridMap inputs = new GridMap();

	  protected internal GridMap values = new GridMap();

	  protected internal IDictionary<string, Range> aliases = new SortedDictionary();

	  protected internal ExprMissing MISSING = new ExprMissing();

	  protected internal bool autoCalculate = true;

	  protected internal string @namespace;

	  public ExprAbstractCalculationEngine(EngineProvider paramEngineProvider)
	  {
		  this.provider = paramEngineProvider;
	  }

	  public virtual EngineProvider Provider
	  {
		  get
		  {
			  return this.provider;
		  }
	  }

	  public virtual bool AutoCalculate
	  {
		  set
		  {
			  this.autoCalculate = value;
		  }
	  }

	  public virtual string Namespace
	  {
		  set
		  {
			  this.@namespace = value;
		  }
	  }

	  public virtual void addAlias(string paramString, Range paramRange)
	  {
		if (!string.ReferenceEquals(paramString, null))
		{
		  this.aliases[paramString.ToUpper()] = paramRange;
		}
	  }

	  public virtual void removeAlias(string paramString)
	  {
		if (!string.ReferenceEquals(paramString, null))
		{
		  this.aliases.Remove(paramString.ToUpper());
		}
	  }

	  public virtual Range getAlias(string paramString)
	  {
		  return (string.ReferenceEquals(paramString, null)) ? null : (Range)this.aliases[paramString.ToUpper()];
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void set(String paramString1, String paramString2) throws org.boris.expr.ExprException
	  public virtual void set(string paramString1, string paramString2)
	  {
		  set(Range.valueOf(paramString1), paramString2);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected abstract void set(Desktop.common.nomitech.common.expr.boqitem.Range paramRange, String paramString) throws org.boris.expr.ExprException;
	  protected internal abstract void set(Range paramRange, string paramString);

	  public virtual ISet<Range> InputRanges
	  {
		  get
		  {
			  return this.rawInputs.Keys;
		  }
	  }

	  public virtual string getInput(Range paramRange)
	  {
		  return (string)this.rawInputs[paramRange];
	  }

	  public virtual Expr getValue(Range paramRange)
	  {
		  return (Expr)this.values[paramRange];
	  }

	  public abstract void calculate(bool paramBoolean);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void annotateFunction(org.boris.expr.ExprFunction paramExprFunction) throws org.boris.expr.ExprException
	  public virtual void annotateFunction(ExprFunction paramExprFunction)
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void annotateVariable(org.boris.expr.ExprVariable paramExprVariable) throws org.boris.expr.ExprException
	  public virtual void annotateVariable(ExprVariable paramExprVariable)
	  {
		Range range = null;
		try
		{
		  range = Range.valueOf(paramExprVariable.Name);
		  updateAliasedRange(range);
		}
		catch (ExprException)
		{
		}
		paramExprVariable.Annotation = range;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluateFunction(org.boris.expr.ExprFunction paramExprFunction) throws org.boris.expr.ExprException
	  public virtual Expr evaluateFunction(ExprFunction paramExprFunction)
	  {
		  return this.provider.evaluateFunction(this, paramExprFunction);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluateVariable(org.boris.expr.ExprVariable paramExprVariable) throws org.boris.expr.ExprException
	  public virtual Expr evaluateVariable(ExprVariable paramExprVariable)
	  {
		  return this.provider.evaluateVariable(this, paramExprVariable);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected void updateAliasedRange(Desktop.common.nomitech.common.expr.boqitem.Range paramRange) throws org.boris.expr.ExprException
	  protected internal virtual void updateAliasedRange(Range paramRange)
	  {
		if (paramRange == null)
		{
		  return;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected void validateRange(Desktop.common.nomitech.common.expr.boqitem.Range paramRange) throws org.boris.expr.ExprException
	  protected internal virtual void validateRange(Range paramRange)
	  {
		  updateAliasedRange(paramRange);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected org.boris.expr.Expr parseExpression(String paramString) throws org.boris.expr.ExprException
	  protected internal virtual Expr parseExpression(string paramString)
	  {
		Expr expr;
		if (!paramString.StartsWith("=", StringComparison.Ordinal))
		{
		  expr = Exprs.parseValue(paramString);
		}
		else
		{
		  paramString = paramString.Substring(1);
		  ExprParser exprParser = new ExprParser();
		  exprParser.ParserVisitor = this;
		  try
		  {
			exprParser.parse(new ExprLexer(paramString));
		  }
		  catch (IOException iOException)
		  {
			throw new ExprException(iOException);
		  }
		  expr = exprParser.get();
		}
		return expr;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\ExprAbstractCalculationEngine.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
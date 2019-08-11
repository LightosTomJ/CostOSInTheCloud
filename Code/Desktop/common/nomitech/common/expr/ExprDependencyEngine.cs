using System;

namespace Desktop.common.nomitech.common.expr
{
	using EngineProvider = Desktop.common.nomitech.common.expr.boqitem.EngineProvider;
	using Graph = Desktop.common.nomitech.common.expr.boqitem.Graph;
	using Range = Desktop.common.nomitech.common.expr.boqitem.Range;
	using Expr = org.boris.expr.Expr;
	using ExprEvaluatable = org.boris.expr.ExprEvaluatable;
	using ExprException = org.boris.expr.ExprException;
	using ExprVariable = org.boris.expr.ExprVariable;
	using IParserVisitor = org.boris.expr.parser.IParserVisitor;
	using Edge = org.boris.expr.util.Edge;
	using GraphCycleException = org.boris.expr.util.GraphCycleException;
	using GraphTraversalListener = org.boris.expr.util.GraphTraversalListener;

	public class ExprDependencyEngine : ExprAbstractCalculationEngine, IParserVisitor, GraphTraversalListener
	{
	  protected internal Graph graph = new Graph();

	  protected internal ExprDependencyEngine() : base(null)
	  {
		this.graph.IncludeEdges = false;
	  }

	  public ExprDependencyEngine(EngineProvider paramEngineProvider) : base(paramEngineProvider)
	  {
		this.graph.IncludeEdges = false;
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
		foreach (Range range in this.graph)
		{
		  Expr expr = (Expr)this.inputs[range];
		  if (expr is ExprEvaluatable)
		  {
			Expr expr1 = ((ExprEvaluatable)expr).evaluate(this);
			this.provider.valueChanged(range, expr1);
			this.values[range] = expr1;
		  }
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void set(Desktop.common.nomitech.common.expr.boqitem.Range paramRange, String paramString) throws org.boris.expr.ExprException
	  public override void set(Range paramRange, string paramString)
	  {
		validateRange(paramRange);
		if (string.ReferenceEquals(paramString, null))
		{
		  this.rawInputs.Remove(paramRange);
		  this.values.Remove(paramRange);
		  this.inputs.Remove(paramRange);
		  updateDependencies(paramRange, null);
		  return;
		}
		this.rawInputs[paramRange] = paramString;
		Expr expr = parseExpression(paramString);
		updateDependencies(paramRange, expr);
		this.provider.inputChanged(paramRange, expr);
		this.inputs[paramRange] = expr;
		if (expr.evaluatable)
		{
		  CurrentField = paramRange.Dimension1Name;
		  Expr expr1 = ((ExprEvaluatable)expr).evaluate(this);
		  string str = PvVars;
		  if (this.pvVarsCalled != null && !string.ReferenceEquals(str, null))
		  {
			if (this.pvVarsCalled.Length == 0)
			{
			  this.pvVarsCalled.Append(str);
			}
			else
			{
			  this.pvVarsCalled.Append(";" + str);
			}
		  }
		  this.provider.valueChanged(paramRange, expr1);
		  this.values[paramRange] = expr1;
		}
		else
		{
		  this.provider.valueChanged(paramRange, expr);
		  this.values[paramRange] = expr;
		}
		if (this.autoCalculate)
		{
		  this.graph.traverse(paramRange, this);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected void updateDependencies(Desktop.common.nomitech.common.expr.boqitem.Range paramRange, org.boris.expr.Expr paramExpr) throws org.boris.expr.ExprException
	  protected internal virtual void updateDependencies(Range paramRange, Expr paramExpr)
	  {
		this.graph.clearInbounds(paramRange);
		ExprVariable[] arrayOfExprVariable = ExprVariable.findVariables(paramExpr);
		foreach (ExprVariable exprVariable in arrayOfExprVariable)
		{
		  Range range = (Range)exprVariable.Annotation;
		  try
		  {
			addDependencies(range, paramRange);
		  }
		  catch (GraphCycleException graphCycleException)
		  {
			foreach (ExprVariable exprVariable1 in arrayOfExprVariable)
			{
			  removeDependencies((Range)exprVariable1.Annotation, paramRange);
			}
			throw new ExprException(graphCycleException);
		  }
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void addDependencies(Desktop.common.nomitech.common.expr.boqitem.Range paramRange1, Desktop.common.nomitech.common.expr.boqitem.Range paramRange2) throws org.boris.expr.util.GraphCycleException
	  private void addDependencies(Range paramRange1, Range paramRange2)
	  {
		  this.graph.add(new Edge(paramRange1, paramRange2));
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void removeDependencies(Desktop.common.nomitech.common.expr.boqitem.Range paramRange1, Desktop.common.nomitech.common.expr.boqitem.Range paramRange2) throws org.boris.expr.util.GraphCycleException
	  private void removeDependencies(Range paramRange1, Range paramRange2)
	  {
		  this.graph.remove(new Edge(paramRange1, paramRange2));
	  }

	  public virtual void traverse(object paramObject)
	  {
		Range range = (Range)paramObject;
		Expr expr = (Expr)this.inputs[range];
		if (expr is ExprEvaluatable)
		{
		  try
		  {
			Expr expr1 = ((ExprEvaluatable)expr).evaluate(this);
			this.provider.valueChanged(range, expr1);
			this.values[range] = expr1;
		  }
		  catch (ExprException exprException)
		  {
			Console.WriteLine(exprException.ToString());
			Console.Write(exprException.StackTrace);
		  }
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\ExprDependencyEngine.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
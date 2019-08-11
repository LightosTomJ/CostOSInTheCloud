namespace Desktop.common.nomitech.common.expr.location
{
	using LocalizationFactorTable = nomitech.common.db.local.LocalizationFactorTable;
	using Expr = org.boris.expr.Expr;
	using ExprDouble = org.boris.expr.ExprDouble;
	using ExprException = org.boris.expr.ExprException;
	using ExprNumber = org.boris.expr.ExprNumber;
	using ExprVariable = org.boris.expr.ExprVariable;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class FactorFromLocation : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		assertArgCount(paramArrayOfExpr, 2);
		if (paramArrayOfExpr[0] is ExprVariable)
		{
		  paramArrayOfExpr[0] = paramIEvaluationContext.evaluateVariable((ExprVariable)paramArrayOfExpr[0]);
		}
		if (!(paramArrayOfExpr[0] is ExprLocation))
		{
		  throw new ExprException("Input " + paramArrayOfExpr[0].ToString() + " is not a Location.");
		}
		if (!(paramArrayOfExpr[1] is ExprNumber))
		{
		  throw new ExprException("Input " + paramArrayOfExpr[1].ToString() + " is not a Number.");
		}
		ExprLocation exprLocation = (ExprLocation)paramArrayOfExpr[0];
		ExprNumber exprNumber = (ExprNumber)paramArrayOfExpr[1];
		if (exprLocation.Factors.Count == 0)
		{
		  return new ExprDouble(1.0D);
		}
		LocalizationFactorTable localizationFactorTable = exprLocation.FirstFactor;
		if (exprNumber.intValue() == 0)
		{
		  return new ExprDouble(localizationFactorTable.AssemblyFactor.doubleValue());
		}
		if (exprNumber.intValue() == 1)
		{
		  return new ExprDouble(localizationFactorTable.EquipmentFactor.doubleValue());
		}
		if (exprNumber.intValue() == 2)
		{
		  return new ExprDouble(localizationFactorTable.SubcontractorFactor.doubleValue());
		}
		if (exprNumber.intValue() == 3)
		{
		  return new ExprDouble(localizationFactorTable.LaborFactor.doubleValue());
		}
		if (exprNumber.intValue() == 4)
		{
		  return new ExprDouble(localizationFactorTable.MaterialFactor.doubleValue());
		}
		if (exprNumber.intValue() == 5)
		{
		  return new ExprDouble(localizationFactorTable.ConsumableFactor.doubleValue());
		}
		throw new ExprException("Invalid factorType value " + exprNumber.intValue() + " valid values are: 0,1,2,3,4,5");
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\location\FactorFromLocation.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
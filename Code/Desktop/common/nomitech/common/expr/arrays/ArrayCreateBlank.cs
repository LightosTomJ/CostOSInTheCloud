using System;

namespace Desktop.common.nomitech.common.expr.arrays
{
	using Expr = org.boris.expr.Expr;
	using ExprArray = org.boris.expr.ExprArray;
	using ExprBoolean = org.boris.expr.ExprBoolean;
	using ExprException = org.boris.expr.ExprException;
	using ExprString = org.boris.expr.ExprString;
	using IEvaluationContext = org.boris.expr.IEvaluationContext;
	using AbstractFunction = org.boris.expr.function.AbstractFunction;

	public class ArrayCreateBlank : AbstractFunction
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.boris.expr.Expr evaluate(org.boris.expr.IEvaluationContext paramIEvaluationContext, org.boris.expr.Expr[] paramArrayOfExpr) throws org.boris.expr.ExprException
	  public virtual Expr evaluate(IEvaluationContext paramIEvaluationContext, Expr[] paramArrayOfExpr)
	  {
		ExprString exprString;
		assertMinArgCount(paramArrayOfExpr, 2);
		int? integer1;
		int? integer2 = (integer1 = Convert.ToInt32(asInteger(paramIEvaluationContext, paramArrayOfExpr[0], true))).valueOf(asInteger(paramIEvaluationContext, paramArrayOfExpr[1], true));
		if (paramArrayOfExpr.Length > 2)
		{
		  exprString = paramArrayOfExpr[2];
		}
		else
		{
		  exprString = new ExprString("");
		}
		return new BlankExprArray(integer1.Value, integer2.Value, exprString);
	  }

	  private class BlankExprArray : ExprArray
	  {
		internal int colCount;

		internal int rowCount;

		internal Expr defValue;

		public BlankExprArray(int param1Int1, int param1Int2, Expr param1Expr) : base(0, 0)
		{
		  this.colCount = param1Int1;
		  this.rowCount = param1Int2;
		  this.defValue = param1Expr;
		}

		public virtual int rows()
		{
			return this.rowCount;
		}

		public virtual int columns()
		{
			return this.colCount;
		}

		public virtual int length()
		{
			return this.rowCount * this.colCount;
		}

		public virtual Expr get(int param1Int)
		{
			return this.defValue;
		}

		public virtual Expr get(int param1Int1, int param1Int2)
		{
			return this.defValue;
		}

		public virtual void set(int param1Int, Expr param1Expr)
		{
		}

		public virtual void set(int param1Int1, int param1Int2, Expr param1Expr)
		{
		}

		public virtual Expr[] InternalArray
		{
			get
			{
				return new Expr[0];
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object param1Object)
		{
			return (param1Object is BlankExprArray);
		}

		public virtual bool Volatile
		{
			get
			{
				return true;
			}
		}

		public virtual void validate()
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected org.boris.expr.Expr eval(org.boris.expr.Expr param1Expr, org.boris.expr.IEvaluationContext param1IEvaluationContext) throws org.boris.expr.ExprException
		protected internal virtual Expr eval(Expr param1Expr, IEvaluationContext param1IEvaluationContext)
		{
			return base.eval(param1Expr, param1IEvaluationContext);
		}

		protected internal virtual ExprBoolean @bool(bool param1Boolean)
		{
			return base.@bool(param1Boolean);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected Object clone() throws CloneNotSupportedException
		protected internal virtual object clone()
		{
			return base.clone();
		}

		public override string ToString()
		{
			return base.ToString();
		}

		~BlankExprArray()
		{
//JAVA TO C# CONVERTER NOTE: The base class finalizer method is automatically called in C#:
//			base.finalize();
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\arrays\ArrayCreateBlank.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
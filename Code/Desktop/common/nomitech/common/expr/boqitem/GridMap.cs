using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr.boqitem
{
	using Expr = org.boris.expr.Expr;

	public class GridMap : Dictionary<Range, Expr>
	{
	  public GridMap()
	  {
	  }

	  public GridMap(int paramInt, float paramFloat) : base(paramInt, paramFloat)
	  {
	  }

	  public GridMap(int paramInt) : base(paramInt)
	  {
	  }

	  public GridMap<T1>(IDictionary<T1> paramMap) where T1 : Range : base(paramMap)
	  {
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\boqitem\GridMap.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
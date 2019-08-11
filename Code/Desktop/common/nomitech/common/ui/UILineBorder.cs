namespace Desktop.common.nomitech.common.ui
{

	public class UILineBorder : LineBorder
	{
	  public UILineBorder(Color paramColor, int paramInt, bool paramBoolean) : base(paramColor, paramInt, paramBoolean)
	  {
	  }

	  public UILineBorder(Color paramColor, int paramInt) : base(paramColor, paramInt)
	  {
	  }

	  public UILineBorder(Color paramColor) : base(paramColor)
	  {
	  }

	  public virtual Color LineColor
	  {
		  set
		  {
			  this.lineColor = value;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\UILineBorder.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
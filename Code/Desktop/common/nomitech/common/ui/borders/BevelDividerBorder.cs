namespace Desktop.common.nomitech.common.ui.borders
{

	public class BevelDividerBorder : Border, SwingConstants
	{
	  private int location;

	  private int slack;

	  private Color light;

	  private Color dark;

	  private Insets insets;

	  public BevelDividerBorder(int paramInt) : this(paramInt, 0)
	  {
	  }

	  public BevelDividerBorder(int paramInt1, int paramInt2) : this(paramInt1, paramInt2, null, null)
	  {
	  }

	  public BevelDividerBorder(int paramInt1, int paramInt2, Color paramColor1, Color paramColor2)
	  {
		if (paramInt1 < 1 || paramInt1 > 4)
		{
		  paramInt1 = 3;
		}
		this.location = paramInt1;
		this.slack = paramInt2;
		this.light = paramColor1;
		this.dark = paramColor2;
		this.insets = new Insets(0, 0, 0, 0);
		switch (paramInt1)
		{
		  case 1:
			this.insets.top = 2;
			break;
		  case 2:
			this.insets.left = 2;
			break;
		  case 3:
			this.insets.bottom = 2;
			break;
		  case 4:
			this.insets.right = 2;
			break;
		}
	  }

	  public virtual Insets getBorderInsets(Component paramComponent)
	  {
		  return this.insets;
	  }

	  public virtual bool BorderOpaque
	  {
		  get
		  {
			  return true;
		  }
	  }

	  public virtual void paintBorder(Component paramComponent, Graphics paramGraphics, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		int i1;
		int n;
		int m;
		int k;
		int j;
		int i;
		if (paramInt3 <= 2 * this.slack)
		{
		  return;
		}
		switch (this.location)
		{
		  case 1:
			i = paramInt1 + this.slack;
			j = paramInt2;
			k = paramInt1 + paramInt3 - this.slack - 2;
			m = paramInt2;
			n = 0;
			i1 = 1;
			break;
		  case 2:
			i = paramInt1;
			j = paramInt2 + this.slack;
			k = paramInt1;
			m = paramInt2 + paramInt4 - this.slack - 2;
			n = 1;
			i1 = 0;
			break;
		  case 3:
			i = paramInt1 + this.slack;
			j = paramInt2 + paramInt4 - 2;
			k = paramInt1 + paramInt3 - this.slack - 2;
			m = j;
			n = 0;
			i1 = 1;
			break;
		  default:
			i = paramInt1 + paramInt3 - 2;
			j = paramInt2 + this.slack;
			k = i;
			m = paramInt2 + paramInt4 - this.slack - 2;
			n = 1;
			i1 = 0;
			break;
		}
		paramGraphics.Color = (this.dark == null) ? paramComponent.Background.darker() : this.dark;
		paramGraphics.drawLine(i, j, k, m);
		paramGraphics.Color = (this.light == null) ? paramComponent.Background.brighter() : this.light;
		paramGraphics.drawLine(i + n, j + i1, k + n, m + i1);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\borders\BevelDividerBorder.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
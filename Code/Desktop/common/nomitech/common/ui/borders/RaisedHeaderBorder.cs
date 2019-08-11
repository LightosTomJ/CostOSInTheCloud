namespace Desktop.common.nomitech.common.ui.borders
{

	public class RaisedHeaderBorder : AbstractBorder
	{
	  private static readonly Insets INSETS = new Insets(1, 1, 1, 0);

	  public virtual Insets getBorderInsets(Component paramComponent)
	  {
		  return INSETS;
	  }

	  public virtual void paintBorder(Component paramComponent, Graphics paramGraphics, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		paramGraphics.translate(paramInt1, paramInt2);
		paramGraphics.Color = UIManager.getColor("controlLtHighlight");
		paramGraphics.fillRect(0, 0, paramInt3, 1);
		paramGraphics.fillRect(0, 1, 1, paramInt4 - 1);
		paramGraphics.Color = UIManager.getColor("controlShadow");
		paramGraphics.fillRect(0, paramInt4 - 1, paramInt3, 1);
		paramGraphics.translate(-paramInt1, -paramInt2);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\borders\RaisedHeaderBorder.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
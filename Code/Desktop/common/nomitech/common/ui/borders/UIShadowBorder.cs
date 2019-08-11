namespace Desktop.common.nomitech.common.ui.borders
{

	public class UIShadowBorder : AbstractBorder
	{
	  private static readonly Insets INSETS = new Insets(1, 1, 3, 3);

	  public virtual Insets getBorderInsets(Component paramComponent)
	  {
		  return INSETS;
	  }

	  public virtual void paintBorder(Component paramComponent, Graphics paramGraphics, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		Color color1 = UIManager.getColor("controlShadow");
		if (color1 == null)
		{
		  color1 = Color.GRAY;
		}
		Color color2 = new Color(color1.Red, color1.Green, color1.Blue, 170);
		Color color3 = new Color(color1.Red, color1.Green, color1.Blue, 70);
		paramGraphics.translate(paramInt1, paramInt2);
		paramGraphics.Color = color1;
		paramGraphics.fillRect(0, 0, paramInt3 - 3, 1);
		paramGraphics.fillRect(0, 0, 1, paramInt4 - 3);
		paramGraphics.fillRect(paramInt3 - 3, 1, 1, paramInt4 - 3);
		paramGraphics.fillRect(1, paramInt4 - 3, paramInt3 - 3, 1);
		paramGraphics.Color = color2;
		paramGraphics.fillRect(paramInt3 - 3, 0, 1, 1);
		paramGraphics.fillRect(0, paramInt4 - 3, 1, 1);
		paramGraphics.fillRect(paramInt3 - 2, 1, 1, paramInt4 - 3);
		paramGraphics.fillRect(1, paramInt4 - 2, paramInt3 - 3, 1);
		paramGraphics.Color = color3;
		paramGraphics.fillRect(paramInt3 - 2, 0, 1, 1);
		paramGraphics.fillRect(0, paramInt4 - 2, 1, 1);
		paramGraphics.fillRect(paramInt3 - 2, paramInt4 - 2, 1, 1);
		paramGraphics.fillRect(paramInt3 - 1, 1, 1, paramInt4 - 2);
		paramGraphics.fillRect(1, paramInt4 - 1, paramInt3 - 2, 1);
		paramGraphics.translate(-paramInt1, -paramInt2);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\borders\UIShadowBorder.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
namespace Desktop.common.nomitech.common.ui
{

	public class GradientPanel : JPanel
	{
	  private Color endColor = null;

	  private bool paintGradient = true;

	  public GradientPanel(Color paramColor)
	  {
		  Background = paramColor;
	  }

	  public GradientPanel(Color paramColor1, Color paramColor2)
	  {
		Background = paramColor1;
		this.endColor = paramColor2;
	  }

	  public GradientPanel(LayoutManager paramLayoutManager, Color paramColor) : base(paramLayoutManager)
	  {
		Background = paramColor;
	  }

	  public GradientPanel(LayoutManager paramLayoutManager, Color paramColor1, Color paramColor2) : base(paramLayoutManager)
	  {
		Background = paramColor1;
		this.endColor = paramColor2;
	  }

	  public virtual void paintComponent(Graphics paramGraphics)
	  {
		base.paintComponent(paramGraphics);
		if (!Opaque)
		{
		  return;
		}
		Color color = UIManager.getColor("UILabelPanel.gradientBegin");
		if (color == null)
		{
		  color = UIManager.getColor("Office2003LnF.ToolBarBeginGradientColor");
		}
		if (color == null)
		{
		  color = UIManager.getColor("control");
		}
		if (this.endColor != null)
		{
		  color = this.endColor;
		}
		int i = Width;
		int j = Height;
		Graphics2D graphics2D = (Graphics2D)paramGraphics;
		Paint paint = graphics2D.Paint;
		if (this.paintGradient)
		{
		  graphics2D.Paint = new GradientPaint(0.0F, 0.0F, Background, i, 0.0F, color);
		}
		else
		{
		  graphics2D.Color = UIManager.getColor("UILabelPanel.noGradientFill");
		}
		graphics2D.fillRect(0, 0, i, j);
		graphics2D.Paint = paint;
	  }

	  public virtual bool PaintGradient
	  {
		  set
		  {
			  this.paintGradient = value;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\GradientPanel.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
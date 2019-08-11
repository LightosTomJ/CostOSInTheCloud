namespace Desktop.common.nomitech.common.laf
{
	using BasicCommandToggleButtonUI = org.pushingpixels.flamingo.@internal.ui.common.BasicCommandToggleButtonUI;

	public class CostOSCommandToggleButtonUI : BasicCommandToggleButtonUI
	{
	  protected internal CostOSCommandButtonPainter painter;

	  public static ComponentUI createUI(JComponent paramJComponent)
	  {
		  return new CostOSCommandToggleButtonUI();
	  }

	  protected internal virtual void installDefaults()
	  {
		base.installDefaults();
		this.painter = new CostOSCommandButtonPainter(this.commandButton);
		this.commandButton.Border = new BorderUIResource.EmptyBorderUIResource(3, 3, 3, 3);
	  }

	  protected internal virtual void paintButtonBackground(Graphics paramGraphics, Rectangle paramRectangle)
	  {
		  this.painter.paintBackground(paramGraphics, paramRectangle);
	  }

	  protected internal virtual Color getForegroundColor(bool paramBoolean)
	  {
		  return paramBoolean ? CostOSCommandButtonPainter.TEXT_COLOR : CostOSCommandButtonPainter.DISABLED_TEXT_COLOR;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSCommandToggleButtonUI.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
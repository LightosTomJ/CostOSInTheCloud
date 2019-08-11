namespace Desktop.common.nomitech.common.laf
{
	using WindowsSliderUI = com.sun.java.swing.plaf.windows.WindowsSliderUI;

	public class CostOSSliderUI : WindowsSliderUI
	{
	  public CostOSSliderUI(JSlider paramJSlider) : base(paramJSlider)
	  {
	  }

	  public static ComponentUI createUI(JComponent paramJComponent)
	  {
		  return new CostOSSliderUI((JSlider)paramJComponent);
	  }

	  public virtual void paintThumb(Graphics paramGraphics)
	  {
		if (CostOSWindowsLookAndFeel.ThemeName.Equals("blue"))
		{
		  base.paintThumb(paramGraphics);
		}
		else if (this.slider.Orientation == 1)
		{
		  base.paintThumb(paramGraphics);
		}
		else
		{
		  paramGraphics.Color = CostOSWindowsLookAndFeel.ribbonBackground;
		  paramGraphics.fillRect(this.thumbRect.x, this.thumbRect.y, this.thumbRect.width, this.thumbRect.height);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSSliderUI.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
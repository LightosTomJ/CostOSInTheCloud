namespace Desktop.common.nomitech.common.laf
{
	using AbstractCommandButton = org.pushingpixels.flamingo.api.common.AbstractCommandButton;
	using ActionButtonModel = org.pushingpixels.flamingo.api.common.model.ActionButtonModel;
	using BasicRibbonTaskToggleButtonUI = org.pushingpixels.flamingo.@internal.ui.ribbon.BasicRibbonTaskToggleButtonUI;

	public class CostOSRibbonTaskToggleButtonUI : BasicRibbonTaskToggleButtonUI
	{
	  private static readonly Color rollOverBackground = CostOSWindowsLookAndFeel.ribbonRollOverBackground;

	  private static readonly Color rollOverForeground = CostOSWindowsLookAndFeel.ribbonRollOverForeground;

	  private static readonly Color selectedBackground = CostOSWindowsLookAndFeel.ribbonTaksAreaBackground;

	  private static readonly Color selectedBorder = CostOSWindowsLookAndFeel.ribbonBorderColor;

	  private static readonly Color selectedBorderShadow = selectedBorder;

	  private Color normalForeground = CostOSWindowsLookAndFeel.ribbonTaskTitleTextForegroundColor;

	  private Color selectedForeground = CostOSWindowsLookAndFeel.ribbonTaskTitleTextSelectedForegroundColor;

	  private PropertyChangeListener officePropertyChangeListener;

	  public static ComponentUI createUI(JComponent paramJComponent)
	  {
		  return new CostOSRibbonTaskToggleButtonUI();
	  }

	  protected internal virtual void installDefaults()
	  {
		  base.installDefaults();
	  }

	  public virtual void uninstallUI(JComponent paramJComponent)
	  {
		uninstallListeners();
		base.uninstallUI(paramJComponent);
	  }

	  protected internal virtual void installListeners()
	  {
		base.installListeners();
		this.officePropertyChangeListener = new PropertyChangeListenerAnonymousInnerClass(this);
		this.commandButton.addPropertyChangeListener(this.officePropertyChangeListener);
	  }

	  private class PropertyChangeListenerAnonymousInnerClass : PropertyChangeListener
	  {
		  private readonly CostOSRibbonTaskToggleButtonUI outerInstance;

		  public PropertyChangeListenerAnonymousInnerClass(CostOSRibbonTaskToggleButtonUI outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public void propertyChange(PropertyChangeEvent param1PropertyChangeEvent)
		  {
			if ("contextualGroupHueColor".Equals(param1PropertyChangeEvent.PropertyName))
			{
			  Color color = (Color)param1PropertyChangeEvent.NewValue;
			  outerInstance.commandButton.Background = color;
			}
		  }
	  }

	  protected internal virtual void uninstallListeners()
	  {
		this.commandButton.removePropertyChangeListener(this.officePropertyChangeListener);
		this.officePropertyChangeListener = null;
		foreach (KeyListener keyListener in this.commandButton.KeyListeners)
		{
		  this.commandButton.removeKeyListener(keyListener);
		}
		base.uninstallListeners();
	  }

	  protected internal virtual Color getForegroundColor(bool paramBoolean)
	  {
		  return paramBoolean ? CostOSCommandButtonPainter.TEXT_COLOR : CostOSCommandButtonPainter.DISABLED_TEXT_COLOR;
	  }

	  protected internal virtual void paintButtonBackground(Graphics paramGraphics, Rectangle paramRectangle)
	  {
		ActionButtonModel actionButtonModel = this.commandButton.ActionModel;
		paramRectangle.height -= 10;
		if ((actionButtonModel.Armed && actionButtonModel.Pressed) || actionButtonModel.Selected)
		{
		  if (actionButtonModel.Selected)
		  {
			paintSelectedBackground(paramGraphics, this.commandButton, paramRectangle);
		  }
		  else
		  {
			paintNormalBackground(paramGraphics, this.commandButton, paramRectangle);
		  }
		  paramGraphics.Color = this.selectedForeground;
		}
		else
		{
		  paintNormalBackground(paramGraphics, this.commandButton, paramRectangle);
		  if (actionButtonModel.Rollover)
		  {
			paramGraphics.Color = rollOverForeground;
		  }
		  else
		  {
			paramGraphics.Color = this.normalForeground;
		  }
		}
	  }

	  protected internal virtual void paintNormalBackground(Graphics paramGraphics, AbstractCommandButton paramAbstractCommandButton, Rectangle paramRectangle)
	  {
		if (!paramAbstractCommandButton.ActionModel.Rollover)
		{
		  return;
		}
		Graphics2D graphics2D = (Graphics2D)paramGraphics;
		int i = paramRectangle.x;
		int j = paramRectangle.y;
		int k = paramRectangle.x + paramRectangle.width - 1;
		int m = paramRectangle.y + paramRectangle.height - 1;
		Color color = graphics2D.Color;
		graphics2D.Color = rollOverBackground;
		graphics2D.fillRect(i, j, paramRectangle.width, paramRectangle.height - 2);
		drawBorder(graphics2D, rollOverBackground, rollOverBackground, i, j, k, m - 2, false);
		graphics2D.Color = color;
	  }

	  protected internal virtual void paintSelectedBackground(Graphics paramGraphics, AbstractCommandButton paramAbstractCommandButton, Rectangle paramRectangle)
	  {
		Graphics2D graphics2D = (Graphics2D)paramGraphics;
		int i = paramRectangle.x;
		int j = paramRectangle.y;
		int k = paramRectangle.x + paramRectangle.width - 1;
		int m = paramRectangle.y + paramRectangle.height - 1;
		Color color = graphics2D.Color;
		graphics2D.Color = selectedBackground;
		graphics2D.fillRect(i, j, paramRectangle.width, paramRectangle.height);
		graphics2D.Color = color;
		drawBorder(graphics2D, selectedBorder, selectedBorderShadow, i, j, k, m, true);
	  }

	  private void drawBorder(Graphics2D paramGraphics2D, Color paramColor1, Color paramColor2, int paramInt1, int paramInt2, int paramInt3, int paramInt4, bool paramBoolean)
	  {
		Color color = paramGraphics2D.Color;
		paramGraphics2D.Color = paramColor1;
		paramGraphics2D.drawLine(paramInt1, paramInt2, paramInt1, paramInt4);
		paramGraphics2D.drawLine(paramInt1, paramInt2, paramInt3, paramInt2);
		paramGraphics2D.drawLine(paramInt3, paramInt2, paramInt3, paramInt4);
		paramGraphics2D.Color = color;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSRibbonTaskToggleButtonUI.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
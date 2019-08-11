namespace Desktop.common.nomitech.common.laf
{
	using CommandButtonLayoutManager = org.pushingpixels.flamingo.api.common.CommandButtonLayoutManager;
	using JCommandButton = org.pushingpixels.flamingo.api.common.JCommandButton;
	using ResizableIcon = org.pushingpixels.flamingo.api.common.icon.ResizableIcon;
	using BasicCommandMenuButtonUI = org.pushingpixels.flamingo.@internal.ui.common.BasicCommandMenuButtonUI;
	using FlamingoUtilities = org.pushingpixels.flamingo.@internal.utils.FlamingoUtilities;

	public class CostOSCommandMenuButtonUI : BasicCommandMenuButtonUI
	{
	  private CostOSCommandButtonPainter painter;

	  public static ComponentUI createUI(JComponent paramJComponent)
	  {
		  return new CostOSCommandMenuButtonUI();
	  }

	  protected internal virtual void installDefaults()
	  {
		base.installDefaults();
		this.painter = new CostOSCommandButtonPainter(this.commandButton);
	  }

	  protected internal virtual void paintButtonBackground(Graphics paramGraphics, Rectangle paramRectangle)
	  {
		  this.painter.paintBackground(paramGraphics, paramRectangle);
	  }

	  protected internal virtual void paintButtonHorizontalSeparator(Graphics paramGraphics, Rectangle paramRectangle)
	  {
		if (this.commandButton is CostOSRibbonApplicationMenuPopupPanel.JCommandAppMenuButton)
		{
		  paramGraphics.Color = CostOSWindowsLookAndFeel.ribbonAppMenuButtonForegroundColor;
		}
		else
		{
		  paramGraphics.Color = CostOSCommandButtonUI.SEPARATOR_COLOR;
		}
		paramGraphics.drawLine(1, paramRectangle.y, (this.commandButton.Bounds).width - 2, paramRectangle.y);
	  }

	  protected internal virtual void paintButtonVerticalSeparator(Graphics paramGraphics, Rectangle paramRectangle)
	  {
		if (this.commandButton is CostOSRibbonApplicationMenuPopupPanel.JCommandAppMenuButton)
		{
		  paramGraphics.Color = CostOSWindowsLookAndFeel.ribbonAppMenuButtonForegroundColor;
		}
		else
		{
		  paramGraphics.Color = CostOSCommandButtonUI.SEPARATOR_COLOR;
		}
		paramGraphics.drawLine(paramRectangle.x, 1, paramRectangle.x, (this.commandButton.Bounds).height - 2);
	  }

	  protected internal virtual ResizableIcon createPopupActionIcon()
	  {
		  return new PopupArrowIcon(((JCommandButton)this.commandButton).PopupOrientationKind);
	  }

	  protected internal virtual int LayoutGap
	  {
		  get
		  {
			  return 2;
		  }
	  }

	  protected internal virtual Color getForegroundColor(bool paramBoolean)
	  {
		  return (this.commandButton is CostOSRibbonApplicationMenuPopupPanel.JCommandAppMenuButton) ? (paramBoolean ? CostOSWindowsLookAndFeel.ribbonAppMenuButtonForegroundColor : CostOSWindowsLookAndFeel.ribbonAppMenuButtonDisabledForegroundColor) : (paramBoolean ? CostOSCommandButtonPainter.TEXT_COLOR : CostOSCommandButtonPainter.DISABLED_TEXT_COLOR);
	  }

	  public virtual void paint(Graphics paramGraphics, JComponent paramJComponent)
	  {
		if (!(this.commandButton is CostOSRibbonApplicationMenuPopupPanel.JCommandAppMenuButton))
		{
		  base.paint(paramGraphics, paramJComponent);
		  return;
		}
		int i = 16;
		paramGraphics.Font = FlamingoUtilities.getFont(this.commandButton, new string[] {"Ribbon.font", "Button.font", "Panel.font"});
		this.layoutInfo = this.layoutManager.getLayoutInfo(this.commandButton, paramGraphics);
		this.commandButton.putClientProperty("icon.bounds", this.layoutInfo.iconRect);
		if (PaintingBackground)
		{
		  paintButtonBackground(paramGraphics, new Rectangle(0, 0, this.commandButton.Width, this.commandButton.Height));
		}
		if (this.layoutInfo.iconRect != null)
		{
		  paintButtonIcon(paramGraphics, this.layoutInfo.iconRect);
		}
		if (this.layoutInfo.popupActionRect.Width > 0.0D)
		{
		  paintPopupActionIcon(paramGraphics, this.layoutInfo.popupActionRect);
		}
		FontMetrics fontMetrics = paramGraphics.FontMetrics;
		bool @bool = this.commandButton.Enabled;
		if (this.commandButton is JCommandButton)
		{
		  JCommandButton jCommandButton = (JCommandButton)this.commandButton;
		  @bool = this.layoutInfo.isTextInActionArea ? jCommandButton.ActionModel.Enabled : jCommandButton.PopupModel.Enabled;
		}
		paramGraphics.Color = getForegroundColor(@bool);
		if (this.layoutInfo.textLayoutInfoList != null)
		{
		  foreach (CommandButtonLayoutManager.TextLayoutInfo textLayoutInfo in this.layoutInfo.textLayoutInfoList)
		  {
			if (textLayoutInfo.text != null)
			{
			  BasicGraphicsUtils.drawString(paramGraphics, textLayoutInfo.text, -1, textLayoutInfo.textRect.x - i, textLayoutInfo.textRect.y + fontMetrics.Ascent);
			}
		  }
		}
		if (@bool)
		{
		  paramGraphics.Color = FlamingoUtilities.getColor(Color.gray, new string[] {"Label.disabledForeground"});
		}
		else
		{
		  paramGraphics.Color = FlamingoUtilities.getColor(Color.gray, new string[] {"Label.disabledForeground"}).brighter();
		}
		if (this.layoutInfo.extraTextLayoutInfoList != null)
		{
		  foreach (CommandButtonLayoutManager.TextLayoutInfo textLayoutInfo in this.layoutInfo.extraTextLayoutInfoList)
		  {
			if (textLayoutInfo.text != null)
			{
			  BasicGraphicsUtils.drawString(paramGraphics, textLayoutInfo.text, -1, textLayoutInfo.textRect.x, textLayoutInfo.textRect.y + fontMetrics.Ascent);
			}
		  }
		}
		if (PaintingSeparators && this.layoutInfo.separatorArea != null)
		{
		  if (this.layoutInfo.separatorOrientation == CommandButtonLayoutManager.CommandButtonSeparatorOrientation.HORIZONTAL)
		  {
			paintButtonHorizontalSeparator(paramGraphics, this.layoutInfo.separatorArea);
		  }
		  else
		  {
			paintButtonVerticalSeparator(paramGraphics, this.layoutInfo.separatorArea);
		  }
		}
	  }

	  public class PopupArrowIcon : ResizableIcon
	  {
		internal static readonly Color C1 = CostOSWindowsLookAndFeel.ribbonAppMenuButtonForegroundColor;

		internal static readonly Color C2 = CostOSWindowsLookAndFeel.ribbonAppMenuButtonForegroundColor;

		internal const int ICON_WIDTH = 7;

		internal const int ICON_HEIGHT = 4;

		internal readonly JCommandButton.CommandButtonPopupOrientationKind orientationKind;

		public PopupArrowIcon(JCommandButton.CommandButtonPopupOrientationKind param1CommandButtonPopupOrientationKind)
		{
			this.orientationKind = param1CommandButtonPopupOrientationKind;
		}

		public virtual Dimension Dimension
		{
			set
			{
			}
		}

		public virtual void paintIcon(Component param1Component, Graphics param1Graphics, int param1Int1, int param1Int2)
		{
		  Graphics2D graphics2D = (Graphics2D)param1Graphics;
		  if (this.orientationKind == JCommandButton.CommandButtonPopupOrientationKind.DOWNWARD)
		  {
			graphics2D.Paint = new LinearGradientPaint(0.0F, 0.0F, 0.0F, 3.0F, new float[] {0.0F, 1.0F}, new Color[] {C1, C2});
			param1Graphics.drawLine(param1Int1, param1Int2, param1Int1 + 6, param1Int2);
			param1Graphics.drawLine(param1Int1 + 1, param1Int2 + 1, param1Int1 + 5, param1Int2 + 1);
			param1Graphics.drawLine(param1Int1 + 2, param1Int2 + 2, param1Int1 + 4, param1Int2 + 2);
			param1Graphics.drawLine(param1Int1 + 3, param1Int2 + 3, param1Int1 + 3, param1Int2 + 3);
		  }
		  else
		  {
			graphics2D.Paint = new LinearGradientPaint(0.0F, 0.0F, 6.0F, 0.0F, new float[] {0.0F, 1.0F}, new Color[] {C1, C2});
			param1Graphics.drawLine(param1Int1, param1Int2, param1Int1, param1Int2 + 6);
			param1Graphics.drawLine(param1Int1 + 1, param1Int2 + 1, param1Int1 + 1, param1Int2 + 5);
			param1Graphics.drawLine(param1Int1 + 2, param1Int2 + 2, param1Int1 + 2, param1Int2 + 4);
			param1Graphics.drawLine(param1Int1 + 3, param1Int2 + 3, param1Int1 + 3, param1Int2 + 3);
		  }
		}

		public virtual int IconWidth
		{
			get
			{
				return (this.orientationKind == JCommandButton.CommandButtonPopupOrientationKind.DOWNWARD) ? 7 : 4;
			}
		}

		public virtual int IconHeight
		{
			get
			{
				return (this.orientationKind == JCommandButton.CommandButtonPopupOrientationKind.DOWNWARD) ? 4 : 7;
			}
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSCommandMenuButtonUI.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
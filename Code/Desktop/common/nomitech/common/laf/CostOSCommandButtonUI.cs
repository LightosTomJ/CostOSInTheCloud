namespace Desktop.common.nomitech.common.laf
{
	using AbstractCommandButton = org.pushingpixels.flamingo.api.common.AbstractCommandButton;
	using JCommandButton = org.pushingpixels.flamingo.api.common.JCommandButton;
	using ResizableIcon = org.pushingpixels.flamingo.api.common.icon.ResizableIcon;
	using BasicCommandButtonListener = org.pushingpixels.flamingo.@internal.ui.common.BasicCommandButtonListener;
	using BasicCommandButtonUI = org.pushingpixels.flamingo.@internal.ui.common.BasicCommandButtonUI;

	public class CostOSCommandButtonUI : BasicCommandButtonUI
	{
	  internal static readonly Color SEPARATOR_COLOR = CostOSWindowsLookAndFeel.ribbonButtonSeperatorColor;

	  protected internal CostOSCommandButtonPainter painter;

	  public static ComponentUI createUI(JComponent paramJComponent)
	  {
		  return new CostOSCommandButtonUI();
	  }

	  protected internal virtual bool hasPopup()
	  {
		  return (this.popupActionIcon != null);
	  }

	  protected internal virtual void installDefaults()
	  {
		base.installDefaults();
		this.painter = new CostOSCommandButtonPainter(this.commandButton);
		this.commandButton.Border = new BorderUIResource.EmptyBorderUIResource(3, 3, 3, 3);
	  }

	  protected internal virtual BasicCommandButtonListener createButtonListener(AbstractCommandButton paramAbstractCommandButton)
	  {
		  return new BasicCommandButtonListenerAnonymousInnerClass(this);
	  }

	  private class BasicCommandButtonListenerAnonymousInnerClass : BasicCommandButtonListener
	  {
		  private readonly CostOSCommandButtonUI outerInstance;

		  public BasicCommandButtonListenerAnonymousInnerClass(CostOSCommandButtonUI outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public void mousePressed(MouseEvent param1MouseEvent)
		  {
			if (param1MouseEvent.ClickCount == 1)
			{
			  base.mousePressed(param1MouseEvent);
			}
		  }

		  public void mouseReleased(MouseEvent param1MouseEvent)
		  {
			  base.mouseReleased(param1MouseEvent);
		  }
	  }

	  protected internal virtual void paintButtonBackground(Graphics paramGraphics, Rectangle paramRectangle)
	  {
		  this.painter.paintBackground(paramGraphics, paramRectangle);
	  }

	  protected internal virtual void paintButtonHorizontalSeparator(Graphics paramGraphics, Rectangle paramRectangle)
	  {
		paramGraphics.Color = SEPARATOR_COLOR;
		paramGraphics.drawLine(1, paramRectangle.y, (this.commandButton.Bounds).width - 2, paramRectangle.y);
	  }

	  protected internal virtual void paintButtonVerticalSeparator(Graphics paramGraphics, Rectangle paramRectangle)
	  {
		paramGraphics.Color = SEPARATOR_COLOR;
		paramGraphics.drawLine(paramRectangle.x, 1, paramRectangle.x, (this.commandButton.Bounds).height - 2);
	  }

	  protected internal virtual ResizableIcon createPopupActionIcon()
	  {
		  return new PopupArrowIcon(((JCommandButton)this.commandButton).PopupOrientationKind);
	  }

	  protected internal virtual void paintPopupActionIcon(Graphics paramGraphics, Rectangle paramRectangle)
	  {
		bool @bool = (this.commandButton is JCommandButton && ((JCommandButton)this.commandButton).PopupModel.Enabled) ? 1 : 0;
		Graphics2D graphics2D = (Graphics2D)paramGraphics.create();
		if (!@bool)
		{
		  graphics2D.Composite = AlphaComposite.getInstance(3, 0.5F);
		}
		this.popupActionIcon.paintIcon(this.commandButton, graphics2D, paramRectangle.x, paramRectangle.y);
		graphics2D.dispose();
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
		  return (this.commandButton is CostOSRibbonApplicationMenuPopupPanel.JCommandFooterButton) ? (paramBoolean ? CostOSWindowsLookAndFeel.ribbonAppMenuButtonForegroundColor : CostOSWindowsLookAndFeel.ribbonAppMenuButtonDisabledForegroundColor) : (paramBoolean ? CostOSCommandButtonPainter.TEXT_COLOR : CostOSCommandButtonPainter.DISABLED_TEXT_COLOR);
	  }

	  public class PopupArrowIcon : ResizableIcon
	  {
		internal static readonly Color C = new Color(8158332);

		internal static readonly Dimension TRIANGLE = new Dimension(5, 3);

		internal readonly Dimension dim = new Dimension();

		internal readonly JCommandButton.CommandButtonPopupOrientationKind orientationKind;

		public PopupArrowIcon(JCommandButton.CommandButtonPopupOrientationKind param1CommandButtonPopupOrientationKind)
		{
			this.orientationKind = param1CommandButtonPopupOrientationKind;
		}

		public virtual Dimension Dimension
		{
			set
			{
			  this.dim.width = value.width;
			  this.dim.height = value.height;
			}
		}

		public virtual void paintIcon(Component param1Component, Graphics param1Graphics, int param1Int1, int param1Int2)
		{
		  Graphics2D graphics2D = (Graphics2D)param1Graphics;
		  int i = (this.dim.width > TRIANGLE.width) ? (param1Int1 + this.dim.width / 2 - TRIANGLE.width / 2) : param1Int1;
		  int j = (this.dim.height > TRIANGLE.height) ? (param1Int2 + this.dim.height / 2 - TRIANGLE.height / 2) : param1Int2;
		  Composite composite = graphics2D.Composite;
		  graphics2D.translate(0, 1);
		  graphics2D.Composite = AlphaComposite.getInstance(3, 0.5F);
		  graphics2D.Color = Color.WHITE;
		  drawTriangle(graphics2D, i, j);
		  graphics2D.Composite = composite;
		  graphics2D.translate(0, -1);
		  graphics2D.Color = C;
		  drawTriangle(graphics2D, i, j);
		}

		internal virtual void drawTriangle(Graphics2D param1Graphics2D, int param1Int1, int param1Int2)
		{
		  if (this.orientationKind == JCommandButton.CommandButtonPopupOrientationKind.DOWNWARD)
		  {
			param1Graphics2D.drawLine(param1Int1, param1Int2, param1Int1 + 4, param1Int2);
			param1Graphics2D.drawLine(param1Int1 + 1, param1Int2 + 1, param1Int1 + 3, param1Int2 + 1);
			param1Graphics2D.drawLine(param1Int1 + 2, param1Int2 + 2, param1Int1 + 2, param1Int2 + 2);
		  }
		  else
		  {
			param1Graphics2D.drawLine(param1Int1, param1Int2, param1Int1, param1Int2 + 4);
			param1Graphics2D.drawLine(param1Int1 + 1, param1Int2 + 1, param1Int1 + 1, param1Int2 + 3);
			param1Graphics2D.drawLine(param1Int1 + 2, param1Int2 + 2, param1Int1 + 2, param1Int2 + 2);
		  }
		}

		public virtual int IconWidth
		{
			get
			{
				return this.dim.width;
			}
		}

		public virtual int IconHeight
		{
			get
			{
				return this.dim.height;
			}
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSCommandButtonUI.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
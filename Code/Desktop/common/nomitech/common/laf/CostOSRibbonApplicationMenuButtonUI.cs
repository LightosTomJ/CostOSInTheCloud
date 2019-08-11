using System;

namespace Desktop.common.nomitech.common.laf
{
	using JideSwingUtilities = com.jidesoft.swing.JideSwingUtilities;
	using AbstractCommandButton = org.pushingpixels.flamingo.api.common.AbstractCommandButton;
	using CommandButtonLayoutManager = org.pushingpixels.flamingo.api.common.CommandButtonLayoutManager;
	using JCommandButton = org.pushingpixels.flamingo.api.common.JCommandButton;
	using PopupButtonModel = org.pushingpixels.flamingo.api.common.model.PopupButtonModel;
	using JPopupPanel = org.pushingpixels.flamingo.api.common.popup.JPopupPanel;
	using PopupPanelCallback = org.pushingpixels.flamingo.api.common.popup.PopupPanelCallback;
	using PopupPanelManager = org.pushingpixels.flamingo.api.common.popup.PopupPanelManager;
	using JRibbon = org.pushingpixels.flamingo.api.ribbon.JRibbon;
	using RibbonApplicationMenu = org.pushingpixels.flamingo.api.ribbon.RibbonApplicationMenu;
	using BasicRibbonApplicationMenuButtonUI = org.pushingpixels.flamingo.@internal.ui.ribbon.appmenu.BasicRibbonApplicationMenuButtonUI;
	using JRibbonApplicationMenuButton = org.pushingpixels.flamingo.@internal.ui.ribbon.appmenu.JRibbonApplicationMenuButton;

	public class CostOSRibbonApplicationMenuButtonUI : BasicRibbonApplicationMenuButtonUI, PopupPanelManager.PopupListener
	{
	  private static ImageIcon backstageNormal;

	  private static ImageIcon backstageOver;

	  private static ImageIcon backstageDown;

	  private static ImageIcon normal;

	  private static ImageIcon over;

	  private static ImageIcon down;

	  private static string applicationButtonText = "FILE";

	  public static ComponentUI createUI(JComponent paramJComponent)
	  {
		  return new CostOSRibbonApplicationMenuButtonUI();
	  }

	  protected internal virtual void uninstallComponents()
	  {
		  PopupPanelManager.defaultManager().removePopupListener(this);
	  }

	  protected internal virtual void installComponents()
	  {
		base.installComponents();
		PopupPanelManager.defaultManager().addPopupListener(this);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.pushingpixels.flamingo.internal.ui.ribbon.appmenu.JRibbonApplicationMenuButton appMenuButton = (org.pushingpixels.flamingo.internal.ui.ribbon.appmenu.JRibbonApplicationMenuButton)this.commandButton;
		JRibbonApplicationMenuButton appMenuButton = (JRibbonApplicationMenuButton)this.commandButton;
		jRibbonApplicationMenuButton.PopupCallback = new PopupPanelCallbackAnonymousInnerClass(this, appMenuButton);
	  }

	  private class PopupPanelCallbackAnonymousInnerClass : PopupPanelCallback
	  {
		  private readonly CostOSRibbonApplicationMenuButtonUI outerInstance;

		  private JRibbonApplicationMenuButton appMenuButton;

		  public PopupPanelCallbackAnonymousInnerClass(CostOSRibbonApplicationMenuButtonUI outerInstance, JRibbonApplicationMenuButton appMenuButton)
		  {
			  this.outerInstance = outerInstance;
			  this.appMenuButton = appMenuButton;
		  }

//JAVA TO C# CONVERTER WARNING: 'final' parameters are ignored unless the option to convert to C# 7.2 'in' parameters is selected:
//ORIGINAL LINE: public org.pushingpixels.flamingo.api.common.popup.JPopupPanel getPopupPanel(final org.pushingpixels.flamingo.api.common.JCommandButton commandButton)
		  public JPopupPanel getPopupPanel(JCommandButton commandButton)
		  {
			if (appMenuButton.Parent is JRibbon)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.pushingpixels.flamingo.api.ribbon.JRibbon ribbon = (org.pushingpixels.flamingo.api.ribbon.JRibbon)appMenuButton.getParent();
			  JRibbon ribbon = (JRibbon)appMenuButton.Parent;
			  RibbonApplicationMenu ribbonApplicationMenu = jRibbon.ApplicationMenu;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final CostOSRibbonApplicationMenuPopupPanel menuPopupPanel = new CostOSRibbonApplicationMenuPopupPanel(appMenuButton, ribbonApplicationMenu)
			  CostOSRibbonApplicationMenuPopupPanel menuPopupPanel = new CostOSRibbonApplicationMenuPopupPanelAnonymousInnerClass(this, appMenuButton, ribbonApplicationMenu);
			  costOSRibbonApplicationMenuPopupPanel.Customizer = new PopupPanelCustomizerAnonymousInnerClass(this);
			  return costOSRibbonApplicationMenuPopupPanel;
			}
			return null;
		  }

		  private class CostOSRibbonApplicationMenuPopupPanelAnonymousInnerClass : CostOSRibbonApplicationMenuPopupPanel
		  {
			  private readonly PopupPanelCallbackAnonymousInnerClass outerInstance;

			  public CostOSRibbonApplicationMenuPopupPanelAnonymousInnerClass(PopupPanelCallbackAnonymousInnerClass outerInstance, JRibbonApplicationMenuButton appMenuButton, RibbonApplicationMenu ribbonApplicationMenu) : base(appMenuButton, ribbonApplicationMenu)
			  {
				  this.outerInstance = outerInstance;
			  }

			  public bool Visible
			  {
				  set
				  {
					Console.WriteLine("CostOSRibbonApplicationMenuButtonUI.installComponents().new PopupPanelCallback() {...}.getPopupPanel(...).new CostOSRibbonApplicationMenuPopupPanel() {...}.setVisible() " + value);
					base.Visible = value;
				  }
			  }
		  }

		  private class PopupPanelCustomizerAnonymousInnerClass : JPopupPanel.PopupPanelCustomizer
		  {
			  private readonly PopupPanelCallbackAnonymousInnerClass outerInstance;

			  public PopupPanelCustomizerAnonymousInnerClass(PopupPanelCallbackAnonymousInnerClass outerInstance)
			  {
				  this.outerInstance = outerInstance;
			  }

			  public Rectangle ScreenBounds
			  {
				  get
				  {
					int i = (this.val$ribbon.LocationOnScreen).x;
					int j = (this.val$commandButton.LocationOnScreen).y + (this.val$commandButton.Size).height;
					return new Rectangle(i, j, (this.val$menuPopupPanel.PreferredSize).width, (this.val$menuPopupPanel.PreferredSize).height);
				  }
			  }
		  }
	  }

	  public virtual void paint(Graphics paramGraphics, JComponent paramJComponent)
	  {
		if (CostOSRibbonUI.Instance.BackstageShowing)
		{
		  Graphics2D graphics2D1 = (Graphics2D)paramGraphics.create();
		  Rectangle rectangle1 = new Rectangle(26, 13, 36, 36);
		  paintButtonIcon(graphics2D1, rectangle1);
		  graphics2D1.dispose();
		  return;
		}
		Graphics2D graphics2D = (Graphics2D)paramGraphics.create();
		Insets insets = paramJComponent.Insets;
		Rectangle rectangle = new Rectangle(insets.left, insets.top, paramJComponent.Width - insets.left - insets.right, paramJComponent.Height - insets.top - insets.bottom);
		paintButtonBackground(graphics2D, rectangle);
		CommandButtonLayoutManager.CommandButtonLayoutInfo commandButtonLayoutInfo = this.layoutManager.getLayoutInfo(this.commandButton, paramGraphics);
		this.commandButton.putClientProperty("icon.bounds", commandButtonLayoutInfo.iconRect);
		rectangle = new Rectangle(10, 5, 16, 16);
		paintButtonIcon(graphics2D, rectangle);
		paramGraphics.Color = CostOSWindowsLookAndFeel.ribbonBorderColor;
		paramGraphics.drawLine(29, 6, 29, 20);
		graphics2D.dispose();
	  }

	  public static string ApplicationMenuButtonText
	  {
		  set
		  {
			  applicationButtonText = value;
		  }
		  get
		  {
			  return applicationButtonText;
		  }
	  }


	  public static void setApplicationIcons(ImageIcon paramImageIcon1, ImageIcon paramImageIcon2, ImageIcon paramImageIcon3)
	  {
		backstageNormal = new ImageIcon(typeof(org.officelaf.ribbon.OfficeRibbonUI).getResource("images/backstage_arrow.png"));
		backstageOver = new ImageIcon(typeof(org.officelaf.ribbon.OfficeRibbonUI).getResource("images/backstage_arrow_selected.png"));
		backstageDown = backstageOver;
		normal = paramImageIcon1;
		over = paramImageIcon2;
		down = paramImageIcon3;
	  }

	  protected internal virtual void configureRenderer()
	  {
		this.buttonRendererPane = new CellRendererPane();
		this.rendererButton = new JButton("");
	  }

	  protected internal virtual void unconfigureRenderer()
	  {
		this.buttonRendererPane = null;
		this.rendererButton = null;
	  }

	  protected internal virtual void paintButtonBackground(Graphics paramGraphics, Rectangle paramRectangle)
	  {
		PopupButtonModel popupButtonModel = this.applicationMenuButton.PopupModel;
		if (popupButtonModel.Pressed || popupButtonModel.PopupShowing)
		{
		  paramGraphics.Color = CostOSWindowsLookAndFeel.applicationButtonSelectedColor;
		}
		else if (popupButtonModel.Rollover)
		{
		  paramGraphics.Color = CostOSWindowsLookAndFeel.applicationButtonColor;
		}
		else
		{
		  paramGraphics.Color = CostOSWindowsLookAndFeel.applicationButtonColor;
		}
		int i = paramRectangle.x;
		int j = paramRectangle.y + paramRectangle.height / 2 + 4;
		int k = paramRectangle.width;
		int m = paramRectangle.height / 2;
		if (CostOSWindowsLookAndFeel.ThemeName.Equals("blue") || CostOSWindowsLookAndFeel.ThemeName.Equals("green"))
		{
		  paramGraphics.fillRect(i, j, k, m - 2);
		}
		else
		{
		  paramGraphics.fillRect(i, j, k, m);
		}
		paintText(paramGraphics, i, j, k, m - 2);
	  }

	  protected internal virtual void paintText(Graphics paramGraphics, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		FontMetrics fontMetrics = paramGraphics.FontMetrics;
		string str = applicationButtonText;
		sbyte b1 = 40;
		sbyte b2 = 30;
		int i = paramInt1 + paramInt3 / 2 - fontMetrics.stringWidth(str) / 2;
		int j = paramInt2 + paramInt4 / 2 - fontMetrics.Height / 2;
		j += 2;
		Rectangle rectangle = new Rectangle(i, j, fontMetrics.stringWidth(str), fontMetrics.Height);
		while (str.Length != 0)
		{
		  int k = fontMetrics.stringWidth(str);
		  if (k <= rectangle.width)
		  {
			break;
		  }
		  str = str.Substring(0, str.Length - 1);
		}
		paramGraphics.Color = Color.white;
		BasicGraphicsUtils.drawString(paramGraphics, str, -1, rectangle.x, rectangle.y + fontMetrics.Ascent);
	  }

	  protected internal virtual Icon IconToPaint
	  {
		  get
		  {
			ImageIcon imageIcon;
			PopupButtonModel popupButtonModel = this.applicationMenuButton.PopupModel;
			if (CostOSRibbonUI.Instance.BackstageShowing)
			{
			  if (popupButtonModel.Pressed)
			  {
				imageIcon = backstageDown;
			  }
			  else if (popupButtonModel.Rollover)
			  {
				imageIcon = backstageOver;
			  }
			  else
			  {
				imageIcon = backstageNormal;
			  }
			}
			else if (popupButtonModel.Pressed || popupButtonModel.PopupShowing)
			{
			  imageIcon = down;
			}
			else if (popupButtonModel.Rollover)
			{
			  imageIcon = over;
			}
			else
			{
			  imageIcon = normal;
			}
			return imageIcon;
		  }
	  }

	  public virtual void popupHidden(PopupPanelManager.PopupEvent paramPopupEvent)
	  {
		if (paramPopupEvent.Component is CostOSRibbonApplicationMenuPopupPanel)
		{
		  CostOSRibbonUI.Instance.BackstageShown = false;
		  CostOSRootPaneUI.Resolver.Ribbon.firePropertyChange("AppMenuHidden", false, true);
		  Window window = SwingUtilities.getWindowAncestor(CostOSRootPaneUI.Resolver.Ribbon);
		  window = JideSwingUtilities.getTopModalDialog(window);
		  if (window != null)
		  {
			window.invalidate();
			window.repaint();
		  }
		}
	  }

	  public virtual void popupShown(PopupPanelManager.PopupEvent paramPopupEvent)
	  {
		if (paramPopupEvent.Component is CostOSRibbonApplicationMenuPopupPanel)
		{
		  CostOSRibbonUI.Instance.BackstageShown = true;
		  CostOSRootPaneUI.Resolver.Ribbon.firePropertyChange("AppMenuShown", false, true);
		}
	  }

	  protected internal virtual void processPopupAction()
	  {
		bool @bool = false;
		if (this.commandButton is JCommandButton)
		{
		  @bool = ((JCommandButton)this.commandButton).PopupModel.PopupShowing;
		}
		PopupPanelManager.defaultManager().hidePopups(this.commandButton);
		if (!(this.commandButton is JCommandButton))
		{
		  return;
		}
		if (@bool)
		{
		  return;
		}
		JCommandButton jCommandButton = (JCommandButton)this.commandButton;
		PopupPanelCallback popupPanelCallback = jCommandButton.PopupCallback;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.pushingpixels.flamingo.api.common.popup.JPopupPanel popupPanel = (popupPanelCallback != null) ? popupPanelCallback.getPopupPanel(jCommandButton) : null;
		JPopupPanel popupPanel = (popupPanelCallback != null) ? popupPanelCallback.getPopupPanel(jCommandButton) : null;
		if (jPopupPanel != null)
		{
		  jPopupPanel.applyComponentOrientation(jCommandButton.ComponentOrientation);
		  SwingUtilities.invokeLater(() =>
		  {
		  if (CostOSRibbonApplicationMenuButtonUI.this.commandButton == null || popupPanel == null)
		  {
			return;
		  }
		  if (!CostOSRibbonApplicationMenuButtonUI.this.commandButton.Showing)
		  {
			return;
		  }
		  popupPanel.doLayout();
		  int i = 0;
		  int j = 0;
		  JPopupPanel.PopupPanelCustomizer popupPanelCustomizer = popupPanel.Customizer;
		  bool @bool = CostOSRibbonApplicationMenuButtonUI.this.commandButton.ComponentOrientation.LeftToRight;
		  Dimension dimension = popupPanel.PreferredSize;
		  if (popupPanelCustomizer == null)
		  {
			switch (CostOSRibbonApplicationMenuButtonUI.null.$SwitchMap$org$pushingpixels$flamingo$api$common$JCommandButton$CommandButtonPopupOrientationKind[((JCommandButton)CostOSRibbonApplicationMenuButtonUI.this.commandButton).PopupOrientationKind.ordinal()])
			{
			  case 1:
				if (@bool)
				{
				  i = (this.this$0.commandButton.LocationOnScreen).x;
				}
				else
				{
				  i = (this.this$0.commandButton.LocationOnScreen).x + CostOSRibbonApplicationMenuButtonUI.this.commandButton.Width - dimension.width;
				}
				j = (this.this$0.commandButton.LocationOnScreen).y + (this.this$0.commandButton.Size).height;
				break;
			  case 2:
				if (@bool)
				{
				  i = (this.this$0.commandButton.LocationOnScreen).x + CostOSRibbonApplicationMenuButtonUI.this.commandButton.Width;
				}
				else
				{
				  i = (this.this$0.commandButton.LocationOnScreen).x - dimension.width;
				}
				j = (this.this$0.commandButton.LocationOnScreen).y + (this.this$0.LayoutInfo).popupClickArea.y;
				break;
			}
		  }
		  else
		  {
			Rectangle rectangle1 = popupPanelCustomizer.ScreenBounds;
			i = rectangle1.x;
			j = rectangle1.y;
		  }
		  Rectangle rectangle = CostOSRibbonApplicationMenuButtonUI.this.commandButton.GraphicsConfiguration.Bounds;
		  int k = dimension.width;
		  int m = dimension.height;
		  if (k > rectangle.width || m > rectangle.height)
		  {
			k = Math.Min(k, rectangle.width);
			m = Math.Min(m, rectangle.height);
			dimension = new Dimension(k, m);
			popupPanel.PreferredSize = dimension;
			popupPanel.Size = dimension;
			popupPanel.doLayout();
		  }
		  if (i + k > rectangle.x + rectangle.width)
		  {
			i = rectangle.x + rectangle.width - k;
		  }
		  if (j + m > rectangle.y + rectangle.height)
		  {
			j = rectangle.y + rectangle.height - m;
		  }
		  if (popupPanelCustomizer != null)
		  {
			Rectangle rectangle1 = popupPanelCustomizer.ScreenBounds;
			i = rectangle1.x;
			j = rectangle1.y;
			popupPanel.PreferredSize = new Dimension(rectangle1.width, rectangle1.height);
		  }
		  Popup popup = PopupFactory.SharedInstance.getPopup(CostOSRibbonApplicationMenuButtonUI.this.commandButton, popupPanel, i, j);
		  PopupPanelManager.defaultManager().addPopup(CostOSRibbonApplicationMenuButtonUI.this.commandButton, popup, popupPanel);
		  });
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSRibbonApplicationMenuButtonUI.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
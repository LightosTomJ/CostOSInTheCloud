using System;

namespace Desktop.common.nomitech.common.laf
{
	using JideButton = com.jidesoft.swing.JideButton;
	using UISplitButton = nomitech.common.ui.UISplitButton;
	using ImageUtils = nomitech.common.util.ImageUtils;
	using BaseRibbon = nomitech.costos.ribbon.BaseRibbon;
	using CommandButtonDisplayState = org.pushingpixels.flamingo.api.common.CommandButtonDisplayState;
	using JCommandButton = org.pushingpixels.flamingo.api.common.JCommandButton;
	using JScrollablePanel = org.pushingpixels.flamingo.api.common.JScrollablePanel;
	using JPopupPanel = org.pushingpixels.flamingo.api.common.popup.JPopupPanel;
	using PopupPanelManager = org.pushingpixels.flamingo.api.common.popup.PopupPanelManager;
	using AbstractRibbonBand = org.pushingpixels.flamingo.api.ribbon.AbstractRibbonBand;
	using JRibbon = org.pushingpixels.flamingo.api.ribbon.JRibbon;
	using RibbonContextualTaskGroup = org.pushingpixels.flamingo.api.ribbon.RibbonContextualTaskGroup;
	using RibbonTask = org.pushingpixels.flamingo.api.ribbon.RibbonTask;
	using BasicRibbonUI = org.pushingpixels.flamingo.@internal.ui.ribbon.BasicRibbonUI;
	using JRibbonTaskToggleButton = org.pushingpixels.flamingo.@internal.ui.ribbon.JRibbonTaskToggleButton;
	using RibbonBandUI = org.pushingpixels.flamingo.@internal.ui.ribbon.RibbonBandUI;
	using JRibbonApplicationMenuButton = org.pushingpixels.flamingo.@internal.ui.ribbon.appmenu.JRibbonApplicationMenuButton;
	using FlamingoUtilities = org.pushingpixels.flamingo.@internal.utils.FlamingoUtilities;

	public class CostOSRibbonUI : BasicRibbonUI
	{
	  protected internal static readonly Color background = CostOSWindowsLookAndFeel.ribbonBackground;

	  protected internal static readonly Color borderColor = CostOSWindowsLookAndFeel.ribbonBorderColor;

	  protected internal static readonly Color taskAreaBg1 = CostOSWindowsLookAndFeel.ribbonTaksAreaBackground;

	  protected internal static readonly Color taskAreaBg2 = taskAreaBg1;

	  protected internal static readonly Color taskAreaBg3 = taskAreaBg1;

	  protected internal static readonly Color taskAreaBg4 = taskAreaBg1;

	  protected internal static readonly Color gray = taskAreaBg1;

	  protected internal static readonly Color gray_0 = taskAreaBg1;

	  protected internal static readonly Color gray_110 = taskAreaBg1;

	  protected internal static readonly Color gray2 = taskAreaBg1;

	  protected internal static readonly Color gray3 = taskAreaBg1;

	  protected internal static readonly Color black_69 = taskAreaBg1;

	  protected internal static readonly Color black_48 = taskAreaBg1;

	  protected internal static readonly Color black_0 = taskAreaBg1;

	  protected internal BufferedImage taskBackgroundCache;

	  protected internal int tabSpacing = 1;

	  protected internal Image ribbonArtImg;

	  protected internal Image ribbonBackstageArtImg;

	  private bool s_backstageShown = false;

	  private JComponent o_trailingButton = null;

	  private JComponent o_searchButton = null;

	  private ImageIcon imgcIcon = null;

	  public virtual bool BackstageShown
	  {
		  set
		  {
			this.s_backstageShown = value;
			if (value)
			{
			  this.applicationMenuButton.Visible = false;
			  this.taskBarPanel.Visible = false;
			  this.bandScrollablePanel.Visible = false;
			  this.taskToggleButtonsScrollablePanel.Visible = false;
			  if (this.o_searchButton != null)
			  {
				this.o_searchButton.Visible = false;
			  }
			  if (this.o_trailingButton != null)
			  {
				this.o_trailingButton.Foreground = CostOSWindowsLookAndFeel.ribbonCommandButtonForegroundColor;
			  }
			}
			else
			{
			  this.applicationMenuButton.Visible = true;
			  this.taskBarPanel.Visible = true;
			  this.bandScrollablePanel.Visible = true;
			  this.taskToggleButtonsScrollablePanel.Visible = true;
			  if (this.o_searchButton != null)
			  {
				this.o_searchButton.Visible = true;
			  }
			  if (this.o_trailingButton != null)
			  {
				this.o_trailingButton.Foreground = CostOSWindowsLookAndFeel.ribbonTaskTitleTextForegroundColor;
			  }
			}
			CostOSRootPaneUI costOSRootPaneUI = (CostOSRootPaneUI)CostOSRootPaneUI.Resolver.MainFrame.RootPane.UI;
			((CostOSTitlePane)costOSRootPaneUI.TitlePane).UpButtons = value;
		  }
	  }

	  public virtual bool BackstageShowing
	  {
		  get
		  {
			  return this.s_backstageShown;
		  }
	  }

	  public static CostOSRibbonUI Instance
	  {
		  get
		  {
			  return (CostOSRibbonUI)CostOSRootPaneUI.Resolver.Ribbon.UI;
		  }
	  }

	  public static ComponentUI createUI(JComponent paramJComponent)
	  {
		  return new CostOSRibbonUI();
	  }

	  protected internal virtual void installDefaults()
	  {
		base.installDefaults();
		this.ribbon.Opaque = false;
		this.ribbonArtImg = ((ImageIcon)UIManager.getIcon("Ribbon.artIcon")).Image;
		this.ribbonBackstageArtImg = ((ImageIcon)UIManager.getIcon("Ribbon.artBackstageIcon")).Image;
	  }

	  protected internal virtual void installComponents()
	  {
		base.installComponents();
		if (this.taskBarPanel != null)
		{
		  this.ribbon.remove(this.taskBarPanel);
		}
		this.taskBarPanel = new TaskbarPanel(this);
		this.taskBarPanel.Name = "JRibbon Task Bar";
		this.taskBarPanel.Layout = createTaskbarLayoutManager();
		this.ribbon.add(this.taskBarPanel);
		this.bandScrollablePanel.Opaque = false;
		foreach (Component component in this.bandScrollablePanel.Components)
		{
		  if (component is JComponent)
		  {
			((JComponent)component).Opaque = false;
		  }
		}
		this.taskToggleButtonsScrollablePanel.Opaque = false;
		foreach (Component component in this.taskToggleButtonsScrollablePanel.Components)
		{
		  if (component is JComponent)
		  {
			((JComponent)component).Opaque = false;
		  }
		}
	  }

	  protected internal virtual void uninstallComponents()
	  {
		if (this.taskBarPanel != null)
		{
		  this.ribbon.remove(this.taskBarPanel);
		  this.taskBarPanel = null;
		}
		foreach (Component component in this.bandScrollablePanel.Components)
		{
		  if (component is JComponent)
		  {
			JComponent jComponent = (JComponent)component;
			foreach (KeyListener keyListener in jComponent.KeyListeners)
			{
			  jComponent.removeKeyListener(keyListener);
			}
		  }
		}
		foreach (Component component in this.taskToggleButtonsScrollablePanel.Components)
		{
		  if (component is JComponent)
		  {
			JComponent jComponent = (JComponent)component;
			foreach (KeyListener keyListener in jComponent.KeyListeners)
			{
			  jComponent.removeKeyListener(keyListener);
			}
		  }
		}
		base.uninstallComponents();
	  }

	  protected internal virtual LayoutManager createTaskbarLayoutManager()
	  {
		  return new TaskbarLayout(this, null);
	  }

	  protected internal virtual BasicRibbonUI.BandHostPanel createBandHostPanel()
	  {
		  return new OfficeBandHostPanel(this);
	  }

	  protected internal virtual BasicRibbonUI.TaskToggleButtonsHostPanel createTaskToggleButtonsHostPanel()
	  {
		  return new OfficeTaskToggleButtonsHostPanel(this);
	  }

	  public virtual int TaskbarHeight
	  {
		  get
		  {
			  return 28;
		  }
	  }

	  public virtual void paint(Graphics paramGraphics, JComponent paramJComponent)
	  {
		paintBackground(paramGraphics);
		Insets insets = paramJComponent.Insets;
		int i = TaskToggleButtonHeight;
		if (!UsingTitlePane)
		{
		  i += TaskbarHeight;
		}
		paintTaskArea(paramGraphics, 0, insets.top + i - 1, paramJComponent.Width, paramJComponent.Height - i - insets.top);
	  }

	  protected internal virtual void paintBackground(Graphics paramGraphics)
	  {
		int i = this.ribbon.Width;
		Graphics2D graphics2D = (Graphics2D)paramGraphics;
		int j = TaskbarHeight + (this.ribbon.Insets).top - 1;
		if (!this.s_backstageShown)
		{
		  graphics2D.Color = background;
		  graphics2D.fillRect(0, j, this.ribbon.Width, this.ribbon.Height - j - 1);
		  int k = i - this.ribbonArtImg.getWidth(null);
		  int m = j;
		  int n = k + this.ribbonArtImg.getWidth(null);
		  int i1 = this.ribbonArtImg.getHeight(null) - 4;
		  sbyte b = 0;
		  int i2 = this.ribbonArtImg.getWidth(null);
		  int i3 = j;
		  int i4 = this.ribbonArtImg.getHeight(null) - 3;
		  graphics2D.drawImage(this.ribbonArtImg, k, m, n, i1, b, i3, i2, i4, null);
		  if (CostOSWindowsLookAndFeel.ThemeName.Equals("white") || CostOSWindowsLookAndFeel.ThemeName.Equals("green"))
		  {
			graphics2D.Color = CostOSWindowsLookAndFeel.ribbonBorderColor;
		  }
		  else
		  {
			graphics2D.Color = background;
		  }
		  int i5 = j + 22;
		  graphics2D.drawLine(0, i5, this.ribbon.Width, i5);
		  graphics2D.Color = CostOSWindowsLookAndFeel.ribbonBorderColor;
		  if (this.ribbon.Height > i5 + 10)
		  {
			graphics2D.fillRect(0, this.ribbon.Height - 1, this.ribbon.Width, 5);
		  }
		}
		else
		{
		  int k = this.ribbon.Height - j - 1;
		  int m = CostOSRibbonApplicationMenuPopupPanel.FirstLevelMenuWidth;
		  paramGraphics.Color = CostOSWindowsLookAndFeel.applicationButtonColor;
		  paramGraphics.fillRect(0, 0, m, k);
		  int n = i - this.ribbonBackstageArtImg.getWidth(null);
		  int i1 = j;
		  int i2 = n + this.ribbonBackstageArtImg.getWidth(null);
		  int i3 = this.ribbonBackstageArtImg.getHeight(null) - 4;
		  sbyte b = 0;
		  int i4 = this.ribbonBackstageArtImg.getWidth(null);
		  int i5 = j;
		  int i6 = this.ribbonBackstageArtImg.getHeight(null) - 3;
		  graphics2D.drawImage(this.ribbonBackstageArtImg, n, i1, i2, i3, b, i5, i4, i6, null);
		}
	  }

	  protected internal virtual void paintTaskArea(Graphics paramGraphics, int paramInt1, int paramInt2, int paramInt3, int paramInt4)
	  {
		Graphics2D graphics2D = (Graphics2D)paramGraphics;
		if (this.taskBackgroundCache == null || paramInt3 != this.taskBackgroundCache.Width || paramInt4 != this.taskBackgroundCache.Height)
		{
		  this.taskBackgroundCache = graphics2D.DeviceConfiguration.createCompatibleImage(paramInt3, paramInt4, 3);
		  Graphics2D graphics2D1 = this.taskBackgroundCache.createGraphics();
		  drawTaskAreaGradient(graphics2D1, paramInt3, paramInt4);
		  graphics2D1.dispose();
		}
		graphics2D.drawImage(this.taskBackgroundCache, paramInt1, paramInt2, null);
	  }

	  protected internal static void drawTaskAreaGradient(Graphics2D paramGraphics2D, int paramInt1, int paramInt2)
	  {
		paramGraphics2D.Color = CostOSWindowsLookAndFeel.ribbonTaksAreaBackground;
		paramGraphics2D.fillRect(0, 1, paramInt1, paramInt2);
	  }

	  protected internal virtual LayoutManager createLayoutManager()
	  {
		  return new RibbonLayout(this, null);
	  }

	  protected internal virtual void syncRibbonState()
	  {
		BasicRibbonUI.BandHostPanel bandHostPanel = (BasicRibbonUI.BandHostPanel)this.bandScrollablePanel.View;
		bandHostPanel.removeAll();
		BasicRibbonUI.TaskToggleButtonsHostPanel taskToggleButtonsHostPanel = (BasicRibbonUI.TaskToggleButtonsHostPanel)this.taskToggleButtonsScrollablePanel.View;
		taskToggleButtonsHostPanel.removeAll();
		if (this.o_searchButton != null)
		{
		  this.ribbon.remove(this.o_searchButton);
		  this.o_searchButton = null;
		}
		if (this.o_trailingButton != null)
		{
		  this.ribbon.remove(this.o_trailingButton);
		  this.o_trailingButton = null;
		}
		if (this.closeButton != null)
		{
		  this.ribbon.remove(this.closeButton);
		  this.closeButton = null;
		}
		if (this.helpButton != null)
		{
		  this.ribbon.remove(this.helpButton);
		  this.helpButton = null;
		}
		System.Collections.IList list = CurrentlyShownRibbonTasks;
		RibbonTask ribbonTask = this.ribbon.SelectedTask;
		foreach (RibbonTask ribbonTask1 in list)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.pushingpixels.flamingo.internal.ui.ribbon.JRibbonTaskToggleButton taskToggleButton = new org.pushingpixels.flamingo.internal.ui.ribbon.JRibbonTaskToggleButton(ribbonTask1);
		  JRibbonTaskToggleButton taskToggleButton = new JRibbonTaskToggleButton(ribbonTask1);
		  jRibbonTaskToggleButton1.KeyTip = ribbonTask1.KeyTip;
		  jRibbonTaskToggleButton1.addActionListener(new ActionListenerAnonymousInnerClass(this, list, taskToggleButton));
		  jRibbonTaskToggleButton1.addMouseListener(new MouseAdapterAnonymousInnerClass(this));
		  if (ribbonTask1.ContextualGroup != null)
		  {
			jRibbonTaskToggleButton1.ContextualGroupHueColor = ribbonTask1.ContextualGroup.HueColor;
		  }
		  jRibbonTaskToggleButton1.putClientProperty("flamingo.internal.commandButton.ui.dontDisposePopups", true);
		  this.taskToggleButtonGroup.add(jRibbonTaskToggleButton1);
		  taskToggleButtonsHostPanel.add(jRibbonTaskToggleButton1);
		  this.taskToggleButtons.put(ribbonTask1, jRibbonTaskToggleButton1);
		}
		JRibbonTaskToggleButton jRibbonTaskToggleButton = (JRibbonTaskToggleButton)this.taskToggleButtons.get(ribbonTask);
		if (jRibbonTaskToggleButton != null)
		{
		  jRibbonTaskToggleButton.ActionModel.Selected = true;
		}
		sbyte b;
		for (b = 0; b < this.ribbon.TaskCount; b++)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.pushingpixels.flamingo.api.ribbon.RibbonTask task = this.ribbon.getTask(b);
		  RibbonTask task = this.ribbon.getTask(b);
		  foreach (AbstractRibbonBand abstractRibbonBand in ribbonTask1.Bands)
		  {
			bandHostPanel.add(abstractRibbonBand);
			abstractRibbonBand.Visible = (ribbonTask == ribbonTask1);
		  }
		}
		for (b = 0; b < this.ribbon.ContextualTaskGroupCount; b++)
		{
		  RibbonContextualTaskGroup ribbonContextualTaskGroup = this.ribbon.getContextualTaskGroup(b);
		  for (sbyte b1 = 0; b1 < ribbonContextualTaskGroup.TaskCount; b1++)
		  {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.pushingpixels.flamingo.api.ribbon.RibbonTask task = ribbonContextualTaskGroup.getTask(b1);
			RibbonTask task = ribbonContextualTaskGroup.getTask(b1);
			foreach (AbstractRibbonBand abstractRibbonBand in ribbonTask1.Bands)
			{
			  bandHostPanel.add(abstractRibbonBand);
			  abstractRibbonBand.Visible = (ribbonTask == ribbonTask1);
			}
		  }
		}
		ActionListener actionListener1 = ((BaseRibbon)this.ribbon).UserNameActionListener;
		if (actionListener1 != null && DatabaseDBUtil.Enterprise)
		{
		  this.o_trailingButton = new UISplitButton("");
		  if (DatabaseDBUtil.Loaded)
		  {
			((UISplitButton)this.o_trailingButton).Text = DatabaseDBUtil.Properties.UserAndRolesData.PrincipalsData.Name;
			((UISplitButton)this.o_trailingButton).VerticalTextPosition = 0;
			((UISplitButton)this.o_trailingButton).HorizontalTextPosition = 2;
			loadImageOfUser(DatabaseDBUtil.Properties.UserId);
			JPopupMenu jPopupMenu = new JPopupMenu();
			JMenuItem[] arrayOfJMenuItem = ((BaseRibbon)this.ribbon).UserMenuItems;
			foreach (JMenuItem jMenuItem in arrayOfJMenuItem)
			{
			  if (jMenuItem == null)
			  {
				jPopupMenu.addSeparator();
			  }
			  else
			  {
				jPopupMenu.add(jMenuItem);
			  }
			}
			((UISplitButton)this.o_trailingButton).Menu = jPopupMenu;
		  }
		  ((UISplitButton)this.o_trailingButton).ButtonStyle = 3;
		  ((UISplitButton)this.o_trailingButton).Foreground = CostOSWindowsLookAndFeel.ribbonTaskTitleTextForegroundColor;
		  this.ribbon.add(this.o_trailingButton);
		  this.o_searchButton = ((BaseRibbon)this.ribbon).SearchButton;
		  this.o_searchButton.PreferredSize = new Dimension((int)this.o_searchButton.PreferredSize.Width, TaskToggleButtonHeight - 1);
		  this.o_searchButton.MaximumSize = new Dimension((int)this.o_searchButton.PreferredSize.Width, TaskToggleButtonHeight - 1);
		  this.ribbon.add(this.o_searchButton);
		}
		ActionListener actionListener2 = this.ribbon.CloseActionListener;
		if (actionListener2 != null)
		{
		  this.closeButton = new JCommandButton("", this.ribbon.CloseIcon);
		  this.closeButton.DisplayState = CommandButtonDisplayState.SMALL;
		  this.closeButton.CommandButtonKind = JCommandButton.CommandButtonKind.ACTION_ONLY;
		  this.closeButton.ActionModel.addActionListener(actionListener2);
		  this.ribbon.add(this.closeButton);
		}
		ActionListener actionListener3 = this.ribbon.HelpActionListener;
		if (actionListener3 != null)
		{
		  this.helpButton = new JCommandButton("", this.ribbon.HelpIcon);
		  this.helpButton.DisplayState = CommandButtonDisplayState.SMALL;
		  this.helpButton.CommandButtonKind = JCommandButton.CommandButtonKind.ACTION_ONLY;
		  this.helpButton.ActionModel.addActionListener(actionListener3);
		  this.ribbon.add(this.helpButton);
		}
		this.ribbon.revalidate();
		this.ribbon.repaint();
	  }

	  private class ActionListenerAnonymousInnerClass : ActionListener
	  {
		  private readonly CostOSRibbonUI outerInstance;

		  private System.Collections.IList list;
		  private JRibbonTaskToggleButton taskToggleButton;

		  public ActionListenerAnonymousInnerClass(CostOSRibbonUI outerInstance, System.Collections.IList list, JRibbonTaskToggleButton taskToggleButton)
		  {
			  this.outerInstance = outerInstance;
			  this.list = list;
			  this.taskToggleButton = taskToggleButton;
		  }

		  public void actionPerformed(ActionEvent param1ActionEvent)
		  {
			  SwingUtilities.invokeLater(() =>
			  {
			CostOSRibbonUI.null.this.this$0.scrollAndRevealTaskToggleButton(taskToggleButton);
			CostOSRibbonUI.null.this.this$0.ribbon.SelectedTask = task;
			if (CostOSRibbonUI.null.this.this$0.ribbon.Minimized)
			{
			  if (true.Equals(CostOSRibbonUI.null.this.this$0.ribbon.getClientProperty("ribbon.internal.justMinimized")))
			  {
				CostOSRibbonUI.null.this.this$0.ribbon.putClientProperty("ribbon.internal.justMinimized", null);
				return;
			  }
			  System.Collections.IList list = PopupPanelManager.defaultManager().ShownPath;
			  if (list.size() > 0)
			  {
				foreach (PopupPanelManager.PopupInfo popupInfo in list)
				{
				  if (popupInfo.PopupOriginator == taskToggleButton)
				  {
					PopupPanelManager.defaultManager().hidePopups(null);
					return;
				  }
				}
			  }
			  PopupPanelManager.defaultManager().hidePopups(null);
			  CostOSRibbonUI.null.this.this$0.ribbon.remove(CostOSRibbonUI.null.this.this$0.bandScrollablePanel);
			  int i = (((BasicRibbonUI.BandHostPanel)this.this$1.this$0.bandScrollablePanel.View).PreferredSize).height;
			  Insets insets = CostOSRibbonUI.null.this.this$0.ribbon.Insets;
			  i += insets.top + insets.bottom;
			  AbstractRibbonBand abstractRibbonBand = (CostOSRibbonUI.null.this.this$0.ribbon.SelectedTask.BandCount > 0) ? CostOSRibbonUI.null.this.this$0.ribbon.SelectedTask.getBand(0) : null;
			  if (abstractRibbonBand != null)
			  {
				Insets insets1 = abstractRibbonBand.Insets;
				i += insets1.top + insets1.bottom;
			  }
			  CostOSRibbonUI.OfficeBandHostPopupPanel officeBandHostPopupPanel = new CostOSRibbonUI.OfficeBandHostPopupPanel(CostOSRibbonUI.null.this.this$0.bandScrollablePanel, new Dimension(CostOSRibbonUI.null.this.this$0.ribbon.Width, i));
			  int j = (this.this$1.this$0.ribbon.LocationOnScreen).x;
			  int k = (this.this$1.this$0.ribbon.LocationOnScreen).y + CostOSRibbonUI.null.this.this$0.ribbon.Height;
			  Rectangle rectangle = CostOSRibbonUI.null.this.this$0.ribbon.GraphicsConfiguration.Bounds;
			  int m = (officeBandHostPopupPanel.PreferredSize).width;
			  if (j + m > rectangle.x + rectangle.width)
			  {
				j = rectangle.x + rectangle.width - m;
			  }
			  int n = (officeBandHostPopupPanel.PreferredSize).height;
			  if (k + n > rectangle.y + rectangle.height)
			  {
				k = rectangle.y + rectangle.height - n;
			  }
			  officeBandHostPopupPanel.PreferredSize = new Dimension(CostOSRibbonUI.null.this.this$0.ribbon.Width, i);
			  Popup popup = PopupFactory.SharedInstance.getPopup(taskToggleButton, officeBandHostPopupPanel, j, k);
			  PopupPanelManager.PopupListener popupListener = new PopupListenerAnonymousInnerClass(this);
			  PopupPanelManager.defaultManager().addPopupListener(popupListener);
			  PopupPanelManager.defaultManager().addPopup(taskToggleButton, popup, officeBandHostPopupPanel);
			}
			  });
		  }

		  private class PopupListenerAnonymousInnerClass : PopupPanelManager.PopupListener
		  {
			  private readonly ActionListenerAnonymousInnerClass outerInstance;

			  public PopupListenerAnonymousInnerClass(ActionListenerAnonymousInnerClass outerInstance)
			  {
				  this.outerInstance = outerInstance;
			  }

			  public void popupShown(PopupPanelManager.PopupEvent param3PopupEvent)
			  {
				JComponent jComponent = param3PopupEvent.PopupOriginator;
				if (jComponent is JRibbonTaskToggleButton)
				{
				  CostOSRibbonUI.null.this.this$0.bandScrollablePanel.doLayout();
				  CostOSRibbonUI.null.this.this$0.bandScrollablePanel.repaint();
				}
			  }

			  public void popupHidden(PopupPanelManager.PopupEvent param3PopupEvent)
			  {
				JComponent jComponent = param3PopupEvent.PopupOriginator;
				if (jComponent is JRibbonTaskToggleButton)
				{
				  CostOSRibbonUI.null.this.this$0.ribbon.add(CostOSRibbonUI.null.this.this$0.bandScrollablePanel);
				  PopupPanelManager.defaultManager().removePopupListener(this);
				  CostOSRibbonUI.null.this.this$0.ribbon.revalidate();
				  CostOSRibbonUI.null.this.this$0.ribbon.doLayout();
				  CostOSRibbonUI.null.this.this$0.ribbon.repaint();
				}
			  }
		  }
	  }

	  private class MouseAdapterAnonymousInnerClass : MouseAdapter
	  {
		  private readonly CostOSRibbonUI outerInstance;

		  public MouseAdapterAnonymousInnerClass(CostOSRibbonUI outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public void mouseClicked(MouseEvent param1MouseEvent)
		  {
			if (outerInstance.ribbon.SelectedTask == task && param1MouseEvent.ClickCount == 2)
			{
			  bool @bool = outerInstance.ribbon.Minimized;
			  outerInstance.ribbon.Minimized = !@bool;
			  if (!@bool)
			  {
				outerInstance.ribbon.putClientProperty("ribbon.internal.justMinimized", true);
			  }
			}
		  }
	  }

	  public virtual void refreshTrailingButton()
	  {
		if (this.o_trailingButton == null)
		{
		  return;
		}
		if (DatabaseDBUtil.Loaded)
		{
		  this.imgcIcon = null;
		  ((JideButton)this.o_trailingButton).Text = DatabaseDBUtil.Properties.UserAndRolesData.PrincipalsData.Name;
		  loadImageOfUser(DatabaseDBUtil.Properties.UserId);
		}
	  }

	  private void loadImageOfUser(string paramString)
	  {
		string str = DatabaseDBUtil.Properties.ConnectionHost;
		if (this.imgcIcon == null && !string.ReferenceEquals(str, null))
		{
		  if (DatabaseDBUtil.Enterprise)
		  {
			if (!str.StartsWith("http://", StringComparison.Ordinal) && !str.StartsWith("https://", StringComparison.Ordinal))
			{
			  str = "http://" + str;
			}
			string str1 = str + "/ces/pictures/showAvatar?userId=" + DatabaseDBUtil.Properties.UserId;
			try
			{
			  BufferedImage bufferedImage1 = ImageIO.read((new URL(str1)).openStream());
			  BufferedImage bufferedImage2 = ImageUtils.resizeImage(bufferedImage1, 1, 12, 12);
			  this.imgcIcon = new ImageIcon(bufferedImage2);
			}
			catch (Exception)
			{
			  this.imgcIcon = new ImageIcon();
			}
		  }
		  else
		  {
			this.imgcIcon = new ImageIcon();
		  }
		}
		if (this.imgcIcon != null)
		{
		  ((JideButton)this.o_trailingButton).Icon = this.imgcIcon;
		}
	  }

	  protected internal class OfficeBandHostPopupPanel : JPopupPanel
	  {
		public OfficeBandHostPopupPanel(Component param1Component, Dimension param1Dimension)
		{
		  Layout = new BorderLayout();
		  add(param1Component, "Center");
		  PreferredSize = param1Dimension;
		  Size = param1Dimension;
		  Border = BorderFactory.createEmptyBorder();
		}

		public virtual void paint(Graphics param1Graphics)
		{
		  base.paint(param1Graphics);
		  param1Graphics.Color = CostOSWindowsLookAndFeel.ribbonBorderColor;
		  param1Graphics.fillRect(0, Height - 1, Width, Height - 1);
		}
	  }

	  private class RibbonLayout : LayoutManager
	  {
		  private readonly CostOSRibbonUI outerInstance;

		internal RibbonLayout(CostOSRibbonUI outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void addLayoutComponent(string param1String, Component param1Component)
		{
		}

		public virtual void removeLayoutComponent(Component param1Component)
		{
		}

		public virtual Dimension preferredLayoutSize(Container param1Container)
		{
		  Insets insets = param1Container.Insets;
		  int i = 0;
		  bool @bool = outerInstance.ribbon.Minimized;
		  if (!@bool && outerInstance.ribbon.TaskCount > 0)
		  {
			RibbonTask ribbonTask = outerInstance.ribbon.SelectedTask;
			foreach (AbstractRibbonBand abstractRibbonBand in ribbonTask.Bands)
			{
			  int m = (abstractRibbonBand.PreferredSize).height;
			  Insets insets1 = abstractRibbonBand.Insets;
			  i = Math.Max(i, m + insets1.top + insets1.bottom);
			}
		  }
		  int j = outerInstance.TaskToggleButtonHeight;
		  if (!outerInstance.UsingTitlePane)
		  {
			j += outerInstance.TaskbarHeight;
		  }
		  int k = i + j + insets.top + insets.bottom;
		  return new Dimension(param1Container.Width, k);
		}

		public virtual Dimension minimumLayoutSize(Container param1Container)
		{
		  Insets insets = param1Container.Insets;
		  int i = 0;
		  int j = 0;
		  int k = outerInstance.BandGap;
		  int m = outerInstance.TaskToggleButtonHeight;
		  if (!outerInstance.UsingTitlePane)
		  {
			m += outerInstance.TaskbarHeight;
		  }
		  if (outerInstance.ribbon.TaskCount > 0)
		  {
			bool @bool = outerInstance.ribbon.Minimized;
			RibbonTask ribbonTask = outerInstance.ribbon.SelectedTask;
			foreach (AbstractRibbonBand abstractRibbonBand in ribbonTask.Bands)
			{
			  int n = (abstractRibbonBand.MinimumSize).height;
			  Insets insets1 = abstractRibbonBand.Insets;
			  RibbonBandUI ribbonBandUI = abstractRibbonBand.UI;
			  i += ribbonBandUI.PreferredCollapsedWidth;
			  if (!@bool)
			  {
				j = Math.Max(j, n + insets1.top + insets1.bottom);
			  }
			}
			i += k * (ribbonTask.BandCount - 1);
		  }
		  else
		  {
			i = 50;
		  }
		  return new Dimension(i, j + m + insets.top + insets.bottom);
		}

		public virtual void layoutContainer(Container param1Container)
		{
		  Insets insets = param1Container.Insets;
		  int i = outerInstance.TabButtonGap;
		  bool bool1 = outerInstance.ribbon.ComponentOrientation.LeftToRight;
		  int j = param1Container.Width;
		  int k = outerInstance.TaskbarHeight;
		  int m = insets.top;
		  bool bool2 = outerInstance.UsingTitlePane;
		  if (!bool2)
		  {
			outerInstance.taskBarPanel.removeAll();
			foreach (Component component in outerInstance.ribbon.TaskbarComponents)
			{
			  outerInstance.taskBarPanel.add(component);
			}
			outerInstance.taskBarPanel.setBounds(insets.left, insets.top, j - insets.left - insets.right, k);
			m += k;
		  }
		  else
		  {
			outerInstance.taskBarPanel.setBounds(0, 0, 0, 0);
		  }
		  Font font = outerInstance.ribbon.Font;
		  if (font == null)
		  {
			font = new Font("SansSerif", 0, 12);
			outerInstance.ribbon.Font = font;
		  }
		  FontMetrics fontMetrics = outerInstance.ribbon.getFontMetrics(font);
		  int n = fontMetrics.stringWidth(CostOSRibbonApplicationMenuButtonUI.ApplicationMenuButtonText) + 24;
		  int i1;
		  for (i1 = 0; i1 < outerInstance.ribbon.TaskCount; i1++)
		  {
			RibbonTask ribbonTask = outerInstance.ribbon.getTask(i1);
			n += fontMetrics.stringWidth(ribbonTask.Title) + 32;
		  }
		  n += 12;
		  i1 = outerInstance.TaskToggleButtonHeight;
		  int i2 = bool1 ? insets.left : (j - insets.right);
		  int i3 = k + i1;
		  if (!bool2)
		  {
			outerInstance.applicationMenuButton.Visible = (outerInstance.ribbon.ApplicationMenu != null);
			if (outerInstance.ribbon.ApplicationMenu != null)
			{
			  if (bool1)
			  {
				outerInstance.applicationMenuButton.setBounds(-5, insets.top, i3 + 24, i3);
			  }
			  else
			  {
				outerInstance.applicationMenuButton.setBounds(i2 - i3, insets.top, i3, i3);
			  }
			}
		  }
		  else
		  {
			outerInstance.applicationMenuButton.Visible = false;
		  }
		  i2 = bool1 ? (i2 + 2) : (i2 - 2);
		  if (FlamingoUtilities.getApplicationMenuButton(SwingUtilities.getWindowAncestor(outerInstance.ribbon)) != null)
		  {
			i2 = bool1 ? (i2 + i3 + 15) : (i2 - i3);
		  }
		  if (outerInstance.o_trailingButton != null && outerInstance.helpButton == null)
		  {
			Dimension dimension = outerInstance.o_trailingButton.PreferredSize;
			if (bool1)
			{
			  outerInstance.o_trailingButton.setBounds(j - insets.right - dimension.width, m, dimension.width, dimension.height);
			}
			else
			{
			  outerInstance.o_trailingButton.setBounds(insets.left, m, dimension.width, dimension.height);
			}
			if (outerInstance.o_searchButton != null)
			{
			  Dimension dimension1 = outerInstance.o_searchButton.PreferredSize;
			  if (bool1)
			  {
				outerInstance.o_searchButton.setBounds(n, m, dimension1.width, dimension1.height);
			  }
			  else
			  {
				outerInstance.o_searchButton.setBounds(insets.left + dimension1.width, m, dimension1.width, dimension1.height);
			  }
			}
		  }
		  if (outerInstance.helpButton != null)
		  {
			Dimension dimension = outerInstance.helpButton.PreferredSize;
			if (bool1)
			{
			  outerInstance.helpButton.setBounds(j - insets.right - dimension.width, m, dimension.width, dimension.height);
			}
			else
			{
			  outerInstance.helpButton.setBounds(insets.left, m, dimension.width, dimension.height);
			}
			if (outerInstance.o_trailingButton != null)
			{
			  Dimension dimension1 = outerInstance.o_trailingButton.PreferredSize;
			  if (bool1)
			  {
				outerInstance.o_trailingButton.setBounds(j - insets.right * 2 - dimension1.width + dimension.width, m, dimension1.width, dimension1.height);
			  }
			  else
			  {
				outerInstance.o_trailingButton.setBounds(insets.left + dimension1.width, m, dimension1.width, dimension1.height);
			  }
			}
		  }
		  int i4 = 0;
		  if (bool1)
		  {
			i4 = (outerInstance.o_trailingButton != null) ? (outerInstance.o_trailingButton.X - i - i2) : (param1Container.Width - insets.right - i2);
			if (outerInstance.helpButton != null && outerInstance.o_trailingButton != null)
			{
			  i4 = outerInstance.o_trailingButton.X - i - i2;
			}
			if (outerInstance.o_searchButton != null && outerInstance.o_trailingButton != null)
			{
			  i4 = outerInstance.o_searchButton.X - i - i2;
			}
			outerInstance.taskToggleButtonsScrollablePanel.setBounds(i2, m, i4, i1);
		  }
		  else
		  {
			i4 = (outerInstance.helpButton != null) ? (i2 - i - outerInstance.helpButton.X - outerInstance.o_trailingButton.Width) : (i2 - insets.left);
			if (outerInstance.helpButton != null && outerInstance.o_trailingButton != null)
			{
			  i4 = i2 - i - outerInstance.o_trailingButton.X - outerInstance.o_trailingButton.Width - outerInstance.helpButton.X - outerInstance.helpButton.Width;
			}
			outerInstance.taskToggleButtonsScrollablePanel.setBounds(i2 - i4, m, i4, i1);
		  }
		  BasicRibbonUI.TaskToggleButtonsHostPanel taskToggleButtonsHostPanel = (BasicRibbonUI.TaskToggleButtonsHostPanel)outerInstance.taskToggleButtonsScrollablePanel.View;
		  int i5 = (taskToggleButtonsHostPanel.MinimumSize).width;
		  taskToggleButtonsHostPanel.PreferredSize = new Dimension(i5, (this.this$0.taskToggleButtonsScrollablePanel.Bounds).height);
		  outerInstance.taskToggleButtonsScrollablePanel.doLayout();
		  m += i1;
		  int i6 = i1;
		  if (!bool2)
		  {
			i6 += k;
		  }
		  if (outerInstance.bandScrollablePanel.Parent == outerInstance.ribbon)
		  {
			if (!outerInstance.ribbon.Minimized && outerInstance.ribbon.TaskCount > 0)
			{
			  Insets insets1 = (outerInstance.ribbon.SelectedTask.BandCount == 0) ? new Insets(0, 0, 0, 0) : outerInstance.ribbon.SelectedTask.getBand(0).Insets;
			  outerInstance.bandScrollablePanel.setBounds(1 + insets.left, m + insets1.top, param1Container.Width - 2 * insets.left - 2 * insets.right - 1, param1Container.Height - i6 - insets.top - insets.bottom - insets1.top - insets1.bottom);
			  BasicRibbonUI.BandHostPanel bandHostPanel = (BasicRibbonUI.BandHostPanel)outerInstance.bandScrollablePanel.View;
			  int i7 = (bandHostPanel.MinimumSize).width;
			  bandHostPanel.PreferredSize = new Dimension(i7, (this.this$0.bandScrollablePanel.Bounds).height);
			  outerInstance.bandScrollablePanel.doLayout();
			  bandHostPanel.doLayout();
			}
			else
			{
			  outerInstance.bandScrollablePanel.setBounds(0, 0, 0, 0);
			}
		  }
		}
	  }

	  protected internal class OfficeBandHostPanel : BasicRibbonUI.BandHostPanel
	  {
		  private readonly CostOSRibbonUI outerInstance;

		public OfficeBandHostPanel(CostOSRibbonUI outerInstance)
		{
			this.outerInstance = outerInstance;
			Opaque = false;
		}

		protected internal virtual void paintComponent(Graphics param1Graphics)
		{
		  param1Graphics.Color = CostOSWindowsLookAndFeel.ribbonTaksAreaBackground;
		  param1Graphics.fillRect(0, 0, (Bounds).width, (Bounds).height);
		  base.paintComponent(param1Graphics);
		}
	  }

	  protected internal class OfficeTaskToggleButtonsHostPanel : BasicRibbonUI.TaskToggleButtonsHostPanel
	  {
		  private readonly CostOSRibbonUI outerInstance;

		public OfficeTaskToggleButtonsHostPanel(CostOSRibbonUI outerInstance) : base(outerInstance)
		{
			this.outerInstance = outerInstance;
		  Opaque = false;
		}

		protected internal virtual void paintTaskOutlines(Graphics param1Graphics)
		{
		}

		protected internal virtual void paintContextualTaskGroupsOutlines(Graphics param1Graphics)
		{
		}
	  }

	  private class TaskbarLayout : LayoutManager
	  {
		  private readonly CostOSRibbonUI outerInstance;

		internal TaskbarLayout(CostOSRibbonUI outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void addLayoutComponent(string param1String, Component param1Component)
		{
		}

		public virtual void removeLayoutComponent(Component param1Component)
		{
		}

		public virtual Dimension preferredLayoutSize(Container param1Container)
		{
		  Insets insets = param1Container.Insets;
		  int i = 0;
		  int j = outerInstance.BandGap;
		  foreach (Component component in outerInstance.ribbon.TaskbarComponents)
		  {
			i += (component.PreferredSize).width;
			i += j;
		  }
		  return new Dimension(i + insets.left + insets.right, outerInstance.TaskbarHeight);
		}

		public virtual Dimension minimumLayoutSize(Container param1Container)
		{
			return preferredLayoutSize(param1Container);
		}

		public virtual void layoutContainer(Container param1Container)
		{
		  Insets insets = param1Container.Insets;
		  int i = outerInstance.BandGap;
		  int j = insets.left + 1 + outerInstance.applicationMenuButton.X + 32;
		  foreach (Component component in outerInstance.ribbon.TaskbarComponents)
		  {
			int k = (component.PreferredSize).width;
			component.setBounds(j, 2, k, param1Container.Height - insets.top - insets.bottom - 4);
			j += k + i;
		  }
		}
	  }

	  private class TaskbarPanel : JPanel
	  {
		  private readonly CostOSRibbonUI outerInstance;

		public TaskbarPanel(CostOSRibbonUI outerInstance)
		{
			this.outerInstance = outerInstance;
		  Opaque = false;
		  Border = BorderFactory.createEmptyBorder(1, 0, 1, 0);
		}

		protected internal virtual void paintComponent(Graphics param1Graphics)
		{
		  if (ComponentCount == 0)
		  {
			return;
		  }
		  int i = Width;
		  int j = 0;
		  for (sbyte b = 0; b < ComponentCount; b++)
		  {
			Component component = getComponent(b);
			i = Math.Min(i, component.X);
			j = Math.Max(j, component.X + component.Width);
		  }
		}

		public virtual Dimension PreferredSize
		{
			get
			{
			  Dimension dimension = base.PreferredSize;
			  return new Dimension(dimension.width + dimension.height / 2, dimension.height);
			}
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSRibbonUI.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
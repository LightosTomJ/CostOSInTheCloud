using System;
using System.Diagnostics;

namespace Desktop.common.nomitech.common.laf
{
	using OfficeLookAndFeelHelper = org.officelaf.OfficeLookAndFeelHelper;
	using SwingUtilities2 = sun.swing.SwingUtilities2;

	public class CostOSTitlePane : JComponent
	{
	  private static readonly Border handyEmptyBorder = new EmptyBorder(0, 0, 0, 0);

	  private const int IMAGE_HEIGHT = 16;

	  private const int IMAGE_WIDTH = 16;

	  private Image ribbonArtImg;

	  private Image ribbonBackstageArtImg;

	  private PropertyChangeListener propertyChangeListener;

	  private JMenuBar menuBar;

	  private Action closeAction;

	  private Action helpAction;

	  private Action iconifyAction;

	  private Action restoreAction;

	  private Action maximizeAction;

	  private JButton toggleButton;

	  private JButton iconifyButton;

	  private JButton closeButton;

	  private JButton helpButton;

	  private Icon maximizeIcon;

	  private Icon maximizeDownIcon;

	  private Icon maximizeOverIcon;

	  private Icon minimizeIcon;

	  private Icon minimizeDownIcon;

	  private Icon minimizeOverIcon;

	  private Image systemIcon;

	  private WindowListener windowListener;

	  private Window window;

	  private JRootPane rootPane;

	  private int buttonsWidth;

	  private int state;

	  private CostOSRootPaneUI rootPaneUI;

	  private Color inactiveBackground = UIManager.getColor("inactiveCaption");

	  private Color inactiveForeground = UIManager.getColor("inactiveCaptionText");

	  private Color inactiveShadow = UIManager.getColor("inactiveCaptionBorder");

	  private Color activeBackground = null;

	  private Color activeForeground = null;

	  private Color activeShadow = null;

	  public CostOSTitlePane(JRootPane paramJRootPane, CostOSRootPaneUI paramCostOSRootPaneUI)
	  {
		this.rootPane = paramJRootPane;
		this.rootPaneUI = paramCostOSRootPaneUI;
		this.state = -1;
		installSubcomponents();
		determineColors();
		installDefaults();
		Layout = createLayout();
		this.ribbonArtImg = ((ImageIcon)UIManager.getIcon("Ribbon.artIcon")).Image;
		this.ribbonArtImg.getHeight(paramJRootPane);
		this.ribbonBackstageArtImg = ((ImageIcon)UIManager.getIcon("Ribbon.artBackstageIcon")).Image;
		if (this.ribbonBackstageArtImg != null)
		{
		  this.ribbonBackstageArtImg.getHeight(paramJRootPane);
		}
		PreferredSize = new Dimension(100, 30);
	  }

	  private void uninstall()
	  {
		uninstallListeners();
		this.window = null;
		removeAll();
	  }

	  private void installListeners()
	  {
		if (this.window != null)
		{
		  this.windowListener = createWindowListener();
		  this.window.addWindowListener(this.windowListener);
		  this.propertyChangeListener = createWindowPropertyChangeListener();
		  this.window.addPropertyChangeListener(this.propertyChangeListener);
		}
	  }

	  private void uninstallListeners()
	  {
		if (this.window != null)
		{
		  this.window.removeWindowListener(this.windowListener);
		  this.window.removePropertyChangeListener(this.propertyChangeListener);
		}
	  }

	  private WindowListener createWindowListener()
	  {
		  return new WindowHandler(this, null);
	  }

	  private PropertyChangeListener createWindowPropertyChangeListener()
	  {
		  return new PropertyChangeHandler(this, null);
	  }

	  public virtual JRootPane RootPane
	  {
		  get
		  {
			  return this.rootPane;
		  }
	  }

	  private int WindowDecorationStyle
	  {
		  get
		  {
			  return RootPane.WindowDecorationStyle;
		  }
	  }

	  public virtual void addNotify()
	  {
		base.addNotify();
		uninstallListeners();
		this.window = SwingUtilities.getWindowAncestor(this);
		if (this.window != null)
		{
		  if (this.window is Frame)
		  {
			State = ((Frame)this.window).ExtendedState;
		  }
		  else
		  {
			State = 0;
		  }
		  Active = this.window.Active;
		  installListeners();
		  updateSystemIcon();
		}
	  }

	  public virtual void removeNotify()
	  {
		base.removeNotify();
		uninstallListeners();
		this.window = null;
	  }

	  private void installSubcomponents()
	  {
		int i = WindowDecorationStyle;
		if (i == 1)
		{
		  createActions();
		  this.menuBar = createMenuBar();
		  this.menuBar.Background = Color.RED;
		  createButtons();
		  add(this.helpButton);
		  add(this.iconifyButton);
		  add(this.toggleButton);
		  add(this.closeButton);
		}
		else if (i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7 || i == 8)
		{
		  createActions();
		  createButtons();
		  add(this.closeButton);
		}
	  }

	  private void determineColors()
	  {
		switch (WindowDecorationStyle)
		{
		  case 1:
			this.activeBackground = UIManager.getColor("activeCaption");
			this.activeForeground = UIManager.getColor("activeCaptionText");
			this.activeShadow = UIManager.getColor("activeCaptionBorder");
			return;
		  case 4:
			this.activeBackground = UIManager.getColor("OptionPane.errorDialog.titlePane.background");
			this.activeForeground = UIManager.getColor("OptionPane.errorDialog.titlePane.foreground");
			this.activeShadow = UIManager.getColor("OptionPane.errorDialog.titlePane.shadow");
			return;
		  case 5:
		  case 6:
		  case 7:
			this.activeBackground = UIManager.getColor("OptionPane.questionDialog.titlePane.background");
			this.activeForeground = UIManager.getColor("OptionPane.questionDialog.titlePane.foreground");
			this.activeShadow = UIManager.getColor("OptionPane.questionDialog.titlePane.shadow");
			return;
		  case 8:
			this.activeBackground = UIManager.getColor("OptionPane.warningDialog.titlePane.background");
			this.activeForeground = UIManager.getColor("OptionPane.warningDialog.titlePane.foreground");
			this.activeShadow = UIManager.getColor("OptionPane.warningDialog.titlePane.shadow");
			return;
		}
		this.activeBackground = UIManager.getColor("activeCaption");
		this.activeForeground = UIManager.getColor("activeCaptionText");
		this.activeShadow = UIManager.getColor("activeCaptionBorder");
	  }

	  private void installDefaults()
	  {
		  Font = OfficeLookAndFeelHelper.getSystemFont(0, 13.0F);
	  }

	  private void uninstallDefaults()
	  {
	  }

	  protected internal virtual JMenuBar createMenuBar()
	  {
		this.menuBar = new SystemMenuBar(this, null);
		this.menuBar.Focusable = false;
		this.menuBar.BorderPainted = true;
		this.menuBar.add(createMenu());
		return this.menuBar;
	  }

	  private void close()
	  {
		Window window1 = Window;
		if (window1 != null)
		{
		  window1.dispatchEvent(new WindowEvent(window1, 201));
		}
	  }

	  private void iconify()
	  {
		Frame frame = Frame;
		if (frame != null)
		{
		  frame.ExtendedState = this.state | true;
		}
	  }

	  private void maximize()
	  {
		Frame frame = Frame;
		if (frame != null)
		{
		  frame.ExtendedState = this.state | 0x6;
		}
	  }

	  private void restore()
	  {
		Frame frame = Frame;
		if (frame == null)
		{
		  return;
		}
		if ((this.state & true) != 0)
		{
		  frame.ExtendedState = this.state & 0xFFFFFFFE;
		}
		else
		{
		  frame.ExtendedState = this.state & 0xFFFFFFF9;
		}
	  }

	  private void createActions()
	  {
		this.closeAction = new CloseAction(this);
		this.helpAction = new HelpAction(this);
		if (WindowDecorationStyle == 1)
		{
		  this.iconifyAction = new IconifyAction(this);
		  this.restoreAction = new RestoreAction(this);
		  this.maximizeAction = new MaximizeAction(this);
		}
	  }

	  private JMenu createMenu()
	  {
		JMenu jMenu = new JMenu("");
		if (WindowDecorationStyle == 1)
		{
		  addMenuItems(jMenu);
		}
		return jMenu;
	  }

	  private void addMenuItems(JMenu paramJMenu)
	  {
		JMenuItem jMenuItem = paramJMenu.add(this.restoreAction);
		int i = getInt("MetalTitlePane.restoreMnemonic", -1);
		if (i != -1)
		{
		  jMenuItem.Mnemonic = i;
		}
		jMenuItem = paramJMenu.add(this.iconifyAction);
		i = getInt("MetalTitlePane.iconifyMnemonic", -1);
		if (i != -1)
		{
		  jMenuItem.Mnemonic = i;
		}
		if (Toolkit.DefaultToolkit.isFrameStateSupported(6))
		{
		  jMenuItem = paramJMenu.add(this.maximizeAction);
		  i = getInt("MetalTitlePane.maximizeMnemonic", -1);
		  if (i != -1)
		  {
			jMenuItem.Mnemonic = i;
		  }
		}
		paramJMenu.add(new JSeparator());
		jMenuItem = paramJMenu.add(this.closeAction);
		i = getInt("MetalTitlePane.closeMnemonic", -1);
		if (i != -1)
		{
		  jMenuItem.Mnemonic = i;
		}
		jMenuItem = paramJMenu.add(this.helpAction);
		i = getInt("MetalTitlePane.helpMnemonic", -1);
		if (i != -1)
		{
		  jMenuItem.Mnemonic = i;
		}
	  }

	  private JButton createTitleButton()
	  {
		JButton jButton = new JButton();
		jButton.UI = new BasicButtonUI();
		jButton.FocusPainted = false;
		jButton.Focusable = false;
		jButton.Opaque = false;
		return jButton;
	  }

	  public virtual bool UpButtons
	  {
		  set
		  {
			if (!value)
			{
			  this.closeButton.Icon = UIManager.getIcon("InternalFrame.closeIcon");
			  this.closeButton.PressedIcon = UIManager.getIcon("InternalFrame.closeDownIcon");
			  this.closeButton.RolloverIcon = UIManager.getIcon("InternalFrame.closeOverIcon");
			  this.helpButton.Icon = UIManager.getIcon("InternalFrame.helpIcon");
			  this.helpButton.PressedIcon = UIManager.getIcon("InternalFrame.helpDownIcon");
			  this.helpButton.RolloverIcon = UIManager.getIcon("InternalFrame.helpOverIcon");
			  this.iconifyButton.Icon = UIManager.getIcon("InternalFrame.iconifyIcon");
			  this.iconifyButton.PressedIcon = UIManager.getIcon("InternalFrame.iconifyDownIcon");
			  this.iconifyButton.RolloverIcon = UIManager.getIcon("InternalFrame.iconifyOverIcon");
			  if (CostOSRootPaneUI.Resolver.MainFrame.Resizable)
			  {
				this.toggleButton.Icon = UIManager.getIcon("InternalFrame.maximizeIcon");
				this.toggleButton.PressedIcon = UIManager.getIcon("InternalFrame.maximizeDownIcon");
				this.toggleButton.RolloverIcon = UIManager.getIcon("InternalFrame.maximizeOverIcon");
			  }
			  else
			  {
				this.toggleButton.Icon = UIManager.getIcon("InternalFrame.minimizeIcon");
				this.toggleButton.PressedIcon = UIManager.getIcon("InternalFrame.minimizeDownIcon");
				this.toggleButton.RolloverIcon = UIManager.getIcon("InternalFrame.minimizeOverIcon");
			  }
			}
			else
			{
			  this.closeButton.Icon = UIManager.getIcon("InternalBackstageFrame.closeIcon");
			  this.closeButton.PressedIcon = UIManager.getIcon("InternalBackstageFrame.closeDownIcon");
			  this.closeButton.RolloverIcon = UIManager.getIcon("InternalBackstageFrame.closeOverIcon");
			  this.helpButton.Icon = UIManager.getIcon("InternalBackstageFrame.helpIcon");
			  this.helpButton.PressedIcon = UIManager.getIcon("InternalBackstageFrame.helpDownIcon");
			  this.helpButton.RolloverIcon = UIManager.getIcon("InternalBackstageFrame.helpOverIcon");
			  this.iconifyButton.Icon = UIManager.getIcon("InternalBackstageFrame.iconifyIcon");
			  this.iconifyButton.PressedIcon = UIManager.getIcon("InternalBackstageFrame.iconifyDownIcon");
			  this.iconifyButton.RolloverIcon = UIManager.getIcon("InternalBackstageFrame.iconifyOverIcon");
			  if (CostOSRootPaneUI.Resolver.MainFrame.Resizable)
			  {
				this.toggleButton.Icon = UIManager.getIcon("InternalBackstageFrame.maximizeIcon");
				this.toggleButton.PressedIcon = UIManager.getIcon("InternalBackstageFrame.maximizeDownIcon");
				this.toggleButton.RolloverIcon = UIManager.getIcon("InternalBackstageFrame.maximizeOverIcon");
			  }
			  else
			  {
				this.toggleButton.Icon = UIManager.getIcon("InternalBackstageFrame.minimizeIcon");
				this.toggleButton.PressedIcon = UIManager.getIcon("InternalBackstageFrame.minimizeDownIcon");
				this.toggleButton.RolloverIcon = UIManager.getIcon("InternalBackstageFrame.minimizeOverIcon");
			  }
			}
		  }
	  }

	  private void createButtons()
	  {
		this.closeButton = createTitleButton();
		this.closeButton.Action = this.closeAction;
		this.closeButton.Text = null;
		this.closeButton.putClientProperty("paintActive", true);
		this.closeButton.Border = handyEmptyBorder;
		this.closeButton.putClientProperty("AccessibleName", "Close");
		this.closeButton.Icon = UIManager.getIcon("InternalFrame.closeIcon");
		this.closeButton.PressedIcon = UIManager.getIcon("InternalFrame.closeDownIcon");
		this.closeButton.RolloverIcon = UIManager.getIcon("InternalFrame.closeOverIcon");
		if (WindowDecorationStyle == 1)
		{
		  this.helpButton = createTitleButton();
		  this.helpButton.Action = this.helpAction;
		  this.helpButton.Text = null;
		  this.helpButton.putClientProperty("paintActive", true);
		  this.helpButton.Border = handyEmptyBorder;
		  this.helpButton.putClientProperty("AccessibleName", "Help");
		  this.helpButton.Icon = UIManager.getIcon("InternalFrame.helpIcon");
		  this.helpButton.PressedIcon = UIManager.getIcon("InternalFrame.helpDownIcon");
		  this.helpButton.RolloverIcon = UIManager.getIcon("InternalFrame.helpOverIcon");
		  this.maximizeIcon = UIManager.getIcon("InternalFrame.maximizeIcon");
		  this.maximizeDownIcon = UIManager.getIcon("InternalFrame.maximizeDownIcon");
		  this.maximizeOverIcon = UIManager.getIcon("InternalFrame.maximizeOverIcon");
		  this.minimizeIcon = UIManager.getIcon("InternalFrame.minimizeIcon");
		  this.minimizeDownIcon = UIManager.getIcon("InternalFrame.minimizeDownIcon");
		  this.minimizeOverIcon = UIManager.getIcon("InternalFrame.minimizeOverIcon");
		  this.iconifyButton = createTitleButton();
		  this.iconifyButton.Action = this.iconifyAction;
		  this.iconifyButton.Text = null;
		  this.iconifyButton.putClientProperty("paintActive", true);
		  this.iconifyButton.Border = handyEmptyBorder;
		  this.iconifyButton.putClientProperty("AccessibleName", "Iconify");
		  this.iconifyButton.Icon = UIManager.getIcon("InternalFrame.iconifyIcon");
		  this.iconifyButton.PressedIcon = UIManager.getIcon("InternalFrame.iconifyDownIcon");
		  this.iconifyButton.RolloverIcon = UIManager.getIcon("InternalFrame.iconifyOverIcon");
		  this.toggleButton = createTitleButton();
		  this.toggleButton.Action = this.restoreAction;
		  this.toggleButton.putClientProperty("paintActive", true);
		  this.toggleButton.Border = handyEmptyBorder;
		  this.toggleButton.putClientProperty("AccessibleName", "Maximize");
		  this.toggleButton.Icon = this.maximizeIcon;
		  this.toggleButton.PressedIcon = this.maximizeDownIcon;
		  this.toggleButton.RolloverIcon = this.maximizeOverIcon;
		}
	  }

	  private LayoutManager createLayout()
	  {
		  return new TitlePaneLayout(this, null);
	  }

	  private bool Active
	  {
		  set
		  {
			bool? @bool = value ? true : false;
			this.closeButton.putClientProperty("paintActive", @bool);
			if (WindowDecorationStyle == 1)
			{
			  this.iconifyButton.putClientProperty("paintActive", @bool);
			  this.toggleButton.putClientProperty("paintActive", @bool);
			  this.helpButton.putClientProperty("paintActive", @bool);
			}
			RootPane.repaint();
		  }
	  }

	  private int State
	  {
		  set
		  {
			  setState(value, false);
		  }
	  }

	  private void setState(int paramInt, bool paramBoolean)
	  {
		Window window1 = Window;
		if (window1 != null && WindowDecorationStyle == 1)
		{
		  if (this.state == paramInt && !paramBoolean)
		  {
			return;
		  }
		  Frame frame = Frame;
		  if (frame != null)
		  {
			JRootPane jRootPane = RootPane;
			if ((paramInt & 0x6) != 0 && (jRootPane.Border == null || jRootPane.Border is javax.swing.plaf.UIResource) && frame.Showing)
			{
			  jRootPane.Border = null;
			}
			else if ((paramInt & 0x6) == 0)
			{
			  this.rootPaneUI.installBorder(jRootPane);
			}
			if (frame.Resizable)
			{
			  if ((paramInt & 0x6) != 0)
			  {
				updateToggleButton(this.restoreAction, this.minimizeIcon, this.minimizeDownIcon, this.minimizeOverIcon);
				this.maximizeAction.Enabled = false;
				this.restoreAction.Enabled = true;
			  }
			  else
			  {
				updateToggleButton(this.maximizeAction, this.maximizeIcon, this.maximizeDownIcon, this.maximizeOverIcon);
				this.maximizeAction.Enabled = true;
				this.restoreAction.Enabled = false;
			  }
			  if (this.toggleButton.Parent == null || this.iconifyButton.Parent == null)
			  {
				add(this.toggleButton);
				add(this.iconifyButton);
				revalidate();
				repaint();
			  }
			  this.toggleButton.Text = null;
			}
			else
			{
			  this.maximizeAction.Enabled = false;
			  this.restoreAction.Enabled = false;
			  if (this.toggleButton.Parent != null)
			  {
				remove(this.toggleButton);
				revalidate();
				repaint();
			  }
			}
		  }
		  else
		  {
			this.maximizeAction.Enabled = false;
			this.restoreAction.Enabled = false;
			this.iconifyAction.Enabled = false;
			remove(this.toggleButton);
			remove(this.iconifyButton);
			revalidate();
			repaint();
		  }
		  this.closeAction.Enabled = true;
		  this.helpAction.Enabled = true;
		  this.state = paramInt;
		}
	  }

	  private void updateToggleButton(Action paramAction, Icon paramIcon1, Icon paramIcon2, Icon paramIcon3)
	  {
		this.toggleButton.Action = paramAction;
		this.toggleButton.Icon = paramIcon1;
		this.toggleButton.PressedIcon = paramIcon2;
		this.toggleButton.RolloverIcon = paramIcon3;
		this.toggleButton.Text = null;
	  }

	  private Frame Frame
	  {
		  get
		  {
			Window window1 = Window;
			return (window1 is Frame) ? (Frame)window1 : null;
		  }
	  }

	  private Window Window
	  {
		  get
		  {
			  return this.window;
		  }
	  }

	  private string Title
	  {
		  get
		  {
			Window window1 = Window;
			return (window1 is Frame) ? ((Frame)window1).Title : ((window1 is Dialog) ? ((Dialog)window1).Title : null);
		  }
	  }

	  public virtual void paintComponent(Graphics paramGraphics)
	  {
		if (Frame != null)
		{
		  State = Frame.ExtendedState;
		}
		JRootPane jRootPane = RootPane;
		Window window1 = Window;
		bool @bool = (window1 == null) ? jRootPane.ComponentOrientation.LeftToRight : window1.ComponentOrientation.LeftToRight;
		int i = Width;
		int j = Height;
		Color color = CostOSWindowsLookAndFeel.ribbonTaskTitleTextForegroundColor;
		if (!CostOSRibbonUI.Instance.BackstageShowing)
		{
		  paramGraphics.Color = CostOSWindowsLookAndFeel.ribbonBackground;
		  paramGraphics.fillRect(0, 0, i, j);
		  paramGraphics.drawImage(this.ribbonArtImg, i - this.ribbonArtImg.getWidth(this), 0, this.ribbonArtImg.getWidth(this), this.ribbonArtImg.getHeight(this), this);
		}
		else
		{
		  int m = CostOSRibbonApplicationMenuPopupPanel.FirstLevelMenuWidth;
		  paramGraphics.Color = CostOSWindowsLookAndFeel.applicationBackground;
		  paramGraphics.fillRect(0, 0, i, j);
		  paramGraphics.Color = CostOSWindowsLookAndFeel.ribbonBackground;
		  paramGraphics.fillRect(0, 0, m, Height);
		  if (this.ribbonBackstageArtImg != null)
		  {
			paramGraphics.drawImage(this.ribbonBackstageArtImg, i - this.ribbonBackstageArtImg.getWidth(this), 0, this.ribbonBackstageArtImg.getWidth(this), this.ribbonBackstageArtImg.getHeight(this), this);
		  }
		  color = CostOSWindowsLookAndFeel.ribbonCommandButtonForegroundColor;
		}
		int k = @bool ? 5 : (i - 5);
		if (WindowDecorationStyle == 1)
		{
		  k += (@bool ? 21 : -21);
		}
		string str = Title;
		if (!string.ReferenceEquals(str, null))
		{
		  FontMetrics fontMetrics = SwingUtilities2.getFontMetrics(jRootPane, paramGraphics);
		  int m = (j - fontMetrics.Height) / 2 + fontMetrics.Ascent;
		  Rectangle rectangle = new Rectangle(0, 0, 0, 0);
		  if (this.iconifyButton != null && this.iconifyButton.Parent != null)
		  {
			rectangle = this.iconifyButton.Bounds;
		  }
		  if (@bool)
		  {
			if (rectangle.x == 0)
			{
			  rectangle.x = window1.Width - (window1.Insets).right - 2;
			}
			int i2 = rectangle.x - k - 4;
			str = SwingUtilities2.clipStringIfNecessary(jRootPane, fontMetrics, str, i2);
		  }
		  else
		  {
			int i2 = k - rectangle.x - rectangle.width - 4;
			str = SwingUtilities2.clipStringIfNecessary(jRootPane, fontMetrics, str, i2);
			k -= SwingUtilities2.stringWidth(jRootPane, fontMetrics, str);
		  }
		  int n = SwingUtilities2.stringWidth(jRootPane, fontMetrics, str);
		  paramGraphics.Color = color;
		  int i1 = (int)(i / 2.0F - n / 2.0F);
		  SwingUtilities2.drawString(jRootPane, paramGraphics, str, i1, m);
		  k += (@bool ? (n + 5) : -5);
		}
	  }

	  private void updateSystemIcon()
	  {
		Window window1 = Window;
		if (window1 == null)
		{
		  this.systemIcon = null;
		  return;
		}
		System.Collections.IList list = window1.IconImages;
		Debug.Assert(list != null);
		if (list.Count == 0)
		{
		  this.systemIcon = null;
		}
		else if (list.Count == 1)
		{
		  this.systemIcon = (Image)list[0];
		}
	  }

	  internal static int getInt(object paramObject, int paramInt)
	  {
		object @object = UIManager.get(paramObject);
		if (@object is int?)
		{
		  return ((int?)@object).Value;
		}
		if (@object is string)
		{
		  try
		  {
			return int.Parse((string)@object);
		  }
		  catch (System.FormatException)
		  {
		  }
		}
		return paramInt;
	  }

	  private class WindowHandler : WindowAdapter
	  {
		  private readonly CostOSTitlePane outerInstance;

		internal WindowHandler(CostOSTitlePane outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void windowActivated(WindowEvent param1WindowEvent)
		{
			outerInstance.Active = true;
		}

		public virtual void windowDeactivated(WindowEvent param1WindowEvent)
		{
			outerInstance.Active = false;
		}
	  }

	  private class PropertyChangeHandler : PropertyChangeListener
	  {
		  private readonly CostOSTitlePane outerInstance;

		internal PropertyChangeHandler(CostOSTitlePane outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void propertyChange(PropertyChangeEvent param1PropertyChangeEvent)
		{
		  string str = param1PropertyChangeEvent.PropertyName;
		  if ("resizable".Equals(str) || "state".Equals(str))
		  {
			Frame frame = outerInstance.Frame;
			if (frame != null)
			{
			  outerInstance.setState(frame.ExtendedState, true);
			}
			if ("resizable".Equals(str))
			{
			  outerInstance.RootPane.repaint();
			}
		  }
		  else if ("title".Equals(str))
		  {
			outerInstance.repaint();
		  }
		  else if ("componentOrientation".Equals(str))
		  {
			outerInstance.revalidate();
			outerInstance.repaint();
		  }
		  else if ("iconImage".Equals(str))
		  {
			outerInstance.updateSystemIcon();
			outerInstance.revalidate();
			outerInstance.repaint();
		  }
		}
	  }

	  private class TitlePaneLayout : LayoutManager
	  {
		  private readonly CostOSTitlePane outerInstance;

		internal TitlePaneLayout(CostOSTitlePane outerInstance)
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
		  int i = computeHeight();
		  return new Dimension(i, i);
		}

		public virtual Dimension minimumLayoutSize(Container param1Container)
		{
			return preferredLayoutSize(param1Container);
		}

		internal virtual int computeHeight()
		{
		  FontMetrics fontMetrics = outerInstance.rootPane.getFontMetrics(outerInstance.Font);
		  int i = fontMetrics.Height;
		  i += 7;
		  sbyte b = 0;
		  if (outerInstance.WindowDecorationStyle == 1)
		  {
			b = 16;
		  }
		  return Math.Max(i, b);
		}

		public virtual void layoutContainer(Container param1Container)
		{
		  int m;
		  sbyte b;
		  bool @bool = (outerInstance.window == null) ? outerInstance.RootPane.ComponentOrientation.LeftToRight : outerInstance.window.ComponentOrientation.LeftToRight;
		  int i = outerInstance.Width;
		  if (outerInstance.closeButton != null && outerInstance.closeButton.Icon != null)
		  {
			b = outerInstance.closeButton.Icon.IconHeight;
			m = outerInstance.closeButton.Icon.IconWidth;
		  }
		  else
		  {
			b = 16;
			m = 16;
		  }
		  int n = outerInstance.Height / 2 - b / 2;
		  int k = -15;
		  int j = @bool ? k : (i - m - k);
		  if (outerInstance.menuBar != null)
		  {
			outerInstance.menuBar.setBounds(j, n, m, b);
		  }
		  j = @bool ? i : 0;
		  k = 3;
		  j += (@bool ? (-k - m) : k);
		  if (outerInstance.closeButton != null)
		  {
			outerInstance.closeButton.setBounds(j, n, m, b);
		  }
		  if (!@bool)
		  {
			j += m;
		  }
		  if (outerInstance.WindowDecorationStyle == 1)
		  {
			if (Toolkit.DefaultToolkit.isFrameStateSupported(6) && outerInstance.toggleButton.Parent != null)
			{
			  k = 0;
			  j += (@bool ? (-k - m) : k);
			  outerInstance.toggleButton.setBounds(j, n, m, b);
			  if (!@bool)
			  {
				j += m;
			  }
			}
			if (outerInstance.iconifyButton != null && outerInstance.iconifyButton.Parent != null)
			{
			  k = 0;
			  j += (@bool ? (-k - m) : k);
			  outerInstance.iconifyButton.setBounds(j, n, m, b);
			  if (!@bool)
			  {
				j += m;
			  }
			}
			if (outerInstance.helpButton != null && outerInstance.helpButton.Parent != null)
			{
			  k = 0;
			  j += (@bool ? (-k - m) : k);
			  outerInstance.helpButton.setBounds(j, n, m, b);
			  if (!@bool)
			  {
				j += m;
			  }
			}
		  }
		  outerInstance.buttonsWidth = @bool ? (i - j) : j;
		}
	  }

	  private class SystemMenuBar : JMenuBar
	  {
		  private readonly CostOSTitlePane outerInstance;

		internal SystemMenuBar(CostOSTitlePane outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void paint(Graphics param1Graphics)
		{
		  if (Opaque)
		  {
			param1Graphics.Color = Background;
			param1Graphics.fillRect(0, 0, Width, Height);
		  }
		  if (outerInstance.systemIcon != null)
		  {
			param1Graphics.drawImage(outerInstance.systemIcon, 0, 0, 16, 16, null);
		  }
		  else
		  {
			Icon icon = UIManager.getIcon("InternalFrame.icon");
			if (icon != null)
			{
			  icon.paintIcon(this, param1Graphics, 0, 0);
			}
		  }
		}

		public virtual Dimension MinimumSize
		{
			get
			{
				return PreferredSize;
			}
		}

		public virtual Dimension PreferredSize
		{
			get
			{
			  Dimension dimension = base.PreferredSize;
			  return new Dimension(Math.Max(16, dimension.width), Math.Max(dimension.height, 16));
			}
		}
	  }

	  private class MaximizeAction : AbstractAction
	  {
		  private readonly CostOSTitlePane outerInstance;

		public MaximizeAction(CostOSTitlePane outerInstance) : base(UIManager.getString("MetalTitlePane.maximizeTitle", this$0.Locale))
		{
			this.outerInstance = outerInstance;
		}

		public virtual void actionPerformed(ActionEvent param1ActionEvent)
		{
			outerInstance.maximize();
		}
	  }

	  private class RestoreAction : AbstractAction
	  {
		  private readonly CostOSTitlePane outerInstance;

		public RestoreAction(CostOSTitlePane outerInstance) : base(UIManager.getString("MetalTitlePane.restoreTitle", this$0.Locale))
		{
			this.outerInstance = outerInstance;
		}

		public virtual void actionPerformed(ActionEvent param1ActionEvent)
		{
			outerInstance.restore();
		}
	  }

	  private class IconifyAction : AbstractAction
	  {
		  private readonly CostOSTitlePane outerInstance;

		public IconifyAction(CostOSTitlePane outerInstance) : base(UIManager.getString("MetalTitlePane.iconifyTitle", this$0.Locale))
		{
			this.outerInstance = outerInstance;
		}

		public virtual void actionPerformed(ActionEvent param1ActionEvent)
		{
			outerInstance.iconify();
		}
	  }

	  private class HelpAction : AbstractAction
	  {
		  private readonly CostOSTitlePane outerInstance;

		public HelpAction(CostOSTitlePane outerInstance) : base(UIManager.getString("MetalTitlePane.helpTitle", this$0.Locale))
		{
			this.outerInstance = outerInstance;
		}

		public virtual void actionPerformed(ActionEvent param1ActionEvent)
		{
			CostOSRootPaneUI.Resolver.fireHelpAction();
		}
	  }

	  private class CloseAction : AbstractAction
	  {
		  private readonly CostOSTitlePane outerInstance;

		public CloseAction(CostOSTitlePane outerInstance) : base(UIManager.getString("MetalTitlePane.closeTitle", this$0.Locale))
		{
			this.outerInstance = outerInstance;
		}

		public virtual void actionPerformed(ActionEvent param1ActionEvent)
		{
			outerInstance.close();
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSTitlePane.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
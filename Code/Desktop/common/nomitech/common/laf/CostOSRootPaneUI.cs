using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.laf
{
	using OfficeWindowsLookAndFeel = org.officelaf.OfficeWindowsLookAndFeel;
	using JRibbon = org.pushingpixels.flamingo.api.ribbon.JRibbon;

	public class CostOSRootPaneUI : BasicRootPaneUI
	{
		private bool InstanceFieldsInitialized = false;

		private void InitializeInstanceFields()
		{
			rootPaneBorder = new RootPaneBorder(this);
		}

	  private static readonly string[] borderKeys = new string[] {null, "RootPane.frameBorder", "RootPane.plainDialogBorder", "RootPane.informationDialogBorder", "RootPane.errorDialogBorder", "RootPane.colorChooserDialogBorder", "RootPane.fileChooserDialogBorder", "RootPane.questionDialogBorder", "RootPane.warningDialogBorder"};

	  private const int CORNER_DRAG_WIDTH = 16;

	  private const int BORDER_DRAG_THICKNESS = 10;

	  private static bool isFirst = true;

	  private Border rootPaneBorder;

	  private Border emptyBorder = BorderFactory.createEmptyBorder();

	  private Window window;

	  private CostOSTitlePane titlePane;

	  private MouseInputListener mouseInputListener;

	  private LayoutManager layoutManager;

	  private LayoutManager savedOldLayout;

	  private JRootPane root;

	  private Cursor lastCursor = Cursor.getPredefinedCursor(0);

	  private JRibbon ribbon;

	  private static CostOSRibbonResolver s_resolver = null;

	  private static readonly int[] cursorMapping = new int[] {6, 6, 8, 7, 7, 6, 0, 0, 0, 7, 10, 0, 0, 0, 11, 4, 0, 0, 0, 5, 4, 4, 9, 5, 5};

	  public CostOSRootPaneUI(JRootPane paramJRootPane)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		  this.root = paramJRootPane;
	  }

	  public static CostOSRibbonResolver Resolver
	  {
		  set
		  {
			  s_resolver = value;
		  }
		  get
		  {
			  return s_resolver;
		  }
	  }


	  public static ComponentUI createUI(JComponent paramJComponent)
	  {
		  return new CostOSRootPaneUI((JRootPane)paramJComponent);
	  }

	  public virtual JRibbon Ribbon
	  {
		  get
		  {
			if (this.ribbon == null)
			{
			  if (s_resolver != null)
			  {
				this.ribbon = s_resolver.Ribbon;
			  }
			  Ribbon = this.ribbon;
			}
			return this.ribbon;
		  }
		  set
		  {
			JRibbon jRibbon = this.ribbon;
			if (jRibbon != null)
			{
			  this.root.LayeredPane.remove(jRibbon);
			}
			this.ribbon = value;
			if (this.ribbon != null)
			{
			  this.ribbon.Visible = true;
			  this.ribbon.putClientProperty("layeredContainerLayer", Convert.ToInt32(0));
			  this.root.LayeredPane.add(this.ribbon, 0);
			}
		  }
	  }


	  public virtual void installUI(JComponent paramJComponent)
	  {
		base.installUI(paramJComponent);
		if (isFirst)
		{
//JAVA TO C# CONVERTER TODO TASK: The following line could not be converted:
		  this.root.addHierarchyListener(new java.awt.@event.HierarchyListener()
		  {
				public void hierarchyChanged(HierarchyEvent param1HierarchyEvent)
				{
				  if (CostOSRootPaneUI.this.root == null)
				  {
					return;
				  }
				  Window window = SwingUtilities.getWindowAncestor(CostOSRootPaneUI.this.root);
				  if (window is Frame)
				  {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final javax.swing.JFrame f = (javax.swing.JFrame)window;
					JFrame f = (JFrame)window;
					if (jFrame != null && !jFrame.Displayable && !jFrame.Undecorated && isFirst)
					{
					  CostOSRootPaneUI.this.root.WindowDecorationStyle = 1;
					  jFrame.Undecorated = true;
					  if (string.Compare("mac os x", System.getProperty("os.name"), StringComparison.OrdinalIgnoreCase) != 0)
					  {
//JAVA TO C# CONVERTER TODO TASK: The following line could not be converted:
						jFrame.addComponentListener(new java.awt.@event.ComponentAdapter()
						{
							  public void componentResized(ComponentEvent param2ComponentEvent)
							  {
								if (f.ExtendedState == 6)
								{
									;
								}
							  }

							  public void componentMoved(ComponentEvent param2ComponentEvent)
							  {
								Rectangle rectangle1 = f.GraphicsConfiguration.Bounds;
								Insets insets = Toolkit.DefaultToolkit.getScreenInsets(f.GraphicsConfiguration);
								Rectangle rectangle2 = new Rectangle(insets.left, insets.top, rectangle1.width - insets.left + insets.right, rectangle1.height - insets.top + insets.bottom);
								if (insets.left == 0 && insets.right == 0 && insets.top == 0 && insets.bottom == 0)
								{
								  f.MaximizedBounds = null;
								}
								else
								{
								  f.MaximizedBounds = rectangle2;
								}
							  }
						}
					  }
						   );
					  CostOSRootPaneUI.this.root.removeHierarchyListener(this);
					  isFirst = false;
					}
				  }
				}
		  }
		}
			 );
		int i = this.root.WindowDecorationStyle;
		if (i != 0)
		{
		  installClientDecorations(this.root);
		}
	  }

	  public virtual void uninstallUI(JComponent paramJComponent)
	  {
		base.uninstallUI(paramJComponent);
		uninstallClientDecorations(this.root);
		this.layoutManager = null;
		this.mouseInputListener = null;
		this.root = null;
	  }

	  public virtual void installBorder(JRootPane paramJRootPane)
	  {
		int i = paramJRootPane.WindowDecorationStyle;
		if (i == 0)
		{
		  LookAndFeel.uninstallBorder(paramJRootPane);
		}
		else
		{
		  LookAndFeel.installBorder(paramJRootPane, borderKeys[i]);
		  int j = (this.titlePane.PreferredSize).height;
		  paramJRootPane.Border = this.rootPaneBorder;
		}
	  }

	  private void uninstallBorder(JRootPane paramJRootPane)
	  {
		  LookAndFeel.uninstallBorder(paramJRootPane);
	  }

	  private void installClientDecorationListeners(JRootPane paramJRootPane)
	  {
		this.window = SwingUtilities.getWindowAncestor(paramJRootPane);
		if (this.window != null)
		{
		  if (this.mouseInputListener != null)
		  {
			uninstallClientDecorationListeners(paramJRootPane);
		  }
		  this.mouseInputListener = createMouseInputListener(paramJRootPane);
		  paramJRootPane.addMouseListener(this.mouseInputListener);
		  paramJRootPane.addMouseMotionListener(this.mouseInputListener);
		  this.titlePane.addMouseListener(this.mouseInputListener);
		  this.titlePane.addMouseMotionListener(this.mouseInputListener);
		}
	  }

	  private void uninstallClientDecorationListeners(JRootPane paramJRootPane)
	  {
		if (this.window != null)
		{
		  paramJRootPane.removeMouseListener(this.mouseInputListener);
		  paramJRootPane.removeMouseMotionListener(this.mouseInputListener);
		  if (this.titlePane != null)
		  {
			this.titlePane.removeMouseListener(this.mouseInputListener);
			this.titlePane.removeMouseMotionListener(this.mouseInputListener);
		  }
		}
	  }

	  private void installLayout(JRootPane paramJRootPane)
	  {
		if (this.layoutManager == null)
		{
		  this.layoutManager = createLayoutManager();
		}
		this.savedOldLayout = paramJRootPane.Layout;
		paramJRootPane.Layout = this.layoutManager;
	  }

	  private void uninstallLayout(JRootPane paramJRootPane)
	  {
		if (this.savedOldLayout != null)
		{
		  paramJRootPane.Layout = this.savedOldLayout;
		  this.savedOldLayout = null;
		}
	  }

	  private void installClientDecorations(JRootPane paramJRootPane)
	  {
		setTitlePane(paramJRootPane, createTitlePane(paramJRootPane));
		installBorder(paramJRootPane);
		installClientDecorationListeners(paramJRootPane);
		installLayout(paramJRootPane);
		if (this.window != null)
		{
		  paramJRootPane.revalidate();
		  paramJRootPane.repaint();
		}
	  }

	  private void uninstallClientDecorations(JRootPane paramJRootPane)
	  {
		uninstallBorder(paramJRootPane);
		uninstallClientDecorationListeners(paramJRootPane);
		setTitlePane(paramJRootPane, null);
		uninstallLayout(paramJRootPane);
		int i = paramJRootPane.WindowDecorationStyle;
		if (i == 0)
		{
		  paramJRootPane.repaint();
		  paramJRootPane.revalidate();
		}
		if (this.window != null)
		{
		  this.window.Cursor = Cursor.getPredefinedCursor(0);
		}
		this.window = null;
	  }

//JAVA TO C# CONVERTER WARNING: 'final' parameters are ignored unless the option to convert to C# 7.2 'in' parameters is selected:
//ORIGINAL LINE: private CostOSTitlePane createTitlePane(final javax.swing.JRootPane root)
	  private CostOSTitlePane createTitlePane(JRootPane root)
	  {
		CostOSTitlePane costOSTitlePane = new CostOSTitlePane(paramJRootPane, this);
		bool @bool = true;
		if (!@bool)
		{
//JAVA TO C# CONVERTER TODO TASK: The following line could not be converted:
		  costOSTitlePane.addMouseListener(new java.awt.@event.MouseAdapter()
		  {
				public void mousePressed(MouseEvent param1MouseEvent)
				{
				  if (param1MouseEvent.Button == 3 && root.JMenuBar != null)
				  {
					JMenuBar jMenuBar = root.JMenuBar;
					JPopupMenu jPopupMenu = new JPopupMenu();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.ArrayList menus = new java.util.ArrayList();
					List<object> menus = new List<object>();
					for (sbyte b = 0; b < jMenuBar.MenuCount; b++)
					{
					  arrayList.add(jMenuBar.getMenu(b));
					}
					foreach (JMenu jMenu in arrayList)
					{
					  jPopupMenu.add(jMenu);
					}
					jPopupMenu.addPopupMenuListener(new PopupMenuListenerAnonymousInnerClass(this, root, menus));
					jPopupMenu.show(param1MouseEvent.Component, param1MouseEvent.X, param1MouseEvent.Y);
				  }
				}
		  }
		}
			 );
		return costOSTitlePane;
	  }

	  private class PopupMenuListenerAnonymousInnerClass : PopupMenuListener
	  {
		  private readonly CostOSRootPaneUI outerInstance;

		  private JRootPane root;
		  private List<object> menus;

		  public PopupMenuListenerAnonymousInnerClass(CostOSRootPaneUI outerInstance, JRootPane root, List<object> menus)
		  {
			  this.outerInstance = outerInstance;
			  this.root = root;
			  this.menus = menus;
		  }

		  public void popupMenuWillBecomeVisible(PopupMenuEvent param2PopupMenuEvent)
		  {
		  }

		  public void popupMenuWillBecomeInvisible(PopupMenuEvent param2PopupMenuEvent)
		  {
			foreach (JMenu jMenu in menus)
			{
			  root.JMenuBar.add(jMenu);
			}
		  }

		  public void popupMenuCanceled(PopupMenuEvent param2PopupMenuEvent)
		  {
		  }
	  }

	  private MouseInputListener createMouseInputListener(JRootPane paramJRootPane)
	  {
		  return new MouseInputHandler(this, null);
	  }

	  private LayoutManager createLayoutManager()
	  {
		  return new MetalRootLayout(null);
	  }

	  private void setTitlePane(JRootPane paramJRootPane, CostOSTitlePane paramCostOSTitlePane)
	  {
		JLayeredPane jLayeredPane = paramJRootPane.LayeredPane;
		JComponent jComponent = TitlePane;
		if (jComponent != null)
		{
		  jComponent.Visible = false;
		  jLayeredPane.remove(jComponent);
		}
		this.titlePane = paramCostOSTitlePane;
		if (paramCostOSTitlePane != null)
		{
		  jLayeredPane.add(paramCostOSTitlePane, JLayeredPane.FRAME_CONTENT_LAYER);
		  paramCostOSTitlePane.Visible = true;
		}
	  }

	  public virtual JComponent TitlePane
	  {
		  get
		  {
			  return this.titlePane;
		  }
	  }

	  private JRootPane RootPane
	  {
		  get
		  {
			  return this.root;
		  }
	  }

	  public virtual void propertyChange(PropertyChangeEvent paramPropertyChangeEvent)
	  {
		base.propertyChange(paramPropertyChangeEvent);
		string str = paramPropertyChangeEvent.PropertyName;
		if (string.ReferenceEquals(str, null))
		{
		  return;
		}
		if (str.Equals("windowDecorationStyle"))
		{
		  JRootPane jRootPane = (JRootPane)paramPropertyChangeEvent.Source;
		  int i = jRootPane.WindowDecorationStyle;
		  uninstallClientDecorations(jRootPane);
		  if (i != 0)
		  {
			installClientDecorations(jRootPane);
		  }
		}
		else if (str.Equals("ancestor"))
		{
		  uninstallClientDecorationListeners(this.root);
		  if (((JRootPane)paramPropertyChangeEvent.Source).WindowDecorationStyle != 0)
		  {
			installClientDecorationListeners(this.root);
		  }
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void main(String[] paramArrayOfString) throws Exception
	  public static void Main(string[] paramArrayOfString)
	  {
		UIManager.LookAndFeel = new OfficeWindowsLookAndFeel();
		JFrame jFrame = new JFrame("Builder Office LAF Test");
		JMenuBar jMenuBar = new JMenuBar();
		JMenu jMenu = new JMenu("File");
		jMenu.add(new JMenuItem("Exit"));
		jMenuBar.add(jMenu);
		jFrame.JMenuBar = jMenuBar;
		jFrame.setSize(800, 600);
		jFrame.LocationRelativeTo = null;
		jFrame.DefaultCloseOperation = 3;
		JPanel jPanel1 = new JPanel(new BorderLayout());
		jPanel1.Background = Color.RED;
		JPanel jPanel2 = new JPanel();
		jPanel2.Background = Color.GREEN;
		jPanel1.add(jPanel2, "Center");
		jFrame.ContentPane = jPanel1;
		jFrame.Visible = true;
	  }

	  private class MouseInputHandler : MouseInputListener
	  {
		  private readonly CostOSRootPaneUI outerInstance;

		internal bool isMovingWindow;

		internal int dragCursor;

		internal int dragOffsetX;

		internal int dragOffsetY;

		internal int dragWidth;

		internal int dragHeight;

		internal MouseInputHandler(CostOSRootPaneUI outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void mousePressed(MouseEvent param1MouseEvent)
		{
		  JRootPane jRootPane = outerInstance.RootPane;
		  if (jRootPane.WindowDecorationStyle == 0)
		  {
			return;
		  }
		  Point point1 = param1MouseEvent.Point;
		  Component component = (Component)param1MouseEvent.Source;
		  Window window = windowForEvent(param1MouseEvent);
		  if (window != null)
		  {
			window.toFront();
		  }
		  Point point2 = SwingUtilities.convertPoint(component, point1, outerInstance.TitlePane);
		  point1 = SwingUtilities.convertPoint(component, point1, window);
		  Frame frame = null;
		  Dialog dialog = null;
		  if (window is Frame)
		  {
			frame = (Frame)window;
		  }
		  else if (window is Dialog)
		  {
			dialog = (Dialog)window;
		  }
		  int i = (frame != null) ? frame.ExtendedState : 0;
		  if (outerInstance.TitlePane != null && outerInstance.TitlePane.contains(point2))
		  {
			if (((frame != null && (i & 0x6) == 0) || dialog != null) && point1.y >= 10 && point1.x >= 10 && point1.x < window.Width - 10)
			{
			  this.isMovingWindow = true;
			  this.dragOffsetX = point1.x;
			  this.dragOffsetY = point1.y;
			}
		  }
		  else if ((frame != null && frame.Resizable && (i & 0x6) == 0) || (dialog != null && dialog.Resizable))
		  {
			this.dragOffsetX = point1.x;
			this.dragOffsetY = point1.y;
			this.dragWidth = window.Width;
			this.dragHeight = window.Height;
			this.dragCursor = getCursor(calculateCorner(window, point1.x, point1.y));
		  }
		}

		public virtual void mouseReleased(MouseEvent param1MouseEvent)
		{
		  if (this.dragCursor != 0 && outerInstance.window != null && !outerInstance.window.Valid)
		  {
			outerInstance.window.validate();
			outerInstance.RootPane.repaint();
		  }
		  Window window = windowForEvent(param1MouseEvent);
		  Frame frame = null;
		  GraphicsDevice graphicsDevice = null;
		  if (window is Frame)
		  {
			frame = (Frame)window;
			graphicsDevice = frame.GraphicsConfiguration.Device;
		  }
		  if (this.isMovingWindow && frame != null)
		  {
			Rectangle rectangle = graphicsDevice.DefaultConfiguration.Bounds;
			Insets insets = Toolkit.DefaultToolkit.getScreenInsets(graphicsDevice.DefaultConfiguration);
			if (param1MouseEvent.XOnScreen == rectangle.X)
			{
			  window.setLocation((int)rectangle.X + insets.left, (int)rectangle.Y + insets.top);
			  window.setSize((int)rectangle.Width / 2 - insets.right, (int)rectangle.Height - insets.bottom);
			}
			else if (param1MouseEvent.YOnScreen == rectangle.Y)
			{
			  window.setLocation((int)rectangle.X + insets.left, (int)rectangle.Y + insets.top);
			  window.setSize((int)rectangle.Width - insets.right, (int)rectangle.Height / 2 - insets.bottom);
			}
			else if (param1MouseEvent.XOnScreen == rectangle.X + rectangle.Width - 1.0D)
			{
			  window.setLocation((int)rectangle.X + (int)(rectangle.Width / 2.0D) + insets.left, (int)rectangle.Y + insets.top);
			  window.setSize((int)(rectangle.Width / 2.0D) - insets.right, (int)rectangle.Height - insets.bottom);
			}
			else if (param1MouseEvent.YOnScreen == rectangle.Y + rectangle.Height - 1.0D)
			{
			  window.setLocation((int)rectangle.X + insets.left, (int)rectangle.Y + (int)(rectangle.Height / 2.0D) + insets.top);
			  window.setSize((int)rectangle.Width - insets.right, (int)(rectangle.Height / 2.0D) - insets.bottom);
			}
		  }
		  this.isMovingWindow = false;
		  this.dragCursor = 0;
		}

		public virtual void mouseMoved(MouseEvent param1MouseEvent)
		{
		  JRootPane jRootPane = outerInstance.RootPane;
		  if (jRootPane.WindowDecorationStyle == 0)
		  {
			return;
		  }
		  Component component = (Component)param1MouseEvent.Source;
		  Window window = windowForEvent(param1MouseEvent);
		  Point point = SwingUtilities.convertPoint(component, param1MouseEvent.Point, window);
		  Frame frame = null;
		  Dialog dialog = null;
		  if (window is Frame)
		  {
			frame = (Frame)window;
		  }
		  else if (window is Dialog)
		  {
			dialog = (Dialog)window;
		  }
		  int i = getCursor(calculateCorner(window, point.x, point.y));
		  if (i != 0 && ((frame != null && frame.Resizable && (frame.ExtendedState & 0x6) == 0) || (dialog != null && dialog.Resizable)))
		  {
			window.Cursor = Cursor.getPredefinedCursor(i);
		  }
		  else
		  {
			window.Cursor = outerInstance.lastCursor;
		  }
		}

		internal virtual void adjust(Rectangle param1Rectangle, Dimension param1Dimension, int param1Int1, int param1Int2, int param1Int3, int param1Int4)
		{
		  param1Rectangle.x += param1Int1;
		  param1Rectangle.y += param1Int2;
		  param1Rectangle.width += param1Int3;
		  param1Rectangle.height += param1Int4;
		  if (param1Dimension != null)
		  {
			if (param1Rectangle.width < param1Dimension.width)
			{
			  int i = param1Dimension.width - param1Rectangle.width;
			  if (param1Int1 != 0)
			  {
				param1Rectangle.x -= i;
			  }
			  param1Rectangle.width = param1Dimension.width;
			}
			if (param1Rectangle.height < param1Dimension.height)
			{
			  int i = param1Dimension.height - param1Rectangle.height;
			  if (param1Int2 != 0)
			  {
				param1Rectangle.y -= i;
			  }
			  param1Rectangle.height = param1Dimension.height;
			}
		  }
		}

		public virtual void mouseDragged(MouseEvent param1MouseEvent)
		{
		  Component component = (Component)param1MouseEvent.Source;
		  Window window = windowForEvent(param1MouseEvent);
		  Point point = SwingUtilities.convertPoint(component, param1MouseEvent.Point, window);
		  if (this.isMovingWindow)
		  {
			Point point1 = param1MouseEvent.LocationOnScreen;
			int i = point1.x - this.dragOffsetX;
			int j = point1.y - this.dragOffsetY;
			window.setLocation(i, j);
		  }
		  else if (this.dragCursor != 0)
		  {
			Rectangle rectangle1 = window.Bounds;
			Rectangle rectangle2 = new Rectangle(rectangle1);
			Dimension dimension = window.MinimumSize;
			switch (this.dragCursor)
			{
			  case 11:
				adjust(rectangle1, dimension, 0, 0, point.x + this.dragWidth - this.dragOffsetX - rectangle1.width, 0);
				break;
			  case 9:
				adjust(rectangle1, dimension, 0, 0, 0, point.y + this.dragHeight - this.dragOffsetY - rectangle1.height);
				break;
			  case 8:
				adjust(rectangle1, dimension, 0, point.y - this.dragOffsetY, 0, -(point.y - this.dragOffsetY));
				break;
			  case 10:
				adjust(rectangle1, dimension, point.x - this.dragOffsetX, 0, -(point.x - this.dragOffsetX), 0);
				break;
			  case 7:
				adjust(rectangle1, dimension, 0, point.y - this.dragOffsetY, point.x + this.dragWidth - this.dragOffsetX - rectangle1.width, -(point.y - this.dragOffsetY));
				break;
			  case 5:
				adjust(rectangle1, dimension, 0, 0, point.x + this.dragWidth - this.dragOffsetX - rectangle1.width, point.y + this.dragHeight - this.dragOffsetY - rectangle1.height);
				break;
			  case 6:
				adjust(rectangle1, dimension, point.x - this.dragOffsetX, point.y - this.dragOffsetY, -(point.x - this.dragOffsetX), -(point.y - this.dragOffsetY));
				break;
			  case 4:
				adjust(rectangle1, dimension, point.x - this.dragOffsetX, 0, -(point.x - this.dragOffsetX), point.y + this.dragHeight - this.dragOffsetY - rectangle1.height);
				break;
			}
			if (!rectangle1.Equals(rectangle2))
			{
			  window.setBounds(rectangle1.x, rectangle1.y, rectangle1.width, rectangle1.height);
			  if (Toolkit.DefaultToolkit.DynamicLayoutActive)
			  {
				window.validate();
				outerInstance.RootPane.repaint();
			  }
			}
		  }
		}

		public virtual void mouseEntered(MouseEvent param1MouseEvent)
		{
		  Window window = windowForEvent(param1MouseEvent);
		  outerInstance.lastCursor = window.Cursor;
		  mouseMoved(param1MouseEvent);
		}

		public virtual void mouseExited(MouseEvent param1MouseEvent)
		{
		  Window window = windowForEvent(param1MouseEvent);
		  window.Cursor = outerInstance.lastCursor;
		}

		public virtual void mouseClicked(MouseEvent param1MouseEvent)
		{
		  Frame frame;
		  Component component = (Component)param1MouseEvent.Source;
		  Window window = windowForEvent(param1MouseEvent);
		  if (window is Frame)
		  {
			frame = (Frame)window;
		  }
		  else
		  {
			return;
		  }
		  Point point = SwingUtilities.convertPoint(component, param1MouseEvent.Point, outerInstance.TitlePane);
		  int i = frame.ExtendedState;
		  if (outerInstance.TitlePane != null && outerInstance.TitlePane.contains(point) && param1MouseEvent.ClickCount % 2 == 0 && (param1MouseEvent.Modifiers & 0x10) != 0 && frame.Resizable)
		  {
			if ((i & 0x6) != 0)
			{
			  frame.ExtendedState = i & 0xFFFFFFF9;
			}
			else
			{
			  frame.ExtendedState = i | 0x6;
			}
		  }
		}

		internal virtual int calculateCorner(Window param1Window, int param1Int1, int param1Int2)
		{
		  Insets insets = param1Window.Insets;
		  int i = calculatePosition(param1Int1 - insets.left, param1Window.Width - insets.left - insets.right);
		  int j = calculatePosition(param1Int2 - insets.top, param1Window.Height - insets.top - insets.bottom);
		  return (i == -1 || j == -1) ? -1 : (j * 5 + i);
		}

		internal virtual int getCursor(int param1Int)
		{
			return (param1Int == -1) ? 0 : cursorMapping[param1Int];
		}

		internal virtual int calculatePosition(int param1Int1, int param1Int2)
		{
			return (param1Int1 < 10) ? 0 : ((param1Int1 < 16) ? 1 : ((param1Int1 >= param1Int2 - 10) ? 4 : ((param1Int1 >= param1Int2 - 16) ? 3 : 2)));
		}

		internal virtual Window windowForEvent(MouseEvent param1MouseEvent)
		{
		  Component component = (Component)param1MouseEvent.Source;
		  return (component is Window) ? (Window)component : SwingUtilities.getWindowAncestor(component);
		}
	  }

	  private class MetalRootLayout : LayoutManager2
	  {
		internal MetalRootLayout()
		{
		}

		public virtual Dimension preferredLayoutSize(Container param1Container)
		{
		  Dimension dimension;
		  int i = 0;
		  int j = 0;
		  int k = 0;
		  int m = 0;
		  int n = 0;
		  int i1 = 0;
		  Insets insets = param1Container.Insets;
		  JRootPane jRootPane = (JRootPane)param1Container;
		  if (jRootPane.ContentPane != null)
		  {
			dimension = jRootPane.ContentPane.PreferredSize;
		  }
		  else
		  {
			dimension = jRootPane.Size;
		  }
		  if (dimension != null)
		  {
			i = dimension.width;
			j = dimension.height;
		  }
		  if (jRootPane.JMenuBar != null)
		  {
			Dimension dimension1 = jRootPane.JMenuBar.PreferredSize;
			if (dimension1 != null)
			{
			  k = dimension1.width;
			  m = dimension1.height;
			}
		  }
		  if (jRootPane.WindowDecorationStyle != 0 && jRootPane.UI is CostOSRootPaneUI)
		  {
			JComponent jComponent = ((CostOSRootPaneUI)jRootPane.UI).TitlePane;
			if (jComponent != null)
			{
			  Dimension dimension1 = jComponent.PreferredSize;
			  if (dimension1 != null)
			  {
				n = dimension1.width;
				i1 = dimension1.height;
			  }
			}
		  }
		  return new Dimension(Math.Max(Math.Max(i, k), n) + insets.left + insets.right, j + m + n + insets.top + insets.bottom);
		}

		public virtual Dimension minimumLayoutSize(Container param1Container)
		{
		  Dimension dimension;
		  int i = 0;
		  int j = 0;
		  int k = 0;
		  int m = 0;
		  int n = 0;
		  int i1 = 0;
		  Insets insets = param1Container.Insets;
		  JRootPane jRootPane = (JRootPane)param1Container;
		  if (jRootPane.ContentPane != null)
		  {
			dimension = jRootPane.ContentPane.MinimumSize;
		  }
		  else
		  {
			dimension = jRootPane.Size;
		  }
		  if (dimension != null)
		  {
			i = dimension.width;
			j = dimension.height;
		  }
		  if (jRootPane.JMenuBar != null)
		  {
			Dimension dimension1 = jRootPane.JMenuBar.MinimumSize;
			if (dimension1 != null)
			{
			  k = dimension1.width;
			  m = dimension1.height;
			}
		  }
		  if (jRootPane.WindowDecorationStyle != 0 && jRootPane.UI is CostOSRootPaneUI)
		  {
			JComponent jComponent = ((CostOSRootPaneUI)jRootPane.UI).TitlePane;
			if (jComponent != null)
			{
			  Dimension dimension1 = jComponent.MinimumSize;
			  if (dimension1 != null)
			  {
				n = dimension1.width;
				i1 = dimension1.height;
			  }
			}
		  }
		  return new Dimension(Math.Max(Math.Max(i, k), n) + insets.left + insets.right, j + m + n + insets.top + insets.bottom);
		}

		public virtual Dimension maximumLayoutSize(Container param1Container)
		{
		  int i = int.MaxValue;
		  int j = int.MaxValue;
		  int k = int.MaxValue;
		  int m = int.MaxValue;
		  int n = int.MaxValue;
		  int i1 = int.MaxValue;
		  Insets insets = param1Container.Insets;
		  JRootPane jRootPane = (JRootPane)param1Container;
		  if (jRootPane.ContentPane != null)
		  {
			Dimension dimension = jRootPane.ContentPane.MaximumSize;
			if (dimension != null)
			{
			  i = dimension.width;
			  j = dimension.height;
			}
		  }
		  if (jRootPane.JMenuBar != null)
		  {
			Dimension dimension = jRootPane.JMenuBar.MaximumSize;
			if (dimension != null)
			{
			  k = dimension.width;
			  m = dimension.height;
			}
		  }
		  if (jRootPane.WindowDecorationStyle != 0 && jRootPane.UI is CostOSRootPaneUI)
		  {
			JComponent jComponent = ((CostOSRootPaneUI)jRootPane.UI).TitlePane;
			if (jComponent != null)
			{
			  Dimension dimension = jComponent.MaximumSize;
			  if (dimension != null)
			  {
				n = dimension.width;
				i1 = dimension.height;
			  }
			}
		  }
		  int i2 = Math.Max(Math.Max(j, m), i1);
		  if (i2 != int.MaxValue)
		  {
			i2 = j + m + i1 + insets.top + insets.bottom;
		  }
		  int i3 = Math.Max(Math.Max(i, k), n);
		  if (i3 != int.MaxValue)
		  {
			i3 += insets.left + insets.right;
		  }
		  return new Dimension(i3, i2);
		}

		public virtual void layoutContainer(Container param1Container)
		{
		  JRootPane jRootPane = (JRootPane)param1Container;
		  Rectangle rectangle = jRootPane.Bounds;
		  Insets insets = jRootPane.Insets;
		  int i = 0;
		  int j = rectangle.width - insets.right - insets.left;
		  int k = rectangle.height - insets.top - insets.bottom;
		  if (jRootPane.LayeredPane != null)
		  {
			jRootPane.LayeredPane.setBounds(insets.left, insets.top, j, k);
		  }
		  if (jRootPane.GlassPane != null)
		  {
			jRootPane.GlassPane.setBounds(insets.left, insets.top, j, k);
		  }
		  if (jRootPane.WindowDecorationStyle != 0 && jRootPane.UI is CostOSRootPaneUI)
		  {
			CostOSRootPaneUI costOSRootPaneUI1 = (CostOSRootPaneUI)jRootPane.UI;
			JComponent jComponent = costOSRootPaneUI1.TitlePane;
			if (jComponent != null)
			{
			  Dimension dimension = jComponent.PreferredSize;
			  if (dimension != null)
			  {
				int m = dimension.height;
				jComponent.setBounds(0, 0, j, m);
				i += m;
			  }
			}
		  }
		  if (jRootPane.JMenuBar != null && jRootPane.JMenuBar.Visible)
		  {
			JMenuBar jMenuBar = jRootPane.JMenuBar;
			Dimension dimension = jMenuBar.PreferredSize;
			jMenuBar.setBounds(43, i, j, dimension.height);
			i += dimension.height;
			bool @bool = true;
			if (!@bool)
			{
			  jRootPane.JMenuBar.Visible = @bool;
			}
		  }
		  CostOSRootPaneUI costOSRootPaneUI = (CostOSRootPaneUI)jRootPane.UI;
		  JRibbon jRibbon = costOSRootPaneUI.Ribbon;
		  if (jRibbon != null && jRibbon.Visible)
		  {
			Dimension dimension = jRibbon.PreferredSize;
			jRibbon.setBounds(0, 0, j, dimension.height);
			i = dimension.height + 0;
		  }
		  if (jRootPane.ContentPane != null)
		  {
			jRootPane.ContentPane.setBounds(0, i, j, (k < i) ? 0 : (k - i));
		  }
		}

		public virtual void addLayoutComponent(string param1String, Component param1Component)
		{
		}

		public virtual void removeLayoutComponent(Component param1Component)
		{
		}

		public virtual void addLayoutComponent(Component param1Component, object param1Object)
		{
		}

		public virtual float getLayoutAlignmentX(Container param1Container)
		{
			return 0.0F;
		}

		public virtual float getLayoutAlignmentY(Container param1Container)
		{
			return 0.0F;
		}

		public virtual void invalidateLayout(Container param1Container)
		{
		}
	  }

	  private class RootPaneBorder : LineBorder
	  {
		  private readonly CostOSRootPaneUI outerInstance;

		public RootPaneBorder(CostOSRootPaneUI outerInstance) : base(CostOSWindowsLookAndFeel.applicationButtonColor, 1)
		{
			this.outerInstance = outerInstance;
		}

		public virtual void paintBorder(Component param1Component, Graphics param1Graphics, int param1Int1, int param1Int2, int param1Int3, int param1Int4)
		{
		  Color color = param1Graphics.Color;
		  param1Graphics.Color = CostOSWindowsLookAndFeel.applicationButtonColor;
		  for (int i = this.thickness / 2; i < this.thickness; i++)
		  {
			param1Graphics.drawRect(param1Int1 + i, param1Int2 + i, param1Int3 - i - i - 1, param1Int4 - i - i - 1);
		  }
		  param1Graphics.Color = color;
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSRootPaneUI.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
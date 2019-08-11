using System.Collections.Generic;

namespace Desktop.common.org.pushingpixels.flamingo.@internal.ui.common.popup
{
	using CostOSRibbonApplicationMenuPopupPanel = nomitech.common.laf.CostOSRibbonApplicationMenuPopupPanel;
	using JCommandButton = org.pushingpixels.flamingo.api.common.JCommandButton;
	using JPopupPanel = org.pushingpixels.flamingo.api.common.popup.JPopupPanel;
	using PopupPanelManager = org.pushingpixels.flamingo.api.common.popup.PopupPanelManager;
	using JRibbon = org.pushingpixels.flamingo.api.ribbon.JRibbon;
	using JRibbonApplicationMenuPopupPanel = org.pushingpixels.flamingo.@internal.ui.ribbon.appmenu.JRibbonApplicationMenuPopupPanel;
	using FlamingoUtilities = org.pushingpixels.flamingo.@internal.utils.FlamingoUtilities;
	using KeyTipManager = org.pushingpixels.flamingo.@internal.utils.KeyTipManager;

	public class BasicPopupPanelUI : PopupPanelUI
	{
	  protected internal JPopupPanel popupPanel;

	  internal static PopupPanelManager.PopupListener popupPanelManagerListener;

	  public static ComponentUI createUI(JComponent paramJComponent)
	  {
		  return new BasicPopupPanelUI();
	  }

	  public virtual void installUI(JComponent paramJComponent)
	  {
		this.popupPanel = (JPopupPanel)paramJComponent;
		base.installUI(this.popupPanel);
		installDefaults();
		installComponents();
		installListeners();
	  }

	  public virtual void uninstallUI(JComponent paramJComponent)
	  {
		uninstallListeners();
		uninstallComponents();
		uninstallDefaults();
		base.uninstallUI(this.popupPanel);
	  }

	  protected internal virtual void installDefaults()
	  {
		Color color = this.popupPanel.Background;
		if (color == null || color is javax.swing.plaf.UIResource)
		{
		  this.popupPanel.Background = FlamingoUtilities.getColor(Color.lightGray, new string[] {"PopupPanel.background", "Panel.background"});
		}
		Border border = this.popupPanel.Border;
		if (border == null || border is javax.swing.plaf.UIResource)
		{
		  Border border1 = UIManager.getBorder("PopupPanel.border");
		  if (border1 == null)
		  {
			border1 = new BorderUIResource.CompoundBorderUIResource(new LineBorder(FlamingoUtilities.BorderColor), new EmptyBorder(1, 1, 1, 1));
		  }
		  this.popupPanel.Border = border1;
		}
		LookAndFeel.installProperty(this.popupPanel, "opaque", true);
	  }

	  protected internal virtual void installListeners()
	  {
		  initiliazeGlobalListeners();
	  }

	  protected internal virtual void installComponents()
	  {
	  }

	  protected internal virtual void uninstallDefaults()
	  {
		  LookAndFeel.uninstallBorder(this.popupPanel);
	  }

	  protected internal virtual void uninstallListeners()
	  {
	  }

	  protected internal virtual void uninstallComponents()
	  {
	  }

	  protected internal static void initiliazeGlobalListeners()
	  {
		if (popupPanelManagerListener != null)
		{
		  return;
		}
		popupPanelManagerListener = new PopupPanelEscapeDismisser();
		PopupPanelManager.defaultManager().addPopupListener(popupPanelManagerListener);
		new WindowTracker();
	  }

	  protected internal class WindowTracker : PopupPanelManager.PopupListener, AWTEventListener, ComponentListener, WindowListener
	  {
		internal Window grabbedWindow;

		internal IList<PopupPanelManager.PopupInfo> lastPathSelected;

		public WindowTracker()
		{
		  PopupPanelManager popupPanelManager = PopupPanelManager.defaultManager();
		  popupPanelManager.addPopupListener(this);
		  this.lastPathSelected = popupPanelManager.ShownPath;
		  if (this.lastPathSelected.Count != 0)
		  {
			grabWindow(this.lastPathSelected);
		  }
		}

		internal virtual void grabWindow(IList<PopupPanelManager.PopupInfo> param1List)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.awt.Toolkit tk = java.awt.Toolkit.getDefaultToolkit();
		  Toolkit tk = Toolkit.DefaultToolkit;
		  AccessController.doPrivileged(new PrivilegedActionAnonymousInnerClass(this, tk));
		  JComponent jComponent = ((PopupPanelManager.PopupInfo)param1List[0]).PopupOriginator;
		  this.grabbedWindow = (jComponent is Window) ? (Window)jComponent : SwingUtilities.getWindowAncestor(jComponent);
		  if (this.grabbedWindow != null)
		  {
			this.grabbedWindow.addComponentListener(this);
			this.grabbedWindow.addWindowListener(this);
		  }
		}

		private class PrivilegedActionAnonymousInnerClass : PrivilegedAction
		{
			private readonly WindowTracker outerInstance;

			private Toolkit tk;

			public PrivilegedActionAnonymousInnerClass(WindowTracker outerInstance, Toolkit tk)
			{
				this.outerInstance = outerInstance;
				this.tk = tk;
			}

			public object run()
			{
			  tk.addAWTEventListener(outerInstance.outerInstance, 131184L);
			  return null;
			}
		}

		internal virtual void ungrabWindow()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.awt.Toolkit tk = java.awt.Toolkit.getDefaultToolkit();
		  Toolkit tk = Toolkit.DefaultToolkit;
		  AccessController.doPrivileged(new PrivilegedActionAnonymousInnerClass2(this, tk));
		  if (this.grabbedWindow != null)
		  {
			this.grabbedWindow.removeComponentListener(this);
			this.grabbedWindow.removeWindowListener(this);
			this.grabbedWindow = null;
		  }
		}

		private class PrivilegedActionAnonymousInnerClass2 : PrivilegedAction
		{
			private readonly WindowTracker outerInstance;

			private Toolkit tk;

			public PrivilegedActionAnonymousInnerClass2(WindowTracker outerInstance, Toolkit tk)
			{
				this.outerInstance = outerInstance;
				this.tk = tk;
			}

			public object run()
			{
			  tk.removeAWTEventListener(outerInstance.outerInstance);
			  return null;
			}
		}

		public virtual void popupShown(PopupPanelManager.PopupEvent param1PopupEvent)
		{
		  PopupPanelManager popupPanelManager = PopupPanelManager.defaultManager();
		  System.Collections.IList list = popupPanelManager.ShownPath;
		  if (this.lastPathSelected.Count == 0 && list.Count != 0)
		  {
			grabWindow(list);
		  }
		  this.lastPathSelected = list;
		}

		public virtual void popupHidden(PopupPanelManager.PopupEvent param1PopupEvent)
		{
		  PopupPanelManager popupPanelManager = PopupPanelManager.defaultManager();
		  System.Collections.IList list = popupPanelManager.ShownPath;
		  if (this.lastPathSelected.Count != 0 && list.Count == 0)
		  {
			ungrabWindow();
		  }
		  this.lastPathSelected = list;
		}

		public virtual void eventDispatched(AWTEvent param1AWTEvent)
		{
		  bool @bool;
		  if (!(param1AWTEvent is MouseEvent))
		  {
			return;
		  }
		  MouseEvent mouseEvent = (MouseEvent)param1AWTEvent;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.awt.Component src = mouseEvent.getComponent();
		  Component src = mouseEvent.Component;
		  JPopupPanel jPopupPanel = (JPopupPanel)SwingUtilities.getAncestorOfClass(typeof(JPopupPanel), component);
		  if (jPopupPanel == null)
		  {
			CostOSRibbonApplicationMenuPopupPanel.CostOSApplicationMenuContainerPanel costOSApplicationMenuContainerPanel = (CostOSRibbonApplicationMenuPopupPanel.CostOSApplicationMenuContainerPanel)SwingUtilities.getAncestorOfClass(typeof(CostOSRibbonApplicationMenuPopupPanel.CostOSApplicationMenuContainerPanel), component);
			if (costOSApplicationMenuContainerPanel != null || param1AWTEvent.Source.ToString().ToLower().IndexOf("weight") != -1 || component is nomitech.common.laf.CostOSTitlePane)
			{
			  return;
			}
		  }
		  switch (mouseEvent.ID)
		  {
			case 501:
			  @bool = false;
			  if (component is JCommandButton)
			  {
				@bool = ((JCommandButton)component).PopupModel.PopupShowing;
			  }
			  if (!@bool && jPopupPanel != null)
			  {
				PopupPanelManager.defaultManager().hidePopups(jPopupPanel);
				return;
			  }
			  if (component is org.pushingpixels.flamingo.@internal.ui.ribbon.JRibbonTaskToggleButton)
			  {
				JRibbon jRibbon = (JRibbon)SwingUtilities.getAncestorOfClass(typeof(JRibbon), component);
				if (jRibbon != null && FlamingoUtilities.isShowingMinimizedRibbonInPopup(jRibbon))
				{
				  return;
				}
			  }
			  if (!@bool && SwingUtilities.getAncestorOfClass(typeof(javax.swing.plaf.basic.ComboPopup), component) == null)
			  {
				PopupPanelManager.defaultManager().hidePopups(component);
			  }
			  break;
			case 502:
			  if (SwingUtilities.getAncestorOfClass(typeof(javax.swing.plaf.basic.ComboPopup), component) != null)
			  {
				SwingUtilities.invokeLater(() =>
				{
				  PopupPanelManager.defaultManager().hidePopups(src);
				}});
			  break;
			case 507:
			  if (jPopupPanel != null)
			  {
				PopupPanelManager.defaultManager().hidePopups(jPopupPanel);
				return;
			  }
			  PopupPanelManager.defaultManager().hidePopups(component);
			  break;
			  }
		  }

		bool isInPopupPanel(Component param1Component)
		{
		  for (Component component = param1Component; component != null && !(component is java.applet.Applet) && !(component is Window); component = component.Parent)
		  {
			if (component is JPopupPanel)
			{
			  return true;
			}
		  }
		  return false;
		}

		public void componentResized(ComponentEvent param1ComponentEvent)
		{
			PopupPanelManager.defaultManager().hidePopups(null);
		}

		public void componentMoved(ComponentEvent param1ComponentEvent)
		{
			PopupPanelManager.defaultManager().hidePopups(null);
		}

		public void componentShown(ComponentEvent param1ComponentEvent)
		{
			PopupPanelManager.defaultManager().hidePopups(null);
		}

		public void componentHidden(ComponentEvent param1ComponentEvent)
		{
			PopupPanelManager.defaultManager().hidePopups(null);
		}

		public void windowClosing(WindowEvent param1WindowEvent)
		{
			PopupPanelManager.defaultManager().hidePopups(null);
		}

		public void windowClosed(WindowEvent param1WindowEvent)
		{
			PopupPanelManager.defaultManager().hidePopups(null);
		}

		public void windowIconified(WindowEvent param1WindowEvent)
		{
			PopupPanelManager.defaultManager().hidePopups(null);
		}

		public void windowDeactivated(WindowEvent param1WindowEvent)
		{
			PopupPanelManager.defaultManager().hidePopups(null);
		}

		public void windowOpened(WindowEvent param1WindowEvent)
		{
		}

		public void windowDeiconified(WindowEvent param1WindowEvent)
		{
		}

		public void windowActivated(WindowEvent param1WindowEvent)
		{
		}
		}

	  protected internal class PopupPanelEscapeDismisser : PopupPanelManager.PopupListener
	  {
		internal ActionMap newActionMap;

		internal InputMap newInputMap;

		internal IList<PopupPanelManager.PopupInfo> outerInstance.lastPathSelected;

		internal JRootPane tracedRootPane;

		public PopupPanelEscapeDismisser()
		{
		  PopupPanelManager popupPanelManager = PopupPanelManager.defaultManager();
		  this.lastPathSelected = popupPanelManager.ShownPath;
		  if (this.lastPathSelected.size() != 0)
		  {
			traceRootPane(this.lastPathSelected);
		  }
		}

		public virtual void popupHidden(PopupPanelManager.PopupEvent param1PopupEvent)
		{
		  PopupPanelManager popupPanelManager = PopupPanelManager.defaultManager();
		  System.Collections.IList list = popupPanelManager.ShownPath;
		  if (this.lastPathSelected.size() != 0 && list.Count == 0)
		  {
			untraceRootPane();
		  }
		  this.lastPathSelected = list;
		}

		internal virtual void untraceRootPane()
		{
		  if (this.tracedRootPane != null)
		  {
			removeUIActionMap(this.tracedRootPane, this.newActionMap);
			removeUIInputMap(this.tracedRootPane, this.newInputMap);
		  }
		}

		public virtual void popupShown(PopupPanelManager.PopupEvent param1PopupEvent)
		{
		  PopupPanelManager popupPanelManager = PopupPanelManager.defaultManager();
		  System.Collections.IList list = popupPanelManager.ShownPath;
		  if (this.lastPathSelected.size() == 0 && list.Count != 0)
		  {
			traceRootPane(list);
		  }
		  this.lastPathSelected = list;
		}

		internal virtual void traceRootPane(IList<PopupPanelManager.PopupInfo> param1List)
		{
		  JComponent jComponent = ((PopupPanelManager.PopupInfo)param1List[0]).PopupOriginator;
		  this.tracedRootPane = SwingUtilities.getRootPane(jComponent);
		  if (this.tracedRootPane != null)
		  {
			this.newInputMap = new ComponentInputMapUIResource(this.tracedRootPane);
			this.newInputMap.put(KeyStroke.getKeyStroke(27, 0), "hidePopupPanel");
			this.newActionMap = new ActionMapUIResource();
			this.newActionMap.put("hidePopupPanel", new AbstractActionAnonymousInnerClass(this));
			addUIInputMap(this.tracedRootPane, this.newInputMap);
			addUIActionMap(this.tracedRootPane, this.newActionMap);
		  }
		}

		private class AbstractActionAnonymousInnerClass : AbstractAction
		{
			private readonly PopupPanelEscapeDismisser outerInstance;

			public AbstractActionAnonymousInnerClass(PopupPanelEscapeDismisser outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public void actionPerformed(ActionEvent param2ActionEvent)
			{
			  System.Collections.IList list = PopupPanelManager.defaultManager().ShownPath;
			  if (list.Count > 0)
			  {
				PopupPanelManager.PopupInfo popupInfo = (PopupPanelManager.PopupInfo)list[list.Count - 1];
				if (popupInfo.PopupPanel is JRibbonApplicationMenuPopupPanel)
				{
				  JRibbonApplicationMenuPopupPanel jRibbonApplicationMenuPopupPanel = (JRibbonApplicationMenuPopupPanel)popupInfo.PopupPanel;
				  KeyTipManager.KeyTipChain keyTipChain = KeyTipManager.defaultManager().CurrentlyShownKeyTipChain;
				  if (keyTipChain != null && keyTipChain.chainParentComponent == jRibbonApplicationMenuPopupPanel.PanelLevel2)
				  {
					return;
				  }
				}
			  }
			  PopupPanelManager.defaultManager().hideLastPopup();
			}
		}

		internal virtual void addUIInputMap(JComponent param1JComponent, InputMap param1InputMap)
		{
		  InputMap inputMap1 = null;
		  InputMap inputMap2;
		  for (inputMap2 = param1JComponent.getInputMap(2); inputMap2 != null && !(inputMap2 is javax.swing.plaf.UIResource); inputMap2 = inputMap2.Parent)
		  {
			inputMap1 = inputMap2;
		  }
		  if (inputMap1 == null)
		  {
			param1JComponent.setInputMap(2, param1InputMap);
		  }
		  else
		  {
			inputMap1.Parent = param1InputMap;
		  }
		  param1InputMap.Parent = inputMap2;
		}

		internal virtual void addUIActionMap(JComponent param1JComponent, ActionMap param1ActionMap)
		{
		  ActionMap actionMap1 = null;
		  ActionMap actionMap2;
		  for (actionMap2 = param1JComponent.ActionMap; actionMap2 != null && !(actionMap2 is javax.swing.plaf.UIResource); actionMap2 = actionMap2.Parent)
		  {
			actionMap1 = actionMap2;
		  }
		  if (actionMap1 == null)
		  {
			param1JComponent.ActionMap = param1ActionMap;
		  }
		  else
		  {
			actionMap1.Parent = param1ActionMap;
		  }
		  param1ActionMap.Parent = actionMap2;
		}

		internal virtual void removeUIInputMap(JComponent param1JComponent, InputMap param1InputMap)
		{
		  InputMap inputMap1 = null;
		  for (InputMap inputMap2 = param1JComponent.getInputMap(2); inputMap2 != null; inputMap2 = inputMap2.Parent)
		  {
			if (inputMap2 == param1InputMap)
			{
			  if (inputMap1 == null)
			  {
				param1JComponent.setInputMap(2, param1InputMap.Parent);
				break;
			  }
			  inputMap1.Parent = param1InputMap.Parent;
			  break;
			}
			inputMap1 = inputMap2;
		  }
		}

		internal virtual void removeUIActionMap(JComponent param1JComponent, ActionMap param1ActionMap)
		{
		  ActionMap actionMap1 = null;
		  for (ActionMap actionMap2 = param1JComponent.ActionMap; actionMap2 != null; actionMap2 = actionMap2.Parent)
		  {
			if (actionMap2 == param1ActionMap)
			{
			  if (actionMap1 == null)
			  {
				param1JComponent.ActionMap = param1ActionMap.Parent;
				break;
			  }
			  actionMap1.Parent = param1ActionMap.Parent;
			  break;
			}
			actionMap1 = actionMap2;
		  }
		}
	  }
	  }


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\org\pushingpixels\flamingo\interna\\ui\common\popup\BasicPopupPanelUI.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
	}
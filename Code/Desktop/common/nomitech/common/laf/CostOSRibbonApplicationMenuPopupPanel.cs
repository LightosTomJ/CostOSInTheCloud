using System;

namespace Desktop.common.nomitech.common.laf
{
	using AbstractCommandButton = org.pushingpixels.flamingo.api.common.AbstractCommandButton;
	using CommandButtonDisplayState = org.pushingpixels.flamingo.api.common.CommandButtonDisplayState;
	using CommandButtonLayoutManager = org.pushingpixels.flamingo.api.common.CommandButtonLayoutManager;
	using JCommandButton = org.pushingpixels.flamingo.api.common.JCommandButton;
	using JCommandMenuButton = org.pushingpixels.flamingo.api.common.JCommandMenuButton;
	using RolloverActionListener = org.pushingpixels.flamingo.api.common.RolloverActionListener;
	using EmptyResizableIcon = org.pushingpixels.flamingo.api.common.icon.EmptyResizableIcon;
	using ResizableIcon = org.pushingpixels.flamingo.api.common.icon.ResizableIcon;
	using JPopupPanel = org.pushingpixels.flamingo.api.common.popup.JPopupPanel;
	using RibbonApplicationMenu = org.pushingpixels.flamingo.api.ribbon.RibbonApplicationMenu;
	using RibbonApplicationMenuEntryPrimary = org.pushingpixels.flamingo.api.ribbon.RibbonApplicationMenuEntryPrimary;
	using CommandButtonLayoutManagerMenuTileLevel1 = org.pushingpixels.flamingo.@internal.ui.ribbon.appmenu.CommandButtonLayoutManagerMenuTileLevel1;
	using JRibbonApplicationMenuButton = org.pushingpixels.flamingo.@internal.ui.ribbon.appmenu.JRibbonApplicationMenuButton;
	using FlamingoUtilities = org.pushingpixels.flamingo.@internal.utils.FlamingoUtilities;

	public class CostOSRibbonApplicationMenuPopupPanel : JPopupPanel
	{
	  private static int firstLevelMenuWidth = -1;

	  private static readonly Color PRIMARY_MENU_COLOR = CostOSWindowsLookAndFeel.applicationButtonColor;

	  private static readonly Color SECONDARY_MENU_COLOR = CostOSWindowsLookAndFeel.ribbonAppMenuSecondaryPanelBackground;

	  private static readonly Color SEPERATOR_COLOR = CostOSWindowsLookAndFeel.ribbonAppMenuButtonSeperatorColor;

	  protected internal JPanel panelLevel1;

	  protected internal JPanel panelLevel2;

	  protected internal JPanel footerPanel;

	  protected internal RibbonApplicationMenuEntryPrimary.PrimaryRolloverCallback defaultPrimaryCallback;

	  protected internal static readonly CommandButtonDisplayState MENU_TILE_LEVEL_1 = new CommandButtonDisplayStateAnonymousInnerClass();

	  private class CommandButtonDisplayStateAnonymousInnerClass : CommandButtonDisplayState
	  {
		  public CommandButtonDisplayStateAnonymousInnerClass() : base("Ribbon application menu tile level 1", 32)
		  {
		  }

		  public CommandButtonLayoutManager createLayoutManager(AbstractCommandButton param1AbstractCommandButton)
		  {
			  return new CommandButtonLayoutManagerMenuTileLevel1();
		  }
	  }

	  public CostOSRibbonApplicationMenuPopupPanel(JRibbonApplicationMenuButton paramJRibbonApplicationMenuButton, RibbonApplicationMenu paramRibbonApplicationMenu)
	  {
		Layout = new BorderLayout();
		Border = BorderFactory.createEmptyBorder();
		if (paramRibbonApplicationMenu.DefaultCallback == null)
		{
		  this.defaultPrimaryCallback = new PrimaryRolloverCallbackAnonymousInnerClass(this);
		}
		else
		{
		  this.defaultPrimaryCallback = paramRibbonApplicationMenu.DefaultCallback;
		}
		CostOSApplicationMenuContainerPanel costOSApplicationMenuContainerPanel = new CostOSApplicationMenuContainerPanel(new BorderLayout());
		costOSApplicationMenuContainerPanel.Background = SECONDARY_MENU_COLOR;
		JFrame jFrame = CostOSRootPaneUI.Resolver.MainFrame;
		costOSApplicationMenuContainerPanel.MinimumSize = new Dimension(jFrame.Width - 2, jFrame.Height - 55);
		costOSApplicationMenuContainerPanel.PreferredSize = new Dimension(jFrame.Width - 2, jFrame.Height - 55);
		costOSApplicationMenuContainerPanel.MaximumSize = new Dimension(jFrame.Width - 2, jFrame.Height - 55);
		this.panelLevel1 = new JPanel();
		this.panelLevel1.Layout = new LayoutManagerAnonymousInnerClass(this);
		this.panelLevel1.Background = PRIMARY_MENU_COLOR;
		this.panelLevel1.Border = BorderFactory.createEmptyBorder();
		if (paramRibbonApplicationMenu != null)
		{
		  System.Collections.IList list = paramRibbonApplicationMenu.PrimaryEntries;
		  if (list != null && list.Count > 0)
		  {
			EmptyResizableIcon emptyResizableIcon = new EmptyResizableIcon(16);
			for (sbyte b = 0; b < list.Count; b++)
			{
			  System.Collections.IList list1 = (System.Collections.IList)list[b];
			  foreach (RibbonApplicationMenuEntryPrimary ribbonApplicationMenuEntryPrimary in list1)
			  {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final JCommandAppMenuButton commandButton = new JCommandAppMenuButton(ribbonApplicationMenuEntryPrimary.getText(), emptyResizableIcon);
				JCommandAppMenuButton commandButton = new JCommandAppMenuButton(ribbonApplicationMenuEntryPrimary.Text, emptyResizableIcon);
				jCommandAppMenuButton.CommandButtonKind = ribbonApplicationMenuEntryPrimary.EntryKind;
				jCommandAppMenuButton.addActionListener(ribbonApplicationMenuEntryPrimary.MainActionListener);
				if (ribbonApplicationMenuEntryPrimary.RolloverCallback != null)
				{
				  jCommandAppMenuButton.addRolloverActionListener(new RolloverActionListenerAnonymousInnerClass(this));
				}
				else if (ribbonApplicationMenuEntryPrimary.SecondaryGroupCount == 0)
				{
				  jCommandAppMenuButton.addRolloverActionListener(new RolloverActionListenerAnonymousInnerClass2(this));
				}
				else
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.pushingpixels.flamingo.api.ribbon.RibbonApplicationMenuEntryPrimary.PrimaryRolloverCallback coreCallback = new org.pushingpixels.flamingo.api.ribbon.RibbonApplicationMenuEntryPrimary.PrimaryRolloverCallback()
				  RibbonApplicationMenuEntryPrimary.PrimaryRolloverCallback coreCallback = new PrimaryRolloverCallbackAnonymousInnerClass2(this, commandButton);
				  jCommandAppMenuButton.addRolloverActionListener(new RolloverActionListenerAnonymousInnerClass3(this, commandButton, coreCallback));
				}
				jCommandAppMenuButton.DisplayState = MENU_TILE_LEVEL_1;
				jCommandAppMenuButton.HorizontalAlignment = 10;
				jCommandAppMenuButton.PopupOrientationKind = JCommandButton.CommandButtonPopupOrientationKind.SIDEWARD;
				jCommandAppMenuButton.Enabled = ribbonApplicationMenuEntryPrimary.Enabled;
				jCommandAppMenuButton.Foreground = CostOSWindowsLookAndFeel.ribbonAppMenuButtonForegroundColor;
				this.panelLevel1.add(jCommandAppMenuButton);
			  }
			  if (b < list.Count - 1)
			  {
				JPopupMenu.Separator separator = new SeparatorAnonymousInnerClass(this);
				this.panelLevel1.add(separator);
			  }
			}
		  }
		}
		costOSApplicationMenuContainerPanel.add(this.panelLevel1, "West");
		this.panelLevel2 = new JPanel();
		this.panelLevel2.Background = SECONDARY_MENU_COLOR;
		this.panelLevel2.Border = new BorderAnonymousInnerClass(this);
		this.panelLevel2.PreferredSize = new Dimension(30 * FlamingoUtilities.getFont(this.panelLevel1, new string[] {"Ribbon.font", "Button.font", "Panel.font"}).Size - 30, 10);
		this.defaultPrimaryCallback.menuEntryActivated(this.panelLevel2);
		costOSApplicationMenuContainerPanel.add(this.panelLevel2, "Center");
		add(costOSApplicationMenuContainerPanel, "Center");
		this.panelLevel1.doLayout();
		firstLevelMenuWidth = (int)this.panelLevel1.PreferredSize.Width;
	  }

	  private class PrimaryRolloverCallbackAnonymousInnerClass : RibbonApplicationMenuEntryPrimary.PrimaryRolloverCallback
	  {
		  private readonly CostOSRibbonApplicationMenuPopupPanel outerInstance;

		  public PrimaryRolloverCallbackAnonymousInnerClass(CostOSRibbonApplicationMenuPopupPanel outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public void menuEntryActivated(JPanel param1JPanel)
		  {
			param1JPanel.removeAll();
			param1JPanel.revalidate();
			param1JPanel.repaint();
		  }
	  }

	  private class LayoutManagerAnonymousInnerClass : LayoutManager
	  {
		  private readonly CostOSRibbonApplicationMenuPopupPanel outerInstance;

		  public LayoutManagerAnonymousInnerClass(CostOSRibbonApplicationMenuPopupPanel outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public void addLayoutComponent(string param1String, Component param1Component)
		  {
		  }

		  public void removeLayoutComponent(Component param1Component)
		  {
		  }

		  public Dimension preferredLayoutSize(Container param1Container)
		  {
			int i = 0;
			int j = 0;
			for (sbyte b = 0; b < param1Container.ComponentCount; b++)
			{
			  Dimension dimension = param1Container.getComponent(b).PreferredSize;
			  i += dimension.height;
			  j = Math.Max(j, dimension.width);
			}
			Insets insets = param1Container.Insets;
			return new Dimension(j + insets.left + insets.right, i + insets.top + insets.bottom);
		  }

		  public Dimension minimumLayoutSize(Container param1Container)
		  {
			  return preferredLayoutSize(param1Container);
		  }

		  public void layoutContainer(Container param1Container)
		  {
			Insets insets = param1Container.Insets;
			int i = insets.top;
			for (sbyte b = 0; b < param1Container.ComponentCount; b++)
			{
			  Component component = param1Container.getComponent(b);
			  Dimension dimension = component.PreferredSize;
			  component.setBounds(insets.left, i, param1Container.Width - insets.left - insets.right, dimension.height);
			  i += dimension.height;
			}
		  }
	  }

	  private class RolloverActionListenerAnonymousInnerClass : RolloverActionListener
	  {
		  private readonly CostOSRibbonApplicationMenuPopupPanel outerInstance;

		  public RolloverActionListenerAnonymousInnerClass(CostOSRibbonApplicationMenuPopupPanel outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public void actionPerformed(ActionEvent param1ActionEvent)
		  {
			  menuEntry.RolloverCallback.menuEntryActivated(outerInstance.panelLevel2);
		  }
	  }

	  private class RolloverActionListenerAnonymousInnerClass2 : RolloverActionListener
	  {
		  private readonly CostOSRibbonApplicationMenuPopupPanel outerInstance;

		  public RolloverActionListenerAnonymousInnerClass2(CostOSRibbonApplicationMenuPopupPanel outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public void actionPerformed(ActionEvent param1ActionEvent)
		  {
			  outerInstance.defaultPrimaryCallback.menuEntryActivated(outerInstance.panelLevel2);
		  }
	  }

	  private class PrimaryRolloverCallbackAnonymousInnerClass2 : RibbonApplicationMenuEntryPrimary.PrimaryRolloverCallback
	  {
		  private readonly CostOSRibbonApplicationMenuPopupPanel outerInstance;

		  private Desktop.common.nomitech.common.laf.CostOSRibbonApplicationMenuPopupPanel.JCommandAppMenuButton commandButton;

		  public PrimaryRolloverCallbackAnonymousInnerClass2(CostOSRibbonApplicationMenuPopupPanel outerInstance, Desktop.common.nomitech.common.laf.CostOSRibbonApplicationMenuPopupPanel.JCommandAppMenuButton commandButton)
		  {
			  this.outerInstance = outerInstance;
			  this.commandButton = commandButton;
		  }

		  public void menuEntryActivated(JPanel param1JPanel)
		  {
			param1JPanel.removeAll();
			param1JPanel.Layout = new BorderLayout();
			CostOSRibbonApplicationMenuPopupPanelSecondary costOSRibbonApplicationMenuPopupPanelSecondary = new CostOSRibbonApplicationMenuPopupPanelSecondaryAnonymousInnerClass(this, menuEntry);
			JScrollPane jScrollPane = new JScrollPane(costOSRibbonApplicationMenuPopupPanelSecondary, 20, 31);
			jScrollPane.Border = BorderFactory.createEmptyBorder();
			jScrollPane.Viewport.Background = SECONDARY_MENU_COLOR;
			jScrollPane.Background = SECONDARY_MENU_COLOR;
			Dimension dimension = costOSRibbonApplicationMenuPopupPanelSecondary.PreferredSize;
			costOSRibbonApplicationMenuPopupPanelSecondary.PreferredSize = new Dimension((param1JPanel.PreferredSize).width - (jScrollPane.VerticalScrollBar.PreferredSize).width, dimension.height);
			param1JPanel.Background = SECONDARY_MENU_COLOR;
			param1JPanel.add(jScrollPane, "Center");
			param1JPanel.revalidate();
		  }

		  private class CostOSRibbonApplicationMenuPopupPanelSecondaryAnonymousInnerClass : CostOSRibbonApplicationMenuPopupPanelSecondary
		  {
			  private readonly PrimaryRolloverCallbackAnonymousInnerClass2 outerInstance;

			  public CostOSRibbonApplicationMenuPopupPanelSecondaryAnonymousInnerClass(PrimaryRolloverCallbackAnonymousInnerClass2 outerInstance, UnknownType menuEntry) : base(menuEntry)
			  {
				  this.outerInstance = outerInstance;
			  }

			  public void removeNotify()
			  {
				base.removeNotify();
				outerInstance.commandButton.PopupModel.PopupShowing = false;
			  }
		  }
	  }

	  private class RolloverActionListenerAnonymousInnerClass3 : RolloverActionListener
	  {
		  private readonly CostOSRibbonApplicationMenuPopupPanel outerInstance;

		  private Desktop.common.nomitech.common.laf.CostOSRibbonApplicationMenuPopupPanel.JCommandAppMenuButton commandButton;
		  private RibbonApplicationMenuEntryPrimary.PrimaryRolloverCallback coreCallback;

		  public RolloverActionListenerAnonymousInnerClass3(CostOSRibbonApplicationMenuPopupPanel outerInstance, Desktop.common.nomitech.common.laf.CostOSRibbonApplicationMenuPopupPanel.JCommandAppMenuButton commandButton, RibbonApplicationMenuEntryPrimary.PrimaryRolloverCallback coreCallback)
		  {
			  this.outerInstance = outerInstance;
			  this.commandButton = commandButton;
			  this.coreCallback = coreCallback;
		  }

		  public void actionPerformed(ActionEvent param1ActionEvent)
		  {
			coreCallback.menuEntryActivated(outerInstance.panelLevel2);
			commandButton.PopupModel.PopupShowing = true;
		  }
	  }

	  private class SeparatorAnonymousInnerClass : JPopupMenu.Separator
	  {
		  private readonly CostOSRibbonApplicationMenuPopupPanel outerInstance;

		  public SeparatorAnonymousInnerClass(CostOSRibbonApplicationMenuPopupPanel outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public void paintComponent(Graphics param1Graphics)
		  {
			param1Graphics.Color = SEPERATOR_COLOR;
			param1Graphics.fillRect(26, 0, Width - 55, 1);
		  }
	  }

	  private class BorderAnonymousInnerClass : Border
	  {
		  private readonly CostOSRibbonApplicationMenuPopupPanel outerInstance;

		  public BorderAnonymousInnerClass(CostOSRibbonApplicationMenuPopupPanel outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  public Insets getBorderInsets(Component param1Component)
		  {
			  return new Insets(0, 1, 0, 0);
		  }

		  public bool BorderOpaque
		  {
			  get
			  {
				  return true;
			  }
		  }

		  public void paintBorder(Component param1Component, Graphics param1Graphics, int param1Int1, int param1Int2, int param1Int3, int param1Int4)
		  {
			param1Graphics.Color = PRIMARY_MENU_COLOR;
			param1Graphics.drawLine(param1Int1, param1Int2, param1Int1, param1Int2 + param1Int4);
		  }
	  }

	  public static int FirstLevelMenuWidth
	  {
		  get
		  {
			  return firstLevelMenuWidth + 1;
		  }
	  }

	  protected internal virtual void paintComponent(Graphics paramGraphics)
	  {
		base.paintComponent(paramGraphics);
		Graphics2D graphics2D = (Graphics2D)paramGraphics;
		graphics2D.Paint = PRIMARY_MENU_COLOR;
		graphics2D.fillRect(0, 0, Width, Height);
	  }

	  public class CostOSApplicationMenuContainerPanel : JPanel
	  {
		public CostOSApplicationMenuContainerPanel(BorderLayout param1BorderLayout) : base(param1BorderLayout)
		{
		}
	  }

	  public class JCommandFooterButton : JCommandButton
	  {
		public JCommandFooterButton(string param1String, ResizableIcon param1ResizableIcon) : base(param1String, param1ResizableIcon)
		{
		}
	  }

	  public class JCommandAppMenuButton : JCommandMenuButton
	  {
		public JCommandAppMenuButton(string param1String, ResizableIcon param1ResizableIcon) : base(param1String, param1ResizableIcon)
		{
		}
	  }

	  protected internal class LineBorder : AbstractBorder
	  {
		internal Color outer;

		internal Color inner;

		internal Insets padding;

		public LineBorder(Color param1Color1, Color param1Color2) : this(param1Color1, param1Color2, new Insets(0, 0, 0, 0))
		{
		}

		public LineBorder(Color param1Color1, Color param1Color2, Insets param1Insets)
		{
		  this.outer = param1Color1;
		  this.inner = param1Color2;
		  this.padding = param1Insets;
		}

		public virtual Insets getBorderInsets(Component param1Component)
		{
			return getBorderInsets(param1Component, base.getBorderInsets(param1Component));
		}

		public virtual Insets getBorderInsets(Component param1Component, Insets param1Insets)
		{
		  param1Insets.left = 2 + this.padding.left;
		  param1Insets.top = 2 + this.padding.top;
		  param1Insets.right = 2 + this.padding.right;
		  param1Insets.bottom = 2 + this.padding.bottom;
		  return param1Insets;
		}

		public virtual void paintBorder(Component param1Component, Graphics param1Graphics, int param1Int1, int param1Int2, int param1Int3, int param1Int4)
		{
		  param1Graphics.Color = this.outer;
		  param1Graphics.drawRect(param1Int1, param1Int2, param1Int3 - 1, param1Int4 - 1);
		  param1Graphics.Color = this.inner;
		  param1Graphics.drawRect(param1Int1 + 1, param1Int2 + 1, param1Int3 - 3, param1Int4 - 3);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSRibbonApplicationMenuPopupPanel.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
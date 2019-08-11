using System;

namespace Desktop.common.nomitech.common.laf
{
	using CollapsedBandIcon = org.officelaf.ribbon.CollapsedBandIcon;
	using OfficeCommandButtonUI = org.officelaf.ribbon.OfficeCommandButtonUI;
	using AbstractCommandButton = org.pushingpixels.flamingo.api.common.AbstractCommandButton;
	using JCommandButton = org.pushingpixels.flamingo.api.common.JCommandButton;
	using JPopupPanel = org.pushingpixels.flamingo.api.common.popup.JPopupPanel;
	using PopupPanelCallback = org.pushingpixels.flamingo.api.common.popup.PopupPanelCallback;
	using AbstractRibbonBand = org.pushingpixels.flamingo.api.ribbon.AbstractRibbonBand;
	using RibbonBandResizePolicy = org.pushingpixels.flamingo.api.ribbon.resize.RibbonBandResizePolicy;
	using AbstractBandControlPanel = org.pushingpixels.flamingo.@internal.ui.ribbon.AbstractBandControlPanel;
	using BasicRibbonBandUI = org.pushingpixels.flamingo.@internal.ui.ribbon.BasicRibbonBandUI;

	public class CostOSRibbonBandUI : BasicRibbonBandUI
	{
	  protected internal static readonly Color borderColor1 = CostOSWindowsLookAndFeel.ribbonBorderColor;

	  protected internal static readonly Color borderColor2 = Color.blue;

	  protected internal static readonly Color highlightColor = CostOSWindowsLookAndFeel.ribbonTaksAreaBackground;

	  protected internal static readonly Color titleBg1 = CostOSWindowsLookAndFeel.ribbonTaksAreaBackground;

	  protected internal static readonly Color titleBg2 = CostOSWindowsLookAndFeel.ribbonTaksAreaBackground;

	  protected internal static readonly Color titleBg1_over = CostOSWindowsLookAndFeel.ribbonTaksAreaBackground;

	  protected internal static readonly Color titleBg2_over = CostOSWindowsLookAndFeel.ribbonTaksAreaBackground;

	  protected internal static readonly Color titleTextColor = CostOSCommandButtonPainter.TEXT_COLOR;

	  internal bool isUnderMouse = false;

	  public static ComponentUI createUI(JComponent paramJComponent)
	  {
		  return new CostOSRibbonBandUI();
	  }

	  protected internal virtual void installDefaults()
	  {
		base.installDefaults();
		this.ribbonBand.Opaque = false;
		this.ribbonBand.Foreground = new ColorUIResource(Color.white);
	  }

	  protected internal virtual void installComponents()
	  {
		base.installComponents();
		CollapsedBandIcon collapsedBandIcon = new CollapsedBandIcon(this.ribbonBand.Icon);
		this.collapsedButton.UI = new CollapsedRibbonBandButtonUI();
		this.collapsedButton.Icon = collapsedBandIcon;
		this.collapsedButton.DisabledIcon = collapsedBandIcon;
	  }

	  protected internal virtual void paintBandBackground(Graphics paramGraphics, Rectangle paramRectangle)
	  {
		if (this.ribbonBand.CurrentResizePolicy is org.pushingpixels.flamingo.api.ribbon.resize.IconRibbonBandResizePolicy)
		{
		  return;
		}
		Graphics2D graphics2D = (Graphics2D)paramGraphics.create();
		graphics2D.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
		int i = paramRectangle.y;
		int j = paramRectangle.x;
		int k = paramRectangle.width;
		int m = paramRectangle.height;
		int n = i + m - 1;
		int i1 = j + k - 2;
		int i2 = i1 - 3;
		int i3 = j + 3;
		int i4 = i + m - 2;
		int i5 = i4 - 3;
		int i6 = i + 3;
		if (this.isUnderMouse)
		{
		  graphics2D.Color = highlightColor;
		  graphics2D.fillRect(j + 1, i + 1, k - 3, m - 3);
		}
		graphics2D.Color = borderColor1;
		graphics2D.drawLine(i1, i6 + 3, i1, i5);
		graphics2D.dispose();
	  }

	  protected internal virtual void paintBandTitle(Graphics paramGraphics, Rectangle paramRectangle, string paramString)
	  {
		this.ribbonBand.Foreground = titleTextColor;
		base.paintBandTitle(paramGraphics, paramRectangle, paramString);
	  }

	  public virtual void trackMouseCrossing(bool paramBoolean)
	  {
		base.trackMouseCrossing(paramBoolean);
		this.isUnderMouse = paramBoolean;
	  }

	  protected internal virtual void paintBandTitleBackground(Graphics paramGraphics, Rectangle paramRectangle, string paramString)
	  {
	  }

	  protected internal virtual LayoutManager createLayoutManager()
	  {
		  return new RibbonBandLayout(this, null);
	  }

	  public class CollapsedRibbonBandButtonUI : OfficeCommandButtonUI
	  {
		protected internal CostOSCommandButtonPainter painter;

		protected internal virtual void installDefaults()
		{
		  base.installDefaults();
		  this.painter = new CostOSCommandButtonPainter(this.commandButton);
		}

		protected internal virtual void paintButtonBackground(Graphics param1Graphics, Rectangle param1Rectangle)
		{
			this.painter.paintCollapsedBandButtonBackground(param1Graphics, param1Rectangle);
		}

		protected internal virtual bool PaintingBackground
		{
			get
			{
				return true;
			}
		}
	  }

	  private class RibbonBandLayout : LayoutManager
	  {
		  private readonly CostOSRibbonBandUI outerInstance;

		internal RibbonBandLayout(CostOSRibbonBandUI outerInstance)
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
		  AbstractBandControlPanel abstractBandControlPanel = outerInstance.ribbonBand.ControlPanel;
		  bool @bool = (abstractBandControlPanel == null || !abstractBandControlPanel.Visible) ? 1 : 0;
		  int i = @bool ? (this.this$0.collapsedButton.PreferredSize).width : (abstractBandControlPanel.PreferredSize).width;
		  int j = (@bool ? (this.this$0.collapsedButton.PreferredSize).height : (abstractBandControlPanel.PreferredSize).height) + outerInstance.BandTitleHeight;
		  return new Dimension(i + 2 + (!@bool ? (insets.left + insets.right) : 0), j + insets.top + insets.bottom);
		}

		public virtual Dimension minimumLayoutSize(Container param1Container)
		{
		  Insets insets = param1Container.Insets;
		  AbstractBandControlPanel abstractBandControlPanel = outerInstance.ribbonBand.ControlPanel;
		  bool @bool = (abstractBandControlPanel == null || !abstractBandControlPanel.Visible) ? 1 : 0;
		  int i = @bool ? (this.this$0.collapsedButton.MinimumSize).width : (abstractBandControlPanel.MinimumSize).width;
		  int j = @bool ? ((this.this$0.collapsedButton.MinimumSize).height + outerInstance.BandTitleHeight) : ((abstractBandControlPanel.MinimumSize).height + outerInstance.BandTitleHeight);
		  return new Dimension(i + 2 + (!@bool ? (insets.left + insets.right) : 0), j + insets.top + insets.bottom);
		}

		public virtual void layoutContainer(Container param1Container)
		{
		  if (!param1Container.Visible)
		  {
			return;
		  }
		  Insets insets = param1Container.Insets;
		  int i = param1Container.Height - insets.top - insets.bottom;
		  RibbonBandResizePolicy ribbonBandResizePolicy = ((AbstractRibbonBand)param1Container).CurrentResizePolicy;
		  if (ribbonBandResizePolicy is org.pushingpixels.flamingo.api.ribbon.resize.IconRibbonBandResizePolicy)
		  {
			outerInstance.collapsedButton.Visible = true;
			int j = (this.this$0.collapsedButton.PreferredSize).width;
			outerInstance.collapsedButton.setBounds(0, 0, param1Container.Width, param1Container.Height);
			if (outerInstance.collapsedButton.PopupCallback == null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.pushingpixels.flamingo.api.ribbon.AbstractRibbonBand popupBand = CostOSRibbonBandUI.this.ribbonBand.cloneBand();
			  AbstractRibbonBand popupBand = outerInstance.ribbonBand.cloneBand();
			  abstractRibbonBand.ControlPanel = outerInstance.ribbonBand.ControlPanel;
			  System.Collections.IList list = outerInstance.ribbonBand.ResizePolicies;
			  abstractRibbonBand.ResizePolicies = list;
			  RibbonBandResizePolicy ribbonBandResizePolicy1 = (RibbonBandResizePolicy)list[0];
			  abstractRibbonBand.CurrentResizePolicy = ribbonBandResizePolicy1;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.awt.Dimension size = new java.awt.Dimension(4 + ribbonBandResizePolicy1.getPreferredWidth(i, 4), insets.top + insets.bottom + Math.max(param1Container.getHeight(), (this.this$0.ribbonBand.getControlPanel().getPreferredSize()).height + CostOSRibbonBandUI.this.getBandTitleHeight()));
			  Dimension size = new Dimension(4 + ribbonBandResizePolicy1.getPreferredWidth(i, 4), insets.top + insets.bottom + Math.Max(param1Container.Height, (this.this$0.ribbonBand.ControlPanel.PreferredSize).height + outerInstance.BandTitleHeight));
			  outerInstance.collapsedButton.PopupCallback = new PopupPanelCallbackAnonymousInnerClass(this, popupBand, size);
			  outerInstance.ribbonBand.ControlPanel = null;
			  outerInstance.ribbonBand.PopupRibbonBand = abstractRibbonBand;
			}
			if (outerInstance.expandButton != null)
			{
			  outerInstance.expandButton.setBounds(0, 0, 0, 0);
			}
			return;
		  }
		  if (outerInstance.collapsedButton.Visible)
		  {
			BasicRibbonBandUI.CollapsedButtonPopupPanel collapsedButtonPopupPanel = (outerInstance.collapsedButton.PopupCallback != null) ? (BasicRibbonBandUI.CollapsedButtonPopupPanel)outerInstance.collapsedButton.PopupCallback.getPopupPanel(outerInstance.collapsedButton) : null;
			if (collapsedButtonPopupPanel != null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.pushingpixels.flamingo.api.ribbon.AbstractRibbonBand popupBand = (org.pushingpixels.flamingo.api.ribbon.AbstractRibbonBand)collapsedButtonPopupPanel.removeComponent();
			  AbstractRibbonBand popupBand = (AbstractRibbonBand)collapsedButtonPopupPanel.removeComponent();
			  outerInstance.ribbonBand.ControlPanel = abstractRibbonBand.ControlPanel;
			  outerInstance.ribbonBand.PopupRibbonBand = null;
			  outerInstance.collapsedButton.PopupCallback = null;
			}
		  }
		  outerInstance.collapsedButton.Visible = false;
		  AbstractBandControlPanel abstractBandControlPanel = outerInstance.ribbonBand.ControlPanel;
		  abstractBandControlPanel.Visible = true;
		  abstractBandControlPanel.setBounds(insets.left, insets.top, param1Container.Width - insets.left - insets.right, param1Container.Height - outerInstance.BandTitleHeight - insets.top - insets.bottom);
		  abstractBandControlPanel.doLayout();
		  if (outerInstance.expandButton != null)
		  {
			int j = (this.this$0.expandButton.PreferredSize).width;
			int k = (this.this$0.expandButton.PreferredSize).height;
			int m = outerInstance.BandTitleHeight - 4;
			if (k > m)
			{
			  k = m;
			}
			int n = param1Container.Height - (outerInstance.BandTitleHeight - k) / 2;
			outerInstance.expandButton.setBounds(param1Container.Width - insets.right - j, n - k, j, k);
		  }
		}

		private class PopupPanelCallbackAnonymousInnerClass : PopupPanelCallback
		{
			private readonly RibbonBandLayout outerInstance;

			private AbstractRibbonBand popupBand;
			private Dimension size;

			public PopupPanelCallbackAnonymousInnerClass(RibbonBandLayout outerInstance, AbstractRibbonBand popupBand, Dimension size)
			{
				this.outerInstance = outerInstance;
				this.popupBand = popupBand;
				this.size = size;
			}

			public JPopupPanel getPopupPanel(JCommandButton param2JCommandButton)
			{
				return new BasicRibbonBandUI.CollapsedButtonPopupPanel(popupBand, size);
			}
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSRibbonBandUI.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
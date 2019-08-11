namespace Desktop.common.nomitech.common.laf
{
	using BasicCommandButtonPanelUI = org.pushingpixels.flamingo.@internal.ui.common.BasicCommandButtonPanelUI;

	public class CostOSApplicationMenuCommandButtonPanelUI : BasicCommandButtonPanelUI
	{
	  private const int BUTTONS_N_WIDTH = 373;

	  private static readonly Font groupHeaderFont = new Font("SansSerif", 0, 24);

	  public static ComponentUI createUI(JComponent paramJComponent)
	  {
		  return new CostOSApplicationMenuCommandButtonPanelUI();
	  }

	  protected internal virtual Insets GroupInsets
	  {
		  get
		  {
			int i = CostOSRootPaneUI.Resolver.MainFrame.Width - CostOSRibbonApplicationMenuPopupPanel.FirstLevelMenuWidth - 2;
			if (i > 418)
			{
			  int j = i - 418;
			  return new Insets(20, 45, 10, j);
			}
			return new Insets(20, 45, 10, 4);
		  }
	  }

	  protected internal virtual void recomputeGroupHeaders()
	  {
		if (this.groupLabels != null)
		{
		  foreach (JLabel jLabel in this.groupLabels)
		  {
			this.buttonPanel.remove(jLabel);
		  }
		}
		int i = this.buttonPanel.GroupCount;
		this.groupLabels = new JLabel[i];
		for (sbyte b = 0; b < i; b++)
		{
		  this.groupLabels[b] = new JLabel(this.buttonPanel.getGroupTitleAt(b));
		  this.groupLabels[b].Font = groupHeaderFont;
		  this.groupLabels[b].ComponentOrientation = this.buttonPanel.ComponentOrientation;
		  this.buttonPanel.add(this.groupLabels[b]);
		  this.groupLabels[b].Visible = this.buttonPanel.ToShowGroupLabels;
		}
	  }

	  public virtual void paint(Graphics paramGraphics, JComponent paramJComponent)
	  {
		Color color = this.buttonPanel.Background;
		paramGraphics.Color = CostOSWindowsLookAndFeel.ribbonAppMenuSecondaryPanelBackground;
		paramGraphics.fillRect(0, 0, paramJComponent.Width, paramJComponent.Height);
	  }

	  protected internal virtual void paintGroupBackground(Graphics paramGraphics, int paramInt1, int paramInt2, int paramInt3, int paramInt4, int paramInt5)
	  {
		Color color = this.buttonPanel.Background;
		if (color == null || color is javax.swing.plaf.UIResource)
		{
		  color = UIManager.getColor("Panel.background");
		  if (color == null)
		  {
			color = new Color(190, 190, 190);
		  }
		  if (paramInt1 % 2 == 1)
		  {
			double d = 0.95D;
			color = new Color((int)(color.Red * d), (int)(color.Green * d), (int)(color.Blue * d));
		  }
		}
		paramGraphics.Color = color;
		paramGraphics.fillRect(paramInt2, paramInt3, paramInt4, paramInt5);
	  }

	  protected internal virtual void paintGroupTitleBackground(Graphics paramGraphics, int paramInt1, int paramInt2, int paramInt3, int paramInt4, int paramInt5)
	  {
		paramGraphics.Color = UIManager.getColor("Panel.background");
		paramGraphics.fillRect(paramInt2, paramInt3, paramInt4, paramInt5);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSApplicationMenuCommandButtonPanelUI.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
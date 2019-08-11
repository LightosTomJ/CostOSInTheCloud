namespace Desktop.common.nomitech.common.laf
{
	using AbstractCommandButton = org.pushingpixels.flamingo.api.common.AbstractCommandButton;
	using CommandButtonDisplayState = org.pushingpixels.flamingo.api.common.CommandButtonDisplayState;
	using CommandButtonLayoutManager = org.pushingpixels.flamingo.api.common.CommandButtonLayoutManager;
	using JCommandButton = org.pushingpixels.flamingo.api.common.JCommandButton;
	using JCommandButtonPanel = org.pushingpixels.flamingo.api.common.JCommandButtonPanel;
	using JCommandMenuButton = org.pushingpixels.flamingo.api.common.JCommandMenuButton;
	using RibbonApplicationMenuEntryPrimary = org.pushingpixels.flamingo.api.ribbon.RibbonApplicationMenuEntryPrimary;
	using RibbonApplicationMenuEntrySecondary = org.pushingpixels.flamingo.api.ribbon.RibbonApplicationMenuEntrySecondary;
	using CommandButtonLayoutManagerMenuTileLevel2 = org.pushingpixels.flamingo.@internal.ui.ribbon.appmenu.CommandButtonLayoutManagerMenuTileLevel2;

	public class CostOSRibbonApplicationMenuPopupPanelSecondary : JCommandButtonPanel
	{
	  protected internal static readonly CommandButtonDisplayState MENU_TILE_LEVEL_2 = new CommandButtonDisplayStateAnonymousInnerClass();

	  private class CommandButtonDisplayStateAnonymousInnerClass : CommandButtonDisplayState
	  {
		  public CommandButtonDisplayStateAnonymousInnerClass() : base("Ribbon application menu tile level 2", 32)
		  {
		  }

		  public CommandButtonLayoutManager createLayoutManager(AbstractCommandButton param1AbstractCommandButton)
		  {
			  return new CommandButtonLayoutManagerMenuTileLevel2();
		  }
	  }

	  public virtual string UIClassID
	  {
		  get
		  {
			  return "CostOSApplicationMenuCommandButtonPanelUI";
		  }
	  }

	  public CostOSRibbonApplicationMenuPopupPanelSecondary(RibbonApplicationMenuEntryPrimary paramRibbonApplicationMenuEntryPrimary) : base(MENU_TILE_LEVEL_2)
	  {
		MaxButtonColumns = 1;
		Border = BorderFactory.createEmptyBorder();
		int i = paramRibbonApplicationMenuEntryPrimary.SecondaryGroupCount;
		for (sbyte b = 0; b < i; b++)
		{
		  string str = paramRibbonApplicationMenuEntryPrimary.getSecondaryGroupTitleAt(b);
		  addButtonGroup(str);
		  foreach (RibbonApplicationMenuEntrySecondary ribbonApplicationMenuEntrySecondary in paramRibbonApplicationMenuEntryPrimary.getSecondaryGroupEntries(b))
		  {
			JCommandMenuButton jCommandMenuButton = new JCommandMenuButton(ribbonApplicationMenuEntrySecondary.Text, ribbonApplicationMenuEntrySecondary.Icon);
			jCommandMenuButton.ExtraText = ribbonApplicationMenuEntrySecondary.DescriptionText;
			jCommandMenuButton.CommandButtonKind = ribbonApplicationMenuEntrySecondary.EntryKind;
			jCommandMenuButton.addActionListener(ribbonApplicationMenuEntrySecondary.MainActionListener);
			jCommandMenuButton.DisplayState = MENU_TILE_LEVEL_2;
			jCommandMenuButton.HorizontalAlignment = 10;
			jCommandMenuButton.PopupOrientationKind = JCommandButton.CommandButtonPopupOrientationKind.SIDEWARD;
			jCommandMenuButton.Enabled = ribbonApplicationMenuEntrySecondary.Enabled;
			jCommandMenuButton.PopupCallback = ribbonApplicationMenuEntrySecondary.PopupCallback;
			jCommandMenuButton.ActionKeyTip = ribbonApplicationMenuEntrySecondary.ActionKeyTip;
			jCommandMenuButton.PopupKeyTip = ribbonApplicationMenuEntrySecondary.PopupKeyTip;
			if (ribbonApplicationMenuEntrySecondary.DisabledIcon != null)
			{
			  jCommandMenuButton.DisabledIcon = ribbonApplicationMenuEntrySecondary.DisabledIcon;
			}
			addButtonToLastGroup(jCommandMenuButton);
		  }
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSRibbonApplicationMenuPopupPanelSecondary.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
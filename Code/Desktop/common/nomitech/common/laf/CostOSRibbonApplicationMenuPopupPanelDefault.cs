namespace Desktop.common.nomitech.common.laf
{
	using AbstractCommandButton = org.pushingpixels.flamingo.api.common.AbstractCommandButton;
	using CommandButtonDisplayState = org.pushingpixels.flamingo.api.common.CommandButtonDisplayState;
	using CommandButtonLayoutManager = org.pushingpixels.flamingo.api.common.CommandButtonLayoutManager;
	using JCommandButtonPanel = org.pushingpixels.flamingo.api.common.JCommandButtonPanel;
	using CommandButtonLayoutManagerMenuTileLevel2 = org.pushingpixels.flamingo.@internal.ui.ribbon.appmenu.CommandButtonLayoutManagerMenuTileLevel2;

	public class CostOSRibbonApplicationMenuPopupPanelDefault : JCommandButtonPanel
	{
	  public static readonly CommandButtonDisplayState MENU_TILE_LEVEL_2 = new CommandButtonDisplayStateAnonymousInnerClass();

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

	  public CostOSRibbonApplicationMenuPopupPanelDefault() : base(MENU_TILE_LEVEL_2)
	  {
		MaxButtonColumns = 1;
		Border = BorderFactory.createEmptyBorder();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\laf\CostOSRibbonApplicationMenuPopupPanelDefault.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
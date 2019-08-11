namespace Desktop.common.nomitech.costos.ribbon
{
	using ResizableCloneableIcon = nomitech.common.ui.ResizableCloneableIcon;
	using JCommandButton = org.pushingpixels.flamingo.api.common.JCommandButton;
	using RibbonApplicationMenu = org.pushingpixels.flamingo.api.ribbon.RibbonApplicationMenu;
	using RibbonTask = org.pushingpixels.flamingo.api.ribbon.RibbonTask;

	public interface BaseRibbon
	{
	  bool Minimized {set;}

	  void addPropertyChangeListener(PropertyChangeListener paramPropertyChangeListener);

	  void updateUI();

	  void configureHelp(ResizableCloneableIcon paramResizableCloneableIcon, ActionListener paramActionListener);

	  Color Background {get;}

	  void addTask(RibbonTask paramRibbonTask);

	  RibbonApplicationMenu ApplicationMenu {set;get;}


	  void addTaskbarComponent(JCommandButton paramJCommandButton);

	  void addTaskbarComponent(JSeparator paramJSeparator);

	  RibbonTask SelectedTask {set;get;}


	  bool Showing {get;}

	  void configureClose(ResizableCloneableIcon paramResizableCloneableIcon, ActionListener paramActionListener);

	  void fireRibbonPropertyChange(string paramString, object paramObject1, object paramObject2);

	  void configureUserName(ActionListener paramActionListener);

	  ActionListener UserNameActionListener {get;}

	  JMenuItem[] UserMenuItems {get;}

	  void configureUserMenuItems(JMenuItem[] paramArrayOfJMenuItem);

	  JComponent SearchButton {get;}

	  void configureSearchButton(JComponent paramJComponent);
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\ribbon\BaseRibbon.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
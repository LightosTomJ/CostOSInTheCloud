namespace Desktop.common.nomitech.costos.plugin.api
{
	public abstract class IImportExtension : IProjectExtension
	{
	  public abstract IRibbonApplicationMenuButtonSecondary ImportMenuButton {get;}

	  public virtual bool ProjectImport
	  {
		  get
		  {
			  return true;
		  }
	  }

	  public override string Name
	  {
		  get
		  {
			  return "Undefined Import Plug-In";
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\IImportExtension.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
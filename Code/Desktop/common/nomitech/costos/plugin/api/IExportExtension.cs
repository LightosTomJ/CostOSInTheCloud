namespace Desktop.common.nomitech.costos.plugin.api
{
	public abstract class IExportExtension : IProjectExtension
	{
	  public abstract IRibbonApplicationMenuButtonSecondary ExportMenuButton {get;}

	  public virtual bool ProjectExport
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
			  return "Undefined Export Plug-In";
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\IExportExtension.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
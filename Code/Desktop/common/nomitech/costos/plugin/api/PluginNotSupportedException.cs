using System;

namespace Desktop.common.nomitech.costos.plugin.api
{
	public class PluginNotSupportedException : System.InvalidOperationException
	{
	  public PluginNotSupportedException(IExtension paramIExtension) : base("Plugin " + paramIExtension.Name + " not supported.")
	  {
	  }

	  public PluginNotSupportedException(string paramString, Exception paramThrowable) : base(paramString, paramThrowable)
	  {
	  }

	  public PluginNotSupportedException(Exception paramThrowable) : base(paramThrowable)
	  {
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\PluginNotSupportedException.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
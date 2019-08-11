using System.Collections.Generic;

namespace Desktop.common.nomitech.costos.plugin.api
{

	public interface IExtension
	{
	  void loadExtension(JFrame paramJFrame, Properties paramProperties);

	  void unloadExtension();

	  IList<ExtensionPropertyDefinition> loadProperties(Properties paramProperties);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: void setNewProperties(java.util.Properties paramProperties) throws IllegalArgumentException;
	  Properties NewProperties {set;}

	  string Name {get;}

	  object callExtension(string paramString, long? paramLong);
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\IExtension.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
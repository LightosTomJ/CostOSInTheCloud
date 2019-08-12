using System.Collections.Generic;

namespace Model.util
{

	using DocumentException = org.dom4j.DocumentException;
	using DocumentHelper = org.dom4j.DocumentHelper;
	using Element = org.dom4j.Element;
	using XPath = org.dom4j.XPath;
	using SAXReader = org.dom4j.io.SAXReader;

	public class HibernateCacheableClassReader
	{

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.ArrayList<String> getDeclaredMappings() throws org.dom4j.DocumentException
		public static List<string> DeclaredMappings
		{
			get
			{
				//Util.newResource(name)
		//		String configFileFolder = configFilePath.replaceAll("hibernateCached.cfg.xml","").replaceAll("Hibernate","HibernateMappings"); 
		//		File configFile = new File(configFilePath).getAbsoluteFile(); 
    
				List<object> mappings = new List<object>();
    
				SAXReader reader = new SAXReader();
				org.dom4j.Document doc = reader.read(ClassLoader.getSystemResource("nomitech/common/hibernateCached.cfg.xml"));
				XPath xpathSelector = DocumentHelper.createXPath("/hibernate-configuration/session-factory/mapping");
				System.Collections.IList results = xpathSelector.selectNodes(doc);
				System.Collections.IEnumerator i = results.GetEnumerator();
				while (i.MoveNext())
				{
					Element element = (Element) i.Current;
					string fileName = element.attribute("resource").Text;
					mappings.Add(fileName);
				}
    
				return mappings;
    
			}
		}

	}

}
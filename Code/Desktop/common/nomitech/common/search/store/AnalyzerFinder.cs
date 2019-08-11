namespace Desktop.common.nomitech.common.search.store
{
	using Analyzer = org.apache.lucene.analysis.Analyzer;
	using ClassicAnalyzer = org.apache.lucene.analysis.standard.ClassicAnalyzer;
	using Version = org.apache.lucene.util.Version;

	public class AnalyzerFinder
	{
	  public static Analyzer LocaleAnalyzer
	  {
		  get
		  {
			string str = System.getProperty("user.language");
			return new ClassicAnalyzer(Version.LUCENE_22);
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\search\store\AnalyzerFinder.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
namespace Desktop.common.nomitech.common.ui
{

	public interface UIProgressInText
	{
	  void appendText(string paramString);

	  void appendHeaderText(string paramString);

	  void appendBlueText(string paramString);

	  void appendErrorText(string paramString);

	  JProgressBar TaskProgressBar {get;}

	  JProgressBar TotalProgressBar {get;}
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\UIProgressInText.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
namespace Desktop.common.nomitech.common.ui
{
	public interface UIProgress
	{
	  string Progress {set;}

	  void setProgress(string paramString, int paramInt);

	  bool Indeterminate {set;get;}

	  int TotalTimes {set;}

	  void forceTotalTimes(int paramInt);

	  void incrementProgress(int paramInt);

	  void incrementProgress(string paramString, int paramInt);

	  string getLangText(string paramString);

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\UIProgress.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
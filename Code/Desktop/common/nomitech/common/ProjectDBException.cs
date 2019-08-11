using System;

namespace Desktop.common.nomitech.common
{
	using UILanguage = Desktop.common.nomitech.common.ui.UILanguage;

	public class ProjectDBException : Exception
	{
	  public ProjectDBException() : base(UILanguage.get("msg.openfile.alreadyopened.text"))
	  {
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\ProjectDBException.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
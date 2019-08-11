namespace Desktop.common.nomitech.common.expr.codes
{
	using GroupCode = Desktop.common.nomitech.common.@base.GroupCode;
	using ResourceTable = Desktop.common.nomitech.common.@base.ResourceTable;

	public interface GroupCodeUtilIntf
	{
	  string getCodeSystem(string paramString);

	  GroupCode extractCode(string paramString1, string paramString2);

	  bool checkCodeExists(string paramString1, string paramString2);

	  bool checkValidCodeWithParent(string paramString1, string paramString2);

	  bool checkValidCode(string paramString1, string paramString2);

	  string getNextCodeOfCode(string paramString1, string paramString2);

	  string getParentOfCode(string paramString1, string paramString2);

	  string getCodeInResourceTable(string paramString, ResourceTable paramResourceTable);

	  string formatCodeAndTitle(string paramString, GroupCode paramGroupCode);

	  bool? checkCodeShowsGroupPrefix(string paramString);

	  bool? checkCodeShowsDivGroupPrefix(string paramString);

	  string getCodeToCodeSeparator(string paramString);

	  string getCodeToTitleSeparator(string paramString);
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\codes\GroupCodeUtilIntf.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
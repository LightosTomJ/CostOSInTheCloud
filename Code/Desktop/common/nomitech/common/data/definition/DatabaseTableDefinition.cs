using System;

namespace Desktop.common.nomitech.common.data.definition
{

	public interface DatabaseTableDefinition
	{

	  string[] Fields {get;}

	  Type[] Classes {get;}

	  string[] ColumnNames {get;}

	  Type fieldNameToClass(string paramString);

	  bool isFieldEditable(string paramString);

	  bool hasFieldFillDown(string paramString);

	  bool isFieldRate(string paramString);

	  bool hasFieldSubtotal(string paramString);

	  bool isColumnRate(string paramString);

	  bool hasColumnSubtotal(string paramString);

	  bool hasTableSubtotals();

	  bool isColumnIndexRolledUp(int paramInt);

	  string columnNameToFieldName(string paramString);

	  string fieldNameToColumnName(string paramString);

	  int ColumnCount {get;}

	  string getTablePrefix(Properties paramProperties, int paramInt);

	  int DatabaseTableType {get;}

	  Image getTableImage(int paramInt);

	  ImageIcon getTableImageIcon(int paramInt);

	  Image getSeeThroughImage(int paramInt);

	  ImageIcon getDisabledImageIcon(int paramInt);

	  ImageIcon WizardIcon {get;}

	  string PanelTitle {get;}

	  string TreeNodeTitle {get;}

	  string LayoutType {get;}

	  sbyte ReportType {get;}

	  DataFlavor TableDataFlavor {get;}

	  DataFlavor TableListDataFlavor {get;}

	  string TableName {get;}

	  bool supportsRenamingColumns();

	  void reloadColumnNames();

	  bool supportsHeaderStyle();

	  string TableUserWriterRole {get;}

	  int indexOfField(string paramString);
	}

	public static class DatabaseTableDefinition_Fields
	{
	  public const int RESOURCE_TABLE = 0;
	  public const int GROUPCODE_TABLE = 1;
	  public const int EPSCODE_TABLE = 2;
	  public const int PANEL_TABLE_PREFIX = 0;
	  public const int SELECT_DIALOG_TABLE_PREFIX = 1;
	  public const int WEB_SELECT_DIALOG_TABLE_PREFIX = 2;
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\data\definition\DatabaseTableDefinition.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
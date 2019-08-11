namespace Desktop.common.nomitech.common.util
{
	using TableUtils = com.jidesoft.grid.TableUtils;

	public class UITableUtil
	{
	  public static void adjustTableColumnWidths(JTable paramJTable, int paramInt1, int paramInt2, bool paramBoolean1, bool paramBoolean2, bool paramBoolean3)
	  {
		TableColumnModel tableColumnModel = paramJTable.ColumnModel;
		for (sbyte b = 0; b < tableColumnModel.ColumnCount; b++)
		{
		  TableUtils.autoResizeColumn(paramJTable, b, true, paramBoolean1, paramInt1, paramInt2, paramBoolean2, paramBoolean3);
		}
	  }

	  public static void adjustTableColumnWidths(JTable paramJTable, int paramInt)
	  {
		TableColumnModel tableColumnModel = paramJTable.ColumnModel;
		for (sbyte b = 0; b < tableColumnModel.ColumnCount; b++)
		{
		  TableColumn tableColumn = tableColumnModel.getColumn(b);
		  if (tableColumn.Width > paramInt)
		  {
			tableColumn.PreferredWidth = paramInt;
		  }
		}
	  }

	  public static void setAllTableColumnWidth(JTable paramJTable, int paramInt)
	  {
		TableColumnModel tableColumnModel = paramJTable.ColumnModel;
		for (sbyte b = 0; b < tableColumnModel.ColumnCount; b++)
		{
		  TableColumn tableColumn = tableColumnModel.getColumn(b);
		  tableColumn.PreferredWidth = paramInt;
		}
	  }

	  public static void setAllTableColumnWidthFromAnotherTable(JTable paramJTable1, JTable paramJTable2)
	  {
		TableColumnModel tableColumnModel1 = paramJTable1.ColumnModel;
		TableColumnModel tableColumnModel2 = paramJTable2.ColumnModel;
		if (tableColumnModel2.ColumnCount < tableColumnModel1.ColumnCount)
		{
		  return;
		}
		for (sbyte b = 0; b < tableColumnModel1.ColumnCount; b++)
		{
		  tableColumnModel1.getColumn(b).PreferredWidth = tableColumnModel2.getColumn(b).PreferredWidth;
		}
	  }

	  public static void scrollToVisible(JTable paramJTable, int paramInt1, int paramInt2)
	  {
		if (!(paramJTable.Parent is JViewport))
		{
		  return;
		}
		JViewport jViewport = (JViewport)paramJTable.Parent;
		Rectangle rectangle = paramJTable.getCellRect(paramInt1, paramInt2, true);
		Point point = jViewport.ViewPosition;
		rectangle.setLocation(rectangle.x - point.x, rectangle.y - point.y);
		paramJTable.scrollRectToVisible(rectangle);
		jViewport.scrollRectToVisible(rectangle);
	  }

	  public static void selectAndEditCellAt(JTable paramJTable, int paramInt1, int paramInt2)
	  {
		paramJTable.SelectionModel.setSelectionInterval(paramInt1, paramInt1);
		paramJTable.ColumnModel.SelectionModel.setSelectionInterval(paramInt2, paramInt2);
		bool @bool = paramJTable.editCellAt(paramInt1, paramInt2);
		if (@bool && paramJTable.EditorComponent != null)
		{
		  Component component = paramJTable.EditorComponent;
		  component.requestFocus();
		  if (component is JTextComponent)
		  {
			((JTextComponent)component).selectAll();
		  }
		  else if (component is JComboBox)
		  {
			((JComboBox)component).showPopup();
		  }
		}
		else
		{
		  paramJTable.changeSelection(paramInt1, paramInt2, false, false);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\UITableUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.ui
{
	using CustomView = com.jxcell.CustomView;

	public class UIExcelView : CustomView
	{
	  public virtual bool SheetsProtected
	  {
		  set
		  {
			try
			{
			  for (sbyte b = 0; b < SheetsCount; b++)
			  {
				setSheetProtected(b, value, null);
			  }
			}
			catch (Exception exception)
			{
			  Console.WriteLine(exception.ToString());
			  Console.Write(exception.StackTrace);
			}
		  }
	  }

	  public virtual void fireNeedsRecalc()
	  {
	  }

	  public virtual void firePastePerformed()
	  {
	  }

	  public virtual void fireRangeCleared(int paramInt1, int paramInt2, int paramInt3, int paramInt4, short paramShort)
	  {
	  }

	  public virtual void fireRangeDeleted(int paramInt1, int paramInt2, int paramInt3, int paramInt4, short paramShort)
	  {
	  }

	  public virtual void fireRangeInserted(int paramInt1, int paramInt2, int paramInt3, int paramInt4, short paramShort)
	  {
	  }

	  public virtual void fireSheetDeleted()
	  {
	  }

	  public virtual bool DesignMode
	  {
		  get
		  {
			  return false;
		  }
	  }

	  public virtual bool DisabledMode
	  {
		  get
		  {
			  return true;
		  }
	  }

	  public virtual IList<JMenu> preparePopupMenu()
	  {
		  return Collections.EMPTY_LIST;
	  }

	  public virtual IList<JMenuItem> preparePopupMenuItems()
	  {
		  return Collections.EMPTY_LIST;
	  }

	  public virtual void fileNewPerformed()
	  {
	  }

	  public virtual void fileOpenPerformed()
	  {
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\UIExcelView.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}
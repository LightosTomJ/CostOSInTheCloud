using System;

/*
 * Created on 17 ��� 2006
 *
 * DataVers Technologies (c) 2005
 */
namespace Model.proj
{

	using BaseTable = nomitech.common.@base.BaseTable;
	using BaseTableList = nomitech.common.@base.BaseTableList;

	/// <summary>
	/// @author george
	/// 
	/// TODO To change the template for this generated type comment go to
	/// Window - Preferences - Java - Code Style - Code Templates
	/// </summary>
	[Serializable]
	public class BoqItemTableList : BaseTableList, Transferable
	{
		// private Vector _o_items;
		private BoqItemTable[] _o_items;
		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.boqitemListDataFlavor};

		private const long serialVersionUID = 1L;

		public BoqItemTableList(BoqItemTable[] items)
		{
			BoqItems = items;
		}

		public virtual BoqItemTable[] BoqItems
		{
			set
			{
				_o_items = value;
				//_o_items = new Vector(value.length);
				//for ( int i = 0; i < value.length; i++ ) {
				  // _o_items.add(value[i]);
				//}
			}
			get
			{
				return _o_items;
				//return (BoqItemTable[])_o_items.toArray(new BoqItemTable[_o_items.size()]);
			}
		}


		public virtual BoqItemTable[] BoqItemsCopy
		{
			get
			{
				BoqItemTable[] copy = new BoqItemTable[_o_items.Length];
				for (int i = 0; i < _o_items.Length; i++)
				{
				   copy[i] = (BoqItemTable)_o_items[i].clone();
				}
    
				return copy;
			}
		}

		public virtual BoqItemTable[] getBoqItemsDeepCopy(bool ciclic)
		{
			BoqItemTable[] copy = new BoqItemTable[_o_items.Length];
			for (int i = 0; i < _o_items.Length; i++)
			{
			   copy[i] = (BoqItemTable)_o_items[i].deepCopy(ciclic);
			}

			return copy;
		}

		public virtual DataFlavor[] TransferDataFlavors
		{
			get
			{
				lock (this)
				{
					return s_supportedDataFlavors;
				}
			}
		}

		public virtual bool isDataFlavorSupported(DataFlavor flavor)
		{
			return DataFlavors.boqitemListDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.boqitemListDataFlavor.Equals(flavor))
				{
					return this;
				}
        
				throw new UnsupportedFlavorException(flavor);
			}
		}

		public override BaseTable[] BaseTables
		{
			get
			{
				return BoqItems;
			}
		}

		public override BaseTable[] cloneBaseTables()
		{
			return getBoqItemsDeepCopy(true);
		}
	}

}
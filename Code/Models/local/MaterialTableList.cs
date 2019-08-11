using System;

/*
 * Created on 13 ��� 2006
 *
 * DataVers Technologies (c) 2005
 */
namespace Models.local
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
	public class MaterialTableList : Transferable, BaseTableList
	{
		// private Vector _o_items;
		private MaterialTable[] _o_items;
		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.materialListDataFlavor};

		private const long serialVersionUID = 1L;

		public MaterialTableList(MaterialTable[] items)
		{
			Materials = items;
		}

		public virtual MaterialTable[] Materials
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
				//return (MaterialTable[])_o_items.toArray(new MaterialTable[_o_items.size()]);
			}
		}


		public virtual MaterialTable[] MaterialsCopy
		{
			get
			{
				MaterialTable[] copy = new MaterialTable[_o_items.Length];
				for (int i = 0; i < _o_items.Length; i++)
				{
				   copy[i] = (MaterialTable)_o_items[i].clone();
				}
    
				return copy;
			}
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
			return DataFlavors.materialListDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.materialListDataFlavor.Equals(flavor))
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
				return _o_items;
			}
		}

		public override BaseTable[] cloneBaseTables()
		{
			MaterialTable[] copy = new MaterialTable[_o_items.Length];
			for (int i = 0; i < _o_items.Length; i++)
			{
			   copy[i] = (MaterialTable)_o_items[i].copyWithSupplier();
			}

			return copy;
		}
	}


}
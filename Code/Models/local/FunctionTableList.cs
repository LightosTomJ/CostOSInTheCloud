using System;

/*
 * Created on 13 ��� 2006
 *
 * DataVers Technologies (c) 2005
 */
namespace Models.local
{

	using BaseTable = Desktop.common.nomitech.common.@base.BaseTable;
	using BaseTableList = Desktop.common.nomitech.common.@base.BaseTableList;

	/// <summary>
	/// @author george
	/// 
	/// TODO To change the template for this generated type comment go to
	/// Window - Preferences - Java - Code Style - Code Templates
	/// </summary>
	[Serializable]
	public class FunctionTableList : Transferable, BaseTableList
	{
		// private Vector _o_items;
		private FunctionTable[] _o_items;
		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.functionListDataFlavor};

		private const long serialVersionUID = 1L;

		public FunctionTableList(FunctionTable[] items)
		{
			Functions = items;
		}

		public virtual FunctionTable[] Functions
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
				//return (FunctionTable[])_o_items.toArray(new FunctionTable[_o_items.size()]);
			}
		}


		public virtual FunctionTable[] FunctionsCopy
		{
			get
			{
				FunctionTable[] copy = new FunctionTable[_o_items.Length];
				for (int i = 0; i < _o_items.Length; i++)
				{
				   copy[i] = (FunctionTable)_o_items[i].copyWithVariables();
				}
    
				return copy;
			}
		}

		public virtual FunctionTable[] FunctionsDeepCopy
		{
			get
			{
				FunctionTable[] copy = new FunctionTable[_o_items.Length];
				for (int i = 0; i < _o_items.Length; i++)
				{
				   copy[i] = (FunctionTable)_o_items[i].copyWithVariables();
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
			return DataFlavors.functionListDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.functionListDataFlavor.Equals(flavor))
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
			return FunctionsDeepCopy;
		}
	}


}
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
	public class AssemblyTableList : Transferable, BaseTableList
	{
		// private Vector _o_items;
		private AssemblyTable[] _o_items;
		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.assemblyListDataFlavor};

		private const long serialVersionUID = 1L;

		public AssemblyTableList(AssemblyTable[] items)
		{
			Assemblys = items;
		}

		public virtual AssemblyTable[] Assemblys
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
				//return (AssemblyTable[])_o_items.toArray(new AssemblyTable[_o_items.size()]);
			}
		}


		public virtual AssemblyTable[] AssemblysCopy
		{
			get
			{
				AssemblyTable[] copy = new AssemblyTable[_o_items.Length];
				for (int i = 0; i < _o_items.Length; i++)
				{
				   copy[i] = (AssemblyTable)_o_items[i].copy();
				}
    
				return copy;
			}
		}

		public virtual AssemblyTable[] AssemblysDeepCopy
		{
			get
			{
				return getAssemblysDeepCopy(false);
			}
		}

		public virtual AssemblyTable[] getAssemblysDeepCopy(bool removeIds)
		{
			AssemblyTable[] copy = new AssemblyTable[_o_items.Length];
			for (int i = 0; i < _o_items.Length; i++)
			{
			   copy[i] = (AssemblyTable)_o_items[i].deepCopy(removeIds);
			}

			return copy;
		}

		public virtual AssemblyTable[] AssemblysDeepRoundCopy
		{
			get
			{
				AssemblyTable[] copy = new AssemblyTable[_o_items.Length];
				for (int i = 0; i < _o_items.Length; i++)
				{
				   copy[i] = (AssemblyTable)_o_items[i].deepRoundCopy();
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
			return DataFlavors.assemblyListDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.assemblyListDataFlavor.Equals(flavor))
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
			return AssemblysDeepCopy;
		}
	}


}
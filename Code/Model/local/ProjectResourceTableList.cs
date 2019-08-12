using System;
using System.Collections.Generic;

namespace Model.local
{

	using BaseTable = Desktop.common.nomitech.common.@base.BaseTable;
	using BaseTableList = Desktop.common.nomitech.common.@base.BaseTableList;

	[Serializable]
	public class ProjectResourceTableList : Transferable, BaseTableList
	{

		private ProjectResourceTable[] _o_items;
		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.projectResourceListDataFlavor};

		private const long serialVersionUID = 1L;

		public ProjectResourceTableList(ProjectResourceTable[] items)
		{
			ProjectResourceItems = items;
		}

		public virtual ProjectResourceTable[] ProjectResourceItems
		{
			set
			{
				_o_items = value;
			}
		}

		public virtual ProjectResourceTable[] Items
		{
			get
			{
				return _o_items;
			}
		}

		public virtual IList<ProjectResourceTable> ItemsList
		{
			get
			{
				return Arrays.asList(_o_items);
			}
		}

		public virtual ProjectResourceTable[] ProjectResourceItemsCopy
		{
			get
			{
				ProjectResourceTable[] copy = new ProjectResourceTable[_o_items.Length];
    
				for (int i = 0; i < _o_items.Length; i++)
				{
				   copy[i] = (ProjectResourceTable)_o_items[i].Clone();
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
			return DataFlavors.projectResourceListDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.projectResourceListDataFlavor.Equals(flavor))
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
			return ProjectResourceItemsCopy;
		}
	}
}
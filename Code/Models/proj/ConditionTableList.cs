using System;

/*
 * Created on 17 ��� 2006
 *
 * DataVers Technologies (c) 2005
 */
namespace Models.proj
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
	public class ConditionTableList : BaseTableList, Transferable
	{
		// private Vector _o_items;
		private ConditionTable[] _o_items;
		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.conditionListDataFlavor};

		private const long serialVersionUID = 1L;

		public ConditionTableList(ConditionTable[] items)
		{
			Conditions = items;
		}

		public virtual ConditionTable[] Conditions
		{
			set
			{
				_o_items = value;
			}
			get
			{
				return _o_items;
			}
		}


		public virtual ConditionTable[] getConditionsDeepCopy(bool ciclic)
		{
			ConditionTable[] copy = new ConditionTable[_o_items.Length];
			for (int i = 0; i < _o_items.Length; i++)
			{
			   copy[i] = (ConditionTable)_o_items[i].clone();
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
			return DataFlavors.conditionListDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.conditionListDataFlavor.Equals(flavor))
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
				return Conditions;
			}
		}

		public override BaseTable[] cloneBaseTables()
		{
			return getConditionsDeepCopy(true);
		}
	}
}
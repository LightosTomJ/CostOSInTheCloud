using System;
using System.Collections.Generic;

namespace Model.cache
{

	using BaseCache = Desktop.common.nomitech.common.@base.BaseCache;
	using GroupCode = Desktop.common.nomitech.common.@base.GroupCode;
	using GroupCodesWithResource = Desktop.common.nomitech.common.@base.GroupCodesWithResource;
	using ResourceTable = Desktop.common.nomitech.common.@base.ResourceTable;
	using ParamItemTable = Desktop.common.nomitech.common.db.local.ParamItemTable;
	using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;

	using Session = org.hibernate.Session;

	public class ParamItemCache : BaseCache
	{

		public const string TABLE_NAME = "ParamItem";

		private IDictionary<string, GroupCode> hashMap = Collections.synchronizedMap(new Dictionary<string, GroupCode>());
		private ProjectDBUtil o_prjDBUtil;

		public ParamItemCache(ProjectDBUtil prjDBUtil)
		{
			o_prjDBUtil = prjDBUtil;

			try
			{
				initializeCache();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				Console.Write(e.StackTrace);
			}
		}

		public ParamItemCache(ProjectDBUtil prjDBUtil, bool initCache)
		{
			o_prjDBUtil = prjDBUtil;

			if (initCache)
			{
				try
				{
					initializeCache();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					Console.Write(e.StackTrace);
				}
			}
		}

		public virtual GroupCode getGroupCode(string code)
		{
			GroupCode gc = hashMap[code];
			if (gc == null)
			{
				if (code.IndexOf(" - ", StringComparison.Ordinal) != -1)
				{
					try
					{
						gc = getById(Convert.ToInt64(code.Substring(0,code.IndexOf(" - ", StringComparison.Ordinal))));
						if (gc != null)
						{
							return gc;
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.ToString());
						Console.Write(ex.StackTrace);
					}
				}
				// must return null here probably
				return new ParamItemGroupCode(this, code); // Compatibility with beta
			}
			return gc;
		}

		public virtual void remove(ParamItemTable gcTable)
		{
			ParamItemGroupCode gc = new ParamItemGroupCode(this, gcTable);
			hashMap[gc.ToString()] = gc;
			hashMap.Remove(gc.ToString());
		}

		public virtual void add(ParamItemTable gcTable)
		{
			//System.out.println("Adding "+gcTable);
			ParamItemGroupCode gc = new ParamItemGroupCode(this, gcTable);
			hashMap[gc.ToString()] = gc;
		}

		public virtual void update(ParamItemTable gcTable)
		{
			//System.out.println("Updating "+gcTable);
			ParamItemGroupCode gc = new ParamItemGroupCode(this, gcTable);
			hashMap[gc.ToString()] = gc;
		}

		public virtual ParamItemGroupCode updateAndGetResult(ParamItemTable gcTable)
		{
			//System.out.println("Updating "+gcTable);
			ParamItemGroupCode gc = new ParamItemGroupCode(this, gcTable);
			hashMap[gc.ToString()] = gc;
			return gc;
		}

		//	public void addOrUpdate(ParamItemTable obj) {
		//		if ( hashMap.get(obj.getGroupCode()) == null ) {
		//			add(obj);
		//		}
		//		else {
		//			update(obj);
		//		}
		//	}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void initializeCache() throws Exception
		public virtual void initializeCache()
		{
			bool hasOpenedSession = o_prjDBUtil.hasOpenedSession();
			Session session = o_prjDBUtil.currentSession();

			hashMap.Clear();

			//System.out.println("Seeking for: "+code);

			IEnumerator<ParamItemTable> iter = session.createQuery("from ParamItemTable o where o.projectId = " + o_prjDBUtil.ProjectUrlId).iterate();

			//System.out.println("Processing: "+prj);
			while (iter.MoveNext())
			{
				ParamItemTable paramItemTable = (ParamItemTable)iter.Current;
				//System.out.println("Adding: "+groupCodeTable);
				ParamItemGroupCode gc = new ParamItemGroupCode(this, paramItemTable);
				hashMap[gc.ToString()] = gc;
			}

			if (!hasOpenedSession)
			{
				o_prjDBUtil.closeSession();
			}
		}

		public class ParamItemGroupCode : GroupCodesWithResource
		{
			internal bool InstanceFieldsInitialized = false;

			internal virtual void InitializeInstanceFields()
			{
				groupCode = "" + id;
			}

			private readonly ParamItemCache outerInstance;


			internal string codeAndTitle;
			internal long? id = 0L;
			internal string title;
			internal string unit = "-";
			internal string groupCode;
			internal decimal quantity = BigDecimalMath.ZERO;
			internal ParamItemTable paramItemTable = null;

			//private BigDecimal unitRate = BigDecimalMath.ZERO;

			public ParamItemGroupCode(ParamItemCache outerInstance, string codeAndTitle)
			{
				this.outerInstance = outerInstance;

				if (!InstanceFieldsInitialized)
				{
					InitializeInstanceFields();
					InstanceFieldsInitialized = true;
				}
				this.codeAndTitle = codeAndTitle;
				if (!string.ReferenceEquals(codeAndTitle, null) && codeAndTitle.Contains(" - "))
				{
					int idx = codeAndTitle.IndexOf(" - ", StringComparison.Ordinal);

					if (idx + 3 < codeAndTitle.Length)
					{
						title = codeAndTitle.Substring(idx + 3);
					}
					else
					{
						title = "";
					}
				}
				else
				{
					title = "";
				}
				groupCode = title;
			}

			public ParamItemGroupCode(ParamItemCache outerInstance, ParamItemTable paramItemTable)
			{
				this.outerInstance = outerInstance;

				if (!InstanceFieldsInitialized)
				{
					InitializeInstanceFields();
					InstanceFieldsInitialized = true;
				}
				ParamItemTable = paramItemTable;
			}

			internal virtual ParamItemTable ParamItemTable
			{
				set
				{
					this.codeAndTitle = value.Id + " - " + value.Title;
					this.title = value.Title;
					this.id = value.Id;
					this.groupCode = "" + id;
					this.unit = value.Unit;
					this.quantity = value.Quantity;
					this.paramItemTable = value;
				}
			}

			public virtual ResourceTable ResourceTable
			{
				get
				{
					return paramItemTable;
				}
			}

			public override int compareTo(GroupCode o)
			{
				return GroupCode.CompareTo(o.GroupCode);
			}

			public override string Description
			{
				get
				{
					return title;
				}
				set
				{
					// TODO Auto-generated method stub
    
				}
			}

			public override string Title
			{
				get
				{
					return title;
				}
				set
				{
					// TODO Auto-generated method stub
    
				}
			}

			public override string GroupCode
			{
				get
				{
					return groupCode;
				}
				set
				{
					// TODO Auto-generated method stub
    
				}
			}

			public override long? Id
			{
				get
				{
					return id;
				}
			}

			public override string ToString()
			{
				return codeAndTitle;
			}

			public virtual object Clone()
			{
				ParamItemGroupCode p = new ParamItemGroupCode(outerInstance, codeAndTitle);
				p.codeAndTitle = codeAndTitle;
				p.title = title;
				p.id = id;
				p.groupCode = groupCode;
				return p;
			}

			public virtual decimal Quantity
			{
				get
				{
					return quantity;
				}
			}

			public virtual decimal getUnitRate(decimal totalCost)
			{
				if (totalCost == null || totalCost.doubleValue() == 0 || Quantity.doubleValue() == 0)
				{
					return BigDecimalMath.ZERO;
				}
				return BigDecimalMath.div(totalCost,Quantity);
			}

			public virtual string Unit
			{
				get
				{
					return unit;
				}
				set
				{
    
				}
			}

			public override bool Equals(object obj)
			{
				if (obj is ParamItemGroupCode)
				{
					ParamItemGroupCode gc = (ParamItemGroupCode)obj;
					return gc.Id.Equals(Id);
				}
				return false;
			}

			public override string EditorId
			{
				get
				{
					// TODO Auto-generated method stub
					return null;
				}
				set
				{
					// TODO Auto-generated method stub
    
				}
			}

			public override string CreateUserId
			{
				get
				{
					// TODO Auto-generated method stub
					return null;
				}
				set
				{
					// TODO Auto-generated method stub
    
				}
			}

			public override DateTime CreateDate
			{
				get
				{
					// TODO Auto-generated method stub
					return null;
				}
				set
				{
					// TODO Auto-generated method stub
    
				}
			}

			public override DateTime LastUpdate
			{
				get
				{
					// TODO Auto-generated method stub
					return null;
				}
				set
				{
					// TODO Auto-generated method stub
    
				}
			}





			public override decimal TableRate
			{
				get
				{
					// TODO Auto-generated method stub
					return null;
				}
			}

			public override GroupCode Data
			{
				set
				{
					// TODO Auto-generated method stub
    
				}
			}

			public override void setFieldData(string field, GroupCode groupCodeTable)
			{
				// TODO Auto-generated method stub

			}


			public override string Notes
			{
				get
				{
					// TODO Auto-generated method stub
					return null;
				}
				set
				{
					// TODO Auto-generated method stub
    
				}
			}





			public override decimal UnitFactor
			{
				get
				{
					return BigDecimalMath.ONE;
				}
				set
				{
    
				}
			}

		}

		public override int getLevelOfGroupCode(GroupCode groupCode)
		{
			// TODO Auto-generated method stub
			return 0;
		}

		public virtual GroupCode getById(long? id)
		{
			foreach (GroupCode pGroupItem in hashMap.Values)
			{
				GroupCodesWithResource gwr = (GroupCodesWithResource)pGroupItem;
				if (gwr.ResourceTable.Id.Equals(id))
				{
					return gwr;
				}
			}
			return null;
		}
	}

}
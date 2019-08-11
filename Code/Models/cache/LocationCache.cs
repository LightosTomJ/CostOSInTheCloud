using System;

namespace Models.cache
{

	using BaseCache = nomitech.common.@base.BaseCache;
	using GroupCode = nomitech.common.@base.GroupCode;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;

	[Serializable]
	public class LocationCache : BaseCache
	{

		private static long? idCounter = 0L;

		public const string TABLE_NAME = "Location";

		public LocationCache(ProjectDBUtil prjDBUtil)
		{

		}

		private long? id;

		public virtual GroupCode getGroupCode(string code)
		{
			return new LocationGroupCode(this, code);
		}

		public class LocationGroupCode : GroupCode
		{
			private readonly LocationCache outerInstance;


			internal string code;
			internal string title;

			public LocationGroupCode(LocationCache outerInstance, string code)
			{
				this.outerInstance = outerInstance;
				this.code = code;
				if (code.Contains("."))
				{
					title = code.Substring(code.LastIndexOf(".", StringComparison.Ordinal) + 1);
				}
				else
				{
					title = code;
				}

				outerInstance.id = idCounter++;
				if (idCounter == long.MaxValue-1)
				{
					idCounter = long.MinValue+1;
				}
			}

			public override int compareTo(GroupCode o)
			{
				return Title.CompareTo(o.Title);
			}

			public override string Description
			{
				get
				{
					return null;
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
    
				}
			}

			public override string GroupCode
			{
				get
				{
					return code;
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
					return outerInstance.id;
				}
			}

			public override string ToString()
			{
				return title;
			}

			public virtual object clone()
			{
				return new LocationGroupCode(outerInstance, code);
			}

			public override string EditorId
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public override string CreateUserId
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public override DateTime CreateDate
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public override DateTime LastUpdate
			{
				get
				{
					return null;
				}
				set
				{
				}
			}





			public override decimal TableRate
			{
				get
				{
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




			public override string Unit
			{
				set
				{
					// TODO Auto-generated method stub
    
				}
				get
				{
					return "";
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


			public override decimal Quantity
			{
				get
				{
					// TODO Auto-generated method stub
					return null;
				}
			}
		}

		public override int getLevelOfGroupCode(GroupCode groupCode)
		{
			// TODO Auto-generated method stub
			return 0;
		}

	}

}
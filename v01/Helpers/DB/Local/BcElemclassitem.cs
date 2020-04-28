using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcElemclassitem
	{
		private LocalContext localContext;

		public BcElemclassitem(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcElemclassitemCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcElemclassitem.Count();
		}

		public List<Models.DB.Local.BcElemclassitem> GetAllBcElemclassitem()
		{
			List<Models.DB.Local.BcElemclassitem> BcElemclassitem = new List<Models.DB.Local.BcElemclassitem>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcElemclassitem = localContext.BcElemclassitem.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcElemclassitem;
		}
		public long CreatebcElemclassitem(List<Models.DB.Local.BcElemclassitem> BcElemclassitem)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElemclassitem bcElemclassitem in BcElemclassitem)
				{
					localContext.BcElemclassitem.Add(bcElemclassitem);
					localContext.SaveChanges();
					returnid = bcElemclassitem.BcElemclassitemId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcElemclassitem(long id, Models.DB.Local.BcElemclassitem bcElemclassitem)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElemclassitem.Update(bcElemclassitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcElemclassitem(long bcElemclassitemId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElemclassitem bcElemclassitem = localContext.BcElemclassitem.First(p => p.BcElemclassitemId == bcElemclassitemId);
				localContext.BcElemclassitem.Remove(bcElemclassitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

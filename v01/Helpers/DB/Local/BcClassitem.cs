using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcClassitem
	{
		private LocalContext localContext;

		public BcClassitem(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcClassitemCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcClassitem.Count();
		}

		public List<Models.DB.Local.BcClassitem> GetAllBcClassitem()
		{
			List<Models.DB.Local.BcClassitem> BcClassitem = new List<Models.DB.Local.BcClassitem>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcClassitem = localContext.BcClassitem.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcClassitem;
		}
		public long CreatebcClassitem(List<Models.DB.Local.BcClassitem> BcClassitem)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcClassitem bcClassitem in BcClassitem)
				{
					localContext.BcClassitem.Add(bcClassitem);
					localContext.SaveChanges();
					returnid = bcClassitem.BcClassitemId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcClassitem(long id, Models.DB.Local.BcClassitem bcClassitem)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcClassitem.Update(bcClassitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcClassitem(long bcClassitemId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcClassitem bcClassitem = localContext.BcClassitem.First(p => p.BcClassitemId == bcClassitemId);
				localContext.BcClassitem.Remove(bcClassitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

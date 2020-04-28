using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcGroupelem
	{
		private LocalContext localContext;

		public BcGroupelem(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcGroupelemCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcGroupelem.Count();
		}

		public List<Models.DB.Local.BcGroupelem> GetAllBcGroupelem()
		{
			List<Models.DB.Local.BcGroupelem> BcGroupelem = new List<Models.DB.Local.BcGroupelem>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcGroupelem = localContext.BcGroupelem.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcGroupelem;
		}
		public long CreatebcGroupelem(List<Models.DB.Local.BcGroupelem> BcGroupelem)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcGroupelem bcGroupelem in BcGroupelem)
				{
					localContext.BcGroupelem.Add(bcGroupelem);
					localContext.SaveChanges();
					returnid = bcGroupelem.BcGroupelemId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcGroupelem(long id, Models.DB.Local.BcGroupelem bcGroupelem)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcGroupelem.Update(bcGroupelem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcGroupelem(long bcGroupelemId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcGroupelem bcGroupelem = localContext.BcGroupelem.First(p => p.BcGroupelemId == bcGroupelemId);
				localContext.BcGroupelem.Remove(bcGroupelem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

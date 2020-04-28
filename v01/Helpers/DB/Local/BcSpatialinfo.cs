using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcSpatialinfo
	{
		private LocalContext localContext;

		public BcSpatialinfo(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcSpatialinfoCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcSpatialinfo.Count();
		}

		public List<Models.DB.Local.BcSpatialinfo> GetAllBcSpatialinfo()
		{
			List<Models.DB.Local.BcSpatialinfo> BcSpatialinfo = new List<Models.DB.Local.BcSpatialinfo>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcSpatialinfo = localContext.BcSpatialinfo.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcSpatialinfo;
		}
		public long CreatebcSpatialinfo(List<Models.DB.Local.BcSpatialinfo> BcSpatialinfo)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcSpatialinfo bcSpatialinfo in BcSpatialinfo)
				{
					localContext.BcSpatialinfo.Add(bcSpatialinfo);
					localContext.SaveChanges();
					returnid = bcSpatialinfo.BcSpatialinfoId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcSpatialinfo(long id, Models.DB.Local.BcSpatialinfo bcSpatialinfo)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcSpatialinfo.Update(bcSpatialinfo);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcSpatialinfo(long bcSpatialinfoId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcSpatialinfo bcSpatialinfo = localContext.BcSpatialinfo.First(p => p.BcSpatialinfoId == bcSpatialinfoId);
				localContext.BcSpatialinfo.Remove(bcSpatialinfo);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

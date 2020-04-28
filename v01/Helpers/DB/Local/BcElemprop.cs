using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcElemprop
	{
		private LocalContext localContext;

		public BcElemprop(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcElempropCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcElemprop.Count();
		}

		public List<Models.DB.Local.BcElemprop> GetAllBcElemprop()
		{
			List<Models.DB.Local.BcElemprop> BcElemprop = new List<Models.DB.Local.BcElemprop>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcElemprop = localContext.BcElemprop.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcElemprop;
		}
		public long CreatebcElemprop(List<Models.DB.Local.BcElemprop> BcElemprop)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElemprop bcElemprop in BcElemprop)
				{
					localContext.BcElemprop.Add(bcElemprop);
					localContext.SaveChanges();
					returnid = bcElemprop.BcElempropId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcElemprop(long id, Models.DB.Local.BcElemprop bcElemprop)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElemprop.Update(bcElemprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcElemprop(long bcElempropId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElemprop bcElemprop = localContext.BcElemprop.First(p => p.BcElempropId == bcElempropId);
				localContext.BcElemprop.Remove(bcElemprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

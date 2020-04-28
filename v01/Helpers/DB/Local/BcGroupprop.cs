using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcGroupprop
	{
		private LocalContext localContext;

		public BcGroupprop(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcGrouppropCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcGroupprop.Count();
		}

		public List<Models.DB.Local.BcGroupprop> GetAllBcGroupprop()
		{
			List<Models.DB.Local.BcGroupprop> BcGroupprop = new List<Models.DB.Local.BcGroupprop>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcGroupprop = localContext.BcGroupprop.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcGroupprop;
		}
		public long CreatebcGroupprop(List<Models.DB.Local.BcGroupprop> BcGroupprop)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcGroupprop bcGroupprop in BcGroupprop)
				{
					localContext.BcGroupprop.Add(bcGroupprop);
					localContext.SaveChanges();
					returnid = bcGroupprop.BcGrouppropId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcGroupprop(long id, Models.DB.Local.BcGroupprop bcGroupprop)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcGroupprop.Update(bcGroupprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcGroupprop(long bcGrouppropId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcGroupprop bcGroupprop = localContext.BcGroupprop.First(p => p.BcGrouppropId == bcGrouppropId);
				localContext.BcGroupprop.Remove(bcGroupprop);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

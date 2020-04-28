using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcClassification
	{
		private LocalContext localContext;

		public BcClassification(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcClassificationCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcClassification.Count();
		}

		public List<Models.DB.Local.BcClassification> GetAllBcClassification()
		{
			List<Models.DB.Local.BcClassification> BcClassification = new List<Models.DB.Local.BcClassification>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcClassification = localContext.BcClassification.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcClassification;
		}
		public long CreatebcClassification(List<Models.DB.Local.BcClassification> BcClassification)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcClassification bcClassification in BcClassification)
				{
					localContext.BcClassification.Add(bcClassification);
					localContext.SaveChanges();
					returnid = bcClassification.BcClassificationId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcClassification(long id, Models.DB.Local.BcClassification bcClassification)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcClassification.Update(bcClassification);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcClassification(long bcClassificationId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcClassification bcClassification = localContext.BcClassification.First(p => p.BcClassificationId == bcClassificationId);
				localContext.BcClassification.Remove(bcClassification);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

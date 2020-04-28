using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcQuantities
	{
		private LocalContext localContext;

		public BcQuantities(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcQuantityCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcQuantity.Count();
		}

		public List<Models.DB.Local.BcQuantity> GetAllBcQuantities()
		{
			List<Models.DB.Local.BcQuantity> BcQuantities = new List<Models.DB.Local.BcQuantity>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcQuantities = localContext.BcQuantity.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcQuantities;
		}
		public long CreatebcQuantity(List<Models.DB.Local.BcQuantity> BcQuantities)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcQuantity bcQuantity in BcQuantities)
				{
					localContext.BcQuantity.Add(bcQuantity);
					localContext.SaveChanges();
					returnid = bcQuantity.BcQuantityId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcQuantity(long id, Models.DB.Local.BcQuantity bcQuantity)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcQuantity.Update(bcQuantity);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcQuantity(long bcQuantityId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcQuantity bcQuantity = localContext.BcQuantity.First(p => p.BcQuantityId == bcQuantityId);
				localContext.BcQuantity.Remove(bcQuantity);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

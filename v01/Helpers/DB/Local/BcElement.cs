using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcElement
	{
		private LocalContext localContext;

		public BcElement(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcElementCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcElement.Count();
		}

		public List<Models.DB.Local.BcElement> GetAllBcElement()
		{
			List<Models.DB.Local.BcElement> BcElement = new List<Models.DB.Local.BcElement>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcElement = localContext.BcElement.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcElement;
		}
		public long CreatebcElement(List<Models.DB.Local.BcElement> BcElement)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElement bcElement in BcElement)
				{
					localContext.BcElement.Add(bcElement);
					localContext.SaveChanges();
					returnid = bcElement.BcElementId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcElement(long id, Models.DB.Local.BcElement bcElement)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElement.Update(bcElement);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcElement(long bcElementId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElement bcElement = localContext.BcElement.First(p => p.BcElementId == bcElementId);
				localContext.BcElement.Remove(bcElement);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

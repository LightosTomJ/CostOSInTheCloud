using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Wsdatamapping
	{
		private LocalContext localContext;

		public Wsdatamapping(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long WsdatamappingCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Wsdatamapping.Count();
		}

		public List<Models.DB.Local.Wsdatamapping> GetAllWsdatamapping()
		{
			List<Models.DB.Local.Wsdatamapping> Wsdatamapping = new List<Models.DB.Local.Wsdatamapping>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Wsdatamapping = localContext.Wsdatamapping.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Wsdatamapping;
		}
		public long Createwsdatamapping(List<Models.DB.Local.Wsdatamapping> Wsdatamapping)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Wsdatamapping wsdatamapping in Wsdatamapping)
				{
					localContext.Wsdatamapping.Add(wsdatamapping);
					localContext.SaveChanges();
					returnid = wsdatamapping.WsdatamappingId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatewsdatamapping(long id, Models.DB.Local.Wsdatamapping wsdatamapping)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Wsdatamapping.Update(wsdatamapping);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletewsdatamapping(long wsdatamappingId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Wsdatamapping wsdatamapping = localContext.Wsdatamapping.First(p => p.WsdatamappingId == wsdatamappingId);
				localContext.Wsdatamapping.Remove(wsdatamapping);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcElemmaterial
	{
		private LocalContext localContext;

		public BcElemmaterial(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcElemmaterialCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcElemmaterial.Count();
		}

		public List<Models.DB.Local.BcElemmaterial> GetAllBcElemmaterial()
		{
			List<Models.DB.Local.BcElemmaterial> BcElemmaterial = new List<Models.DB.Local.BcElemmaterial>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcElemmaterial = localContext.BcElemmaterial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcElemmaterial;
		}
		public long CreatebcElemmaterial(List<Models.DB.Local.BcElemmaterial> BcElemmaterial)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElemmaterial bcElemmaterial in BcElemmaterial)
				{
					localContext.BcElemmaterial.Add(bcElemmaterial);
					localContext.SaveChanges();
					returnid = bcElemmaterial.BcElemmaterialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcElemmaterial(long id, Models.DB.Local.BcElemmaterial bcElemmaterial)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElemmaterial.Update(bcElemmaterial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcElemmaterial(long bcElemmaterialId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElemmaterial bcElemmaterial = localContext.BcElemmaterial.First(p => p.BcElemmaterialId == bcElemmaterialId);
				localContext.BcElemmaterial.Remove(bcElemmaterial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Locfactor
	{
		private LocalContext localContext;

		public Locfactor(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long LocfactorCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Locfactor.Count();
		}

		public List<Models.DB.Local.Locfactor> GetAllLocfactor()
		{
			List<Models.DB.Local.Locfactor> Locfactor = new List<Models.DB.Local.Locfactor>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Locfactor = localContext.Locfactor.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Locfactor;
		}
		public long Createlocfactor(List<Models.DB.Local.Locfactor> Locfactor)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Locfactor locfactor in Locfactor)
				{
					localContext.Locfactor.Add(locfactor);
					localContext.SaveChanges();
					returnid = locfactor.LocfactorId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatelocfactor(long id, Models.DB.Local.Locfactor locfactor)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Locfactor.Update(locfactor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletelocfactor(long locfactorId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Locfactor locfactor = localContext.Locfactor.First(p => p.LocfactorId == locfactorId);
				localContext.Locfactor.Remove(locfactor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

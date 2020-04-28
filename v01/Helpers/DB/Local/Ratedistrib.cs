using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Ratedistrib
	{
		private LocalContext localContext;

		public Ratedistrib(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long RatedistribCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Ratedistrib.Count();
		}

		public List<Models.DB.Local.Ratedistrib> GetAllRatedistrib()
		{
			List<Models.DB.Local.Ratedistrib> Ratedistrib = new List<Models.DB.Local.Ratedistrib>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Ratedistrib = localContext.Ratedistrib.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Ratedistrib;
		}
		public long Createratedistrib(List<Models.DB.Local.Ratedistrib> Ratedistrib)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Ratedistrib ratedistrib in Ratedistrib)
				{
					localContext.Ratedistrib.Add(ratedistrib);
					localContext.SaveChanges();
					returnid = ratedistrib.RatedistribId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateratedistrib(long id, Models.DB.Local.Ratedistrib ratedistrib)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Ratedistrib.Update(ratedistrib);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteratedistrib(long ratedistribId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Ratedistrib ratedistrib = localContext.Ratedistrib.First(p => p.RatedistribId == ratedistribId);
				localContext.Ratedistrib.Remove(ratedistrib);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

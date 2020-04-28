using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Locprof
	{
		private LocalContext localContext;

		public Locprof(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long LocprofCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Locprof.Count();
		}

		public List<Models.DB.Local.Locprof> GetAllLocprof()
		{
			List<Models.DB.Local.Locprof> Locprof = new List<Models.DB.Local.Locprof>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Locprof = localContext.Locprof.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Locprof;
		}
		public long Createlocprof(List<Models.DB.Local.Locprof> Locprof)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Locprof locprof in Locprof)
				{
					localContext.Locprof.Add(locprof);
					localContext.SaveChanges();
					returnid = locprof.LocprofId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatelocprof(long id, Models.DB.Local.Locprof locprof)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Locprof.Update(locprof);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletelocprof(long locprofId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Locprof locprof = localContext.Locprof.First(p => p.LocprofId == locprofId);
				localContext.Locprof.Remove(locprof);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

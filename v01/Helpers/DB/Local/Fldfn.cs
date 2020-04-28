using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Fldfn
	{
		private LocalContext localContext;

		public Fldfn(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long FldfnCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Fldfn.Count();
		}

		public List<Models.DB.Local.Fldfn> GetAllFldfn()
		{
			List<Models.DB.Local.Fldfn> Fldfn = new List<Models.DB.Local.Fldfn>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Fldfn = localContext.Fldfn.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Fldfn;
		}
		public long Createfldfn(List<Models.DB.Local.Fldfn> Fldfn)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Fldfn fldfn in Fldfn)
				{
					localContext.Fldfn.Add(fldfn);
					localContext.SaveChanges();
					returnid = fldfn.FldfnId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatefldfn(long id, Models.DB.Local.Fldfn fldfn)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Fldfn.Update(fldfn);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletefldfn(long fldfnId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Fldfn fldfn = localContext.Fldfn.First(p => p.FldfnId == fldfnId);
				localContext.Fldfn.Remove(fldfn);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

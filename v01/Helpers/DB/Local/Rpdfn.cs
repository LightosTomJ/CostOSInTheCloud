using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Rpdfn
	{
		private LocalContext localContext;

		public Rpdfn(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long RpdfnCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Rpdfn.Count();
		}

		public List<Models.DB.Local.Rpdfn> GetAllRpdfn()
		{
			List<Models.DB.Local.Rpdfn> Rpdfn = new List<Models.DB.Local.Rpdfn>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Rpdfn = localContext.Rpdfn.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Rpdfn;
		}
		public long Createrpdfn(List<Models.DB.Local.Rpdfn> Rpdfn)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Rpdfn rpdfn in Rpdfn)
				{
					localContext.Rpdfn.Add(rpdfn);
					localContext.SaveChanges();
					returnid = rpdfn.RpdfnId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updaterpdfn(long id, Models.DB.Local.Rpdfn rpdfn)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Rpdfn.Update(rpdfn);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleterpdfn(long rpdfnId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Rpdfn rpdfn = localContext.Rpdfn.First(p => p.RpdfnId == rpdfnId);
				localContext.Rpdfn.Remove(rpdfn);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

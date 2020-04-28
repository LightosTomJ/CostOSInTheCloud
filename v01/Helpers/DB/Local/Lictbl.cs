using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Lictbl
	{
		private LocalContext localContext;

		public Lictbl(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long LictblCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Lictbl.Count();
		}

		public List<Models.DB.Local.Lictbl> GetAllLictbl()
		{
			List<Models.DB.Local.Lictbl> Lictbl = new List<Models.DB.Local.Lictbl>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Lictbl = localContext.Lictbl.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Lictbl;
		}
		public long Createlictbl(List<Models.DB.Local.Lictbl> Lictbl)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Lictbl lictbl in Lictbl)
				{
					localContext.Lictbl.Add(lictbl);
					localContext.SaveChanges();
					returnid = lictbl.LictblId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatelictbl(long id, Models.DB.Local.Lictbl lictbl)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Lictbl.Update(lictbl);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletelictbl(long lictblId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Lictbl lictbl = localContext.Lictbl.First(p => p.LictblId == lictblId);
				localContext.Lictbl.Remove(lictbl);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

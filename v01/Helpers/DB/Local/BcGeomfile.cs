using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcGeomfile
	{
		private LocalContext localContext;

		public BcGeomfile(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcGeomfileCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcGeomfile.Count();
		}

		public List<Models.DB.Local.BcGeomfile> GetAllBcGeomfile()
		{
			List<Models.DB.Local.BcGeomfile> BcGeomfile = new List<Models.DB.Local.BcGeomfile>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcGeomfile = localContext.BcGeomfile.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcGeomfile;
		}
		public long CreatebcGeomfile(List<Models.DB.Local.BcGeomfile> BcGeomfile)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcGeomfile bcGeomfile in BcGeomfile)
				{
					localContext.BcGeomfile.Add(bcGeomfile);
					localContext.SaveChanges();
					returnid = bcGeomfile.BcGeomfileId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcGeomfile(long id, Models.DB.Local.BcGeomfile bcGeomfile)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcGeomfile.Update(bcGeomfile);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcGeomfile(long bcGeomfileId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcGeomfile bcGeomfile = localContext.BcGeomfile.First(p => p.BcGeomfileId == bcGeomfileId);
				localContext.BcGeomfile.Remove(bcGeomfile);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

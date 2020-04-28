using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcGeometries
	{
		private LocalContext localContext;

		public BcGeometries(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcGeometryCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcGeometry.Count();
		}

		public List<Models.DB.Local.BcGeometry> GetAllBcGeometries()
		{
			List<Models.DB.Local.BcGeometry> BcGeometries = new List<Models.DB.Local.BcGeometry>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcGeometries = localContext.BcGeometry.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcGeometries;
		}
		public long CreatebcGeometry(List<Models.DB.Local.BcGeometry> BcGeometries)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcGeometry bcGeometry in BcGeometries)
				{
					localContext.BcGeometry.Add(bcGeometry);
					localContext.SaveChanges();
					returnid = bcGeometry.BcGeometryId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcGeometry(long id, Models.DB.Local.BcGeometry bcGeometry)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcGeometry.Update(bcGeometry);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcGeometry(long bcGeometryId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcGeometry bcGeometry = localContext.BcGeometry.First(p => p.BcGeometryId == bcGeometryId);
				localContext.BcGeometry.Remove(bcGeometry);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Subcontractor
	{
		private LocalContext localContext;

		public Subcontractor(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long SubcontractorCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Subcontractor.Count();
		}

		public List<Models.DB.Local.Subcontractor> GetAllSubcontractor()
		{
			List<Models.DB.Local.Subcontractor> Subcontractor = new List<Models.DB.Local.Subcontractor>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Subcontractor = localContext.Subcontractor.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Subcontractor;
		}
		public long Createsubcontractor(List<Models.DB.Local.Subcontractor> Subcontractor)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Subcontractor subcontractor in Subcontractor)
				{
					localContext.Subcontractor.Add(subcontractor);
					localContext.SaveChanges();
					returnid = subcontractor.SubcontractorId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatesubcontractor(long id, Models.DB.Local.Subcontractor subcontractor)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Subcontractor.Update(subcontractor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletesubcontractor(long subcontractorId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Subcontractor subcontractor = localContext.Subcontractor.First(p => p.SubcontractorId == subcontractorId);
				localContext.Subcontractor.Remove(subcontractor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

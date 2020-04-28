using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class AlcObjectsStatus
	{
		private LocalContext localContext;

		public AlcObjectsStatus(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long AlcObjectsStatusCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.AlcObjectsStatus.Count();
		}

		public List<Models.DB.Local.AlcObjectsStatus> GetAllAlcObjectsStatus()
		{
			List<Models.DB.Local.AlcObjectsStatus> AlcObjectsStatus = new List<Models.DB.Local.AlcObjectsStatus>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				AlcObjectsStatus = localContext.AlcObjectsStatus.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return AlcObjectsStatus;
		}
		public long CreatealcObjectsStatus(List<Models.DB.Local.AlcObjectsStatus> AlcObjectsStatus)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcObjectsStatus alcObjectsStatus in AlcObjectsStatus)
				{
					localContext.AlcObjectsStatus.Add(alcObjectsStatus);
					localContext.SaveChanges();
					returnid = alcObjectsStatus.AlcObjectsStatusId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatealcObjectsStatus(long id, Models.DB.Local.AlcObjectsStatus alcObjectsStatus)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcObjectsStatus.Update(alcObjectsStatus);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletealcObjectsStatus(long alcObjectsStatusId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcObjectsStatus alcObjectsStatus = localContext.AlcObjectsStatus.First(p => p.AlcObjectsStatusId == alcObjectsStatusId);
				localContext.AlcObjectsStatus.Remove(alcObjectsStatus);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

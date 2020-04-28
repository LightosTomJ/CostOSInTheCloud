using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Labor
	{
		private LocalContext localContext;

		public Labor(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long LaborCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Labor.Count();
		}

		public List<Models.DB.Local.Labor> GetAllLabor()
		{
			List<Models.DB.Local.Labor> Labor = new List<Models.DB.Local.Labor>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Labor = localContext.Labor.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Labor;
		}
		public long Createlabor(List<Models.DB.Local.Labor> Labor)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Labor labor in Labor)
				{
					localContext.Labor.Add(labor);
					localContext.SaveChanges();
					returnid = labor.LaborId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatelabor(long id, Models.DB.Local.Labor labor)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Labor.Update(labor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletelabor(long laborId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Labor labor = localContext.Labor.First(p => p.LaborId == laborId);
				localContext.Labor.Remove(labor);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

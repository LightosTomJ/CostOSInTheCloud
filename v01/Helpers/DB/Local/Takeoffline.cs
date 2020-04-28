using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Takeoffline
	{
		private LocalContext localContext;

		public Takeoffline(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long TakeofflineCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Takeoffline.Count();
		}

		public List<Models.DB.Local.Takeoffline> GetAllTakeoffline()
		{
			List<Models.DB.Local.Takeoffline> Takeoffline = new List<Models.DB.Local.Takeoffline>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Takeoffline = localContext.Takeoffline.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Takeoffline;
		}
		public long Createtakeoffline(List<Models.DB.Local.Takeoffline> Takeoffline)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Takeoffline takeoffline in Takeoffline)
				{
					localContext.Takeoffline.Add(takeoffline);
					localContext.SaveChanges();
					returnid = takeoffline.TakeofflineId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatetakeoffline(long id, Models.DB.Local.Takeoffline takeoffline)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Takeoffline.Update(takeoffline);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletetakeoffline(long takeofflineId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Takeoffline takeoffline = localContext.Takeoffline.First(p => p.TakeofflineId == takeofflineId);
				localContext.Takeoffline.Remove(takeoffline);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Takeoffcon
	{
		private LocalContext localContext;

		public Takeoffcon(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long TakeoffconCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Takeoffcon.Count();
		}

		public List<Models.DB.Local.Takeoffcon> GetAllTakeoffcon()
		{
			List<Models.DB.Local.Takeoffcon> Takeoffcon = new List<Models.DB.Local.Takeoffcon>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Takeoffcon = localContext.Takeoffcon.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Takeoffcon;
		}
		public long Createtakeoffcon(List<Models.DB.Local.Takeoffcon> Takeoffcon)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Takeoffcon takeoffcon in Takeoffcon)
				{
					localContext.Takeoffcon.Add(takeoffcon);
					localContext.SaveChanges();
					returnid = takeoffcon.TakeoffconId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatetakeoffcon(long id, Models.DB.Local.Takeoffcon takeoffcon)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Takeoffcon.Update(takeoffcon);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletetakeoffcon(long takeoffconId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Takeoffcon takeoffcon = localContext.Takeoffcon.First(p => p.TakeoffconId == takeoffconId);
				localContext.Takeoffcon.Remove(takeoffcon);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

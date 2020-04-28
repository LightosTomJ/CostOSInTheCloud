using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Takeoffpoint
	{
		private LocalContext localContext;

		public Takeoffpoint(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long TakeoffpointCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Takeoffpoint.Count();
		}

		public List<Models.DB.Local.Takeoffpoint> GetAllTakeoffpoint()
		{
			List<Models.DB.Local.Takeoffpoint> Takeoffpoint = new List<Models.DB.Local.Takeoffpoint>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Takeoffpoint = localContext.Takeoffpoint.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Takeoffpoint;
		}
		public long Createtakeoffpoint(List<Models.DB.Local.Takeoffpoint> Takeoffpoint)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Takeoffpoint takeoffpoint in Takeoffpoint)
				{
					localContext.Takeoffpoint.Add(takeoffpoint);
					localContext.SaveChanges();
					returnid = takeoffpoint.TakeoffpointId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatetakeoffpoint(long id, Models.DB.Local.Takeoffpoint takeoffpoint)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Takeoffpoint.Update(takeoffpoint);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletetakeoffpoint(long takeoffpointId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Takeoffpoint takeoffpoint = localContext.Takeoffpoint.First(p => p.TakeoffpointId == takeoffpointId);
				localContext.Takeoffpoint.Remove(takeoffpoint);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

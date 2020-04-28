using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Takeofflegend
	{
		private LocalContext localContext;

		public Takeofflegend(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long TakeofflegendCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Takeofflegend.Count();
		}

		public List<Models.DB.Local.Takeofflegend> GetAllTakeofflegend()
		{
			List<Models.DB.Local.Takeofflegend> Takeofflegend = new List<Models.DB.Local.Takeofflegend>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Takeofflegend = localContext.Takeofflegend.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Takeofflegend;
		}
		public long Createtakeofflegend(List<Models.DB.Local.Takeofflegend> Takeofflegend)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Takeofflegend takeofflegend in Takeofflegend)
				{
					localContext.Takeofflegend.Add(takeofflegend);
					localContext.SaveChanges();
					returnid = takeofflegend.TakeofflegendId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatetakeofflegend(long id, Models.DB.Local.Takeofflegend takeofflegend)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Takeofflegend.Update(takeofflegend);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletetakeofflegend(long takeofflegendId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Takeofflegend takeofflegend = localContext.Takeofflegend.First(p => p.TakeofflegendId == takeofflegendId);
				localContext.Takeofflegend.Remove(takeofflegend);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

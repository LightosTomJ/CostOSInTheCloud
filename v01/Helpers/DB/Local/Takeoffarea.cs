using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Takeoffarea
	{
		private LocalContext localContext;

		public Takeoffarea(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long TakeoffareaCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Takeoffarea.Count();
		}

		public List<Models.DB.Local.Takeoffarea> GetAllTakeoffarea()
		{
			List<Models.DB.Local.Takeoffarea> Takeoffarea = new List<Models.DB.Local.Takeoffarea>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Takeoffarea = localContext.Takeoffarea.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Takeoffarea;
		}
		public long Createtakeoffarea(List<Models.DB.Local.Takeoffarea> Takeoffarea)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Takeoffarea takeoffarea in Takeoffarea)
				{
					localContext.Takeoffarea.Add(takeoffarea);
					localContext.SaveChanges();
					returnid = takeoffarea.TakeoffareaId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatetakeoffarea(long id, Models.DB.Local.Takeoffarea takeoffarea)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Takeoffarea.Update(takeoffarea);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletetakeoffarea(long takeoffareaId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Takeoffarea takeoffarea = localContext.Takeoffarea.First(p => p.TakeoffareaId == takeoffareaId);
				localContext.Takeoffarea.Remove(takeoffarea);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

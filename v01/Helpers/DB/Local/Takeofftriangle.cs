using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Takeofftriangle
	{
		private LocalContext localContext;

		public Takeofftriangle(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long TakeofftriangleCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Takeofftriangle.Count();
		}

		public List<Models.DB.Local.Takeofftriangle> GetAllTakeofftriangle()
		{
			List<Models.DB.Local.Takeofftriangle> Takeofftriangle = new List<Models.DB.Local.Takeofftriangle>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Takeofftriangle = localContext.Takeofftriangle.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Takeofftriangle;
		}
		public long Createtakeofftriangle(List<Models.DB.Local.Takeofftriangle> Takeofftriangle)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Takeofftriangle takeofftriangle in Takeofftriangle)
				{
					localContext.Takeofftriangle.Add(takeofftriangle);
					localContext.SaveChanges();
					returnid = takeofftriangle.TakeofftriangleId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatetakeofftriangle(long id, Models.DB.Local.Takeofftriangle takeofftriangle)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Takeofftriangle.Update(takeofftriangle);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletetakeofftriangle(long takeofftriangleId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Takeofftriangle takeofftriangle = localContext.Takeofftriangle.First(p => p.TakeofftriangleId == takeofftriangleId);
				localContext.Takeofftriangle.Remove(takeofftriangle);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

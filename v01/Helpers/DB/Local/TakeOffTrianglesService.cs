using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class TakeOffTrianglesService
	{
		private LocalContext localContext;

		public TakeOffTrianglesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> TakeOffTriangleCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.TakeOffTriangle.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.TakeOffTriangle>> GetAllTakeOffTriangles()
		{
			IList<Models.DB.Local.TakeOffTriangle> TakeOffTriangles = new List<Models.DB.Local.TakeOffTriangle>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.TakeOffTriangle> takeOffTriangles = await localContext.TakeOffTriangle.ToListAsync();
				return takeOffTriangles;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateTakeOffTriangle(List<Models.DB.Local.TakeOffTriangle> TakeOffTriangles)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.TakeOffTriangle takeOffTriangle in TakeOffTriangles)
				{
					localContext.TakeOffTriangle.Add(takeOffTriangle);
					await localContext.SaveChangesAsync();
					returnid = takeOffTriangle.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateTakeOffTriangle(long id, Models.DB.Local.TakeOffTriangle takeOffTriangle)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.TakeOffTriangle.Update(takeOffTriangle);
				await localContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteTakeOffTriangle(long takeOffTriangleId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.TakeOffTriangle takeOffTriangle = localContext.TakeOffTriangle.First(p => p.Id == takeOffTriangleId);
				localContext.TakeOffTriangle.Remove(takeOffTriangle);
				await localContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
	}
}

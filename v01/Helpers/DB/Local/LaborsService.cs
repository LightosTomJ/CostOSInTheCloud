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
	public class LaborsService
	{
		private LocalContext localContext;

		public LaborsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> LaborCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Labor.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Labor>> GetAllLaborers()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Labor> labors = await localContext.Labor.ToListAsync();
				return labors;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateLabor(List<Models.DB.Local.Labor> Labors)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Labor labor in Labors)
				{
					localContext.Labor.Add(labor);
					await localContext.SaveChangesAsync();
					returnid = labor.Laborid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateLabor(Models.DB.Local.Labor labor)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Labor.Update(labor);
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
		public async Task<bool> DeleteLabor(long laborId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Labor labor = localContext.Labor.First(p => p.Laborid == laborId);
				localContext.Labor.Remove(labor);
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

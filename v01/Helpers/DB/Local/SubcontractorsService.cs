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
	public class SubcontractorsService
	{
		private LocalContext localContext;

		public SubcontractorsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> SubcontractorCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Subcontractor.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Subcontractor>> GetAllSubcontractors()
		{
			IList<Models.DB.Local.Subcontractor> Subcontractors = new List<Models.DB.Local.Subcontractor>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Subcontractor> subcontractors = await localContext.Subcontractor.ToListAsync();
				return subcontractors;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateSubcontractor(List<Models.DB.Local.Subcontractor> Subcontractors)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Subcontractor subcontractor in Subcontractors)
				{
					localContext.Subcontractor.Add(subcontractor);
					await localContext.SaveChangesAsync();
					returnid = subcontractor.Subcontractorid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateSubcontractor(long id, Models.DB.Local.Subcontractor subcontractor)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Subcontractor.Update(subcontractor);
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
		public async Task<bool> DeleteSubcontractor(long subcontractorId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Subcontractor subcontractor = localContext.Subcontractor.First(p => p.Subcontractorid == subcontractorId);
				localContext.Subcontractor.Remove(subcontractor);
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

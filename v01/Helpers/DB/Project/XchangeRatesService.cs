using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class XchangeRatesService
	{
		private ProjectContext projectContext;

		public XchangeRatesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> XchangeRateCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.XchangeRate.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.XchangeRate>> GetAllXchangeRates()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.XchangeRate> xchangeRates = await projectContext.XchangeRate.ToListAsync();
				return xchangeRates;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateXchangeRate(List<Models.DB.Project.XchangeRate> XchangeRates)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.XchangeRate xchangeRate in XchangeRates)
				{
					projectContext.XchangeRate.Add(xchangeRate);
					await projectContext.SaveChangesAsync();
					returnid = xchangeRate.Xchangerateid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateXchangeRate(Models.DB.Project.XchangeRate xchangeRate)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.XchangeRate.Update(xchangeRate);
				await projectContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteXchangeRate(long xchangeRateId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.XchangeRate xchangeRate = projectContext.XchangeRate.First(p => p.Xchangerateid == xchangeRateId);
				projectContext.XchangeRate.Remove(xchangeRate);
				await projectContext.SaveChangesAsync();
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

using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Config
{
	public class CompaniesService
	{
		private ConfigContext configContext;

		public CompaniesService(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public async Task<long> CompaniesCount()
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				return await configContext.Companies.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Config.Companies>> GetAllCompanies()
		{
			IList<Models.DB.Config.Companies> Companies = new List<Models.DB.Config.Companies>();
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				IList<Models.DB.Config.Companies> companies = await configContext.Companies.ToListAsync();
				return companies;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateCompanies(List<Models.DB.Config.Companies> Companies)
		{
			long returnid = -1;
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.Companies companies in Companies)
				{
					configContext.Companies.Add(companies);
					await configContext.SaveChangesAsync();
					returnid = companies.CompanyId;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateCompanies(long id, Models.DB.Config.Companies companies)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.Companies.Update(companies);
				await configContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteCompanies(long companiesId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.Companies companies = configContext.Companies.First(p => p.CompanyId == companiesId);
				configContext.Companies.Remove(companies);
				await configContext.SaveChangesAsync();
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

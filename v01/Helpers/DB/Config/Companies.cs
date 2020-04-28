using Models.DB.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Config
{
	public class Companies
	{
		private ConfigContext configContext;

		public Companies(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public long CompaniesCount()
		{
			if (configContext == null) configContext = new ConfigContext();
			return configContext.Companies.Count();
		}

		public List<Models.DB.Config.Companies> GetAllCompanies()
		{
			List<Models.DB.Config.Companies> Companies = new List<Models.DB.Config.Companies>();
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Companies = configContext.Companies.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Companies;
		}
		public long Createcompanies(List<Models.DB.Config.Companies> Companies)
		{
			long returnid = 0;
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.Companies companies in Companies)
				{
					configContext.Companies.Add(companies);
					configContext.SaveChanges();
					returnid = companies.CompaniesId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatecompanies(long id, Models.DB.Config.Companies companies)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.Companies.Update(companies);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletecompanies(long companiesId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.Companies companies = configContext.Companies.First(p => p.CompaniesId == companiesId);
				configContext.Companies.Remove(companies);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

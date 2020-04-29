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
	public class GendersService
	{
		private ConfigContext configContext;

		public GendersService(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public async Task<long> GendersCount()
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				return await configContext.Genders.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Config.Genders>> GetAllGenders()
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				IList<Models.DB.Config.Genders> genders = await configContext.Genders.ToListAsync();
				return genders;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateGenders(List<Models.DB.Config.Genders> Genders)
		{
			long returnid = -1;
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.Genders genders in Genders)
				{
					configContext.Genders.Add(genders);
					await configContext.SaveChangesAsync();
					returnid = genders.GenderId;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateGenders(Models.DB.Config.Genders genders)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.Genders.Update(genders);
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
		public async Task<bool> DeleteGenders(long gendersId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.Genders genders = configContext.Genders.First(p => p.GenderId == gendersId);
				configContext.Genders.Remove(genders);
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

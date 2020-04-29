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
	public class AspNetUserClaimsService
	{
		private ConfigContext configContext;

		public AspNetUserClaimsService(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public async Task<long> AspNetUserClaimsCount()
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				return await configContext.AspNetUserClaims.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Config.AspNetUserClaims>> GetAllAspNetUserClaims()
		{
			IList<Models.DB.Config.AspNetUserClaims> AspNetUserClaims = new List<Models.DB.Config.AspNetUserClaims>();
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				IList<Models.DB.Config.AspNetUserClaims> aspNetUserClaims = await configContext.AspNetUserClaims.ToListAsync();
				return aspNetUserClaims;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateAspNetUserClaims(List<Models.DB.Config.AspNetUserClaims> AspNetUserClaims)
		{
			long returnid = -1;
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.AspNetUserClaims aspNetUserClaims in AspNetUserClaims)
				{
					configContext.AspNetUserClaims.Add(aspNetUserClaims);
					await configContext.SaveChangesAsync();
					returnid = aspNetUserClaims.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAspNetUserClaims(long id, Models.DB.Config.AspNetUserClaims aspNetUserClaims)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.AspNetUserClaims.Update(aspNetUserClaims);
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
		public async Task<bool> DeleteAspNetUserClaims(long aspNetUserClaimsId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.AspNetUserClaims aspNetUserClaims = configContext.AspNetUserClaims.First(p => p.Id == aspNetUserClaimsId);
				configContext.AspNetUserClaims.Remove(aspNetUserClaims);
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

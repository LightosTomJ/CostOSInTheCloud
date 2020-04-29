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
	public class BcGroupsService
	{
		private LocalContext localContext;

		public BcGroupsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcGroupCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcGroup.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcGroup>> GetAllBcGroups()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcGroup> bcGroups = await localContext.BcGroup.ToListAsync();
				return bcGroups;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcGroup(List<Models.DB.Local.BcGroup> BcGroups)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcGroup bcGroup in BcGroups)
				{
					localContext.BcGroup.Add(bcGroup);
					await localContext.SaveChangesAsync();
					returnid = bcGroup.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcGroup(Models.DB.Local.BcGroup bcGroup)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcGroup.Update(bcGroup);
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
		public async Task<bool> DeleteBcGroup(long bcGroupId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcGroup bcGroup = localContext.BcGroup.First(p => p.Id == bcGroupId);
				localContext.BcGroup.Remove(bcGroup);
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

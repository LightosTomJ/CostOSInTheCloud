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
	public class GroupcodesService
	{
		private LocalContext localContext;

		public GroupcodesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> GroupcodeCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Groupcode.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Groupcode>> GetAllGroupcodes()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Groupcode> groupcodes = await localContext.Groupcode.ToListAsync();
				return groupcodes;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateGroupcode(List<Models.DB.Local.Groupcode> Groupcodes)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Groupcode groupcode in Groupcodes)
				{
					localContext.Groupcode.Add(groupcode);
					await localContext.SaveChangesAsync();
					returnid = groupcode.Groupcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateGroupcode(Models.DB.Local.Groupcode groupcode)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Groupcode.Update(groupcode);
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
		public async Task<bool> DeleteGroupcode(long groupcodeId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Groupcode groupcode = localContext.Groupcode.First(p => p.Groupcodeid == groupcodeId);
				localContext.Groupcode.Remove(groupcode);
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

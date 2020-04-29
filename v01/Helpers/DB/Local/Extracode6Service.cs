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
	public class Extracode6Service
	{
		private LocalContext localContext;

		public Extracode6Service(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> Extracode6Count()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Extracode6.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Extracode6>> GetAllExtracode6s()
		{
			IList<Models.DB.Local.Extracode6> Extracode6s = new List<Models.DB.Local.Extracode6>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Extracode6> extracode6s = await localContext.Extracode6.ToListAsync();
				return extracode6s;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtracode6(List<Models.DB.Local.Extracode6> Extracode6s)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extracode6 extracode6 in Extracode6s)
				{
					localContext.Extracode6.Add(extracode6);
					await localContext.SaveChangesAsync();
					returnid = extracode6.Groupcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtracode6(long id, Models.DB.Local.Extracode6 extracode6)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extracode6.Update(extracode6);
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
		public async Task<bool> DeleteExtracode6(long extracode6Id)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extracode6 extracode6 = localContext.Extracode6.First(p => p.Groupcodeid == extracode6Id);
				localContext.Extracode6.Remove(extracode6);
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

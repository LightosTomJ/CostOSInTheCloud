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
	public class Extracode2Service
	{
		private LocalContext localContext;

		public Extracode2Service(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> Extracode2Count()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Extracode2.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Extracode2>> GetAllExtracode2s()
		{
			IList<Models.DB.Local.Extracode2> Extracode2s = new List<Models.DB.Local.Extracode2>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Extracode2> extracode2s = await localContext.Extracode2.ToListAsync();
				return extracode2s;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtracode2(List<Models.DB.Local.Extracode2> Extracode2s)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extracode2 extracode2 in Extracode2s)
				{
					localContext.Extracode2.Add(extracode2);
					await localContext.SaveChangesAsync();
					returnid = extracode2.Groupcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtracode2(Models.DB.Local.Extracode2 extracode2)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extracode2.Update(extracode2);
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
		public async Task<bool> DeleteExtracode2(long extracode2Id)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extracode2 extracode2 = localContext.Extracode2.First(p => p.Groupcodeid == extracode2Id);
				localContext.Extracode2.Remove(extracode2);
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

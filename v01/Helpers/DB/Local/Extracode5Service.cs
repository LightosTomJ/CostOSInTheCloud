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
	public class Extracode5Service
	{
		private LocalContext localContext;

		public Extracode5Service(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> Extracode5Count()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Extracode5.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Extracode5>> GetAllExtracode5s()
		{
			IList<Models.DB.Local.Extracode5> Extracode5s = new List<Models.DB.Local.Extracode5>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Extracode5> extracode5s = await localContext.Extracode5.ToListAsync();
				return extracode5s;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtracode5(List<Models.DB.Local.Extracode5> Extracode5s)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extracode5 extracode5 in Extracode5s)
				{
					localContext.Extracode5.Add(extracode5);
					await localContext.SaveChangesAsync();
					returnid = extracode5.Groupcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtracode5(Models.DB.Local.Extracode5 extracode5)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extracode5.Update(extracode5);
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
		public async Task<bool> DeleteExtracode5(long extracode5Id)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extracode5 extracode5 = localContext.Extracode5.First(p => p.Groupcodeid == extracode5Id);
				localContext.Extracode5.Remove(extracode5);
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

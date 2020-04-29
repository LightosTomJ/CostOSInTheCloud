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
	public class Extracode7Service
	{
		private LocalContext localContext;

		public Extracode7Service(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> Extracode7Count()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Extracode7.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Extracode7>> GetAllExtracode7s()
		{
			IList<Models.DB.Local.Extracode7> Extracode7s = new List<Models.DB.Local.Extracode7>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Extracode7> extracode7s = await localContext.Extracode7.ToListAsync();
				return extracode7s;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtracode7(List<Models.DB.Local.Extracode7> Extracode7s)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extracode7 extracode7 in Extracode7s)
				{
					localContext.Extracode7.Add(extracode7);
					await localContext.SaveChangesAsync();
					returnid = extracode7.Groupcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtracode7(long id, Models.DB.Local.Extracode7 extracode7)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extracode7.Update(extracode7);
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
		public async Task<bool> DeleteExtracode7(long extracode7Id)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extracode7 extracode7 = localContext.Extracode7.First(p => p.Groupcodeid == extracode7Id);
				localContext.Extracode7.Remove(extracode7);
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

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
	public class Extracode4Service
	{
		private LocalContext localContext;

		public Extracode4Service(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> Extracode4Count()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Extracode4.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Extracode4>> GetAllExtracode4s()
		{
			IList<Models.DB.Local.Extracode4> Extracode4s = new List<Models.DB.Local.Extracode4>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Extracode4> extracode4s = await localContext.Extracode4.ToListAsync();
				return extracode4s;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtracode4(List<Models.DB.Local.Extracode4> Extracode4s)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extracode4 extracode4 in Extracode4s)
				{
					localContext.Extracode4.Add(extracode4);
					await localContext.SaveChangesAsync();
					returnid = extracode4.Groupcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtracode4(long id, Models.DB.Local.Extracode4 extracode4)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extracode4.Update(extracode4);
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
		public async Task<bool> DeleteExtracode4(long extracode4Id)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extracode4 extracode4 = localContext.Extracode4.First(p => p.Groupcodeid == extracode4Id);
				localContext.Extracode4.Remove(extracode4);
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

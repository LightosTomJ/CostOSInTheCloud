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
	public class Extracode3Service
	{
		private LocalContext localContext;

		public Extracode3Service(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> Extracode3Count()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Extracode3.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Extracode3>> GetAllExtracode3s()
		{
			IList<Models.DB.Local.Extracode3> Extracode3s = new List<Models.DB.Local.Extracode3>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Extracode3> extracode3s = await localContext.Extracode3.ToListAsync();
				return extracode3s;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateExtracode3(List<Models.DB.Local.Extracode3> Extracode3s)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Extracode3 extracode3 in Extracode3s)
				{
					localContext.Extracode3.Add(extracode3);
					await localContext.SaveChangesAsync();
					returnid = extracode3.Groupcodeid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateExtracode3(long id, Models.DB.Local.Extracode3 extracode3)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Extracode3.Update(extracode3);
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
		public async Task<bool> DeleteExtracode3(long extracode3Id)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Extracode3 extracode3 = localContext.Extracode3.First(p => p.Groupcodeid == extracode3Id);
				localContext.Extracode3.Remove(extracode3);
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

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
	public class FnctonsService
	{
		private LocalContext localContext;

		public FnctonsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> FnctonCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Fncton.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Fncton>> GetAllFnctons()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Fncton> fnctons = await localContext.Fncton.ToListAsync();
				return fnctons;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateFncton(List<Models.DB.Local.Fncton> Fnctons)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Fncton fncton in Fnctons)
				{
					localContext.Fncton.Add(fncton);
					await localContext.SaveChangesAsync();
					returnid = fncton.Functionid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateFncton(Models.DB.Local.Fncton fncton)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Fncton.Update(fncton);
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
		public async Task<bool> DeleteFncton(long fnctonId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Fncton fncton = localContext.Fncton.First(p => p.Functionid == fnctonId);
				localContext.Fncton.Remove(fncton);
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

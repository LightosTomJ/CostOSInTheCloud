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
	public class PrjPropsService
	{
		private LocalContext localContext;

		public PrjPropsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> PrjPropCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.PrjProp.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.PrjProp>> GetAllPrjProps()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.PrjProp> prjProps = await localContext.PrjProp.ToListAsync();
				return prjProps;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreatePrjProp(List<Models.DB.Local.PrjProp> PrjProps)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.PrjProp prjProp in PrjProps)
				{
					localContext.PrjProp.Add(prjProp);
					await localContext.SaveChangesAsync();
					returnid = prjProp.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdatePrjProp(Models.DB.Local.PrjProp prjProp)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.PrjProp.Update(prjProp);
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
		public async Task<bool> DeletePrjProp(long prjPropId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.PrjProp prjProp = localContext.PrjProp.First(p => p.Id == prjPropId);
				localContext.PrjProp.Remove(prjProp);
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

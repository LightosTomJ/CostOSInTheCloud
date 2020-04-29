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
	public class FldFnsService
	{
		private LocalContext localContext;

		public FldFnsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> FldFnCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.FldFn.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.FldFn>> GetAllFldFns()
		{
			IList<Models.DB.Local.FldFn> FldFns = new List<Models.DB.Local.FldFn>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.FldFn> fldFns = await localContext.FldFn.ToListAsync();
				return fldFns;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateFldFn(List<Models.DB.Local.FldFn> FldFns)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.FldFn fldFn in FldFns)
				{
					localContext.FldFn.Add(fldFn);
					await localContext.SaveChangesAsync();
					returnid = fldFn.Fldfnid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateFldFn(long id, Models.DB.Local.FldFn fldFn)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.FldFn.Update(fldFn);
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
		public async Task<bool> DeleteFldFn(long fldFnId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.FldFn fldFn = localContext.FldFn.First(p => p.Fldfnid == fldFnId);
				localContext.FldFn.Remove(fldFn);
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

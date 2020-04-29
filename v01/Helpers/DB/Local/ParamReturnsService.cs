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
	public class ParamReturnsService
	{
		private LocalContext localContext;

		public ParamReturnsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ParamReturnCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ParamReturn.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.ParamReturn>> GetAllParamReturns()
		{
			IList<Models.DB.Local.ParamReturn> ParamReturns = new List<Models.DB.Local.ParamReturn>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.ParamReturn> paramReturns = await localContext.ParamReturn.ToListAsync();
				return paramReturns;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateParamReturn(List<Models.DB.Local.ParamReturn> ParamReturns)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ParamReturn paramReturn in ParamReturns)
				{
					localContext.ParamReturn.Add(paramReturn);
					await localContext.SaveChangesAsync();
					returnid = paramReturn.Paramreturnid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateParamReturn(long id, Models.DB.Local.ParamReturn paramReturn)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ParamReturn.Update(paramReturn);
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
		public async Task<bool> DeleteParamReturn(long paramReturnId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ParamReturn paramReturn = localContext.ParamReturn.First(p => p.Paramreturnid == paramReturnId);
				localContext.ParamReturn.Remove(paramReturn);
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

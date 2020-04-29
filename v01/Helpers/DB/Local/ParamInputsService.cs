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
	public class ParamInputsService
	{
		private LocalContext localContext;

		public ParamInputsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ParamInputCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ParamInput.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.ParamInput>> GetAllParamInputs()
		{
			IList<Models.DB.Local.ParamInput> ParamInputs = new List<Models.DB.Local.ParamInput>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.ParamInput> paramInputs = await localContext.ParamInput.ToListAsync();
				return paramInputs;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateParamInput(List<Models.DB.Local.ParamInput> ParamInputs)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ParamInput paramInput in ParamInputs)
				{
					localContext.ParamInput.Add(paramInput);
					await localContext.SaveChangesAsync();
					returnid = paramInput.Paraminputid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateParamInput(long id, Models.DB.Local.ParamInput paramInput)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ParamInput.Update(paramInput);
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
		public async Task<bool> DeleteParamInput(long paramInputId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ParamInput paramInput = localContext.ParamInput.First(p => p.Paraminputid == paramInputId);
				localContext.ParamInput.Remove(paramInput);
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

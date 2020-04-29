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
	public class ParamOutputsService
	{
		private LocalContext localContext;

		public ParamOutputsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> ParamOutputCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.ParamOutput.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.ParamOutput>> GetAllParamOutputs()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.ParamOutput> paramOutputs = await localContext.ParamOutput.ToListAsync();
				return paramOutputs;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateParamOutput(List<Models.DB.Local.ParamOutput> ParamOutputs)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.ParamOutput paramOutput in ParamOutputs)
				{
					localContext.ParamOutput.Add(paramOutput);
					await localContext.SaveChangesAsync();
					returnid = paramOutput.Paramoutputid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateParamOutput(Models.DB.Local.ParamOutput paramOutput)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.ParamOutput.Update(paramOutput);
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
		public async Task<bool> DeleteParamOutput(long paramOutputId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.ParamOutput paramOutput = localContext.ParamOutput.First(p => p.Paramoutputid == paramOutputId);
				localContext.ParamOutput.Remove(paramOutput);
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

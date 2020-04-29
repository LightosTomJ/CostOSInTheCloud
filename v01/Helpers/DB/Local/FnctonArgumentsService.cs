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
	public class FnctonArgumentsService
	{
		private LocalContext localContext;

		public FnctonArgumentsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> FnctonArgumentCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.FnctonArgument.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.FnctonArgument>> GetAllFnctonArguments()
		{
			IList<Models.DB.Local.FnctonArgument> FnctonArguments = new List<Models.DB.Local.FnctonArgument>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.FnctonArgument> fnctonArguments = await localContext.FnctonArgument.ToListAsync();
				return fnctonArguments;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateFnctonArgument(List<Models.DB.Local.FnctonArgument> FnctonArguments)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.FnctonArgument fnctonArgument in FnctonArguments)
				{
					localContext.FnctonArgument.Add(fnctonArgument);
					await localContext.SaveChangesAsync();
					returnid = fnctonArgument.Fargid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateFnctonArgument(long id, Models.DB.Local.FnctonArgument fnctonArgument)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.FnctonArgument.Update(fnctonArgument);
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
		public async Task<bool> DeleteFnctonArgument(long fnctonArgumentId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.FnctonArgument fnctonArgument = localContext.FnctonArgument.First(p => p.Fargid == fnctonArgumentId);
				localContext.FnctonArgument.Remove(fnctonArgument);
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

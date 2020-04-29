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
	public class BcModelsService
	{
		private LocalContext localContext;

		public BcModelsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcModelCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcModel.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcModel>> GetAllBcModels()
		{
			IList<Models.DB.Local.BcModel> BcModels = new List<Models.DB.Local.BcModel>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcModel> bcModels = await localContext.BcModel.ToListAsync();
				return bcModels;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcModel(List<Models.DB.Local.BcModel> BcModels)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcModel bcModel in BcModels)
				{
					localContext.BcModel.Add(bcModel);
					await localContext.SaveChangesAsync();
					returnid = bcModel.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcModel(long id, Models.DB.Local.BcModel bcModel)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcModel.Update(bcModel);
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
		public async Task<bool> DeleteBcModel(long bcModelId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcModel bcModel = localContext.BcModel.First(p => p.Id == bcModelId);
				localContext.BcModel.Remove(bcModel);
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

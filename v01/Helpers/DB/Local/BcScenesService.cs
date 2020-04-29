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
	public class BcScenesService
	{
		private LocalContext localContext;

		public BcScenesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcSceneCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcScene.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcScene>> GetAllBcScenes()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcScene> bcScenes = await localContext.BcScene.ToListAsync();
				return bcScenes;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcScene(List<Models.DB.Local.BcScene> BcScenes)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcScene bcScene in BcScenes)
				{
					localContext.BcScene.Add(bcScene);
					await localContext.SaveChangesAsync();
					returnid = bcScene.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcScene(Models.DB.Local.BcScene bcScene)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcScene.Update(bcScene);
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
		public async Task<bool> DeleteBcScene(long bcSceneId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcScene bcScene = localContext.BcScene.First(p => p.Id == bcSceneId);
				localContext.BcScene.Remove(bcScene);
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

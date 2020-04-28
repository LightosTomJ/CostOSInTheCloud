using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcScene
	{
		private LocalContext localContext;

		public BcScene(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcSceneCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcScene.Count();
		}

		public List<Models.DB.Local.BcScene> GetAllBcScene()
		{
			List<Models.DB.Local.BcScene> BcScene = new List<Models.DB.Local.BcScene>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcScene = localContext.BcScene.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcScene;
		}
		public long CreatebcScene(List<Models.DB.Local.BcScene> BcScene)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcScene bcScene in BcScene)
				{
					localContext.BcScene.Add(bcScene);
					localContext.SaveChanges();
					returnid = bcScene.BcSceneId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcScene(long id, Models.DB.Local.BcScene bcScene)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcScene.Update(bcScene);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcScene(long bcSceneId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcScene bcScene = localContext.BcScene.First(p => p.BcSceneId == bcSceneId);
				localContext.BcScene.Remove(bcScene);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

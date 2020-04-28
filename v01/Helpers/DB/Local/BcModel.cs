using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcModel
	{
		private LocalContext localContext;

		public BcModel(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcModelCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcModel.Count();
		}

		public List<Models.DB.Local.BcModel> GetAllBcModel()
		{
			List<Models.DB.Local.BcModel> BcModel = new List<Models.DB.Local.BcModel>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcModel = localContext.BcModel.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcModel;
		}
		public long CreatebcModel(List<Models.DB.Local.BcModel> BcModel)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcModel bcModel in BcModel)
				{
					localContext.BcModel.Add(bcModel);
					localContext.SaveChanges();
					returnid = bcModel.BcModelId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcModel(long id, Models.DB.Local.BcModel bcModel)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcModel.Update(bcModel);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcModel(long bcModelId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcModel bcModel = localContext.BcModel.First(p => p.BcModelId == bcModelId);
				localContext.BcModel.Remove(bcModel);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

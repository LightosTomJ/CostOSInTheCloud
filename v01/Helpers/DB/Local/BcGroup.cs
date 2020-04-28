using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcGroup
	{
		private LocalContext localContext;

		public BcGroup(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcGroupCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcGroup.Count();
		}

		public List<Models.DB.Local.BcGroup> GetAllBcGroup()
		{
			List<Models.DB.Local.BcGroup> BcGroup = new List<Models.DB.Local.BcGroup>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcGroup = localContext.BcGroup.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcGroup;
		}
		public long CreatebcGroup(List<Models.DB.Local.BcGroup> BcGroup)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcGroup bcGroup in BcGroup)
				{
					localContext.BcGroup.Add(bcGroup);
					localContext.SaveChanges();
					returnid = bcGroup.BcGroupId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcGroup(long id, Models.DB.Local.BcGroup bcGroup)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcGroup.Update(bcGroup);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcGroup(long bcGroupId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcGroup bcGroup = localContext.BcGroup.First(p => p.BcGroupId == bcGroupId);
				localContext.BcGroup.Remove(bcGroup);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

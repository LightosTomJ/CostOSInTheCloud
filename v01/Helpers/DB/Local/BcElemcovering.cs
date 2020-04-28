using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcElemcovering
	{
		private LocalContext localContext;

		public BcElemcovering(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcElemcoveringCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcElemcovering.Count();
		}

		public List<Models.DB.Local.BcElemcovering> GetAllBcElemcovering()
		{
			List<Models.DB.Local.BcElemcovering> BcElemcovering = new List<Models.DB.Local.BcElemcovering>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcElemcovering = localContext.BcElemcovering.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcElemcovering;
		}
		public long CreatebcElemcovering(List<Models.DB.Local.BcElemcovering> BcElemcovering)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElemcovering bcElemcovering in BcElemcovering)
				{
					localContext.BcElemcovering.Add(bcElemcovering);
					localContext.SaveChanges();
					returnid = bcElemcovering.BcElemcoveringId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcElemcovering(long id, Models.DB.Local.BcElemcovering bcElemcovering)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElemcovering.Update(bcElemcovering);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcElemcovering(long bcElemcoveringId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElemcovering bcElemcovering = localContext.BcElemcovering.First(p => p.BcElemcoveringId == bcElemcoveringId);
				localContext.BcElemcovering.Remove(bcElemcovering);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Gekcode
	{
		private LocalContext localContext;

		public Gekcode(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long GekcodeCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Gekcode.Count();
		}

		public List<Models.DB.Local.Gekcode> GetAllGekcode()
		{
			List<Models.DB.Local.Gekcode> Gekcode = new List<Models.DB.Local.Gekcode>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Gekcode = localContext.Gekcode.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Gekcode;
		}
		public long Creategekcode(List<Models.DB.Local.Gekcode> Gekcode)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Gekcode gekcode in Gekcode)
				{
					localContext.Gekcode.Add(gekcode);
					localContext.SaveChanges();
					returnid = gekcode.GekcodeId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updategekcode(long id, Models.DB.Local.Gekcode gekcode)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Gekcode.Update(gekcode);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletegekcode(long gekcodeId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Gekcode gekcode = localContext.Gekcode.First(p => p.GekcodeId == gekcodeId);
				localContext.Gekcode.Remove(gekcode);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

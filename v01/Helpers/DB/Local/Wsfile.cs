using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Wsfile
	{
		private LocalContext localContext;

		public Wsfile(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long WsfileCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Wsfile.Count();
		}

		public List<Models.DB.Local.Wsfile> GetAllWsfile()
		{
			List<Models.DB.Local.Wsfile> Wsfile = new List<Models.DB.Local.Wsfile>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Wsfile = localContext.Wsfile.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Wsfile;
		}
		public long Createwsfile(List<Models.DB.Local.Wsfile> Wsfile)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Wsfile wsfile in Wsfile)
				{
					localContext.Wsfile.Add(wsfile);
					localContext.SaveChanges();
					returnid = wsfile.WsfileId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatewsfile(long id, Models.DB.Local.Wsfile wsfile)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Wsfile.Update(wsfile);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletewsfile(long wsfileId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Wsfile wsfile = localContext.Wsfile.First(p => p.WsfileId == wsfileId);
				localContext.Wsfile.Remove(wsfile);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

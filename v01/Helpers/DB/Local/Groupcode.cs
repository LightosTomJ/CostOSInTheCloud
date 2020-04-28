using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Groupcode
	{
		private LocalContext localContext;

		public Groupcode(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long GroupcodeCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Groupcode.Count();
		}

		public List<Models.DB.Local.Groupcode> GetAllGroupcode()
		{
			List<Models.DB.Local.Groupcode> Groupcode = new List<Models.DB.Local.Groupcode>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Groupcode = localContext.Groupcode.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Groupcode;
		}
		public long Creategroupcode(List<Models.DB.Local.Groupcode> Groupcode)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Groupcode groupcode in Groupcode)
				{
					localContext.Groupcode.Add(groupcode);
					localContext.SaveChanges();
					returnid = groupcode.GroupcodeId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updategroupcode(long id, Models.DB.Local.Groupcode groupcode)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Groupcode.Update(groupcode);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletegroupcode(long groupcodeId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Groupcode groupcode = localContext.Groupcode.First(p => p.GroupcodeId == groupcodeId);
				localContext.Groupcode.Remove(groupcode);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Filtroproperties
	{
		private LocalContext localContext;

		public Filtroproperties(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long FiltropropertyCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Filtroproperty.Count();
		}

		public List<Models.DB.Local.Filtroproperty> GetAllFiltroproperties()
		{
			List<Models.DB.Local.Filtroproperty> Filtroproperties = new List<Models.DB.Local.Filtroproperty>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Filtroproperties = localContext.Filtroproperty.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Filtroproperties;
		}
		public long Createfiltroproperty(List<Models.DB.Local.Filtroproperty> Filtroproperties)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Filtroproperty filtroproperty in Filtroproperties)
				{
					localContext.Filtroproperty.Add(filtroproperty);
					localContext.SaveChanges();
					returnid = filtroproperty.FiltropropertyId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatefiltroproperty(long id, Models.DB.Local.Filtroproperty filtroproperty)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Filtroproperty.Update(filtroproperty);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletefiltroproperty(long filtropropertyId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Filtroproperty filtroproperty = localContext.Filtroproperty.First(p => p.FiltropropertyId == filtropropertyId);
				localContext.Filtroproperty.Remove(filtroproperty);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

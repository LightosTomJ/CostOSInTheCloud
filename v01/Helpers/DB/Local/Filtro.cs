using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Filtro
	{
		private LocalContext localContext;

		public Filtro(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long FiltroCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Filtro.Count();
		}

		public List<Models.DB.Local.Filtro> GetAllFiltro()
		{
			List<Models.DB.Local.Filtro> Filtro = new List<Models.DB.Local.Filtro>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Filtro = localContext.Filtro.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Filtro;
		}
		public long Createfiltro(List<Models.DB.Local.Filtro> Filtro)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Filtro filtro in Filtro)
				{
					localContext.Filtro.Add(filtro);
					localContext.SaveChanges();
					returnid = filtro.FiltroId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatefiltro(long id, Models.DB.Local.Filtro filtro)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Filtro.Update(filtro);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletefiltro(long filtroId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Filtro filtro = localContext.Filtro.First(p => p.FiltroId == filtroId);
				localContext.Filtro.Remove(filtro);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

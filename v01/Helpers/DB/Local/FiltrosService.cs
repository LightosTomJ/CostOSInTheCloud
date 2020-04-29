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
	public class FiltrosService
	{
		private LocalContext localContext;

		public FiltrosService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> FiltroCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.Filtro.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.Filtro>> GetAllFiltros()
		{
			IList<Models.DB.Local.Filtro> Filtros = new List<Models.DB.Local.Filtro>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.Filtro> filtros = await localContext.Filtro.ToListAsync();
				return filtros;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateFiltro(List<Models.DB.Local.Filtro> Filtros)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Filtro filtro in Filtros)
				{
					localContext.Filtro.Add(filtro);
					await localContext.SaveChangesAsync();
					returnid = filtro.Filtroid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateFiltro(long id, Models.DB.Local.Filtro filtro)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Filtro.Update(filtro);
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
		public async Task<bool> DeleteFiltro(long filtroId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Filtro filtro = localContext.Filtro.First(p => p.Filtroid == filtroId);
				localContext.Filtro.Remove(filtro);
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

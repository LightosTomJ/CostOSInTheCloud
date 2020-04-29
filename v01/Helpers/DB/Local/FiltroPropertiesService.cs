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
	public class FiltroPropertiesService
	{
		private LocalContext localContext;

		public FiltroPropertiesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> FiltroPropertyCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.FiltroProperty.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.FiltroProperty>> GetAllFiltroProperties()
		{
			IList<Models.DB.Local.FiltroProperty> FiltroProperties = new List<Models.DB.Local.FiltroProperty>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.FiltroProperty> filtroProperties = await localContext.FiltroProperty.ToListAsync();
				return filtroProperties;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateFiltroProperty(List<Models.DB.Local.FiltroProperty> FiltroProperties)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.FiltroProperty filtroProperty in FiltroProperties)
				{
					localContext.FiltroProperty.Add(filtroProperty);
					await localContext.SaveChangesAsync();
					returnid = filtroProperty.Filtropropertyid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateFiltroProperty(long id, Models.DB.Local.FiltroProperty filtroProperty)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.FiltroProperty.Update(filtroProperty);
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
		public async Task<bool> DeleteFiltroProperty(long filtroPropertyId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.FiltroProperty filtroProperty = localContext.FiltroProperty.First(p => p.Filtropropertyid == filtroPropertyId);
				localContext.FiltroProperty.Remove(filtroProperty);
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

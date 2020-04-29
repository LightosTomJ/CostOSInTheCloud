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
	public class AlcUlsService
	{
		private LocalContext localContext;

		public AlcUlsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AlcUlCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AlcUl.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AlcUl>> GetAllAlcUls()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AlcUl> alcUls = await localContext.AlcUl.ToListAsync();
				return alcUls;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<Guid> CreateAlcUl(List<Models.DB.Local.AlcUl> AlcUls)
		{
			Guid returnid = Guid.Empty;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcUl alcUl in AlcUls)
				{
					localContext.AlcUl.Add(alcUl);
					await localContext.SaveChangesAsync();
					returnid = alcUl.Ulgid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAlcUl(Models.DB.Local.AlcUl alcUl)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcUl.Update(alcUl);
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
		public async Task<bool> DeleteAlcUl(Guid alcUlId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcUl alcUl = localContext.AlcUl.First(p => p.Ulgid == alcUlId);
				localContext.AlcUl.Remove(alcUl);
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

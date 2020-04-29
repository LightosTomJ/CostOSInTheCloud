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
	public class UnitAliasService
	{
		private LocalContext localContext;

		public UnitAliasService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> UnitAliasCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.UnitAlias.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.UnitAlias>> GetAllUnitAlias()
		{
			IList<Models.DB.Local.UnitAlias> UnitAlias = new List<Models.DB.Local.UnitAlias>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.UnitAlias> unitAlias = await localContext.UnitAlias.ToListAsync();
				return unitAlias;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateUnitAlias(List<Models.DB.Local.UnitAlias> UnitAlias)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.UnitAlias unitAlias in UnitAlias)
				{
					localContext.UnitAlias.Add(unitAlias);
					await localContext.SaveChangesAsync();
					returnid = unitAlias.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateUnitAlias(long id, Models.DB.Local.UnitAlias unitAlias)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.UnitAlias.Update(unitAlias);
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
		public async Task<bool> DeleteUnitAlias(long unitAliasId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.UnitAlias unitAlias = localContext.UnitAlias.First(p => p.Id == unitAliasId);
				localContext.UnitAlias.Remove(unitAlias);
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

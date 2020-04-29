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
	public class AlcObjectsInUsesService
	{
		private LocalContext localContext;

		public AlcObjectsInUsesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> AlcObjectsInUseCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.AlcObjectsInUse.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.AlcObjectsInUse>> GetAllAlcObjectsInUses()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.AlcObjectsInUse> alcObjectsInUses = await localContext.AlcObjectsInUse.ToListAsync();
				return alcObjectsInUses;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<string> CreateAlcObjectsInUse(List<Models.DB.Local.AlcObjectsInUse> AlcObjectsInUses)
		{
			string returnid = "";
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.AlcObjectsInUse alcObjectsInUse in AlcObjectsInUses)
				{
					localContext.AlcObjectsInUse.Add(alcObjectsInUse);
					await localContext.SaveChangesAsync();
					returnid = alcObjectsInUse.ObjId;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateAlcObjectsInUse(Models.DB.Local.AlcObjectsInUse alcObjectsInUse)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.AlcObjectsInUse.Update(alcObjectsInUse);
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
		public async Task<bool> DeleteAlcObjectsInUse(string alcObjectsInUseId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.AlcObjectsInUse alcObjectsInUse = localContext.AlcObjectsInUse.First(p => p.ObjId == alcObjectsInUseId);
				localContext.AlcObjectsInUse.Remove(alcObjectsInUse);
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

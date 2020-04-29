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
	public class FieldCustomsService
	{
		private LocalContext localContext;

		public FieldCustomsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> FieldCustomCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.FieldCustom.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.FieldCustom>> GetAllFieldCustoms()
		{
			IList<Models.DB.Local.FieldCustom> FieldCustoms = new List<Models.DB.Local.FieldCustom>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.FieldCustom> fieldCustoms = await localContext.FieldCustom.ToListAsync();
				return fieldCustoms;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateFieldCustom(List<Models.DB.Local.FieldCustom> FieldCustoms)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.FieldCustom fieldCustom in FieldCustoms)
				{
					localContext.FieldCustom.Add(fieldCustom);
					await localContext.SaveChangesAsync();
					returnid = fieldCustom.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateFieldCustom(long id, Models.DB.Local.FieldCustom fieldCustom)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.FieldCustom.Update(fieldCustom);
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
		public async Task<bool> DeleteFieldCustom(long fieldCustomId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.FieldCustom fieldCustom = localContext.FieldCustom.First(p => p.Id == fieldCustomId);
				localContext.FieldCustom.Remove(fieldCustom);
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

using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Utils
{
	public class PlaceholdersService
	{
		private UtilsContext utilsContext;

		public PlaceholdersService(UtilsContext dbContext)
		{
			utilsContext = dbContext;
		}

		public async Task<long> PlaceholderCount()
		{
			try
			{
				if (utilsContext == null) utilsContext = new UtilsContext();
				return await utilsContext.Placeholder.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Utils.Placeholder>> GetAllPlaceholders()
		{
			try
			{
				if (utilsContext == null) utilsContext = new UtilsContext();
				IList<Models.DB.Utils.Placeholder> placeholders = await utilsContext.Placeholder.ToListAsync();
				return placeholders;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreatePlaceholder(List<Models.DB.Utils.Placeholder> Placeholders)
		{
			long returnid = -1;
			try
			{
				if (utilsContext == null) utilsContext = new UtilsContext();
				foreach (Models.DB.Utils.Placeholder placeholder in Placeholders)
				{
					utilsContext.Placeholder.Add(placeholder);
					await utilsContext.SaveChangesAsync();
					returnid = placeholder.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdatePlaceholder(Models.DB.Utils.Placeholder placeholder)
		{
			try
			{
				if (utilsContext == null) utilsContext = new UtilsContext();
				utilsContext.Placeholder.Update(placeholder);
				await utilsContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeletePlaceholder(long placeholderId)
		{
			try
			{
				if (utilsContext == null) utilsContext = new UtilsContext();
				Models.DB.Utils.Placeholder placeholder = utilsContext.Placeholder.First(p => p.Id == placeholderId);
				utilsContext.Placeholder.Remove(placeholder);
				await utilsContext.SaveChangesAsync();
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

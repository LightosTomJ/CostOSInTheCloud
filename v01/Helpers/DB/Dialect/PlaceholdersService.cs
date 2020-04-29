using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Dialect;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Dialect
{
	public class PlaceholdersService
	{
		private DialectContext dialectContext;

		public PlaceholdersService(DialectContext dbContext)
		{
			dialectContext = dbContext;
		}

		public async Task<long> PlaceholderCount()
		{
			try
			{
				if (dialectContext == null) dialectContext = new DialectContext();
				return await dialectContext.Placeholder.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Dialect.Placeholder>> GetAllPlaceholders()
		{
			IList<Models.DB.Dialect.Placeholder> Placeholders = new List<Models.DB.Dialect.Placeholder>();
			try
			{
				if (dialectContext == null) dialectContext = new DialectContext();
				IList<Models.DB.Dialect.Placeholder> placeholders = await dialectContext.Placeholder.ToListAsync();
				return placeholders;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreatePlaceholder(List<Models.DB.Dialect.Placeholder> Placeholders)
		{
			long returnid = -1;
			try
			{
				if (dialectContext == null) dialectContext = new DialectContext();
				foreach (Models.DB.Dialect.Placeholder placeholder in Placeholders)
				{
					dialectContext.Placeholder.Add(placeholder);
					await dialectContext.SaveChangesAsync();
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

		public async Task<bool> UpdatePlaceholder(long id, Models.DB.Dialect.Placeholder placeholder)
		{
			try
			{
				if (dialectContext == null) dialectContext = new DialectContext();
				dialectContext.Placeholder.Update(placeholder);
				await dialectContext.SaveChangesAsync();
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
				if (dialectContext == null) dialectContext = new DialectContext();
				Models.DB.Dialect.Placeholder placeholder = dialectContext.Placeholder.First(p => p.Id == placeholderId);
				dialectContext.Placeholder.Remove(placeholder);
				await dialectContext.SaveChangesAsync();
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

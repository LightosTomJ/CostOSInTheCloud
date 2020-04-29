using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Types
{
	public class PlaceholdersService
	{
		private TypesContext typesContext;

		public PlaceholdersService(TypesContext dbContext)
		{
			typesContext = dbContext;
		}

		public async Task<long> PlaceholderCount()
		{
			try
			{
				if (typesContext == null) typesContext = new TypesContext();
				return await typesContext.Placeholder.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Types.Placeholder>> GetAllPlaceholders()
		{
			try
			{
				if (typesContext == null) typesContext = new TypesContext();
				IList<Models.DB.Types.Placeholder> placeholders = await typesContext.Placeholder.ToListAsync();
				return placeholders;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreatePlaceholder(List<Models.DB.Types.Placeholder> Placeholders)
		{
			long returnid = -1;
			try
			{
				if (typesContext == null) typesContext = new TypesContext();
				foreach (Models.DB.Types.Placeholder placeholder in Placeholders)
				{
					typesContext.Placeholder.Add(placeholder);
					await typesContext.SaveChangesAsync();
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

		public async Task<bool> UpdatePlaceholder(Models.DB.Types.Placeholder placeholder)
		{
			try
			{
				if (typesContext == null) typesContext = new TypesContext();
				typesContext.Placeholder.Update(placeholder);
				await typesContext.SaveChangesAsync();
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
				if (typesContext == null) typesContext = new TypesContext();
				Models.DB.Types.Placeholder placeholder = typesContext.Placeholder.First(p => p.Id == placeholderId);
				typesContext.Placeholder.Remove(placeholder);
				await typesContext.SaveChangesAsync();
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

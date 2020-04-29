using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.View
{
	public class PlaceholdersService
	{
		private ViewContext viewContext;

		public PlaceholdersService(ViewContext dbContext)
		{
			viewContext = dbContext;
		}

		public async Task<long> PlaceholderCount()
		{
			try
			{
				if (viewContext == null) viewContext = new ViewContext();
				return await viewContext.Placeholder.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.View.Placeholder>> GetAllPlaceholders()
		{
			try
			{
				if (viewContext == null) viewContext = new ViewContext();
				IList<Models.DB.View.Placeholder> placeholders = await viewContext.Placeholder.ToListAsync();
				return placeholders;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreatePlaceholder(List<Models.DB.View.Placeholder> Placeholders)
		{
			long returnid = -1;
			try
			{
				if (viewContext == null) viewContext = new ViewContext();
				foreach (Models.DB.View.Placeholder placeholder in Placeholders)
				{
					viewContext.Placeholder.Add(placeholder);
					await viewContext.SaveChangesAsync();
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

		public async Task<bool> UpdatePlaceholder(Models.DB.View.Placeholder placeholder)
		{
			try
			{
				if (viewContext == null) viewContext = new ViewContext();
				viewContext.Placeholder.Update(placeholder);
				await viewContext.SaveChangesAsync();
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
				if (viewContext == null) viewContext = new ViewContext();
				Models.DB.View.Placeholder placeholder = viewContext.Placeholder.First(p => p.Id == placeholderId);
				viewContext.Placeholder.Remove(placeholder);
				await viewContext.SaveChangesAsync();
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

using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Layout
{
	public class PlaceholdersService
	{
		private LayoutContext layoutContext;

		public PlaceholdersService(LayoutContext dbContext)
		{
			layoutContext = dbContext;
		}

		public async Task<long> PlaceholderCount()
		{
			try
			{
				if (layoutContext == null) layoutContext = new LayoutContext();
				return await layoutContext.Placeholder.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Layout.Placeholder>> GetAllPlaceholders()
		{
			IList<Models.DB.Layout.Placeholder> Placeholders = new List<Models.DB.Layout.Placeholder>();
			try
			{
				if (layoutContext == null) layoutContext = new LayoutContext();
				IList<Models.DB.Layout.Placeholder> placeholders = await layoutContext.Placeholder.ToListAsync();
				return placeholders;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreatePlaceholder(List<Models.DB.Layout.Placeholder> Placeholders)
		{
			long returnid = -1;
			try
			{
				if (layoutContext == null) layoutContext = new LayoutContext();
				foreach (Models.DB.Layout.Placeholder placeholder in Placeholders)
				{
					layoutContext.Placeholder.Add(placeholder);
					await layoutContext.SaveChangesAsync();
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

		public async Task<bool> UpdatePlaceholder(long id, Models.DB.Layout.Placeholder placeholder)
		{
			try
			{
				if (layoutContext == null) layoutContext = new LayoutContext();
				layoutContext.Placeholder.Update(placeholder);
				await layoutContext.SaveChangesAsync();
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
				if (layoutContext == null) layoutContext = new LayoutContext();
				Models.DB.Layout.Placeholder placeholder = layoutContext.Placeholder.First(p => p.Id == placeholderId);
				layoutContext.Placeholder.Remove(placeholder);
				await layoutContext.SaveChangesAsync();
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

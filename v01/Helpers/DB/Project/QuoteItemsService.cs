using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class QuoteItemsService
	{
		private ProjectContext projectContext;

		public QuoteItemsService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> QuoteItemCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.QuoteItem.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.QuoteItem>> GetAllQuoteItems()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.QuoteItem> quoteItems = await projectContext.QuoteItem.ToListAsync();
				return quoteItems;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateQuoteItem(List<Models.DB.Project.QuoteItem> QuoteItems)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.QuoteItem quoteItem in QuoteItems)
				{
					projectContext.QuoteItem.Add(quoteItem);
					await projectContext.SaveChangesAsync();
					returnid = quoteItem.Quoteitemid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateQuoteItem(Models.DB.Project.QuoteItem quoteItem)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.QuoteItem.Update(quoteItem);
				await projectContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteQuoteItem(long quoteItemId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.QuoteItem quoteItem = projectContext.QuoteItem.First(p => p.Quoteitemid == quoteItemId);
				projectContext.QuoteItem.Remove(quoteItem);
				await projectContext.SaveChangesAsync();
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

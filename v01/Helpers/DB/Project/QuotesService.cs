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
	public class QuotesService
	{
		private ProjectContext projectContext;

		public QuotesService(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public async Task<long> QuoteCount()
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				return await projectContext.Quote.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Project.Quote>> GetAllQuotes()
		{
			IList<Models.DB.Project.Quote> Quotes = new List<Models.DB.Project.Quote>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				IList<Models.DB.Project.Quote> quotes = await projectContext.Quote.ToListAsync();
				return quotes;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateQuote(List<Models.DB.Project.Quote> Quotes)
		{
			long returnid = -1;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Quote quote in Quotes)
				{
					projectContext.Quote.Add(quote);
					await projectContext.SaveChangesAsync();
					returnid = quote.Expenseid;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateQuote(long id, Models.DB.Project.Quote quote)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Quote.Update(quote);
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
		public async Task<bool> DeleteQuote(long quoteId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Quote quote = projectContext.Quote.First(p => p.Expenseid == quoteId);
				projectContext.Quote.Remove(quote);
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

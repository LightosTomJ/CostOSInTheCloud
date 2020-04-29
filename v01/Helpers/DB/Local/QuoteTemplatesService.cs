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
	public class QuoteTemplatesService
	{
		private LocalContext localContext;

		public QuoteTemplatesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> QuoteTemplateCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.QuoteTemplate.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.QuoteTemplate>> GetAllQuoteTemplates()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.QuoteTemplate> quoteTemplates = await localContext.QuoteTemplate.ToListAsync();
				return quoteTemplates;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateQuoteTemplate(List<Models.DB.Local.QuoteTemplate> QuoteTemplates)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.QuoteTemplate quoteTemplate in QuoteTemplates)
				{
					localContext.QuoteTemplate.Add(quoteTemplate);
					await localContext.SaveChangesAsync();
					returnid = quoteTemplate.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateQuoteTemplate(Models.DB.Local.QuoteTemplate quoteTemplate)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.QuoteTemplate.Update(quoteTemplate);
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
		public async Task<bool> DeleteQuoteTemplate(long quoteTemplateId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.QuoteTemplate quoteTemplate = localContext.QuoteTemplate.First(p => p.Id == quoteTemplateId);
				localContext.QuoteTemplate.Remove(quoteTemplate);
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

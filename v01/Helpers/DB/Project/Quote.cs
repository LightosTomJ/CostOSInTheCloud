using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Quote
	{
		private ProjectContext projectContext;

		public Quote(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long QuoteCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Quote.Count();
		}

		public List<Models.DB.Project.Quote> GetAllQuote()
		{
			List<Models.DB.Project.Quote> Quote = new List<Models.DB.Project.Quote>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Quote = projectContext.Quote.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Quote;
		}
		public long Createquote(List<Models.DB.Project.Quote> Quote)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Quote quote in Quote)
				{
					projectContext.Quote.Add(quote);
					projectContext.SaveChanges();
					returnid = quote.QuoteId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatequote(long id, Models.DB.Project.Quote quote)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Quote.Update(quote);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletequote(long quoteId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Quote quote = projectContext.Quote.First(p => p.QuoteId == quoteId);
				projectContext.Quote.Remove(quote);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

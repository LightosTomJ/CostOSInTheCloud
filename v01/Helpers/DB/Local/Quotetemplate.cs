using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Quotetemplate
	{
		private LocalContext localContext;

		public Quotetemplate(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long QuotetemplateCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Quotetemplate.Count();
		}

		public List<Models.DB.Local.Quotetemplate> GetAllQuotetemplate()
		{
			List<Models.DB.Local.Quotetemplate> Quotetemplate = new List<Models.DB.Local.Quotetemplate>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Quotetemplate = localContext.Quotetemplate.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Quotetemplate;
		}
		public long Createquotetemplate(List<Models.DB.Local.Quotetemplate> Quotetemplate)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Quotetemplate quotetemplate in Quotetemplate)
				{
					localContext.Quotetemplate.Add(quotetemplate);
					localContext.SaveChanges();
					returnid = quotetemplate.QuotetemplateId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatequotetemplate(long id, Models.DB.Local.Quotetemplate quotetemplate)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Quotetemplate.Update(quotetemplate);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletequotetemplate(long quotetemplateId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Quotetemplate quotetemplate = localContext.Quotetemplate.First(p => p.QuotetemplateId == quotetemplateId);
				localContext.Quotetemplate.Remove(quotetemplate);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

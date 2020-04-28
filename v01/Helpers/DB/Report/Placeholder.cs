using Models.DB.Report;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Report
{
	public class Placeholder
	{
		private ReportContext reportContext;

		public Placeholder(ReportContext dbContext)
		{
			reportContext = dbContext;
		}

		public long PlaceholderCount()
		{
			if (reportContext == null) reportContext = new ReportContext();
			return reportContext.Placeholder.Count();
		}

		public List<Models.DB.Report.Placeholder> GetAllPlaceholder()
		{
			List<Models.DB.Report.Placeholder> Placeholder = new List<Models.DB.Report.Placeholder>();
			try
			{
				if (reportContext == null) reportContext = new ReportContext();
				Placeholder = reportContext.Placeholder.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Placeholder;
		}
		public long Createplaceholder(List<Models.DB.Report.Placeholder> Placeholder)
		{
			long returnid = 0;
			try
			{
				if (reportContext == null) reportContext = new ReportContext();
				foreach (Models.DB.Report.Placeholder placeholder in Placeholder)
				{
					reportContext.Placeholder.Add(placeholder);
					reportContext.SaveChanges();
					returnid = placeholder.PlaceholderId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateplaceholder(long id, Models.DB.Report.Placeholder placeholder)
		{
			try
			{
				if (reportContext == null) reportContext = new ReportContext();
				reportContext.Placeholder.Update(placeholder);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteplaceholder(long placeholderId)
		{
			try
			{
				if (reportContext == null) reportContext = new ReportContext();
				Models.DB.Report.Placeholder placeholder = reportContext.Placeholder.First(p => p.PlaceholderId == placeholderId);
				reportContext.Placeholder.Remove(placeholder);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

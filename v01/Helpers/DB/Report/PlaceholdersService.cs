using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Report;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Report
{
	public class PlaceholdersService
	{
		private ReportContext reportContext;

		public PlaceholdersService(ReportContext dbContext)
		{
			reportContext = dbContext;
		}

		public async Task<long> PlaceholderCount()
		{
			try
			{
				if (reportContext == null) reportContext = new ReportContext();
				return await reportContext.Placeholder.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Report.Placeholder>> GetAllPlaceholders()
		{
			try
			{
				if (reportContext == null) reportContext = new ReportContext();
				IList<Models.DB.Report.Placeholder> placeholders = await reportContext.Placeholder.ToListAsync();
				return placeholders;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreatePlaceholder(List<Models.DB.Report.Placeholder> Placeholders)
		{
			long returnid = -1;
			try
			{
				if (reportContext == null) reportContext = new ReportContext();
				foreach (Models.DB.Report.Placeholder placeholder in Placeholders)
				{
					reportContext.Placeholder.Add(placeholder);
					await reportContext.SaveChangesAsync();
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

		public async Task<bool> UpdatePlaceholder(Models.DB.Report.Placeholder placeholder)
		{
			try
			{
				if (reportContext == null) reportContext = new ReportContext();
				reportContext.Placeholder.Update(placeholder);
				await reportContext.SaveChangesAsync();
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
				if (reportContext == null) reportContext = new ReportContext();
				Models.DB.Report.Placeholder placeholder = reportContext.Placeholder.First(p => p.Id == placeholderId);
				reportContext.Placeholder.Remove(placeholder);
				await reportContext.SaveChangesAsync();
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

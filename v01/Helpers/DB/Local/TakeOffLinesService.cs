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
	public class TakeOffLinesService
	{
		private LocalContext localContext;

		public TakeOffLinesService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> TakeOffLineCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.TakeOffLine.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.TakeOffLine>> GetAllTakeOffLines()
		{
			IList<Models.DB.Local.TakeOffLine> TakeOffLines = new List<Models.DB.Local.TakeOffLine>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.TakeOffLine> takeOffLines = await localContext.TakeOffLine.ToListAsync();
				return takeOffLines;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateTakeOffLine(List<Models.DB.Local.TakeOffLine> TakeOffLines)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.TakeOffLine takeOffLine in TakeOffLines)
				{
					localContext.TakeOffLine.Add(takeOffLine);
					await localContext.SaveChangesAsync();
					returnid = takeOffLine.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateTakeOffLine(long id, Models.DB.Local.TakeOffLine takeOffLine)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.TakeOffLine.Update(takeOffLine);
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
		public async Task<bool> DeleteTakeOffLine(long takeOffLineId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.TakeOffLine takeOffLine = localContext.TakeOffLine.First(p => p.Id == takeOffLineId);
				localContext.TakeOffLine.Remove(takeOffLine);
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

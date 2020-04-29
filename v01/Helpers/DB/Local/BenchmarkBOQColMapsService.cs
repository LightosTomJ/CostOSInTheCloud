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
	public class BenchmarkBOQColMapsService
	{
		private LocalContext localContext;

		public BenchmarkBOQColMapsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BenchmarkBOQColMapCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BenchmarkBOQColMap.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BenchmarkBOQColMap>> GetAllBenchmarkBOQColMaps()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BenchmarkBOQColMap> benchmarkBOQColMaps = await localContext.BenchmarkBOQColMap.ToListAsync();
				return benchmarkBOQColMaps;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBenchmarkBOQColMap(List<Models.DB.Local.BenchmarkBOQColMap> BenchmarkBOQColMaps)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BenchmarkBOQColMap benchmarkBOQColMap in BenchmarkBOQColMaps)
				{
					localContext.BenchmarkBOQColMap.Add(benchmarkBOQColMap);
					await localContext.SaveChangesAsync();
					returnid = benchmarkBOQColMap.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBenchmarkBOQColMap(Models.DB.Local.BenchmarkBOQColMap benchmarkBOQColMap)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BenchmarkBOQColMap.Update(benchmarkBOQColMap);
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
		public async Task<bool> DeleteBenchmarkBOQColMap(long benchmarkBOQColMapId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BenchmarkBOQColMap benchmarkBOQColMap = localContext.BenchmarkBOQColMap.First(p => p.Id == benchmarkBOQColMapId);
				localContext.BenchmarkBOQColMap.Remove(benchmarkBOQColMap);
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

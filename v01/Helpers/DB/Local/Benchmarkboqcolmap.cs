using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Benchmarkboqcolmap
	{
		private LocalContext localContext;

		public Benchmarkboqcolmap(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BenchmarkboqcolmapCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Benchmarkboqcolmap.Count();
		}

		public List<Models.DB.Local.Benchmarkboqcolmap> GetAllBenchmarkboqcolmap()
		{
			List<Models.DB.Local.Benchmarkboqcolmap> Benchmarkboqcolmap = new List<Models.DB.Local.Benchmarkboqcolmap>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Benchmarkboqcolmap = localContext.Benchmarkboqcolmap.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Benchmarkboqcolmap;
		}
		public long Createbenchmarkboqcolmap(List<Models.DB.Local.Benchmarkboqcolmap> Benchmarkboqcolmap)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Benchmarkboqcolmap benchmarkboqcolmap in Benchmarkboqcolmap)
				{
					localContext.Benchmarkboqcolmap.Add(benchmarkboqcolmap);
					localContext.SaveChanges();
					returnid = benchmarkboqcolmap.BenchmarkboqcolmapId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatebenchmarkboqcolmap(long id, Models.DB.Local.Benchmarkboqcolmap benchmarkboqcolmap)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Benchmarkboqcolmap.Update(benchmarkboqcolmap);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletebenchmarkboqcolmap(long benchmarkboqcolmapId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Benchmarkboqcolmap benchmarkboqcolmap = localContext.Benchmarkboqcolmap.First(p => p.BenchmarkboqcolmapId == benchmarkboqcolmapId);
				localContext.Benchmarkboqcolmap.Remove(benchmarkboqcolmap);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

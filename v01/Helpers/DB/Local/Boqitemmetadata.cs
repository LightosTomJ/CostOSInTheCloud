using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Boqitemmetadata
	{
		private LocalContext localContext;

		public Boqitemmetadata(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BoqitemmetadataCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Boqitemmetadata.Count();
		}

		public List<Models.DB.Local.Boqitemmetadata> GetAllBoqitemmetadata()
		{
			List<Models.DB.Local.Boqitemmetadata> Boqitemmetadata = new List<Models.DB.Local.Boqitemmetadata>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Boqitemmetadata = localContext.Boqitemmetadata.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Boqitemmetadata;
		}
		public long Createboqitemmetadata(List<Models.DB.Local.Boqitemmetadata> Boqitemmetadata)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Boqitemmetadata boqitemmetadata in Boqitemmetadata)
				{
					localContext.Boqitemmetadata.Add(boqitemmetadata);
					localContext.SaveChanges();
					returnid = boqitemmetadata.BoqitemmetadataId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateboqitemmetadata(long id, Models.DB.Local.Boqitemmetadata boqitemmetadata)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Boqitemmetadata.Update(boqitemmetadata);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteboqitemmetadata(long boqitemmetadataId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Boqitemmetadata boqitemmetadata = localContext.Boqitemmetadata.First(p => p.BoqitemmetadataId == boqitemmetadataId);
				localContext.Boqitemmetadata.Remove(boqitemmetadata);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

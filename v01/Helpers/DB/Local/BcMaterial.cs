using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcMaterial
	{
		private LocalContext localContext;

		public BcMaterial(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long BcMaterialCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.BcMaterial.Count();
		}

		public List<Models.DB.Local.BcMaterial> GetAllBcMaterial()
		{
			List<Models.DB.Local.BcMaterial> BcMaterial = new List<Models.DB.Local.BcMaterial>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				BcMaterial = localContext.BcMaterial.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return BcMaterial;
		}
		public long CreatebcMaterial(List<Models.DB.Local.BcMaterial> BcMaterial)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcMaterial bcMaterial in BcMaterial)
				{
					localContext.BcMaterial.Add(bcMaterial);
					localContext.SaveChanges();
					returnid = bcMaterial.BcMaterialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void UpdatebcMaterial(long id, Models.DB.Local.BcMaterial bcMaterial)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcMaterial.Update(bcMaterial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void DeletebcMaterial(long bcMaterialId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcMaterial bcMaterial = localContext.BcMaterial.First(p => p.BcMaterialId == bcMaterialId);
				localContext.BcMaterial.Remove(bcMaterial);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

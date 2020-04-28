using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Material
	{
		private LocalContext localContext;

		public Material(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long MaterialCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Material.Count();
		}

		public List<Models.DB.Local.Material> GetAllMaterial()
		{
			List<Models.DB.Local.Material> Material = new List<Models.DB.Local.Material>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Material = localContext.Material.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Material;
		}
		public long Creatematerial(List<Models.DB.Local.Material> Material)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Material material in Material)
				{
					localContext.Material.Add(material);
					localContext.SaveChanges();
					returnid = material.MaterialId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatematerial(long id, Models.DB.Local.Material material)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Material.Update(material);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletematerial(long materialId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Material material = localContext.Material.First(p => p.MaterialId == materialId);
				localContext.Material.Remove(material);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

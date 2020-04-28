using Models.DB.Config;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Config
{
	public class Genders
	{
		private ConfigContext configContext;

		public Genders(ConfigContext dbContext)
		{
			configContext = dbContext;
		}

		public long GendersCount()
		{
			if (configContext == null) configContext = new ConfigContext();
			return configContext.Genders.Count();
		}

		public List<Models.DB.Config.Genders> GetAllGenders()
		{
			List<Models.DB.Config.Genders> Genders = new List<Models.DB.Config.Genders>();
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Genders = configContext.Genders.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Genders;
		}
		public long Creategenders(List<Models.DB.Config.Genders> Genders)
		{
			long returnid = 0;
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				foreach (Models.DB.Config.Genders genders in Genders)
				{
					configContext.Genders.Add(genders);
					configContext.SaveChanges();
					returnid = genders.GendersId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updategenders(long id, Models.DB.Config.Genders genders)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				configContext.Genders.Update(genders);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletegenders(long gendersId)
		{
			try
			{
				if (configContext == null) configContext = new ConfigContext();
				Models.DB.Config.Genders genders = configContext.Genders.First(p => p.GendersId == gendersId);
				configContext.Genders.Remove(genders);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

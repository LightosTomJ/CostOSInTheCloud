using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Consumable
	{
		private ProjectContext projectContext;

		public Consumable(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long ConsumableCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Consumable.Count();
		}

		public List<Models.DB.Project.Consumable> GetAllConsumable()
		{
			List<Models.DB.Project.Consumable> Consumable = new List<Models.DB.Project.Consumable>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Consumable = projectContext.Consumable.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Consumable;
		}
		public long Createconsumable(List<Models.DB.Project.Consumable> Consumable)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Consumable consumable in Consumable)
				{
					projectContext.Consumable.Add(consumable);
					projectContext.SaveChanges();
					returnid = consumable.ConsumableId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateconsumable(long id, Models.DB.Project.Consumable consumable)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Consumable.Update(consumable);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteconsumable(long consumableId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Consumable consumable = projectContext.Consumable.First(p => p.ConsumableId == consumableId);
				projectContext.Consumable.Remove(consumable);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

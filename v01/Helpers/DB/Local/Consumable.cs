using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Consumable
	{
		private LocalContext localContext;

		public Consumable(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ConsumableCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Consumable.Count();
		}

		public List<Models.DB.Local.Consumable> GetAllConsumable()
		{
			List<Models.DB.Local.Consumable> Consumable = new List<Models.DB.Local.Consumable>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Consumable = localContext.Consumable.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Consumable;
		}
		public long Createconsumable(List<Models.DB.Local.Consumable> Consumable)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Consumable consumable in Consumable)
				{
					localContext.Consumable.Add(consumable);
					localContext.SaveChanges();
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

		public void Updateconsumable(long id, Models.DB.Local.Consumable consumable)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Consumable.Update(consumable);
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
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Consumable consumable = localContext.Consumable.First(p => p.ConsumableId == consumableId);
				localContext.Consumable.Remove(consumable);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

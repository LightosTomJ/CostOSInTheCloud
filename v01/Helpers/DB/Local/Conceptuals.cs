using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Conceptuals
	{
		private LocalContext localContext;

		public Conceptuals(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ConceptualsCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Conceptuals.Count();
		}

		public List<Models.DB.Local.Conceptuals> GetAllConceptuals()
		{
			List<Models.DB.Local.Conceptuals> Conceptuals = new List<Models.DB.Local.Conceptuals>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Conceptuals = localContext.Conceptuals.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Conceptuals;
		}
		public long Createconceptuals(List<Models.DB.Local.Conceptuals> Conceptuals)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Conceptuals conceptuals in Conceptuals)
				{
					localContext.Conceptuals.Add(conceptuals);
					localContext.SaveChanges();
					returnid = conceptuals.ConceptualsId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateconceptuals(long id, Models.DB.Local.Conceptuals conceptuals)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Conceptuals.Update(conceptuals);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteconceptuals(long conceptualsId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Conceptuals conceptuals = localContext.Conceptuals.First(p => p.ConceptualsId == conceptualsId);
				localContext.Conceptuals.Remove(conceptuals);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

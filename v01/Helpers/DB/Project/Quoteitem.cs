using Models.DB.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Project
{
	public class Quoteitem
	{
		private ProjectContext projectContext;

		public Quoteitem(ProjectContext dbContext)
		{
			projectContext = dbContext;
		}

		public long QuoteitemCount()
		{
			if (projectContext == null) projectContext = new ProjectContext();
			return projectContext.Quoteitem.Count();
		}

		public List<Models.DB.Project.Quoteitem> GetAllQuoteitem()
		{
			List<Models.DB.Project.Quoteitem> Quoteitem = new List<Models.DB.Project.Quoteitem>();
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Quoteitem = projectContext.Quoteitem.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Quoteitem;
		}
		public long Createquoteitem(List<Models.DB.Project.Quoteitem> Quoteitem)
		{
			long returnid = 0;
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				foreach (Models.DB.Project.Quoteitem quoteitem in Quoteitem)
				{
					projectContext.Quoteitem.Add(quoteitem);
					projectContext.SaveChanges();
					returnid = quoteitem.QuoteitemId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatequoteitem(long id, Models.DB.Project.Quoteitem quoteitem)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				projectContext.Quoteitem.Update(quoteitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletequoteitem(long quoteitemId)
		{
			try
			{
				if (projectContext == null) projectContext = new ProjectContext();
				Models.DB.Project.Quoteitem quoteitem = projectContext.Quoteitem.First(p => p.QuoteitemId == quoteitemId);
				projectContext.Quoteitem.Remove(quoteitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

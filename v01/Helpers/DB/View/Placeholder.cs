using Models.DB.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.View
{
	public class Placeholder
	{
		private viewContext viewContext;

		public Placeholder(viewContext dbContext)
		{
			viewContext = dbContext;
		}

		public long PlaceholderCount()
		{
			if (viewContext == null) viewContext = new viewContext();
			return viewContext.Placeholder.Count();
		}

		public List<Models.DB.View.Placeholder> GetAllPlaceholder()
		{
			List<Models.DB.View.Placeholder> Placeholder = new List<Models.DB.View.Placeholder>();
			try
			{
				if (viewContext == null) viewContext = new viewContext();
				Placeholder = viewContext.Placeholder.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Placeholder;
		}
		public long Createplaceholder(List<Models.DB.View.Placeholder> Placeholder)
		{
			long returnid = 0;
			try
			{
				if (viewContext == null) viewContext = new viewContext();
				foreach (Models.DB.View.Placeholder placeholder in Placeholder)
				{
					viewContext.Placeholder.Add(placeholder);
					viewContext.SaveChanges();
					returnid = placeholder.PlaceholderId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateplaceholder(long id, Models.DB.View.Placeholder placeholder)
		{
			try
			{
				if (viewContext == null) viewContext = new viewContext();
				viewContext.Placeholder.Update(placeholder);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteplaceholder(long placeholderId)
		{
			try
			{
				if (viewContext == null) viewContext = new viewContext();
				Models.DB.View.Placeholder placeholder = viewContext.Placeholder.First(p => p.PlaceholderId == placeholderId);
				viewContext.Placeholder.Remove(placeholder);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

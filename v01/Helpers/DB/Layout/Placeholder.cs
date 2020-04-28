using Models.DB.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Layout
{
	public class Placeholders
	{
		private LayoutContext layoutContext;

		public Placeholders(LayoutContext dbContext)
		{
			layoutContext = dbContext;
		}

		public long PlaceholderCount()
		{
			if (layoutContext == null) layoutContext = new LayoutContext();
			return layoutContext.Placeholder.Count();
		}

		public List<Models.DB.Layout.Placeholder> GetAllPlaceholders()
		{
			List<Models.DB.Layout.Placeholder> Placeholders = new List<Models.DB.Layout.Placeholder>();
			try
			{
				if (layoutContext == null) layoutContext = new LayoutContext();
				Placeholders = layoutContext.Placeholder.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Placeholders;
		}
		public long Createplaceholder(List<Models.DB.Layout.Placeholder> Placeholders)
		{
			long returnid = 0;
			try
			{
				if (layoutContext == null) layoutContext = new LayoutContext();
				foreach (Models.DB.Layout.Placeholder placeholder in Placeholders)
				{
					layoutContext.Placeholder.Add(placeholder);
					layoutContext.SaveChanges();
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

		public void Updateplaceholder(long id, Models.DB.Layout.Placeholder placeholder)
		{
			try
			{
				if (layoutContext == null) layoutContext = new LayoutContext();
				layoutContext.Placeholder.Update(placeholder);
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
				if (layoutContext == null) layoutContext = new LayoutContext();
				Models.DB.Layout.Placeholder placeholder = layoutContext.Placeholder.First(p => p.PlaceholderId == placeholderId);
				layoutContext.Placeholder.Remove(placeholder);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

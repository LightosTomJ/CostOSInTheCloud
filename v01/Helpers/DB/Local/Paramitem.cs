using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Paramitem
	{
		private LocalContext localContext;

		public Paramitem(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long ParamitemCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Paramitem.Count();
		}

		public List<Models.DB.Local.Paramitem> GetAllParamitem()
		{
			List<Models.DB.Local.Paramitem> Paramitem = new List<Models.DB.Local.Paramitem>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Paramitem = localContext.Paramitem.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Paramitem;
		}
		public long Createparamitem(List<Models.DB.Local.Paramitem> Paramitem)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Paramitem paramitem in Paramitem)
				{
					localContext.Paramitem.Add(paramitem);
					localContext.SaveChanges();
					returnid = paramitem.ParamitemId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updateparamitem(long id, Models.DB.Local.Paramitem paramitem)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Paramitem.Update(paramitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deleteparamitem(long paramitemId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Paramitem paramitem = localContext.Paramitem.First(p => p.ParamitemId == paramitemId);
				localContext.Paramitem.Remove(paramitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

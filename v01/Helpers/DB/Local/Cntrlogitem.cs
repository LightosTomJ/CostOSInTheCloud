using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class Cntrlogitem
	{
		private LocalContext localContext;

		public Cntrlogitem(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public long CntrlogitemCount()
		{
			if (localContext == null) localContext = new LocalContext();
			return localContext.Cntrlogitem.Count();
		}

		public List<Models.DB.Local.Cntrlogitem> GetAllCntrlogitem()
		{
			List<Models.DB.Local.Cntrlogitem> Cntrlogitem = new List<Models.DB.Local.Cntrlogitem>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Cntrlogitem = localContext.Cntrlogitem.ToList();
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return Cntrlogitem;
		}
		public long Createcntrlogitem(List<Models.DB.Local.Cntrlogitem> Cntrlogitem)
		{
			long returnid = 0;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.Cntrlogitem cntrlogitem in Cntrlogitem)
				{
					localContext.Cntrlogitem.Add(cntrlogitem);
					localContext.SaveChanges();
					returnid = cntrlogitem.CntrlogitemId;
				}
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
				if (ae.InnerException != null) strError = ae.InnerException.ToString();
			}
			return returnid;
		}

		public void Updatecntrlogitem(long id, Models.DB.Local.Cntrlogitem cntrlogitem)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.Cntrlogitem.Update(cntrlogitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
		public void Deletecntrlogitem(long cntrlogitemId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.Cntrlogitem cntrlogitem = localContext.Cntrlogitem.First(p => p.CntrlogitemId == cntrlogitemId);
				localContext.Cntrlogitem.Remove(cntrlogitem);
			}
			catch (Exception ae)
			{
				string strError = ae.Message.ToString();
			}
			return;
		}
	}
}

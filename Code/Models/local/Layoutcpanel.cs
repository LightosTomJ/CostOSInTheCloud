
namespace Models.local
{
	public class Layoutcpanel : BaseClass.Layoutcpanel//, Interfaces.ILayoutcpanel
	{
		public Layoutcpanel Clone()
		{
			Layoutcpanel c = new Layoutcpanel();
			c.Layoutcpanelid = Layoutcpanelid;
			c.Layoutcid = Layoutcid;
			c.Prefcols = Prefcols;
			c.Lockedcols = Lockedcols;
			c.Sortedcols = Sortedcols;
			c.Filtercols = Filtercols;
			c.Assment = Assment;
			c.Vizer = Vizer;
			c.Selvizer = Selvizer;
			c.Side = Side;
			c.Grpn = Grpn;
			c.Dsgrp = Dsgrp;
			c.Grpcols = Grpcols;
			c.Grpords = Grpords;
			c.Vsble = Vsble;
			c.Columns = Columns;
			c.Columnwidths = Columnwidths;
			c.Sorttypeup = Sorttypeup;
			c.Sortindex = Sortindex;
			c.Autoresize = Autoresize;
			c.Rowheight = Rowheight;
			c.Filters = Filters;
			c.Xtralvl = Xtralvl;
			c.Layoutcpanelcount = Layoutcpanelcount;
			c.Layoutc = Layoutc;

			return c;
		}
	}
}

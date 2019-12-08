
namespace Models.local
{
	public class Layoutc : BaseClass.Layoutc//, Interfaces.ILayoutc
	{
		public Layoutc Clone()
		{
			Layoutc c = new Layoutc();
			c.Layoutcid = Layoutcid;
			c.Name = Name;
			c.Lastupdate = Lastupdate;
			c.Creatorid = Creatorid;
			c.Editorid = Editorid;
			c.Selectedgk = Selectedgk;
			c.Pblk = Pblk;
			c.Dflt = Dflt;
			c.Type = Type;
			c.Visibtabs = Visibtabs;
			c.Showtree = Showtree;
			c.Spangrp = Spangrp;
			c.Rowstrp = Rowstrp;
			c.Grpname = Grpname;
			c.F1name = F1name;
			c.F1size = F1size;
			c.F1style = F1style;
			c.F2name = F2name;
			c.F2size = F2size;
			c.F2style = F2style;
			c.F3name = F3name;
			c.F3size = F3size;
			c.F3style = F3style;
			c.F4name = F4name;
			c.F4size = F4size;
			c.Fnname = Fnname;
			c.Fnsize = Fnsize;
			c.Fnstyle = Fnstyle;
			c.Fnclr = Fnclr;
			c.Funame = Funame;
			c.Fusize = Fusize;
			c.Fustyle = Fustyle;
			c.Fuclr = Fuclr;
			c.F4style = F4style;
			c.F5name = F5name;
			c.F5size = F5size;
			c.F5style = F5style;
			c.Lfname = Lfname;
			c.Lfsize = Lfsize;
			c.Lfstyle = Lfstyle;
			c.F1clr = F1clr;
			c.F2clr = F2clr;
			c.F3clr = F3clr;
			c.F4clr = F4clr;
			c.F5clr = F5clr;
			c.Lfclr = Lfclr;
			c.Rs1clr = Rs1clr;
			c.Rs2clr = Rs2clr;
			c.Mltln = Mltln;
			c.Zoom = Zoom;
			c.Gridon = Gridon;
			c.Hgridon = Hgridon;
			c.F1undl = F1undl;
			c.F2undl = F2undl;
			c.F3undl = F3undl;
			c.F4undl = F4undl;
			c.F5undl = F5undl;
			c.Fnundl = Fnundl;
			c.Fuundl = Fuundl;
			c.Flundl = Flundl;
			c.L1bclr = L1bclr;
			c.L2bclr = L2bclr;
			c.L3bclr = L3bclr;
			c.L4bclr = L4bclr;
			c.L5bclr = L5bclr;
			c.Lnbclr = Lnbclr;
			c.Unbclr = Unbclr;
			c.Lfbclr = Lfbclr;
			c.Rowhead = Rowhead;
			c.Csep = Csep;
			c.Csepclr = Csepclr;
			c.Gridclr = Gridclr;
			c.Layoutroles = Layoutroles;
			c.Layoutcpanel = Layoutcpanel;

			return c;
		}
	}
}

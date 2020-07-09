using Models.DB.Local;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Pages.DTO.Local
{
    public class ProjectEPSDto
    {

        public long ProjectEPSId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public long ProjectId { get; set; }
        public bool HasChildren { get; set; } = false;
        public short Level { get; set; }

        public ProjectEPSDto()
        { ; }
        public ProjectEPSDto(ProjectEPS p)
        {
            ProjectEPSId = p.Projectepsid;
            Code = p.Code;
            Title = p.Title;
            Value = string.Concat(p.Code, " - ", p.Title);
            ProjectId = 0;
        }

        public ProjectEPSDto(ProjectInfo p)
        {
            ProjectEPSId = (long)p.Projectepsid;
            Code = p.Code;
            Title = p.Title;
            Value = p.Title;
            ProjectId = p.Projectinfoid;
            if (p.Projectepsid != null)
            { HasChildren = true; }
            else
            { HasChildren = false; }
        }

        public List<ProjectEPSDto> FromEPSList(List<ProjectEPS> lp)
        {
            List<ProjectEPSDto> l = new List<ProjectEPSDto>();
            foreach (var p in lp)
            {
                l.Add(new ProjectEPSDto(p));
            }
            return l;
        }

        public List<ProjectEPSDto> FromInfoList(List<ProjectInfo> lp)
        {
            List<ProjectEPSDto> l = new List<ProjectEPSDto>();
            foreach (var p in lp)
            {
                l.Add(new ProjectEPSDto(p));
            }
            return l;
        }
    }
}

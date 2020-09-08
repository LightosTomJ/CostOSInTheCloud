using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REST.Projects
{
    public static class Service
    {
        public static async Task<List<ProjectInfo>> GetAllProjectsAsync()
        {
            List<ProjectInfo> lp = null;
            try
            {
                //Verify login token is set
                if (Authorization.Service.Token == "") await Authorization.Service.LoginAsync();

                var res = await API.ProcessCallAsync(
                    new Uri(API.Server + @"/api/v1/projects"),
                    JsonConvert.SerializeObject(new DTO.Request()), Method.Get);
                if (res != null)
                {
                    DTO.Response.ProjectSummary c = JsonConvert.DeserializeObject<DTO.Response.ProjectSummary>(res);
                    foreach (var p in c.Projects)
                    {
                        lp.Add(new ProjectInfo
                        {
                            Projectinfoid = p.Id,
                            Title = p.Name,
                            Code = p.Code,
                            Description = p.Description,
                            Projectepsid = p.Parent,
                            Creatorid = p.GlobalId
                        });
                    }
                }
            }
            catch (Exception)
            { throw; }
            return lp;
        }

        public static async Task<ProjectInfo> GetProjectsByIdAsync(int Id)
        {
            ProjectInfo pi = null;
            try
            {
                List<DTO.Response.ProjectSummary> lp = new List<DTO.Response.ProjectSummary>();
                var res = await API.ProcessCallAsync(
                    new Uri(API.Server + @"/api/v1/projects/" + Id.ToString()),
                    JsonConvert.SerializeObject(lp), Method.Get);
                if (res != null)
                {
                    DTO.Response.Project p = JsonConvert.DeserializeObject<DTO.Response.Project>(res);
                    if (p != null)
                    {
                        pi = new ProjectInfo();
                        pi.Projectinfoid = p.Id;
                        pi.Title = p.Name;
                        pi.Code = p.Code;
                        pi.Description = p.Description;
                        pi.Projectepsid = p.Parent;
                        pi.Creatorid = p.GlobalId;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return pi;
        }

        public static async Task GetProjectsByIdPreviewAsync(int Id)
        {
            try
            {
                List<DTO.Response.ProjectSummary> lp = new List<DTO.Response.ProjectSummary>();
                var res = await API.ProcessCallAsync(
                    new Uri(API.Server + @"/api/v1/projects/" + Id.ToString() + "/preview"),
                    JsonConvert.SerializeObject(lp), Method.Get);
                if (res != null)
                {
                    lp = JsonConvert.DeserializeObject<List<DTO.Response.ProjectSummary>>(res);

                }
            }
            catch (Exception)
            { throw; }
        }
    }
}

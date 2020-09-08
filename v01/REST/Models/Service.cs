using Log = Diagnostics.Logger.Log;
using Newtonsoft.Json;
using REST.Models.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REST.Models
{
    public static class Service
    {
        public static async Task<List<Model>> GetAllModelsAsync()
        {
            List<Model> Models = null;
            try
            {
                //Verify login token is set
                if (Authorization.Service.Token == "") await Authorization.Service.LoginAsync();

                var res = await API.ProcessCallAsync(
                    new Uri(API.Server + @"/api/v1/models"),
                    JsonConvert.SerializeObject(new DTO.Request()), Method.Get);
                if (res != null)
                {
                    var a = JsonConvert.DeserializeObject(res);
                    ModelsSummary lm = JsonConvert.DeserializeObject<ModelsSummary>(res);
                    foreach(var m in lm.Models)
                    {

                    }
                }
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message.ToString());
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return Models;
        }

        public static async Task<Model> GetModelByIdAsync(long id)
        {
            Model model = null;
            try
            {
                var res = await API.ProcessCallAsync(
                    new Uri(API.Server + @"/api/v1/models/" + id.ToString()),
                    JsonConvert.SerializeObject(new DTO.Request()), Method.Get);

                model = JsonConvert.DeserializeObject<Model>(res);
                Console.WriteLine(DateTime.Now.ToString() + ": Model " + id.ToString() + " acquired");
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message.ToString());
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return model;
        }

        public static async Task<List<Model>> GetModelsAsync(List<int> ids)
        {
            List<Model> models = new List<Model>();
            try
            {
                List<Task> Tasks = new List<Task>();
                foreach (int id in ids)
                {
                    Tasks.Add(Task.Run(async () =>
                    {
                        models.Add(await GetModelByIdAsync(id));
                    }));
                }
                await Task.WhenAll(Tasks.ToArray());
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message.ToString());
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return models;
        }

        public static async Task<List<Model>> GetModelsAndElementsAsync(List<int> ids)
        {
            List<Model> models = new List<Model>();
            try
            {
                List<Task> Tasks = new List<Task>();
                foreach (int id in ids)
                {
                    Tasks.Add(Task.Run(async () =>
                    {
                        Model m = await GetModelByIdAsync(id);
                        models.Add(m);
                        //m = await Elements.Service.GetAllModelElementsAsync(m);
                    }));
                }
                await Task.WhenAll(Tasks.ToArray());
            }
            catch (Exception ae)
            {
                Log.WriteLine(ae.Message.ToString());
                if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
            }
            return models;
        }
    }
}

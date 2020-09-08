using REST.Authorization.DTO;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace REST.Authorization
{
    public static class Service
    {
        public static string Token { get; set; } = "";
        public static async Task LoginAsync()
        {
            try
            {
                DTO.Request l = new DTO.Request();
                var res = await API.ProcessCallAsync(
                    new Uri(API.Server + @"/api/v1/auth/login"),
                    JsonConvert.SerializeObject(l), Method.Post);
                if (res != null)
                {
                    Response r = JsonConvert.DeserializeObject<Response>(res);
                    Token = r.Token;
                }
            }
            catch (Exception)
            { throw; }
        }
    }
}

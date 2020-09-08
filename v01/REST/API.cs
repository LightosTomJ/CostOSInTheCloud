using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace REST
{
    public static class API
    {
        public static string Server = "https://demo.nomitech.net/bimct-server";
        private static readonly HttpClient client = new HttpClient();

        public static HttpResponseMessage ProcessCall(Uri uri, string payload)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("auth_token", Authorization.Service.Token);
            
            HttpContent httpContent = new StringContent(payload, Encoding.UTF8, "application/json");

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);

            var stringTask = client.PostAsync(uri, httpContent);
            return stringTask.Result;
        }

        public static async Task<string> ProcessCallAsync(Uri uri, string payload, Method method)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Authorization =
            //    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Authorization.Service.Token);
            //client.DefaultRequestHeaders.Authorization =
            //    new System.Net.Http.Headers.AuthenticationHeaderValue("auth_token", Authorization.Service.Token);

            if (Authorization.Service.Token != "")
            {
                uri = new Uri(uri.AbsoluteUri + "?auth_token=" + Authorization.Service.Token.ToString());
            }

            HttpContent httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
            
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            HttpResponseMessage resMessage = null;
            if (method == Method.Get)
            {
                req.Method = HttpMethod.Get.ToString();
                resMessage = await client.GetAsync(uri);
            }
            else if (method == Method.Post)
            {
                req.Method = HttpMethod.Post.ToString();
                resMessage = await client.PostAsync(uri, httpContent);
            }
            else if (method == Method.Put)
            {
                req.Method = HttpMethod.Put.ToString();
                resMessage = await client.PutAsync(uri, httpContent);
            }
            else if (method == Method.Delete)
            {
                req.Method = HttpMethod.Delete.ToString();
                resMessage = await client.DeleteAsync(uri);
            }
            else
            { }

            string res = await resMessage.Content.ReadAsStringAsync();
            return res;
        }
    }
    public enum Method
    {
        Get = 1,
        Post = 2,
        Put = 3,
        Delete = 4,
        Head = 5
    }
}

using System.Text;
using System.IO;

namespace Desktop.common.nomitech.coins.api
{
    using ObjectMapper = Desktop.common.com.fasterxml.jackson.databind.ObjectMapper;

    public class COINSApi
    {
        private ObjectMapper objectMapper = new ObjectMapper();

        private string username;

        private string password;

        private string apiBaseUrl;

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public COINSApi(String paramString1, String paramString2, String paramString3) throws Exception
        public COINSApi(string paramString1, string paramString2, string paramString3)
        {
            this.username = paramString2.ToLower();
            this.password = paramString3;
            this.apiBaseUrl = paramString1;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public String sendTestMessage() throws Exception
        public virtual string sendTestMessage()
        {
            string str1 = "{\"coins\": {\"header\": [{\"id\": \"123456\",\"msgID\": \"123456\",\"action\": \"UPDATE\",\"entity\": \"TIJ001\",\"testMsg\": false,\"userID\": \"George\",\"from\": \"CostOS\",\"hostname\": \"UKSLOUX030.coins.local\",\"environment\": \"dev\",\"created\": \"2014-07-02\",\"version\": \"v4\",\"user\": \"stecur\",\"password\": \"stecur\",\"body\": [{\"dummy\":\"a\"}]}]}}";
            string str2 = "http://oaenvs.coins-global.com/cgi-bin/wsdevrtb11/wouesb.p?json=TIJ001";
            return httpPut(str2, str1);
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private static String httpPut(String paramString1, String paramString2) throws java.io.UnsupportedEncodingException, java.io.IOException
        private static string httpPut(string paramString1, string paramString2)
        {
            URL uRL = new URL(paramString1);
            HttpURLConnection httpURLConnection = (HttpURLConnection)uRL.openConnection();
            httpURLConnection.RequestMethod = "PUT";
            httpURLConnection.DoOutput = true;
            httpURLConnection.setRequestProperty("Content-Type", "application/json");
            StreamWriter outputStreamWriter = new StreamWriter(httpURLConnection.OutputStream, Encoding.UTF8);
            outputStreamWriter.Write(paramString2);
            outputStreamWriter.Close();
            if (httpURLConnection.ResponseCode != 200)
            {
                throw new IOException(httpURLConnection.ResponseMessage);
            }
            StreamReader bufferedReader = new StreamReader(httpURLConnection.InputStream, Encoding.UTF8);
            StringBuilder stringBuilder = new StringBuilder();
            string str;
            while (!string.ReferenceEquals((str = bufferedReader.ReadLine()), null))
            {
                stringBuilder.Append(str);
            }
            bufferedReader.Close();
            httpURLConnection.disconnect();
            return stringBuilder.ToString();
        }
    }


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\coins\api\COINSApi.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}
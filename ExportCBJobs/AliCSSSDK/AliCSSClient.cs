using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using RestSharp;
using RestSharp.Extensions;
using System.Text.RegularExpressions;
using System.Web;

namespace AliCSSSDK
{
    public class AliCSSClient : RestClient
    {
        private readonly String CLIENT_ID;
        private readonly String CLIENT_SECRET;
        private readonly String API_URL = "http://css.aliyun.com/v1/api";

        public AliCSSClient(string client_id, string client_secret)
        {
            CLIENT_ID = client_id;
            CLIENT_SECRET = client_secret;

            base.BaseUrl = this.API_URL;
        }

        public override IRestResponse Execute(IRestRequest request)
        {
            if (request.Method == Method.GET || request.Method == Method.POST)
            {
                request.AddParameter("nonce", Nonce);
                request.AddParameter("client_id", CLIENT_ID);
                request.Parameters.RemoveAll(t => String.Equals(t.Name, "sign", StringComparison.CurrentCultureIgnoreCase));
                var paramsters = request.Parameters.OrderBy(t => t.Name).ToList();
                var sb = new StringBuilder();
                paramsters.ForEach(t =>
                    {
                        var value = HttpUtility.UrlEncode(t.Value.ToString());
                        value = Regex.Replace(value, "(%[0-9a-f][0-9a-f])", c => c.Value.ToUpper());
                        value = value.Replace("(", "%28").Replace(")", "%29").Replace("$", "%24").Replace("*", "%2A").Replace("'", "%26");
                        value = value.Replace("%7E", "~");
                        sb.AppendFormat("{0}={1}&", t.Name, value);
                    });
                if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);
                sb.Append(CLIENT_SECRET);
                request.AddParameter("sign", GetMD5(sb.ToString()));
            }
            else
            {
                throw new Exception("We Just Support GET/POST now");
            }

            return base.Execute(request);
        }

        private String Nonce
        {
            get
            {
                var time = Convert.ToInt64((double)(DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1).Ticks) / 10000000);
                return String.Format("{0}.{1}", GetMD5(string.Format("{0}{1}{2}", CLIENT_ID, CLIENT_SECRET, time)), time);
            }
        }

        private String GetMD5(string str)
        {

            MD5 md5 = MD5.Create();
            byte[] byteString = Encoding.UTF8.GetBytes(str);
            byte[] resultByteArray = md5.ComputeHash(byteString);
            StringBuilder resultBuilder = new StringBuilder();
            foreach (byte byt in resultByteArray)
            {
                resultBuilder.Append(byt.ToString("x2"));
            }

            return resultBuilder.ToString();
        }
    }
}

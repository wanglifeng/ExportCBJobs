using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliCSSSDK.Callers
{
    public abstract class BaseResourceCaller
    {
        protected readonly AliCSSClient CLIENT;
        protected IRestRequest request = new RestRequest();

        protected BaseResourceCaller(AliCSSClient client)
        {
            CLIENT = client;
        }

        protected IRestResponse Execute(IRestRequest request)
        {
            var rsp = CLIENT.Execute(request);
            Console.WriteLine("{0}:{1}", rsp.StatusCode, rsp.Content);
            return rsp;
        }

        protected IRestResponse<T> Execute<T>(IRestRequest request) where T : new()
        {
            var rsp = CLIENT.Execute<T>(request);
            return rsp;
        }
    }
}

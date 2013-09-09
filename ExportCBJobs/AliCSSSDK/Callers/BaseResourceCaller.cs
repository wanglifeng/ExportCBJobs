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
            Console.WriteLine(rsp.Content);
            return rsp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace AliCSSSDK.Callers
{
    public class Index : BaseResourceCaller
    {
        public Index(AliCSSClient client) : base(client) { }

        public void AllIndex()
        {
            request.Method = Method.POST;
            request.Resource = "index";
            base.Execute(request);
        }

        public void Detail(string IndexName)
        {
            request.Method = Method.POST;
            request.AddParameter("action", "status");
            request.Resource = string.Format("index/{0}", IndexName);
            base.Execute(request);
        }
    }
}

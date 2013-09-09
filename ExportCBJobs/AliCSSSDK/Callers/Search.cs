using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace AliCSSSDK.Callers
{
    public class Search : BaseResourceCaller
    {
        public Search(AliCSSClient client) : base(client) { }

        public void DoSearch(string indexName)
        {
            request.Method = Method.POST;
            request.Resource = string.Format("search/{0}", indexName);
            request.AddParameter("cq", "");
            request.AddParameter("facet", "facet_key:thumbnail ,facet_fun:count()");
            base.Execute(request);
        }
    }
}

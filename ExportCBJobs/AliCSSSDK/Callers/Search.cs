using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using AliCSSSDK.Models;

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
            //request.AddParameter("facet", "facet_key:thumbnail ,facet_fun:count()");
            base.Execute(request);
        }


        public Result<T> DoSearch<T>(String index, SearchParams param)
        {
            request.Method = Method.POST;
            request.Resource = string.Format("search/{0}", index);
            var sb = new StringBuilder();
            foreach (KeyValuePair<String, String> t in param.Query)
            {
                if (sb.Length > 0)
                    sb.Append(" AND ");

                sb.AppendFormat(" {0}:\"{1}\" ", t.Key, t.Value);
            }
            request.AddParameter("cq", sb.ToString().Trim());
            request.AddParameter("page", param.page);
            request.AddParameter("page_size", param.page_size);
            var rsp = base.Execute<Result<T>>(request);

            return rsp.Data;
        }

        public class SearchParams
        {
            public Dictionary<string, String> Query { get; set; }
            public int page { get; set; }
            public int page_size { get; set; }
            public SearchParams() { Query = new Dictionary<string, string>(); page = 1; page_size = 20; }
        }

        public class Result<T>
        {
            // public Result() { result = new ItemsResult<T>(); }

            public String status { get; set; }
            public ItemsResult<T> result { get; set; }
        }

        public class ItemsResult<T>
        {
            //public ItemsResult() { items = new List<T>(); }

            public List<T> items { get; set; }

            public int num { get; set; }
            public int total { get; set; }
        }
    }
}

using AliCSSSDK.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Serializers;

namespace AliCSSSDK.Callers
{
    public class Doc : BaseResourceCaller
    {
        public Doc(AliCSSClient client) : base(client) { }

        public void Detail(string indexName, string docId)
        {
            request.Method = Method.POST;
            request.Resource = string.Format("index/doc/{0}", indexName);
            request.AddParameter("id", docId);
            base.Execute(request);
        }

        public void Create(string indexName, BaseModel[] model)
        {
            request.Method = Method.POST;
            request.Resource = string.Format("index/doc/{0}", indexName);
            var docs = new List<UploadDocModel>();
            Array.ForEach(model, d =>
                {
                    docs.Add(new UploadDocModel() { cmd = "add", fields = d });
                });
            request.AddParameter("action", "push");
            request.AddParameter("items", (new JsonSerializer()).Serialize(docs));
            base.Execute(request);
        }
    }
}

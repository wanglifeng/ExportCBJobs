using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExportCBJobs;
using AliCSSSDK;
using AliCSSSDK.Models;
using APICaller.Callers;
using APICaller.Models;

namespace ConsoleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] categories = new string[] { "JN008", "JN044", "JN007", "JN045", "JN001",
                "JN034", "JN058", "JN010", "JN068", "JN071", "JN022", "JN029", "JN023", 
                "JN049", "JN002", "JN020", "JN111", "JN079", "JN026", "JN003", "JN082", 
                "JN094", "JN004", "JN009", "JN043", "JN047", "JN030", "JN057", "JN013", 
                "JN070", "JN086", "JN054", "JN014", "JN091", "JN053", "JN033", "JN067", 
                "JN077", "JN027", "JN021", "JN064", "JN025", "JN048", "JN078", "JN016",
                "JN005", "JN011", "JN018" };

            JobSearchAPICaller caller = new JobSearchAPICaller();
            Array.ForEach(categories, c =>
                {
                    var request = new JobSearchRequest()
                    {
                        HostSite = "CN",
                        PageNumber = 1,
                        PerPage = 20,
                        Category = c
                    };
                    var response = new JobSearchResponse();
                    do
                    {
                        caller.Search("WD1B37Z74Y7BL07ZM89B", request, out response);
                    }
                    while (response == null);

                    Console.WriteLine("Category:{0},TotalPage:{1}", c, response.TotalPages);
                    for (int i = 1; i < response.TotalPages + 1; i++)
                    {
                        Console.WriteLine(i);
                        request.PageNumber = i;
                        do
                        {
                            caller.Search("WD1B37Z74Y7BL07ZM89B", request, out response);
                        }
                        while (response == null);
                        var novels = new List<BaseModel>();
                        if (response != null)
                        {
                            response.Results.ForEach(r =>
                                {
                                    //novels.Add(DocumentTransform.CreateSearchDocument(r));
                                    JobAPICaller jdCaller = new JobAPICaller();
                                    JobDetailResponse rsp = new JobDetailResponse();
                                    Console.WriteLine(r.DID);
                                    jdCaller.Detail("WDHQ6RD6JDNC5B4QVL8K", new JobDetailRequest() { DID = r.DID, outputjson = true, Showjobskin="showtokens" }, out rsp);
                                    System.IO.File.WriteAllText(@"d:/jobs/" + r.DID + ".json", jdCaller.Content);
                                });
                            //AliCSSCaller aliCaller = new AliCSSCaller();
                            //aliCaller.Doc.Create("jobsearch", novels.ToArray());
                        }
                        //System.Threading.Thread.Sleep(1000);
                    }
                });


        }
    }
}

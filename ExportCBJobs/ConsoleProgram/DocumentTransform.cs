using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AliCSSSDK.Models;
using APICaller.Models;

namespace ConsoleProgram
{
    class DocumentTransform
    {
        public static BaseModel CreateSearchDocument(JobSearchResponse.JobSearchResult job)
        {
            Novel n = new Novel()
            {
                id = job.DID,
                author = job.Company,
                title = job.JobTitle,
                press = job.CompanyDID,
                source = job.CompanyDetailURL,
                body = job.DescriptionTeaser,
                url = job.JobDetailsURL,
                era = job.Location,
                create_timestamp = Convert.ToInt32((double)(Convert.ToDateTime(job.PostedDate).Ticks - new DateTime(1970, 1, 1).Ticks) / 10000000),
                thumbnail = job.CompanyImageURL

            };
            return n;
        }
    }
}

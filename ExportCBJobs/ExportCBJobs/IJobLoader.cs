using ExportCBJobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExportCBJobs
{
    public interface IJobLoader
    {
        List<Job> LoadJobsByParams(SearchParams param);

        Job LoadByDID(string did);
    }
}

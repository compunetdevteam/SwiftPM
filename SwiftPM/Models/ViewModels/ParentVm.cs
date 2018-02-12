using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwiftPMModel;
using SwiftPM.Extensions;
using Microsoft.AspNet.Identity;

namespace SwiftPM.Models.ViewModels
{
    public  class ParentVm
    {    
       
        public string FullName { get; set; } 

        public string GetTaskIssuesCount()
        {
             SwiftPmDb db = new SwiftPmDb();
        
            var taskCount = db.ModuleTaskIssues.Count().ToString();
            return taskCount;
        }


    }
}
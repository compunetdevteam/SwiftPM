using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace SwiftPMModel
{

    // Handles processes of the system
    public class QueryProcessor
    {

        public string LoggedUserId { get; set; }

        public string FullName { get; set; }


        // Calculates the completeion percentage rate of a task assigned
        public decimal CompletionRate(AssignedTask assignedTask)
        {
            return 0;
        }


    }
}

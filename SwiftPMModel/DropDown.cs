using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftPMModel
{         public class DropDown
        {
           
            public enum Gender
            {          
                Male = 1,
                Female,
            }
             public enum NotFound
            {          
                NoUser = 1,
                NoDepartment,
                NotCompleted,
                NoProject,
                NoTask,
                NoTaskIssues,
                NoDepartmentAssigned,
               
            }

            public enum State
            {
                Abia = 1, Adamawa, Anambra, Akwa_Ibom, Bauchi, Bayelsa, Benue, Borno, Cross_River, Delta, Ebonyi, Enugu, Edo, Ekiti, Gombe, Imo, JigawaKaduna, Kano, Katsina, Kebbi, Kogi, Kwara, Lagos, Nasarawa, Niger, Ogun, Ondo, Osun, Oyo, Plateau, Rivers, Sokoto, Taraba, Yobe, Zamfara,

            }

            public enum TaskStatus
            {
               Pending = 1, Ongoing, Completed
            }

            public enum Title
            {
                Mr = 1, Mrs, Dr, Master, Miss,Engr,Barister,Pastor
            }

            public enum MaritalStatus
            {
                Select_Status, Single, Married, Divorced, Widowed, Widower
            }

            public enum Role
            {
                Select_Role =1,
                AppAdmin ,
                HR,
                CompanyIT,
                CEO,
                Director,
                HOD,
                Supervisor,
                Staff




            }
    }
    }


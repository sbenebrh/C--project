using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{   /// <summary>
    /// the list to stock the objets
    /// </summary>
    public static class DataSource
    {
       
        public static List<specialization> specializationList = new List<specialization>();//list of specialisation
        public static List<Employee> EmployeeList = new List<Employee>();//list of employee
        public static List<Employer> EmployerList = new List<Employer>();//list of employer
        public static List<contract> contractList = new List<contract>();//list of contract
        public static List<bank> branchlist = new List<bank>();//list of bank

    }
}

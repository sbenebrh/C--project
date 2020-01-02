using BE;
using System;
using System.Collections.Generic;


namespace DAL
{
    public interface Idal
    {
        void addExpert(specialization e);
        void removeExpert(specialization e);
        bool updateExpert(specialization e);

        void addEmployee(Employee e);
        void removeEmployee(Employee e);
        bool uptdateEmployee(Employee e);

        void addEmployer(Employer e);
        void removeEmployer(Employer e);
        bool uptdateEmployer(Employer e);

        void addcontract(contract c);
        void removecontract(contract c);
        bool uptdatecontract(contract c);
        int get_number_Contract();
        bool seaurchID_existEmployee(int ID);
        bool seaurchID_existEmployer(int ID);
        Employer searchId_find(int ID);
        Employee searchId_find_employee(int ID);


        List<specialization> allExpert();

      /*  
        List<Employee> allEmployee();
        List<Employer> allEmployer();
        List<contract> allContract();
        List<bank> allbranch();
        */


        // rajouter
        IEnumerable<specialization> Allspecialization(Func<specialization, bool> predicate = null);
        IEnumerable<contract> Allcontract(Func<contract, bool> predicate = null);
        IEnumerable<Employee> AllEmployee(Func<Employee, bool> predicate = null);
        IEnumerable<Employer> AllEmployer(Func<Employer, bool> predicate = null);
        IEnumerable<bank> Allbank(Func<bank, bool> predicate = null);

    }
}
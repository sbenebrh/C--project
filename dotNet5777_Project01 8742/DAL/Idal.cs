using BE;
using System;
using System.Collections.Generic;


namespace DAL
{
    public interface Idal
    {
        /// <summary>
        /// idal interface
        /// </summary>
        
        #region specialization
        void addExpert(specialization e);
        void removeExpert(int id);
        void updateExpert(specialization e);
        specialization searchId_find_specialization(int ID);
        bool seaurchID_existspecialization(int ID);
        IEnumerable<specialization> Allspecialization();
        #endregion

        #region employee
        void addEmployee(Employee e);
        void removeEmployee(Employee e);
        void uptdateEmployee(Employee e);
        bool seaurchID_existEmployee(int ID);
        Employee searchId_find_employee(int ID);
        IEnumerable<Employee> AllEmployee();
        #endregion

        #region employer
        void addEmployer(Employer e);
        void removeEmployer(Employer e);
        void uptdateEmployer(Employer e);
        bool seaurchID_existEmployer(int ID);
        Employer searchId_find_employer(int ID);
        IEnumerable<Employer> AllEmployer();
        #endregion

        #region contract
        void addcontract(contract c);
        void removecontract(contract c);
        void uptdatecontract(contract c);
        int get_number_Contract();
        bool seaurchID_existcontract(int ID);
        contract searchId_contract_find(int ID);
        IEnumerable<contract> Allcontract();
        #endregion

        #region bank 
        IEnumerable<string> returnyeshouv();
        IEnumerable<string> return_nom_bank(string y);
        IEnumerable<string> return_nom_address_atm(string y, string b);
        IEnumerable<int> return_code_bank();
        IEnumerable<int> return_code_snif();
        void threa_isalive();
        IEnumerable<bank> Allbank();
        #endregion

    }
}
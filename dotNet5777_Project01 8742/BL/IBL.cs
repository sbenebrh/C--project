using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public interface IBL
    {


        #region Function add
        void addExpert(specialization  e);
        void addEmployee(Employee e);
        void addEmployer(Employer e);
        void addcontract(contract c);
        #endregion

        #region Function remove
        void removeEmployee(int id);
        void removeEmployer(int ID);
        void removecontract(int ID);
        void removeExpert(int id);
        #endregion

        #region Function update
        void uptdateEmployee(Employee e);
        void uptdateEmployer(Employer e);
        void uptdatecontract(contract c);
        void updateExpert(specialization e);
        #endregion

        #region Function all lists
        IEnumerable<specialization> Allspecialization_condition(Predicate<specialization> condition = null);
        IEnumerable<contract> Allcontract_condition(Predicate<contract> condition = null);
        IEnumerable<Employee> AllEmployee_condition(Predicate<Employee> condition = null);
        IEnumerable<Employer> AllEmployer_condition(Predicate<Employer> condition = null);
        IEnumerable<bank> Allbank_condition(Predicate<bank> condition = null);
        IEnumerable<contract> AllCONTRACT_TO_EMPLOYER(int ID);
        #endregion

        #region all lists
        IEnumerable<specialization> Allspecialization();
        IEnumerable<contract> Allcontract();
        IEnumerable<Employee> AllEmployee();
        IEnumerable<Employer> AllEmployer();
        IEnumerable<bank> Allbank();
        IEnumerable<contract> AllCONTRACT_TO_employee(int ID);
        #endregion

        #region function groupings
        IEnumerable<IGrouping<expertise, contract>> Grouping_expert(bool miyoun);
        IEnumerable<IGrouping<string, contract>>  Grouping_city();
        #endregion
        
        #region functions return object
        Employer searchId_find_employer(int ID);
        specialization return_expert(int ID);
        Employee return_emploee(int ID);
        contract return_contrat(int ID);
       
        #endregion

        #region functions return names id of all list
        IEnumerable<int> return_names_id_employer();
        IEnumerable<int> return_names_id_employee();
        IEnumerable<int> return_names_id_specialization();
        IEnumerable<int> return_names_id_contract();

        int get_number_Contract();

        #endregion

        #region grouping
        List<contract> Grouping_contract_revahim(int b, int end);
        int sahar_employee(int ID);
        #endregion

        #region bank 
        IEnumerable<int> return_code_bank();
        IEnumerable<string> return_nom_bank(string y);
        IEnumerable<string> returnyeshouv();
        IEnumerable<int> return_code_snif();
        IEnumerable<string> return_nom_address_atm(string y , string b);
        IEnumerable<int> Alllist();
        void threa_isalive();
        #endregion



    }
}
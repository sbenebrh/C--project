using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    public class Dal_imp : Idal
    {
        private static Dal_imp instance = null;

        public static Dal_imp getInstance()
        {
            return instance ?? (new Dal_imp());
        }
        #region employee
        public void addEmployee(Employee e)//add employee :save in list of employee in data source
        {
            DS.DataSource.EmployeeList.Add(e);
        }

        public void removeEmployee(Employee e)// receive an objet employee in parameter and delete it from the list in the ds
        {
            DS.DataSource.EmployeeList.Remove(e);
        }

        public bool seaurchID_existEmployee(int ID)//receive int in parameter verifie if the objet employee who have this id exist in the DS and return true if yess
        {
            if (DataSource.EmployeeList.Exists(s => s.ID == ID))
                return true;
            else return false;
        }

        public void uptdateEmployee(Employee e)// receive an objet employee and update his parameters
        {
            int id = e.ID;
            if (DS.DataSource.EmployeeList.Exists(c => c.ID == e.ID))
            {
                int index = DS.DataSource.EmployeeList.FindIndex(x => x.ID == e.ID);
                if (index != -1)
                    DataSource.EmployeeList[index] = e;
                else
                    throw new KeyNotFoundException(" The Employee Id doesn't exist  : " + id);
            }
            else throw new KeyNotFoundException(" The Employee Id doesn't exist  : " + id);
        }

        public Employee searchId_find_employee(int ID)//receive int in parameter and return the employee who has this ID
        {
            return DataSource.EmployeeList.Find(s => s.ID == ID);
        }

        public IEnumerable<Employee> AllEmployee()//ienumerable of employee return the employee list
        {
            return DataSource.EmployeeList;
        }
        #endregion

        #region employer
        public void addEmployer(Employer e)//add employer :save in list of employer in data source
        {
            DS.DataSource.EmployerList.Add(e);
        }

        public void removeEmployer(Employer e)// receive an objet employer in parameter and delete it from the list in the ds
        {
            DS.DataSource.EmployerList.Remove(e);
        }

        public bool seaurchID_existEmployer(int ID)//receive int in parameter verifie if the objet employer who has this id exist in the DS and return true if yess
        {
            return (DataSource.EmployerList.Exists(s => s.companyID == ID));
        }

        public Employer searchId_find_employer(int ID)//receive int in parameter and return the employer who has this ID
        {
            return DataSource.EmployerList.Find(s => s.companyID == ID);
        }

        public void uptdateEmployer(Employer e)// receive an objet employer and update his parameters
        {
            int id = e.companyID;
            if (DS.DataSource.EmployerList.Exists(c => c.companyID == e.companyID))
            {

                int index = DS.DataSource.EmployerList.FindIndex(x => x.companyID == e.companyID);
                if (index != -1)
                    DataSource.EmployerList[index] = e;
                else
                    throw new KeyNotFoundException(" The Employer Id doesn't exist  : " + id);
            }

            else throw new KeyNotFoundException(" The Employee Id doesn't exist  : " + id);
        }

        public IEnumerable<Employer> AllEmployer()//ienumerable of employer return the employer list
        {
            return DataSource.EmployerList;
        }
        #endregion

        #region contract
        public void addcontract(contract c)//add contract :save in list of contract in data source
        {
            DS.DataSource.contractList.Add(c);
        }

        public int get_number_Contract()//return number of contract
        {
            return DataSource.contractList.Count;
        }

        public void removecontract(contract c)// receive an objet contract in parameter and delete it from the list in the ds
        {
            DS.DataSource.contractList.Remove(c);
        }

        public void uptdatecontract(contract c)// receive an objet contact and update his parameters
        {
            int id = c.contractID;
            if (DS.DataSource.contractList.Exists(d => d.contractID == c.contractID))
            {
                int index = DS.DataSource.contractList.FindIndex(x => x.contractID == c.contractID);
                if (index != -1)
                    DataSource.contractList[index] = c;
                else
                    throw new KeyNotFoundException(" The contractId Id doesn't exist  : " + id);
            }
        }
        public IEnumerable<contract> Allcontract()//ienumerable of specialisation return the specialization list
        {
            return DataSource.contractList;
        }

        public bool seaurchID_existcontract(int ID)//receive int in parameter verifie if the objet contract who has this id exist in the DS and return true if yess
        {
            return (DataSource.contractList.Exists(s => s.contractID == ID));
        }

        public contract searchId_contract_find(int ID)//receive int in parameter and return the contract who has this ID
        {
            return DataSource.contractList.Find(s => s.contractID == ID);
        }
        #endregion

        #region specialization
        public void addExpert(specialization e)//add specialization :save in list of specialization in data source
        {
            DS.DataSource.specializationList.Add(e);
        }

        public void removeExpert(int id)// receive an objet expert in parameter and delete it from the list in the ds
        {
            DS.DataSource.specializationList.Remove(this.searchId_find_specialization(id));
        }

        public void updateExpert(specialization e)// receive an objet specialization and update his parameters
        {
            int id = e.specialization_id;
            if (DS.DataSource.specializationList.Exists(c => c.specialization_id == e.specialization_id))
            {
                int index = DS.DataSource.specializationList.FindIndex(x => x.specialization_id == e.specialization_id);
                if (index != -1)
                    DataSource.specializationList[index] = e;
                else
                    throw new KeyNotFoundException(" The Specialization Id doesn't exist  : " + id);
            }
            else throw new KeyNotFoundException("The Specialization Id doesn't exist  : " + id);

        }

        public IEnumerable<specialization> Allspecialization()//ienumerable of specialisation return the specialization list
        {
            return DataSource.specializationList;
        }

        public specialization searchId_find_specialization(int ID)//receive int in parameter and return the specialization who has this ID
        {
            return DataSource.specializationList.Find(s => s.specialization_id == ID);
        }

        public bool seaurchID_existspecialization(int ID)//receive int in parameter verifie if the objet specialization who has this id exist in the DS and return true if yess
        {
            return (DataSource.specializationList.Exists(s => s.specialization_id == ID));
        }

        #endregion

        #region bank
        public IEnumerable<bank> Allbank()//ienumerable of bank return the bank list
        {
            return DataSource.branchlist;
        }

        public IEnumerable<int> return_code_bank()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> return_nom_bank(string y)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> returnyeshouv()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> return_code_snif()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> return_nom_address_atm(string y, string b)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> return_nom_address_atm()
        {
            throw new NotImplementedException();
        }

        public void threa_isalive()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

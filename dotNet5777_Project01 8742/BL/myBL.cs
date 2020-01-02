using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using DS;
using DAL;
namespace BL
{
    internal class myBL : IBL
    {
        DAL.Idal dal = Factory_DAL.getInstance("XML");


        #region IEnumerable all list
        public IEnumerable<specialization> Allspecialization()//ienumerable of specialization
        {
            return dal.Allspecialization();//return the fonction allspialisation of the dal(return of the list of specialisation)
        }

        public IEnumerable<contract> Allcontract()//ienumerable of contract
        {
            return dal.Allcontract();//return the fonction allcontract of the dal(return of the list of contract)
        }

        public IEnumerable<Employee> AllEmployee()//ienumerable of Employee
        {
            return dal.AllEmployee();//return the fonction allEmployee of the dal(return of the list of Employee)
        }

        public IEnumerable<Employer> AllEmployer()//ienumerable of Employer
        {
            return dal.AllEmployer();//return the fonction allEmployer of the dal(return of the list of Employer)
        }

        public IEnumerable<bank> Allbank()//ienumerable of bank
        {
            return dal.Allbank();//return the fonction allbank of the dal(return of the list of bank)
        }

        #endregion

        #region IEnumerable by condition  all list
        public IEnumerable<specialization> Allspecialization_condition(Predicate<specialization> condition = null)//delegate with condition 
        {
            return from c in dal.Allspecialization()
                   where condition(c)
                   select c;
        }

        public IEnumerable<contract> Allcontract_condition(Predicate<contract> condition = null)//delegate with condition 
        {
            return from c in dal.Allcontract()
                   where condition(c)
                   select c;
        }

        public IEnumerable<Employee> AllEmployee_condition(Predicate<Employee> condition = null)//delegate with condition 
        {
            return from c in dal.AllEmployee()
                          where condition(c)
                          select c;
        }

        public IEnumerable<Employer> AllEmployer_condition(Predicate<Employer> condition = null)//delegate with condition 
        {
            return from c in dal.AllEmployer()
                   where condition(c)
                   select c;
        }

        public IEnumerable<bank> Allbank_condition(Predicate<bank> condition = null)//delegate with condition 
        {
            return from c in dal.Allbank()
                   where condition(c)
                   select c;
        }



        #endregion

        #region functions add
        public void addcontract(contract c)//add contract
        {
            int ID_E = c.employerID; // ID EMPLOYER
            Employer temp= searchId_find_employer(ID_E);
            DateTime b = temp.creationDate;
            DateTime now = DateTime.Now;
            int ID = c.contractID;  // ID CONTRACT
           // DateTime T_BEGINING = c.beginning;
           // DateTime T_END = c.end;
            TimeSpan t = now - b;               
            if (t.Days<365 )       //hevra less than 1 year 
                throw new NotImplementedException("not possibility to add hevha age under 1 years");
            else
            {
                hichouvSacharEmployee(c);//sahar
                dal.addcontract(c);    //call the dal method to add contract           
            }
            
        }

        public void addEmployee(Employee e) //add employee
        {
            int ID = e.ID;
            DateTime d = DateTime.Today;
            DateTime birth_day = e.birthDate;
            TimeSpan Age = d - birth_day;
            int a = Age.Days / 365;
            e.age = a;
            if (e.age < 18)
                throw new Exception("not possibility to add employee Under 18 years");
            else  dal.addEmployee(e);//call the dal method to add employee   
        }
      
        public void addEmployer(Employer e)//add employer
        {
                dal.addEmployer(e);//call the dal method to add employer 
        }

        public void addExpert(specialization s)//add specialisation
        {
                dal.addExpert(s);//call the dal method to add specialisation   
        }
        #endregion

        #region functions remove
        public void removecontract(int ID)//remove contract
        {
            contract C = new contract();
            C.contractID = ID;
            dal.removecontract(C);//call the dal method to remov from the xeleement file
        }

        public void removeEmployee(int ID)//remove employee
        {
            Employee e = new Employee();
             e.ID = ID;
             dal.removeEmployee(e);   //call the dal method to remov from the xeleement file                   
        }

        public void removeEmployer(int ID)//remove employer
        {
            Employer e = new Employer();
            e.companyID = ID;
            dal.removeEmployer(e);//call the dal method to remov from the xeleement file
        }
        public void removeExpert(int ID)//remove specialisation
        {
            dal.removeExpert(ID);//call the dal method to remov from the xeleement file
        }


        #endregion

        #region functions update
        public void updateExpert(specialization s)//update specialisation
        {
            dal.updateExpert(s); //call the dal method to update from the xeleement file          
        }

        public void uptdatecontract(contract c)//update contract
        {
            hichouvSacharEmployee(c);//new salaire
            dal.uptdatecontract(c);     //call the dal method to remov from the xeleement file    
        }


        public void uptdateEmployee(Employee e)//update employee
        {
            dal.uptdateEmployee(e);      //call the dal method to remov from the xeleement file

        }


        public void uptdateEmployer(Employer e)//update employer
        {
            dal.uptdateEmployer(e);//call the dal method to remov from the xeleement file

        }


        #endregion

        #region functions grouping
        public IEnumerable<IGrouping<string, contract>> Grouping_city()//grouping by city
        {
            IEnumerable<IGrouping<string, contract>> result = from n in dal.Allcontract()
                                                                       group n by n.city;       
            return result;         
        }

        public IEnumerable<IGrouping<expertise, contract>> Grouping_expert(bool miyoun)//grouping by specialisation
        {
            IEnumerable<IGrouping<expertise, contract>> result = from n in dal.Allcontract()
                                                                 group n by n.expertise;

            List<contract> lst = new List<contract>();
            foreach (IGrouping<expertise, contract> expert in result)
            {
              
                switch (expert.Key)
                {
                    case expertise.PROGRAMMER:
                        foreach (contract n in expert)
                            lst.Add(n);                          
                        break;
                    case expertise.DESIGNER:
                        foreach (contract n in expert)
                            lst.Add(n);
                        break;
                    case expertise.APPLICATION_INGINEER:
                        foreach (contract n in expert)
                            lst.Add(n);
                        break;
                    case expertise.ALGO_INGINEER:
                        foreach (contract n in expert)
                            lst.Add(n);
                        break;
                }
            }
            
            return result;
        }
       
        public List<contract>  Grouping_contract_revahim(int beg , int end)//by revahim
        {
            IEnumerable<IGrouping<double, contract>> result = from n in dal.Allcontract()
                                                           group n by n.commission;
        
            List<contract> lst = new List<contract>();
         /*   foreach (IGrouping<int, contract> date in result)
            {
                foreach (contract n in date)
                { 
                    if (n.beginning.Year>beg)
                    {
                        lst.Add(n);
                    }                  
                }
            }*/
            foreach (contract n in dal.Allcontract())
            {
                if (n.beginning.Year>=beg && n.end.Year <=end)
                {
                    lst.Add(n);
                }
            }
            return lst;                                
        }

        #endregion

        #region other functions
        public int get_number_Contract()//return the number of contract
        {
            return dal.get_number_Contract();//call the dal method
        }


        public delegate bool conditionDelegate(contract c);
        public int number_of_contracts( conditionDelegate cond)//return number of contract 
        {
            var List_contract = from n in dal.Allcontract()
                                where cond(n)
                                select n;
            return List_contract.Count(); 
        }

        public void hichouvSacharEmployee(contract c)
        {
            /*var Listcontracts = from n in dal.Allcontract()
                                where n.employeeID == c.employeeID && n.employerID == c.employerID
                                select n;*/
            TimeSpan t = c.end - c.beginning;
            if (number_of_contracts(x => x.employeeID == c.employeeID && x.employerID == c.employerID) == 1)//number of contract =1
            {
                c.commission = (c.salaryBrute * 0.10);
                c.salaryNet = c.salaryBrute - c.commission;
                c.commission = c.commission * (t.Days / 30);
                
            }
            else if (number_of_contracts(x=>x.employeeID == c.employeeID && x.employerID == c.employerID) >1 )//delegate number of contract>1 amala
            {
                c.commission = c.salaryBrute * Math.Pow(0.25, number_of_contracts(x => x.employeeID == c.employeeID && x.employerID == c.employerID));
                c.salaryNet = c.salaryBrute - c.commission;
                c.commission = c.commission * (t.Days / 30);
            }
            else
            {
                c.commission = (c.salaryBrute * 0.10);
                c.salaryNet = c.salaryBrute - c.commission;
                c.commission = c.commission * (t.Days / 30);
            }
        }

        #endregion

        #region functions return object
        public IEnumerable<contract> AllCONTRACT_TO_EMPLOYER(int ID)//return list of contract
        {
            Employer temp = searchId_find_employer(ID);

            return Allcontract_condition(x=>x.employerID==temp.companyID);

        }
        public IEnumerable<contract> AllCONTRACT_TO_employee(int ID)//return list of contract
        {
            Employee temp = searchId_find_employee(ID);

            return Allcontract_condition(x => x.employeeID == temp.ID);

        }

        public Employee return_emploee(int ID)//return employee
        {
            return dal.searchId_find_employee(ID);//call dal method to find employee in xml file
        }

        public contract return_contrat(int ID)//return contrat
        {
            return dal.searchId_contract_find(ID);//call dal method to find contract in xml file
        }
        public Employer searchId_find_employer(int ID)//return employer
        {
            return dal.searchId_find_employer(ID);//call dal method to find contract in xml file
        }
        public Employee searchId_find_employee(int ID)//return employee
        {
            return dal.searchId_find_employee(ID);//call dal method to find employee in xml file
        }

        public specialization return_expert(int ID)//return specialisation
        {
            return dal.searchId_find_specialization(ID);//call dal method to find specialization in xml file
        }
        #endregion

        #region functions return names id of all list
        public IEnumerable<int> return_names_id_employee()
        {
            var v = from item in dal.AllEmployee()
                    select item.ID;
            return v;
        }

        public IEnumerable<int> return_names_id_specialization()
        {
            var v = from item in dal.Allspecialization()
                    select item.specialization_id;
            return v;
        }

        public IEnumerable<int> return_names_id_contract()
        {
            var v = from item in dal.Allcontract()
                    select item.contractID;
            return v;
        }
        public IEnumerable<int> return_names_id_employer()
        {
            var v = from item in dal.AllEmployer()
                    select item.companyID;
            return v;
        }

        public int sahar_employee(int ID)
        {
           int sahar;
            var v = from n in dal.Allcontract()
                    where n.employeeID == ID
                    select n.salaryNet;
           string a = v.ToString();
           int.TryParse(a, out sahar);

            return sahar;
        }




        #endregion

        #region bank
        public IEnumerable<int> return_code_bank()
        {
            return dal.return_code_bank();//call dal method to find code bankcontract in xml file
        }

        public IEnumerable<string> return_nom_bank(string y)
        {
            return dal.return_nom_bank(y);//call dal method to find name in xml file
        }

        public IEnumerable<string> returnyeshouv()
        {
            return dal.returnyeshouv();//call dal method to find yeshuv in xml file
        }

        public IEnumerable<int> return_code_snif()
        {
            return dal.return_code_snif();//call dal method to find snif in xml file
        }

        public IEnumerable<string> return_nom_address_atm(string y, string b)
        {
            return dal.return_nom_address_atm(y, b);//call dal method to find adress in xml file
        }

        public IEnumerable<int> Alllist()
        {
          List<int> lst = new List<int>();  
             
           return lst;
       }

        public void threa_isalive()
        {
            dal.threa_isalive();
        }
        #endregion

    }
}

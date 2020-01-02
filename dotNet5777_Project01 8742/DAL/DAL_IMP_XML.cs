using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.IO;
using System.Net;
using System.Threading;

namespace DAL
{
    class DAL_IMP_XML : Idal
    {
        private static DAL_IMP_XML instance = null;

        public static DAL_IMP_XML getInstance()
        {
            return instance ?? (new DAL_IMP_XML());
        }
        #region folder xml
        //root of every xml folders
        XElement SPECIALIZATION_ROOT;
        XElement CONTRACT_ROOT;
        XElement EMPLOYEE_ROOT;
        XElement EMPLOYER_ROOT;
        XElement BANK_ROOT;
        //path to the folders xml
        string specialization_path = @"XML\SPECIALIZATION.xml";
        string CONTRACT_path = @"XML\CONTRACTS.xml";
        string EMPLOYEE_path = @"XML\EMPLOYEE.XML";
        string EMPLOYER_path = @"XML\EMPLOYER.XML";
        string xmlLocalPath_bank = @"XML\atm.xml";

        Thread thread_bank;
        private bool thread_finish = false;//flag
        DAL_IMP_XML()//ctor
        {
            thread_bank = new Thread(new ThreadStart(load_bank_file));
            CreateFiles();
            loadFIles();
            
        }

        private void load_bank_file()//download the bank
        {
            try
            {
                if (!File.Exists(xmlLocalPath_bank))
                {
                    BANK_ROOT = new XElement(new XElement("ATMs"));
                    BANK_ROOT.Save(xmlLocalPath_bank);
                    WebClient wc = new WebClient();
                    try
                    {
                        string xmlServerPath = @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
                        wc.DownloadFile(xmlServerPath, xmlLocalPath_bank);
                    }
                    catch (Exception)
                    {
                        string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                        wc.DownloadFile(xmlServerPath, xmlLocalPath_bank);
                    }
                    finally
                    {
                        wc.Dispose();

                    }
                    thread_finish = true;
                    BANK_ROOT = XElement.Load(xmlLocalPath_bank);
                   // Thread.Sleep(200);

                }
                // thread_finish = true;         
                BANK_ROOT = XElement.Load(xmlLocalPath_bank);
                Thread.Sleep(1000);
            }
            catch
            {
                throw new Exception("problem reading the files");
            }
        }

        private void CreateFiles()//create the differente files of xml
        {
            if (!Directory.Exists("XML"))
                Directory.CreateDirectory(@"XML");

            if (!File.Exists(specialization_path))//creation of specialization file
            {
                SPECIALIZATION_ROOT = new XElement(new XElement("specializations"));
                SPECIALIZATION_ROOT.Save(specialization_path);
            }
            if (!File.Exists(CONTRACT_path))//creation of contract file
            {
                CONTRACT_ROOT = new XElement(new XElement("CONTRACTS"));
                CONTRACT_ROOT.Save(CONTRACT_path);
            }
            if (!File.Exists(EMPLOYEE_path))//creation of employee file
            {
                EMPLOYEE_ROOT = new XElement(new XElement("employees"));
                EMPLOYEE_ROOT.Save(EMPLOYEE_path);
            }
            if (!File.Exists(EMPLOYER_path))//creation of employer file
            {
                EMPLOYER_ROOT = new XElement(new XElement("employer"));
                EMPLOYER_ROOT.Save(EMPLOYER_path);
            }
            if (!File.Exists(xmlLocalPath_bank) && thread_bank.IsAlive == false)
            {
                thread_bank.Start();
            }
           // else thread_finish = true;
        }
        private void loadFIles()//read the files
        {
            
                SPECIALIZATION_ROOT = XElement.Load(specialization_path);
                CONTRACT_ROOT = XElement.Load(CONTRACT_path);
                EMPLOYER_ROOT = XElement.Load(EMPLOYER_path);
                EMPLOYEE_ROOT = XElement.Load(EMPLOYEE_path);
            if (File.Exists(xmlLocalPath_bank) && thread_bank.IsAlive == false && thread_finish == true)
                BANK_ROOT = XElement.Load(xmlLocalPath_bank);
        }

        private void SaveFiles()//save the files
        {
            try
            {
                SPECIALIZATION_ROOT.Save(specialization_path);
                CONTRACT_ROOT.Save(CONTRACT_path);
                EMPLOYEE_ROOT.Save(EMPLOYEE_path);
                EMPLOYER_ROOT.Save(EMPLOYER_path);
                BANK_ROOT.Save(xmlLocalPath_bank);
               
            }
            catch
            {
                throw new Exception("problem saving the files");
            }
        }
        #endregion
        
        #region object to Xelement 
        private XElement ConvertSpecialization(BE.specialization specialization)//convert objet specialization in XELEMENT
        {
            XElement newpecialization = new XElement("specialisation",
                new XElement("specialization_id", specialization.specialization_id),
                new XElement("discipline", specialization.discipline),
                new XElement("expertise", specialization.expertise),
                new XElement("minWage", specialization.minWage),
                new XElement("maxWage", specialization.maxWage)
                );

            return newpecialization;
        }

        private XElement ConvertCONTRACT(BE.contract C)//convert objet contract in XELEMENT
        {
            XElement newCONTRACT = new XElement("Contract",
                new XElement("contractID",C.contractID ),
                new XElement("employerID",C.employerID),
                new XElement("employeeID",C.employeeID ),
                new XElement("professionalID",C.professionalID ),
                new XElement("isSigned",C.isSigned ),
                new XElement("salaryBrute", C.salaryBrute),
                new XElement("salaryNet", C.salaryNet),
                new XElement("beginning", C.beginning),
                new XElement("end", C.end),
                new XElement("numHours",C.numHours ),
                new XElement("expertise", C.expertise),
                new XElement("city",C.city ),
                new XElement("commission",C.commission )
                );

            return newCONTRACT;
        }
        private XElement ConvertEmployee(BE.Employee employee)//convert objet employee in XELEMENT
        {
            XElement newemployee = new XElement("employee",                  
                  new XElement("lastname", employee.lastName),
                  new XElement("firstname", employee.firstName),
                  new XElement("birthdate", employee.birthDate),
                  new XElement("age", employee.age),
                  new XElement("ID", employee.ID),
                  new XElement("phone", employee.phone),
                  new XElement("degree",employee.degree),
                      new XElement("CODE-BANK", employee.bankdetails.bankNum),
                      new XElement("NAME-BANK", employee.bankdetails.bankName),
                      new XElement("CITY", employee.bankdetails.city),
                      new XElement("CODE-SNIF", employee.bankdetails.branchBank),
                      new XElement("ADDRESS-ATM", employee.bankdetails.adressBank)
                );

            return newemployee;
        }
        private XElement Convertemployer(BE.Employer employer)//convert objet employer in XELEMENT
        {
            XElement newemployer = new XElement("employer",
                new XElement("ID", employer.companyID),
            //  new XElement("company name", employer.companyName),
            
              new XElement("lastname", employer.lastName),
              new XElement("firstname", employer.firstName),
              new XElement("phone", employer.phone),
              new XElement("adresse", employer.adresse),
              new XElement("city", employer.city),

              //  new XElement("creation date", employer.creationDate),
                new XElement("discipline", employer.discipline),
               // new XElement("number employee", employer.numberEmployee),
                new XElement("private", employer.isPrivate)/* */
                );

            return newemployer;
        }
        private XElement ConvertBank(BE.bank bank) //convert objet bank in XELEMENT
        {
            XElement newbank = new XElement("bank",
                new XElement("BankNum", bank.bankNum),
                new XElement("BankName", bank.bankName), new XElement("City", bank.city),
                new XElement("Branch_Bank", bank.branchBank), new XElement("AdressBank", bank.adressBank),
                new XElement("AccountNum", bank.accountNum));
            return newbank;
        }
        #endregion

        #region convert Xelement to object 

        private BE.specialization ConvertSpecialization(XElement specialization)//convert an xelement to specialisation objet and return it
        {
            try
            {
                return new BE.specialization(
                    int.Parse(specialization.Element("specialization_id").Value),
                    (BE.discipline)(Enum.Parse(typeof(BE.discipline),specialization.Element("discipline").Value)),
                    (BE.expertise)(Enum.Parse(typeof(BE.expertise), specialization.Element("expertise").Value)),
                    double.Parse(specialization.Element("minWage").Value),
                    double.Parse(specialization.Element("maxWage").Value)

                    );

            }
            catch
            {
                throw new Exception("the object cold not be converted");
            }
            
        }


        private BE.contract ConvertCONTRACT(XElement c)//convert an xelement to contract objet and return it
        {
            try
            {
                return new BE.contract(
                   int.Parse(c.Element("contractID").Value),
                   int.Parse(c.Element("employerID").Value),
                   int.Parse(c.Element("employeeID").Value),
                   int.Parse(c.Element("professionalID").Value),
                   bool.Parse(c.Element("isSigned").Value),
                   double.Parse(c.Element("salaryBrute").Value),
                   double.Parse(c.Element("salaryNet").Value),
                   DateTime.Parse(c.Element("beginning").Value),
                   DateTime.Parse(c.Element("end").Value),
                   int.Parse(c.Element("numHours").Value),

                    (BE.expertise)(Enum.Parse(typeof(BE.expertise), c.Element("expertise").Value)),
                   c.Element("city").Value,
                    double.Parse(c.Element("commission").Value)

                    );

            }
            catch
            {
                throw new Exception("the object cold not be converted");
            }

        }
        private BE.Employee ConvertEmployee(XElement EMPLOYEE)//convert an xelement to employee objet and return it
        {
           
           try
            {

                return new Employee(
                    EMPLOYEE.Element("lastname").Value,
                    EMPLOYEE.Element("firstname").Value,
                    DateTime.Parse(EMPLOYEE.Element("birthdate").Value),
                    int.Parse(EMPLOYEE.Element("age").Value),
                    int.Parse(EMPLOYEE.Element("ID").Value),
                    int.Parse(EMPLOYEE.Element("phone").Value),
                     int.Parse(EMPLOYEE.Element("CODE-BANK").Value),
                     EMPLOYEE.Element("NAME-BANK").Value,
                      EMPLOYEE.Element("CITY").Value,
                       int.Parse(EMPLOYEE.Element("CODE-SNIF").Value),
                       EMPLOYEE.Element("ADDRESS-ATM").Value,
                       (BE.Degree)(Enum.Parse(typeof(BE.Degree), EMPLOYEE.Element("degree").Value))
                    );
             



            }
            catch
            {
                 throw new Exception("the object cold not be converted  ");               
            }

        }
        private BE.Employer ConvertEmployer(XElement EMPLOYER)//convert an xelement to employer objet and return it
        {
         
            try
            {
                    return new Employer(
                    int.Parse(EMPLOYER.Element("ID").Value),
                 //   EMPLOYER.Element("company name").Value,
                    EMPLOYER.Element("lastname").Value,
                    EMPLOYER.Element("firstname").Value,
                  //  EMPLOYER.Element("phone").Value,
                    int.Parse(EMPLOYER.Element("phone").Value),
                    EMPLOYER.Element("adresse").Value,
                    EMPLOYER.Element("city").Value,
                   // DateTime.Parse(EMPLOYER.Element("creation date").Value),
                    (BE.discipline)(Enum.Parse(typeof(BE.discipline), EMPLOYER.Element("discipline").Value)),
                  //  int.Parse(EMPLOYER.Element("number employee").Value),
                   bool.Parse(EMPLOYER.Element("private").Value)
                        
  
                    );  
    
            }
            catch
            {
               
                throw new Exception("the object cold not be converted");
            }

        }

        private BE.bank ConvertBank(XElement bank)//convert an xelement to bank objet and return it
        {
            try
            {
                return new BE.bank(
                    int.Parse(bank.Element("קוד_בנק").Value),
                    bank.Element("שם_בנק").Value.ToString(),
                    bank.Element("ישוב").Value.ToString(),
                    int.Parse(bank.Element("קוד_סניף").Value),
                    bank.Element("כתובת_ה-ATM").Value.ToString()
                    );
            }
            catch
            {
                throw new Exception("the object bank could not be converted");
            }
        }

        #endregion

        #region specialization
        public void addExpert(specialization e)//receive a specialization ,convert it in XELEMENT ,add in the files and save the file
        {
            if (e.minWage > e.maxWage)
                throw new Exception("the minwage is bigger than the maxwage");
            if (e.specialization_id == 0)
                throw new Exception("the specialization doesn't have a  id");
            else if(e.minWage==0)
                throw new Exception("the specialization doesn't have a min wage");
            else if (e.maxWage == 0)
                throw new Exception("the specialization doesn't have a max age");
            else if (seaurchID_existspecialization(e.specialization_id))
              throw new Exception("the specialization id :" + e.specialization_id + " doesn't exist");
            else 
            {
                SPECIALIZATION_ROOT.Add(ConvertSpecialization(e));//convert and add to the files
                SaveFiles();//save the files
            }
        }
        public void removeExpert(int id)//remove a specialization
        {
              if (seaurchID_existspecialization(id) == true)//verifie if their is a specialisation with this id
            {
                XElement expertid_delete = (from s in SPECIALIZATION_ROOT.Elements()//link to xml
                                         where s.Element("specialization_id").Value == id.ToString()
                                         select s).First();//select this xelement 
                expertid_delete.Remove();//remove from the files
                SaveFiles();  //save the files             
            }
           else throw new Exception("the specialization id :" + id + " doesn't exist");
        }
        public bool seaurchID_existspecialization(int ID)//verifie if exist the specialisation with this id
        {
            try
            {
                XElement expertid_xml = (from s in SPECIALIZATION_ROOT.Elements()//link to xml
                                         where s.Element("specialization_id").Value == ID.ToString()
                                         select s).First();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public void updateExpert(specialization e)//update the parameter of this specialisation
        {
            if (e.minWage > e.maxWage)
                throw new Exception("the minwage is bigger than the maxwage");
            if (e.specialization_id == 0)
                throw new Exception("the specialization doesn't have a  id");
            else if (e.minWage == 0)
                throw new Exception("the specialization doesn't have a min wage");
            else if (e.maxWage == 0)
                throw new Exception("the specialization doesn't have a max age");
            else if (seaurchID_existspecialization(e.specialization_id))//if the specialization exist
            {
                XElement ex = (from p in SPECIALIZATION_ROOT.Elements()//linq to xml
                               where Convert.ToInt32(p.Element("specialization_id").Value) == e.specialization_id
                               select p).FirstOrDefault();//select the XELEMENT 
                //change the value of this XELEMENT
                ex.Element("discipline").Value = e.discipline.ToString();
                ex.Element("expertise").Value = e.expertise.ToString();
                ex.Element("minWage").Value = e.minWage.ToString();
                ex.Element("maxWage").Value = e.maxWage.ToString();
                SPECIALIZATION_ROOT.Save(specialization_path);
            }
            else throw new Exception("the specialization id :" + e.specialization_id +" doesn't exist");

        }
     
        public specialization searchId_find_specialization(int ID)//return a specialization object
        {
            try
            {
                XElement expertid_xml = (from s in SPECIALIZATION_ROOT.Elements()//linq to xml
                                         where s.Element("specialization_id").Value == ID.ToString()
                                         select s).First();//select this xelement
                return ConvertSpecialization(expertid_xml);//convert to object specialisation and return it
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<specialization> Allspecialization()  //ienumerable of specialisation
        {
            return (from c in SPECIALIZATION_ROOT.Elements() select ConvertSpecialization(c)).ToList();//return the list of xelement 
        }

        #endregion

        #region contract

          public void addcontract(contract c)//add contract
        {
            Employee temp = searchId_find_employee(c.employeeID);
            Employer temp1 = searchId_find_employer(c.employerID);
            if (c.contractID == 0)
                throw new Exception("the specialization doesn't have a  id");
         
             else if (seaurchID_existcontract(c.contractID))
              throw new Exception("the specialization id :" + c.contractID + " exist");
          else if (seaurchID_existEmployer(c.contractID) == true)
               throw new NotImplementedException("EMPLOYER ID DOESN'T EXIST !!"); 
            else
            {
                CONTRACT_ROOT.Add(ConvertCONTRACT(c));//convert in xelement and add to the files
                SaveFiles();//save the files
            }
        }
        public IEnumerable<contract> Allcontract()//ienumerable of contract
        {
            return (from c in CONTRACT_ROOT.Elements() select ConvertCONTRACT(c)).ToList();//return the list of contract after convert it from xelement
        }

        public int get_number_Contract()//return number of contract
        {
            return (from c in CONTRACT_ROOT.Elements() select ConvertCONTRACT(c)).Count();//link to xml to count the number of contract after convert it from xelement
        }

        public void removecontract(contract c)//remove a contract
        {
            
            if (seaurchID_existcontract(c.contractID))//verifie if a contract exist with this id
            {

                XElement contrat_delete = (from s in CONTRACT_ROOT.Elements()
                                            where s.Element("contractID").Value == c.contractID.ToString()
                                            select s).First();//select this XELEMENT
                contrat_delete.Remove();//remove from the xml file
                SaveFiles();           //save the files
            }
            else
                throw new NotImplementedException("id doesn't exist");
        }

        public contract searchId_contract_find(int ID)//return a contract
        {
            try
            {
                XElement c_xml = (from s in CONTRACT_ROOT.Elements()
                                         where s.Element("contractID").Value == ID.ToString()
                                         select s).First();//select this xelement
                return ConvertCONTRACT(c_xml);//convert it to objet and return it
            }
            catch
            {
                return null;
            }
        }
        public bool seaurchID_existcontract(int ID)//verifie if the contract exist
        {
            try
            {
                XElement contrat_xml = (from s in CONTRACT_ROOT.Elements()
                                         where s.Element("contractID").Value == ID.ToString()
                                         select s).First();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public void uptdatecontract(contract c)//update the contract
        {

            if (seaurchID_existcontract(c.contractID))//verifie if exist
            {
                XElement ct = (from p in CONTRACT_ROOT.Elements()
                               where Convert.ToInt32(p.Element("contractID").Value) == c.contractID
                               select p).FirstOrDefault();//select the xelement 
                //change the value of this xelement
                ct.Element("employerID").Value = c.employerID.ToString();
                ct.Element("employeeID").Value = c.employeeID.ToString();
                ct.Element("professionalID").Value = c.professionalID.ToString();
                ct.Element("isSigned").Value = c.isSigned.ToString();
                ct.Element("salaryBrute").Value = c.salaryBrute.ToString();
                ct.Element("salaryNet").Value = c.salaryNet.ToString();
                ct.Element("beginning").Value = c.beginning.ToString();
                ct.Element("end").Value = c.end.ToString();
                ct.Element("numHours").Value = c.numHours.ToString();
                ct.Element("expertise").Value = c.expertise.ToString();
                ct.Element("city").Value = c.city;
                ct.Element("commission").Value = c.commission.ToString();
                CONTRACT_ROOT.Save(CONTRACT_path);//save it
            }
            else
                throw new NotImplementedException("id doesn't exist");

        }
        #endregion

        #region EMPLOYEE
        public void addEmployee(Employee e)//add employee
        {          
             if (e.ID == 0)
                throw new Exception("the employee doesnt have an ID");
            else if (e.phone == 0)
                throw new Exception("their is no phone number");
            else if (seaurchID_existEmployee(e.ID) == false)//verifie if exist
            {
                EMPLOYEE_ROOT.Add(ConvertEmployee(e));//convert in xelement and add to the files
                SaveFiles();//save the files
            }
            else
                throw new Exception("the employee id :" + e.ID + " still exist");
        }

        public void removeEmployee(Employee P)//remove xelement
        {
            int ID = P.ID;
            if (seaurchID_existEmployee(ID))//verrifie if exist
            {

                XElement employee_delete = (from e in EMPLOYEE_ROOT.Elements()
                                            where e.Element("ID").Value == ID.ToString()
                                            select e).First();//select it
                employee_delete.Remove();//remove
                SaveFiles();//save

            }
            else
                throw new Exception("the employee id :" + P.ID + " doesn't exist");
        }

        public void uptdateEmployee(Employee e)//update
        {
         
            if (e.ID == 0)
                throw new Exception("the specialization doesn't have a min wage");
            else if (e.phone == 0)
                throw new Exception("their is no phone number");
            if (seaurchID_existEmployee(e.ID))//verifie if exist
            {
                XElement employe = (from p in EMPLOYEE_ROOT.Elements()
                                       where Convert.ToInt32(p.Element("ID").Value) == e.ID
                                       select p).FirstOrDefault();// select the xelement

            //change the value
                employe.Element("lastname").Value = e.lastName;
                employe.Element("firstname").Value = e.firstName;
                employe.Element("birthdate").Value = e.birthDate.ToString();
                employe.Element("age").Value = e.age.ToString();
                employe.Element("phone").Value = e.phone.ToString();
                employe.Element("CODE-BANK").Value = e.bankdetails.bankNum.ToString();
                employe.Element("NAME-BANK").Value = e.bankdetails.bankName.ToString();
                employe.Element("CITY").Value = e.bankdetails.city.ToString();
                employe.Element("CODE-SNIF").Value = e.bankdetails.branchBank.ToString();
                employe.Element("ADDRESS-ATM").Value = e.bankdetails.adressBank.ToString();
                EMPLOYEE_ROOT.Save(EMPLOYEE_path);//save in the file
            }
            else throw new Exception("the  id :" + e.ID + " doesn't exist");
        }

        public IEnumerable<Employee> AllEmployee()//ienumerable of employee
        {
            return (from c in EMPLOYEE_ROOT.Elements() select ConvertEmployee(c)).ToList();    //return the list of employee        
        }

        public bool seaurchID_existEmployee(int ID)//verifie if the xelement exist
        {
            try
            {
                XElement employee_xml = (from e in EMPLOYEE_ROOT.Elements()
                                         where e.Element("ID").Value == ID.ToString()
                                         select e).First();//select it
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Employee searchId_find_employee(int ID)//return employee
        {
            try
            {
                XElement employee_xml = (from e in EMPLOYEE_ROOT.Elements()
                                         where e.Element("ID").Value == ID.ToString()
                                         select e).First();//select the xelement
                return ConvertEmployee(employee_xml);//convert to employee and return it
            }
            catch
            {
                return null;
            }
        }


        #endregion

        #region EMPLOYER
        public void addEmployer(Employer e)//add employer
        {

            if (e.companyID == 0)
                throw new Exception("the specialization doesn't have a min wage");
            else if (e.lastName.Length == 0)
                throw new Exception("their is no last name");
            else if (e.firstName.Length == 0)
                throw new Exception("their is no first name");
          
            else if (e.phone == 0)
                throw new Exception("their is no phone number");
            else if (seaurchID_existEmployer(e.companyID)== false)//verifie if exist
            {
                EMPLOYER_ROOT.Add(Convertemployer(e));//convert and add to the files
                SaveFiles();//save files
            }
            else
                throw new Exception("the company id :" + e.companyID + " still exist");
        }

        public void removeEmployer(Employer P)//remove xelement
        {
            int ID = P.companyID;
            if (seaurchID_existEmployer(ID) == true)//verifie if exist
            {

                XElement employer_delete = (from e in EMPLOYER_ROOT.Elements()
                                            where e.Element("ID").Value == ID.ToString()
                                            select e).First();//select the xelement 
                employer_delete.Remove();//remove
                SaveFiles();//save

            }
            else throw new Exception("the company id :" +  P.companyID + " doesn't exist");

        }

        public void uptdateEmployer(Employer e)//update 
        {
             if (e.companyID == 0)
                throw new Exception("the specialization doesn't have a min wage");
            else if (e.lastName.Length == 0)
                throw new Exception("their is no last name");
            else if (e.firstName.Length == 0)
                throw new Exception("their is no first name");           
            else if (e.phone == 0)
                throw new Exception("their is no phone number");
            else if (seaurchID_existEmployer(e.companyID))//verifie if exist
            {
                XElement ex = (from p in EMPLOYER_ROOT.Elements()
                               where Convert.ToInt32(p.Element("ID").Value) == e.companyID
                               select p).FirstOrDefault();//select the xelement
                //change the value
                ex.Element("lastname").Value = e.lastName;
                ex.Element("firstname").Value = e.firstName;
                ex.Element("phone").Value = e.phone.ToString();
                ex.Element("adresse").Value = e.adresse;
                ex.Element("city").Value = e.city;
                ex.Element("discipline").Value = e.discipline.ToString();
                ex.Element("private").Value = e.isPrivate.ToString();
                EMPLOYER_ROOT.Save(EMPLOYER_path);//save 
            }
            else throw new Exception("the  company id :" + e.companyID + " doesn't exist");
        }

        public IEnumerable<Employer> AllEmployer()//ienumerable of employer
        {
            return (from e in EMPLOYER_ROOT.Elements() select ConvertEmployer(e)).ToList();    //return the list of employer       
        }

        public Employer searchId_find_employer(int ID)//return an employer
        {
            try
            {
                XElement employer_xml = (from e in EMPLOYER_ROOT.Elements()
                                         where e.Element("ID").Value == ID.ToString()
                                         select e).First();//select the xelement
                return ConvertEmployer(employer_xml);//convert to employer and return it
            }
            catch
            {
                return null;
            }
        }

        public bool seaurchID_existEmployer(int ID)//verifie if the xelement exist
        {
            try
            {
                XElement employer_xml = (from e in EMPLOYER_ROOT.Elements()
                                         where e.Element("ID").Value == ID.ToString()
                                         select e).First();
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion

        #region BANK
        public IEnumerable<bank> Allbank()
        {
            return (from c in BANK_ROOT.Elements() select ConvertBank(c)).ToList();
        }

        public IEnumerable<int> return_code_bank()
        {
            var v = from item in Allbank()
                    select item.bankNum;
            List<int> newList = new List<int>();
            foreach (int item in v)
            {
                if (newList.Contains(item) == false)
                {
                    newList.Add(item);
                }
            }
            return newList;
        }

        public IEnumerable<string> return_nom_bank(string y)
        {
            var v = from item in Allbank()
                    where item.city == y
                    select item.bankName;
            List<string> newList = new List<string>();
            foreach (string item in v)
            {
                if (newList.Contains(item) == false)
                {
                    newList.Add(item);
                }
            }
            return newList;
        }

        public IEnumerable<string> returnyeshouv()
        {
            if (thread_finish == true)
            {
                loadFIles();
                var v = from item in Allbank()
                        select item.city;
                List<string> newList = new List<string>();
                foreach (string item in v)
                {
                    if (newList.Contains(item) == false)
                    {
                        newList.Add(item);
                    }
                }
                return newList;
            }
            else return null;
        }

        public IEnumerable<int> return_code_snif()
        {
            var v = from item in Allbank()
                    select item.bankNum;
            List<int> newList = new List<int>();
            foreach (int item in v)
            {
                if (newList.Contains(item) == false)
                {
                    newList.Add(item);
                }
            }
            return newList;
        }

        public IEnumerable<string> return_nom_address_atm(string y, string b)
        {
            var v = from item in Allbank()
                    where item.city == y && item.bankName == b
                    select item.adressBank;
            List<string> newList = new List<string>();
            foreach (string item in v)
            {
                if (newList.Contains(item) == false)
                {
                    newList.Add(item);
                }
            }
            return newList;

        }

        public void threa_isalive()// To update a specialization
        {

            try
            {
                BANK_ROOT = XElement.Load(xmlLocalPath_bank);
                thread_finish = true;
            }
            catch
            {
                throw new Exception("the bank doesn't finish to download");
            }
        }
        #endregion




    }
}

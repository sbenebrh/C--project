using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Employer
    {
        //parameters
        public int companyID { get; set; }
        public bool isPrivate { get; set; }      
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string companyName { get; set; }
        public int phone { get; set; }
        public string adresse { get; set; }
        public discipline discipline { get; set; }
        public DateTime creationDate { get; set; }
        public int numberEmployee { get; set; }
        public string city { get; set; }
        public city villes { get; set; }

        public Employer() { }//ctor
        public Employer(int id = 0,  string lastName_ = null, string firstname_ = null, int phone1 = 0, string adresse_ = null, string city_ = null, discipline d = 0, bool isprivate = false)//ctor with parameters
        {


            companyID = id;
           // companyName = companyName_;
            lastName = lastName_;
            firstName = firstname_;
            phone = phone1;
            adresse = adresse_;
            city = city_;
           // creationDate = creation;
            discipline = d;
           // numberEmployee = employeenum;

            isPrivate = isprivate;

        }


        
        //to string
            public override string ToString()
        {
            string res = "employer Details: \n";
            res += "--------------------\n";
            res += this.ToStringProperties();
            return res;
        }

    
    }
}


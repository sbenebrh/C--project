using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Employee
    {

        //parameters
        public int ID { get; set; }
        public int age { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public DateTime birthDate { get; set; }
        public int phone { get; set; }
        public string adress { get; set; }
        public Degree degree { get; set; }
        public bool veteran { get; set; }
        public bank bankdetails { get; set; }
        public specialization specialite { get; set; }
        public int experience { get; set; }
        //  public string recommendation { get; set; }
        //  public int mispar_iskote { get; set; }

        public Employee() { }//ctor 
        public Employee(string lastname_ = null, string value2 = null, DateTime dateTime = default(DateTime), int v1 = 0, int v2 = 0, int v3 = 0,  int B_NUM = 0 , string B_NAME= null, string CITY = null,int B_BRANCHS = 0 , string B_aDDRESS = null,Degree d =0)// with parameters
        {
            bankdetails = new bank();
            this.lastName = lastname_;
            this.firstName = value2;
            this.birthDate = dateTime;
            this.age = v1;
            this.ID = v2;
            this.phone = v3;
            bankdetails.bankNum = B_NUM;
            bankdetails.bankName = B_NAME;
            bankdetails.city = CITY;
            bankdetails.branchBank = B_BRANCHS;
            bankdetails.adressBank = B_aDDRESS;
            degree = d;
        }
        //tostring
        public override string ToString()
        {
            string res = "employee Details: \n";
            res += "--------------------\n";
            res += this.ToStringProperties();
            return res;
        }

    }
}

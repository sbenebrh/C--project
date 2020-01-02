using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class contract
    {
        //parameter with properties get set
        public int contractID { get; set; } 
        public int employerID { get; set; }
        public int employeeID { get; set; }
        public int professionalID { get; set; }
        public bool isSigned { get; set; }
        public double salaryBrute { get; set; }
        public double salaryNet { get; set; }
        public DateTime beginning { get; set; }
        public DateTime end { get; set; }
        public int numHours { get; set; }
        public expertise expertise { get; set; }
        public string city { get; set; }
        public double commission { get; set; }

        public contract() { }//ctor
       public  contract (int contractID_=0 ,int employerID_=0 , int employeeID_=0 ,int professionalID_=0 ,bool isSigned_= false  ,
           double salaryBrute_=0 ,double salaryNet_ =0, DateTime dt = default(DateTime), DateTime end_ = default(DateTime), int  numHours_=0 ,expertise  e_= expertise.ALGO_INGINEER,
           string city_= null , double commission_=0 )//ctor with parameter because of xml field
        {
            contractID = contractID_;
            employerID = employerID_;
            employeeID = employeeID_;
            professionalID = professionalID_;
            isSigned = isSigned_;
            salaryBrute = salaryBrute_;
            salaryNet = salaryNet_;
            beginning = dt;
            end = end_;
            numHours = numHours_;
            expertise = e_;
            city = city_;
           commission = commission_;

    }
        //to string
        public override string ToString()
        {
            string res = "contract Details: \n";
            res += "--------------------\n";
            res += this.ToStringProperties();
            return res;
        }
    }
}

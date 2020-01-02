using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{              // class bank
    public class bank
    {
        //parameter
        public int bankNum { get; set; } // CodeBank
        public string bankName { get; set; }
        public string city { get; set; }
        public int branchBank { get; set; }
        public string adressBank { get; set; }
        public int accountNum { get; set; }

        public bank() { }//ctor
        public bank(int my_bankNum = 0, string my_bankName = "", string my_city = "", int my_branchBank = 0, string my_adressBank = "")//ctor with parameter
        {
            bankNum = my_bankNum;
            bankName = my_bankName;
            city = my_city;
            branchBank = my_branchBank;
            adressBank = my_adressBank;
          //  accountNum = my_accountNum;
        }
        //totring
        public override string ToString()
        {
            string res = "bank Details:\n";
            res += this.ToStringProperties();
            return res;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BL;
using BE;
namespace PL_UI2
{
    /// <summary>
    /// Logique d'interaction pour grouping_expert.xaml
    /// </summary>
    public partial class grouping_expert : Window
    {
        BL.IBL bl;
        contract c = new contract();
       
        public grouping_expert(int k)//ctor
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
          
        }
        private void expert_Click(object sender, RoutedEventArgs e)//datagrid contract
        {

            DataGrid_s.ItemsSource = null;
            DataGrid_s.ItemsSource = bl.Allcontract();
        }

        private void city_Click(object sender, RoutedEventArgs e)//grouping by city
        {
            DataGrid_s.ItemsSource = null;
            DataGrid_s.ItemsSource = DataGrid_s.ItemsSource = from a in bl.Grouping_city()
                                                              select new
                                                              {
                                                                  city = a.First(),
                                                              };

        }


        private void date_Click(object sender, RoutedEventArgs e)//linq for employee without contract
        {
            DataGrid_s.ItemsSource = null;
            DataGrid_s.ItemsSource = DataGrid_s.ItemsSource = from a in bl.AllEmployee()
                                                              where bl.AllCONTRACT_TO_employee(a.ID).Count() == 0
                                                              select new
                                                              {
                                                                  NAME = a.firstName,
                                                                  ID_EMPLOYEE = a.ID,
                                                                  CITY = a.bankdetails.city,
                                                                  BANKNAME = a.bankdetails.bankName,
                                                                  ADDRRESS = a.bankdetails.adressBank,
                                                                  BRANCH = a.bankdetails.branchBank,
                                                              };

            //bl.AllEmployee_condition(x => bl.AllCONTRACT_TO_employee(x.ID).Count() == 0);

        }

        private void age_Click(object sender, RoutedEventArgs e)//employee more than 50
        {

            DataGrid_s.ItemsSource = null;
            DataGrid_s.ItemsSource = /*from a in bl.AllEmployee() 
                                     select new
                                     {
                                         age = a.age,
                                         name = a.firstName + a.lastName,
                                         Salaire = a.phone,
        };*/
        bl.AllEmployee_condition(x => x.age>50 );
        }

        private void branch_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_s.ItemsSource = null;
            DataGrid_s.ItemsSource = from a in bl.Allcontract() select new {ID_contract = a.contractID ,salaire_brute = a.salaryBrute,
                salaire_net = a.salaryNet ,hevah = a.salaryBrute-a.salaryNet };
        }

        private void menu_Click(object sender, RoutedEventArgs e)//cloe
        {
            this.Close();
        }

        private void branch_Copy_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_s.ItemsSource = from a in bl.AllEmployee()
                                     select new
                                     {
                                         NAME = a.firstName,
                                         ID_EMPLOYEE= a.ID ,
                                         CITY= a.bankdetails.city,
                                         BANKNAME = a.bankdetails.bankName,
                                         ADDRRESS= a.bankdetails.adressBank,
                                         BRANCH= a.bankdetails.branchBank,
                                     };
        }
    }
}

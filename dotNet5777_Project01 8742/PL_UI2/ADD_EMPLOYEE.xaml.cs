using BE;
using System;
using System.Collections.Generic;
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

namespace PL_UI2
{

    public partial class ADD_EMPLOYEE : Window
    {
        BE.Employee employee;
        BE.bank BANK;
        BL.IBL bl;
        public ADD_EMPLOYEE(BL.IBL Bl)//ctor
        {
            this.bl = Bl;
            InitializeComponent();
            employee = new BE.Employee();
            BANK = new bank();
            this.DataContext = employee;
            bl = BL.FactoryBL.GetBL();
            showDataGridView();
            this.degreeComboBox.ItemsSource = Enum.GetValues(typeof(BE.Degree));
            comboboxyeshouv();

        }
        private void comboboxyeshouv()
        {

            try
            {
                bl.threa_isalive();
                if (bl.returnyeshouv() == null)
                {
                    MessageBox.Show("bank doesn't downloaded");
                }
                else foreach (string id in bl.returnyeshouv())
                    {
                        cityComboBox.Items.Add(id);
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("bank doesn't downloaded");
            }

        }
        private void showDataGridView()//show datagrid
        {
         
            try
            {

                DataGrid_s.ItemsSource = null;
                DataGrid_s.ItemsSource = bl.AllEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            int branch;
            int bank_n;
            try
            {
                BANK.city = cityComboBox.SelectedItem.ToString();
                BANK.bankName = bankNameComboBox.SelectedItem.ToString();
                BANK.adressBank = adressBankComboBox.SelectedItem.ToString();
                int.TryParse(branchBankComboBox.SelectedItem.ToString(),out branch);
                int.TryParse(banknum.Text, out bank_n);
                BANK.branchBank = branch;
                BANK.bankNum = bank_n;
                employee.bankdetails = BANK;
                bl.addEmployee(employee);               
                employee = new BE.Employee();              
                banknum.Text = null;
                branchBankComboBox.SelectedItem = null;
                adressBankComboBox.SelectedItem = null;
                bankNameComboBox.SelectedItem = null;
                cityComboBox.SelectedItem = null;
                this.DataContext = employee;
                showDataGridView();                          
            }
            catch (Exception ex)
            {
                showDataGridView();
                MessageBox.Show(ex.Message);
            }
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)//close 
        {
            this.Close();
        }

  

        private void cityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)//if selection has changed
        {

            if (cityComboBox.SelectedItem != null)
            {
                bankNameComboBox.Items.Clear();
                foreach (string id in bl.return_nom_bank(cityComboBox.SelectedItem.ToString()))//affiche le combobox d apres
                {
                    bankNameComboBox.Items.Add(id);
                }
            }
        }

        private void bankNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)//if selection has changed
        {
            if (bankNameComboBox.SelectedItem != null)
            {
                adressBankComboBox.Items.Clear();
                foreach (string id in bl.return_nom_address_atm(cityComboBox.SelectedItem.ToString(), bankNameComboBox.SelectedItem.ToString()))
                {
                    adressBankComboBox.Items.Add(id);//affiche le combobox d apres
                }
            }
        }

 
        private void adressBankComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)//if selection has changed
        {
            if (adressBankComboBox.SelectedItem != null)
            {
                branchBankComboBox.Items.Clear();
                foreach (int id in bl.return_code_snif())
                {
                    branchBankComboBox.Items.Add(id);//affiche le combobox d apres
                }
            }
        }

     
    }
}

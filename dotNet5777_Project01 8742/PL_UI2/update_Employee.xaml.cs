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

namespace PL_UI2
{
    /// <summary>
    /// Logique d'interaction pour update_Employee.xaml
    /// </summary>
    public partial class update_Employee : Window
    {
        BE.Employee employee;
        BE.bank BANK;
        BL.IBL bl;
        public update_Employee(BL.IBL Bl)//ctor
        {
            this.bl = Bl;
            InitializeComponent();
            employee = new BE.Employee();
            BANK = new bank();
            this.DataContext = employee;

            bl = BL.FactoryBL.GetBL();
            showDataGridView();
            foreach (int id in bl.return_names_id_employee())
            {
                comboBox.Items.Add(id);
            }
            this.degreeComboBox.ItemsSource = Enum.GetValues(typeof(BE.Degree));
            comboboxyeshouv();
        }
        private void showDataGridView()
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
        private void addButton_Click(object sender, RoutedEventArgs e)//update
        {
            int ID;
            int branch;
            int bank_n;
            DateTime d = DateTime.Today;
            DateTime birth_day = employee.birthDate;
            TimeSpan Age = d - birth_day;
            int a = Age.Days / 365;
            try
            {
                employee.age = a;
                if (employee.age < 18)
                    throw new Exception("not possibility to add employee Under 18 years");
                int.TryParse(comboBox.SelectedItem.ToString(), out ID);
                BANK.city = cityComboBox.SelectedItem.ToString();
                BANK.bankName = bankNameComboBox.SelectedItem.ToString();
                BANK.adressBank = adressBankComboBox.SelectedItem.ToString();
                int.TryParse(branchBankComboBox.SelectedItem.ToString(), out branch);
                int.TryParse(bankNumTextBox.Text, out bank_n);
                BANK.branchBank = branch;
                BANK.bankNum = bank_n;
                employee.bankdetails = BANK;
                employee.ID = ID;
                bl.uptdateEmployee(employee);
                employee = new BE.Employee();
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

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)//update
        {
            int ID;
            int.TryParse(comboBox.SelectedItem.ToString(), out ID);
            employee = bl.return_emploee(ID);
            this.DataContext = employee;
            showDataGridView();
        }

        private void REMOVE_Click(object sender, RoutedEventArgs e)//remove
        {
            int ID;
            try
            {
                MessageBoxResult result = MessageBox.Show("You really want to delete this employee", "Warning", MessageBoxButton.YesNoCancel,
           MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        {
                            int.TryParse(comboBox.SelectedItem.ToString(), out ID);
                            if (bl.AllCONTRACT_TO_employee(ID).Count() != 0)//verifie if he has a contract
                                throw new Exception("this employee has got a contract");
                            bl.removeEmployee(ID);
                            showDataGridView();
                            break;
                        }
                    case MessageBoxResult.No:
                        break;
                }
          
            }
            catch (Exception ex)
            {
                showDataGridView();
                MessageBox.Show(ex.Message);
            }
        }

        private void cityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cityComboBox.SelectedItem != null)
            {
                bankNameComboBox.Items.Clear();
                foreach (string id in bl.return_nom_bank(cityComboBox.SelectedItem.ToString()))
                {
                    bankNameComboBox.Items.Add(id);
                }
            }
        }

        private void bankNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bankNameComboBox.SelectedItem != null)
            {
                adressBankComboBox.Items.Clear();
                foreach (string id in bl.return_nom_address_atm(cityComboBox.SelectedItem.ToString(), bankNameComboBox.SelectedItem.ToString()))
                {
                    adressBankComboBox.Items.Add(id);
                }
            }
        }


        private void adressBankComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (adressBankComboBox.SelectedItem != null)
            {
                branchBankComboBox.Items.Clear();
                foreach (int id in bl.return_code_snif())
                {
                    branchBankComboBox.Items.Add(id);
                }
            }
        }

        private void branchBankComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

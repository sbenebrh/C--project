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
    /// Logique d'interaction pour update_employer.xaml
    /// </summary>
    public partial class update_employer : Window
    {

        BE.Employer employer;
        BL.IBL bl;
        public update_employer(BL.IBL Bl)
        {
            this.bl = Bl;
            InitializeComponent();
            employer = new BE.Employer();
            this.DataContext = employer;

            bl = BL.FactoryBL.GetBL();
            showDataGridView();
            this.disciplineComboBox.ItemsSource = Enum.GetValues(typeof(BE.discipline));
            foreach (int id in bl.return_names_id_employer())
            {
                comboBox.Items.Add(id);
            }
            this.comboBox_city.ItemsSource = Enum.GetValues(typeof(BE.city));
        }
        private void showDataGridView()
        {
            try
            {
                DataGrid_s.ItemsSource = null;
                DataGrid_s.ItemsSource = bl.AllEmployer();

            }
            catch (Exception)
            {
                MessageBox.Show("שגיאה", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            int ID;
            int.TryParse(comboBox.SelectedItem.ToString(), out ID);
            try
            {
                employer.city = comboBox_city.SelectedValue.ToString();
                employer.companyID = ID;
                bl.uptdateEmployer(employer);
                employer = new BE.Employer();
                this.DataContext = employer;
                showDataGridView();
            }
            catch (Exception ex)
            {
                showDataGridView();
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ID; 
            int.TryParse(comboBox.SelectedItem.ToString(), out ID);
            employer = bl.searchId_find_employer(ID);
            
            this.DataContext = employer;
            comboBox_city.SelectedItem = employer.city;
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            int Employer_ID;
            try
            {
             MessageBoxResult result = MessageBox.Show("You really want to delete this employer", "Warning", MessageBoxButton.YesNoCancel,
             MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        {
                            int.TryParse(comboBox.SelectedItem.ToString(), out Employer_ID);
                            if (bl.AllCONTRACT_TO_EMPLOYER(Employer_ID).Count() != 0)
                                throw new Exception("this employer has got a contract with an employee you cant remove it");//verifie if the employer has got a contrat with an employee
                            bl.removeEmployer(Employer_ID);
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
    }
}

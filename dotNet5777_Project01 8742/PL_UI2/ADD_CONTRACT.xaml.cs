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
using BE;

namespace PL_UI2
{
    /// <summary>
    /// Logique d'interaction pour ADD_CONTRACT.xaml
    /// </summary>
    public partial class ADD_CONTRACT : Window
    {

       // BE.Employer employer;
        BL.IBL bl;
        BE.contract contrat;
      
       public ADD_CONTRACT(BL.IBL Bl)//ctor
        {
            this.bl = Bl;
            InitializeComponent();  
            contrat = new BE.contract();
            this.DataContext = contrat;
            bl = BL.FactoryBL.GetBL();
            showDataGridView();
            this.expertiseComboBox.ItemsSource = Enum.GetValues(typeof(BE.expertise));         
            contrat.beginning = DateTime.Now;
            contrat.end = DateTime.Now;
            foreach (int id in bl.return_names_id_employer())
            {
                comboBox.Items.Add(id);
            }
            foreach (int id in bl.return_names_id_employee())
            {
                comboBox_Copy.Items.Add(id);
            }
            this.comboBox_city.ItemsSource = Enum.GetValues(typeof(BE.city));
        }
        private void showDataGridView()//show all contract
        {
            try
            {
                DataGrid_s.ItemsSource = null;
                DataGrid_s.ItemsSource = bl.Allcontract();

            }
            catch (Exception)
            {
                MessageBox.Show("שגיאה", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int id_e;
            try
            {
                TimeSpan t = contrat.beginning - contrat.end;

                if (t.Days > 0)//error in date contract
                    throw new Exception("error date end before date begining");

                if (comboBox_city.SelectedValue == null && comboBox_Copy.SelectedValue == null && comboBox.SelectedValue == null && expertiseComboBox.SelectedValue == null)//field empty
                    throw new Exception("you don't have select a combobox");
                if (contrat.contractID != 0 &&  contrat.numHours!=0  && contrat.professionalID!=0 && contrat.salaryBrute!=0)
                {
                    contrat.city = comboBox_city.SelectedItem.ToString();
                    int.TryParse(comboBox_Copy.SelectedItem.ToString(),out id_e);
                    contrat.employeeID = id_e;
                    int.TryParse(comboBox.SelectedItem.ToString(), out id);
                    contrat.employerID = id;
                    bl.addcontract(contrat);
                    contrat = new BE.contract();
                    this.DataContext = contrat;
                    showDataGridView();
                }
                else throw new Exception(" impossible to enter 0  !!");
    
            }
            catch (Exception ex)
            {
                showDataGridView();
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//close the page
        {
            this.Close();
        }

        

    }
}

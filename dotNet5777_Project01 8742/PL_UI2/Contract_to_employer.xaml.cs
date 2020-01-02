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
    /// Interaction logic for Contract_to_employer.xaml
    /// </summary>
    public partial class Contract_to_employer : Window
    {
        BL.IBL bl;
        public Contract_to_employer()//ctor
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();

            foreach (int id in bl.return_names_id_employer())//add item into the combobox
            {
                comboBox_1.Items.Add(id);
            }
            foreach (int id in bl.return_names_id_employee())//add item into the combobox
            {
                comboBox_1_Copy.Items.Add(id);
            }

        }
        private void showDataGridView(int i, int id)//datagrid
        {          
            try
            {
                DataGrid_s.ItemsSource = null;
                if (i==1)
                {
                    var v = from n in bl.Allcontract()
                            where n.employeeID == id
                            select n;
                    DataGrid_s.ItemsSource = v;
                } 
                else if (i==2)
                    DataGrid_s.ItemsSource = bl.AllCONTRACT_TO_EMPLOYER(id);
            }
            catch (Exception)
            {
                MessageBox.Show("שגיאה", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void comboBox_1_SelectionChanged(object sender, SelectionChangedEventArgs e)//selection has changed
        {
            int k;
            string i = comboBox_1.SelectedValue.ToString();
            Int32.TryParse(i, out k);
            showDataGridView(2,k);
        }

        private void menu_Click(object sender, RoutedEventArgs e)//close
        {
            this.Close();
        }

        private void comboBox_1_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)//selection has changed
        {
            int k;
            string i = comboBox_1_Copy.SelectedValue.ToString();
            Int32.TryParse(i, out k);
            showDataGridView(1,k);
        }
    }
}

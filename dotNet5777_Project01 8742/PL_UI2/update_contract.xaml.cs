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
    /// Logique d'interaction pour update_contract.xaml
    /// </summary>
    public partial class update_contract : Window
    {
        // BE.Employer employer;
        BL.IBL bl;
        BE.contract contrat;

        public update_contract(BL.IBL Bl)
        {
            this.bl = Bl;
            InitializeComponent();
            //   employer = new Employer();
            //    this.DataContext = contr;

            contrat = new BE.contract();
            this.DataContext = contrat;
            bl = BL.FactoryBL.GetBL();
            showDataGridView();
            this.expertiseComboBox.ItemsSource = Enum.GetValues(typeof(BE.expertise));
            foreach (int id in bl.return_names_id_contract())
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
                DataGrid_s.ItemsSource = bl.Allcontract();

            }
            catch (Exception)
            {
                MessageBox.Show("שגיאה", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int ID;
            try
            {
                if (comboBox.SelectedValue == null)
                    throw new Exception("you don't have select a ID contract");
                int.TryParse(comboBox.SelectedItem.ToString(), out ID);
                contrat.city = comboBox_city.SelectedItem.ToString();
                contrat.contractID = ID;
                bl.uptdatecontract(contrat);
                contrat = new BE.contract();
                this.DataContext = contrat;
                showDataGridView();
            }
            catch (Exception ex)
            {
                showDataGridView();
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ID;

            int.TryParse(comboBox.SelectedItem.ToString(), out ID);
            contrat = bl.return_contrat(ID);
            this.DataContext = contrat;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int ID;
            TimeSpan t = contrat.beginning - contrat.end;
            int time = t.Days / 365;
            try
            {
                if (comboBox.SelectedValue == null)
                    throw new Exception("you don't have select a ID contract");
                MessageBoxResult result = MessageBox.Show("You really want to delete this contract", 
                    "Warning",
                    MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question);
                
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        {
                            int.TryParse(comboBox.SelectedItem.ToString(), out ID);
                            bl.removecontract(ID);
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

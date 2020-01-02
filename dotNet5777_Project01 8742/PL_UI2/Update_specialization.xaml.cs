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
    /// Logique d'interaction pour Update_specialization.xaml
    /// </summary>
    public partial class Update_specialization : Window
    {
        BE.specialization expert;
        BL.IBL bl;
        public Update_specialization()
        {
            InitializeComponent();
            expert = new BE.specialization();
            this.DataContext = expert;
            bl = BL.FactoryBL.GetBL();
            this.expertiseComboBox.ItemsSource = Enum.GetValues(typeof(BE.expertise));
            this.disciplineComboBox.ItemsSource = Enum.GetValues(typeof(BE.discipline));
            showDataGridView();
            COMBO_bOX();
        }

        private void COMBO_bOX()
        {
            foreach (int id in bl.return_names_id_specialization())
            {
                comboBox.Items.Add(id);
            }           
        }
        private void showDataGridView()
        {
            try
            {
                DataGrid_s.ItemsSource = null;
                DataGrid_s.ItemsSource = bl.Allspecialization();
            }
            catch (Exception)
            {
                MessageBox.Show("שגיאה", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            int ID;
            //int.TryParse(comboBox.SelectedItem.ToString(), out ID);
            try
            {
                if (expert.maxWage < expert.minWage)
                    throw new Exception("the wage is not smaller than max");
                int.TryParse(comboBox.SelectedItem.ToString(), out ID);
                expert.specialization_id = ID;
                bl.updateExpert(expert);
                expert = new BE.specialization();
                this.DataContext = expert;
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
            expert = bl.return_expert(ID);
            this.DataContext = expert;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int ID;
            try
            {
                MessageBoxResult result = MessageBox.Show("You really want to delete this specialization", "Warning", MessageBoxButton.YesNoCancel,
              MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        {
                            int.TryParse(comboBox.SelectedItem.ToString(), out ID);
                            bl.removeExpert(ID);
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

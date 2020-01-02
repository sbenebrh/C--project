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
using DAL;

namespace PL_UI2
{
    /// <summary>
    /// Logique d'interaction pour Window_specialization.xaml
    /// </summary>
    public partial class Window_specialization : Window 
    {
        BL.IBL bl;
        BE.specialization specialiste;

        public Window_specialization(BL.IBL bl)//ctor
        {         
            this.bl = bl;
            InitializeComponent();
            specialiste = new BE.specialization();
            this.DataContext = specialiste;
            bl = BL.FactoryBL.GetBL();
            showDataGridView();
            this.expertiseComboBox.ItemsSource = Enum.GetValues(typeof(BE.expertise));
            this.disciplineComboBox.ItemsSource = Enum.GetValues(typeof(BE.discipline));
        }

        private void showDataGridView()//datagrid
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

     /*   private void addButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int minwag;
            int maxwag;
            try
            {
                int.TryParse(textBoxCONTRACT_ID.Text, out id);
                int.TryParse(textBoxmin.Text, out minwag);
                int.TryParse(textBoxmax.Text, out maxwag);
                bl.addExpert(new BE.specialization
                {
                    specialization_id = id,
                    minWage = minwag,
                    maxWage = maxwag,
                });

                this.DataContext = specialiste;
                showDataGridView();
                
            }
            catch (Exception ex)
            {
               
                showDataGridView();
                MessageBox.Show(ex.Message);
            }
        }
        */
        private void button_Click(object sender, RoutedEventArgs e)//add
        {
            try
            {

                if (specialiste.maxWage < specialiste.minWage)
                    throw new Exception("the wage is not smaller than max");
                bl.addExpert(specialiste);
                specialiste = new BE.specialization();
                this.DataContext = specialiste;
                showDataGridView();
            }
            catch (Exception ex)
            {

                showDataGridView();
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//close
        {
            this.Close();
        }
    }
}
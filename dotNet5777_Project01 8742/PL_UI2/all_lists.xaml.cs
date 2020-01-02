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
    /// Logique d'interaction pour all_lists.xaml
    /// </summary>
    public partial class all_lists : Window
    {

        BL.IBL bl;
        public all_lists()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }
        private void showDataGridView(int a)//datagrid en fonction des boutons
        {

            try
            {
                if (a == 1)
                {
                    DataGrid_s.ItemsSource = null;
                    DataGrid_s.ItemsSource = bl.Allcontract();
                }
                else if (a == 3)
                {
                    DataGrid_s.ItemsSource = null;
                    DataGrid_s.ItemsSource = bl.AllEmployee();
                }
                else if (a == 2)
                {
                    DataGrid_s.ItemsSource = null;
                    DataGrid_s.ItemsSource = bl.AllEmployer();
                }
                else if (a == 4)
                {
                    DataGrid_s.ItemsSource = null;
                    DataGrid_s.ItemsSource = bl.Allspecialization();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("שגיאה", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)//close
        {
            this.Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            showDataGridView(1);
        }

        private void button3_Copy_Click(object sender, RoutedEventArgs e)
        {
            showDataGridView(2);
        }

        private void button3_Copy1_Click(object sender, RoutedEventArgs e)
        {
            showDataGridView(3);
        }

        private void button3_Copy2_Click(object sender, RoutedEventArgs e)
        {
            showDataGridView(4);
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("You really want to delete all list specializations", "Warning", MessageBoxButton.YesNoCancel,
            MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    {
                        foreach (int id in bl.return_names_id_specialization())
                        {
                            bl.removeExpert(id);
                        }
                        break;
                    }
                case MessageBoxResult.No:
                    break;
            }
            showDataGridView(4);
        }

        private void button4_Click(object sender, RoutedEventArgs e)//delete all contract
        {
            MessageBoxResult result = MessageBox.Show("You really want to delete all list contracts", "Warning", MessageBoxButton.YesNoCancel,
            MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    {
                        foreach (int id in bl.return_names_id_contract())
                        {
                            bl.removecontract(id);
                        }
                        break;
                    }
                case MessageBoxResult.No:
                    break;
            }
            showDataGridView(1);
        }

        private void button1_Click(object sender, RoutedEventArgs e)//delete all employer
        {
            MessageBoxResult result = MessageBox.Show("You really want to delete all list employers", "Warning", MessageBoxButton.YesNoCancel,
       MessageBoxImage.Question);
            try
            {
                switch (result)
                {

                    case MessageBoxResult.Yes:
                        {

                            if (bl.Allcontract().Count() != 0)
                                throw new Exception("you have to supprime first the contract list");
                            foreach (int id in bl.return_names_id_employer())
                            {
                                bl.removeEmployer(id);
                            }
                            break;
                        }



                    case MessageBoxResult.No:
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("שגיאה", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            showDataGridView(2);
        }

        private void button2_Click(object sender, RoutedEventArgs e)//delete all employee
        {
            MessageBoxResult result = MessageBox.Show("You really want to delete all list employees", "Warning", MessageBoxButton.YesNoCancel,
      MessageBoxImage.Hand);
            try
            {
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        {
                            if (bl.Allcontract().Count() != 0)
                                throw new Exception("you have to delete first the contract list");
                            foreach (int id in bl.return_names_id_employee())
                            {
                                bl.removeEmployee(id);
                            }
                            break;
                        }
                    case MessageBoxResult.No:
                        break;
                }
            }
            catch (Exception)
            { MessageBox.Show("שגיאה", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error); }

            showDataGridView(3);
        }

    }
}

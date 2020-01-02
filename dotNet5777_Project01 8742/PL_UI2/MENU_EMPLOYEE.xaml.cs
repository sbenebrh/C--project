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
    /// Logique d'interaction pour MENU_EMPLOYEE.xaml
    /// </summary>
    public partial class MENU_EMPLOYEE : Window
    {
        BL.IBL bl;
        public MENU_EMPLOYEE()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void Employee_b_Click(object sender, RoutedEventArgs e)
        {
            Window addemployee = new ADD_EMPLOYEE(bl);
            try
            {
                bl.threa_isalive();
                addemployee.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("bank doesn't downloaded");
            }
        }

       

        private void button1_Copy5_Click(object sender, RoutedEventArgs e)
        {
            Window update_Employee = new update_Employee(bl);
            try
            {
                bl.threa_isalive();
                update_Employee.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("bank doesn't downloaded");
            }
        }

      
    }
}

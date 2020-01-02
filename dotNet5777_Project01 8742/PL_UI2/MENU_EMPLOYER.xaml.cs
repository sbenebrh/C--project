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
    /// Logique d'interaction pour MENU_EMPLOYER.xaml
    /// </summary>
    public partial class MENU_EMPLOYER : Window
    {
        BL.IBL bl;
        public MENU_EMPLOYER()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void Employer_b_Click(object sender, RoutedEventArgs e)
        {
            Window addemployer = new ADDEmployer(bl);
            addemployer.Show();
        }

     

        private void button1_Copy4_Click(object sender, RoutedEventArgs e)
        {
            Window update_employer = new update_employer(bl);
            update_employer.Show();
        }

       
    }
}

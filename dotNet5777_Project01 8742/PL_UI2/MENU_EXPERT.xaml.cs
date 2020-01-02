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
    /// Logique d'interaction pour MENU_EXPERT.xaml
    /// </summary>
    public partial class MENU_EXPERT : Window
    {
        BL.IBL bl;
        public MENU_EXPERT()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void specialization_b_Click(object sender, RoutedEventArgs e)
        {
            Window specialization_w = new Window_specialization(bl);
            specialization_w.Show();
        }

        private void button1_Copy6_Click(object sender, RoutedEventArgs e)
        {
            Window update_EXPERT = new Update_specialization();
            update_EXPERT.Show();
        }

       
    }
}

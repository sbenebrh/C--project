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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using System.Collections.ObjectModel;
using BL;
using System.Threading;

namespace PL_UI2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {

        BL.IBL bl;
        List<int> lst;

        public MainWindow()//ctor
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();      
            lst = new List<int>();
         


        }

        private void button_Click_4(object sender, RoutedEventArgs e)//show grouping
        {
            Window groupe = new grouping_expert(1);
            groupe.Show();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)//show grouping
        {
            Window groupe = new grouping_expert(2);
            groupe.Show();
        }


      

        private void button_Copy_Click_1(object sender, RoutedEventArgs e)
        {
            Window alllists = new all_lists();
            alllists.Show();
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Window w = new profilt_by_year_contracts();
            w.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window contrat = new MENU_CONTRACT();
            contrat.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        
        {
            Window EMPLOYER = new MENU_EMPLOYER();
            EMPLOYER.Show();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)

        {
            Window EMPLOYER = new MENU_EMPLOYEE();
            EMPLOYER.Show();
        }

       
            private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Window EXPERT = new MENU_EXPERT();
            EXPERT.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Window c_to_em = new Contract_to_employer();
            c_to_em.Show();
        }
    }

}


    

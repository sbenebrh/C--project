using BE;
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
    /// Logique d'interaction pour profilt_by_year_contracts.xaml
    /// </summary>
    public partial class profilt_by_year_contracts : Window
    {
        BL.IBL bl;
        List<contract> lst1 = new List<contract>();
        double sum = 0;

        public profilt_by_year_contracts()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();  
        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                DateTime begin_ = (DateTime)button_.SelectedDate;
                DateTime end_ = (DateTime)button__.SelectedDate;
                TimeSpan t = begin_ - end_;
                if (t.Days > 0)
                    throw new Exception("error date");
                lst1 = bl.Grouping_contract_revahim(begin_.Year, end_.Year);
                foreach (contract n in lst1)
                {
                    sum += n.commission;
                }
                label1.Content = sum.ToString();
            }
            catch(Exception)
            { MessageBox.Show("שגיאה", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}

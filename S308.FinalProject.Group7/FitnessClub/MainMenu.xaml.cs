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

namespace FitnessClub
{
    ///Evelyn Delph, Tyler Sweem, Tiffany Pham
    /// <summary>
    /// image source: https://naotw-pd.s3.amazonaws.com/images/goldsgym-calvario.jpg
    /// Interaction logic for Window1.xaml
    /// Main Menu is first window, takes user to login, membership information, membership sales, pricing management, and merchandise pages
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnMerchandise_Click(object sender, RoutedEventArgs e)
        {
            Merchandise winMerch = new Merchandise();
            winMerch.Show();
            this.Close();
        }

        private void btnPricingManagement_Click(object sender, RoutedEventArgs e)
        {
            PricingManagement winPurchManage = new PricingManagement();
            winPurchManage.Show();
            this.Close();
        }

        private void btnMembershipSales_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales winMemberSales = new MembershipSales();
            winMemberSales.Show();
            this.Close();
        }

        private void btnMembershipInformation_Click(object sender, RoutedEventArgs e)
        {
            MembershipInformation winMemberInfo = new MembershipInformation();
            winMemberInfo.Show();
            this.Close();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            Login winLogin = new Login();
            winLogin.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

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
    /// <summary>
    /// image source: http://www.truegritness.com/wp-content/uploads/2014/12/TG-BKG-IRON-GYM-SM-DARK.jpg
    /// Interaction logic for MembershipSignUp.xaml
    /// User gets to the Membership Registration page after entering in information in the Membership Sales Page. Can navigate back to the Membership Sales and Main Menu pages.
    /// </summary>
    public partial class MembershipSignUp : Window
    {
        public MembershipSignUp()
        {
            InitializeComponent();
        }

        private void txbMemSales_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MembershipSales winMemberSales = new MembershipSales();
            winMemberSales.Show();
            this.Close();
        }
        private void txbPaymentInfo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Payment winPayment = new Payment();
            winPayment.Show();
            this.Close();
        }
        private void txbMainMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
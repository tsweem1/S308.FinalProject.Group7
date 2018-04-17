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

        private void btnMainMenu1_Click(object sender, RoutedEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }

        private void btnMembershipSales_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales winMemberSales = new MembershipSales();
            winMemberSales.Show();
            this.Close();
        }

        private void btnRegister1_Click(object sender, RoutedEventArgs e)
        {
            // Questions
            // Ask about if you need to validate inputs before you create an instance
            // Ask about generating a random number for UserID as the user clicks "register"
                //Random rand = new Random(100);
                //int ccc = rand.Next(000000000, 999999999);
                //Member memberNew = new Member(txtUserID.Text,txtFirstName.Text, txtLastName.Text, txtPhone.Text, cboGender.Text,DateTime txtBirthday.Text);

            //Coding needed
            //1. Validate phone number
            //2. Valdidate weight as int
            //3. Validiate email
            //4. Append data to file
        }
    }
}

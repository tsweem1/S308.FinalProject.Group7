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
    /// Interaction logic for MembershipInformation.xaml
    /// Get to Membership Information page from the main menu. from this page, users can access the fitness goals and purchase history of members from the buttons to go to their designated pages
    /// </summary>
    public partial class MembershipInformation : Window
    {
        public MembershipInformation()
        {
            InitializeComponent();
        }

        private void btnPurchaseHistory_Click(object sender, RoutedEventArgs e)
        {
            Member_Purchase_History winPurchHistory = new Member_Purchase_History();
            winPurchHistory.Show();
            this.Close();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }

        private void btnFitnessGoals_Click(object sender, RoutedEventArgs e)
        {
            FitnessGoals winFitGoals = new FitnessGoals();
            winFitGoals.Show();
            this.Close();
        }
    }
}

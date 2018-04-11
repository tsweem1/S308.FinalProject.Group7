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
    /// Interaction logic for FitnessGoals.xaml
    /// User can get to Fitness Goals page from the Membership Information page. Can navigate back to the Membership Information and Main Menu pages.
    /// </summary>
    public partial class FitnessGoals : Window
    {
        public FitnessGoals()
        {
            InitializeComponent();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }

        private void btnMembershipInformation_Click(object sender, RoutedEventArgs e)
        {
            MembershipInformation winMemberInfo = new MembershipInformation();
            winMemberInfo.Show();
            this.Close();
        }
    }
}

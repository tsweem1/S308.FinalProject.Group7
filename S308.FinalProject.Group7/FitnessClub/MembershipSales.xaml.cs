﻿using System;
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
    /// Interaction logic for MembershipSales.xaml
    /// Users can navigate to the Membership Sales page from the Main Menu. Once the user enters in information, can proceed to the registration page. 
    /// </summary>
    public partial class MembershipSales : Window
    {
      public MembershipSales()
        {
            InitializeComponent();
        }
        #region navigating between windows
        private void txbMemReg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MembershipSignUp winMemberReg = new MembershipSignUp();
            winMemberReg.Show();
            this.Close();
        }
        private void txbMainMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }
        #endregion
        private void btnSaveQuota_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

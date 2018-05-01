using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
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
        List<Member> memberList;

        public MembershipInformation()
        {
            InitializeComponent();
            // Load Json File
            GetDataSetFromFile();
        }

        private void GetDataSetFromFile()
        {
            List<Member> lstMember = new List<Member>();

            string strFilePath = @"..\..\..\Data\Members.json";

            try
            {

                //use system.oi.file to read the entire data file
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();


                //serialize the json data to a list of customers
                memberList = JsonConvert.DeserializeObject<List<Member>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Member from file: " + ex.Message);
            }


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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //clear all user input fields

            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            //lbxSearchResults.te = "";
            txtMemberDetails.Text = "";
        }

        private void btnSearchMember_Click(object sender, RoutedEventArgs e)
        {
            List<Member> memberSearch;

            //declare variables
            string strFirstName;
            string strLastName;
            string strEmail;
            string strPhoneNumber;

            //convert input fields
            strFirstName = Convert.ToString(txtFirstName.Text);
            strLastName = Convert.ToString(txtLastName.Text);
            strEmail = Convert.ToString(txtEmail.Text);
            strPhoneNumber = Convert.ToString(txtPhoneNumber.Text);


            //validate user input

            //user must enter at least one search field
            if (strFirstName == "" && strLastName == "" && strPhoneNumber == "" && strEmail == "")
            {
                MessageBox.Show("Please enter information in at least one search field.");
                return;
            }

            //conduct member search 
            memberSearch = memberList.Where(m =>
               m.LastName.StartsWith(strLastName) &&
               m.FirstName.StartsWith(strFirstName) &&
               m.EmailAddress.StartsWith(strEmail) &&
               m.PhoneNumber.StartsWith(strPhoneNumber)).ToList();


            int counter = 0;

            foreach (var i in memberSearch)
            {
                if (strLastName.Length == 0 || strLastName == i.LastName)
                {
                    counter += 1;
                }
                else
                {
                    counter -= 1;
                }
                if(strFirstName.Length == 0 || strFirstName == i.FirstName)
                {
                    counter += 1;
                }
                else
                {
                    counter -= 1;
                }
                if(strEmail.Length == 0 || strEmail == i.EmailAddress)
                {
                    counter += 1;
                }
                else
                {
                    counter -= 1;
                }
                if(strPhoneNumber.Length == 0 || strPhoneNumber == i.PhoneNumber)
                {
                    counter += 1;
                }
                else
                {
                    counter -= 1;
                }

            }
            if(counter != 4)
            {
                MessageBox.Show("One or more of your entries is incorrect.");
                return;
            }

                //display search items and results in listbox if field is not blank
                foreach (Member m in memberSearch)
            {
                if (strLastName == "")
                {
                    lstMember.Items.Add("");
                }
                else
                {
                    lstMember.Items.Add(m.LastName);
                }

                if (strFirstName == "")
                {
                    lstMember.Items.Add("");
                }
                else
                {
                    lstMember.Items.Add(m.FirstName);
                }
                if (strEmail == "")
                {
                    lstMember.Items.Add("");
                }
                else
                {
                    lstMember.Items.Add(m.EmailAddress);
                }

                if (strPhoneNumber == "")
                {
                    lstMember.Items.Add("");
                }
                else
                {
                    lstMember.Items.Add(m.PhoneNumber);
                }

            }

            lblNumResults.Content = "(" + memberSearch.Count.ToString() + ")";
        }
        private void txbMainMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }

        private void lstMember_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {

            if (lstMember.SelectedIndex > -1)
            {
                MessageBox.Show(lstMember.SelectedIndex.ToString());
                string strSelectedName = lstMember.SelectedItem.ToString();

                Member memberSelected = memberList.Where(m => m.LastName + m.FirstName == strSelectedName).FirstOrDefault();
                txtMemberDetails.Text = memberSelected.ToString();
            }
        }

        private void btnClearContents_Click(object sender, RoutedEventArgs e)
        {
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMemberDetails.Text = "";
            txtPhoneNumber.Text = "";
            lstMember.Items.Clear();
            lblNumResults.Content = "(0)";
        }
    }
}


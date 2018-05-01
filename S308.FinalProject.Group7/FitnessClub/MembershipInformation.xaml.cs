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
            //1. Load Json File
            GetDataSetFromFile();
        }

        private void GetDataSetFromFile()
        {
            //2. Declare new list for all Member properties
            List<Member> lstMember = new List<Member>();
            //3. Declare string for file path
            string strFilePath = @"..\..\..\Data\Members.json";

            try
            {
                //4. use system.oi.file to read the entire data file
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();

                //5. serialize the json data to a list of customers
                memberList = JsonConvert.DeserializeObject<List<Member>>(jsonData);
            }
            catch (Exception ex)
            {
                //6. Show error message if failed to read Json File
                MessageBox.Show("Error loading Member from file: " + ex.Message);
            }


        }

        #region Helper Functions
        // Go To Main Menu Window
        private void txbMainMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 winMainMenu = new Window1();
            winMainMenu.Show();
            this.Close();
        }

        //clear all user input fields
        private void btnClearContents_Click(object sender, RoutedEventArgs e)
        {
            lstMember.Items.Clear();
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            txtMemberDetails.Text = "";
            lblNumResults.Content = "(0)";
        }

        #endregion 

        //7. Member Search Functionality
        private void btnSearchMember_Click(object sender, RoutedEventArgs e)
        {
            List<Member> memberSearch;

            //8. Clear previous search content
            lstMember.Items.Clear();
            txtMemberDetails.Text = "";
            lblNumResults.Content = "(0)";

            //9. declare variables
            string strFullName;
            string strFirstName;
            string strLastName;
            string strEmail;
            string strPhoneNumber;

            //10. Convert input fields
            strFullName = "";
            strFirstName = Convert.ToString(txtFirstName.Text);
            strLastName = Convert.ToString(txtLastName.Text);
            strEmail = Convert.ToString(txtEmail.Text);
            strPhoneNumber = Convert.ToString(txtPhoneNumber.Text);


            //11. Validate user input and initiate member search

            //11.1 user must enter at least one search field
            if (strFirstName == "" && strLastName == "" && strPhoneNumber == "" && strEmail == "")
            {
                MessageBox.Show("Please enter information in at least one search field.");
                return;
            }

            //11.2 conduct member search 
            memberSearch = memberList.Where(m =>
               m.Fullname.StartsWith(strFullName) &&
               m.LastName.StartsWith(strLastName) &&
               m.FirstName.StartsWith(strFirstName) &&
               m.EmailAddress.StartsWith(strEmail) &&
               m.PhoneNumber.StartsWith(strPhoneNumber)).ToList();

            //11.3 Validate that info from user input are correct for existing members
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
            if(counter < 4)
            {
                MessageBox.Show("One or more of your entries is incorrect.");
                return;
            }

                //display search items and results in listbox if field is not blank
                foreach (Member m in memberSearch)
            {
                if (strLastName == "")
                {
                    
                }
                else
                {
                    if (!lstMember.Items.Contains(m.Fullname))
                    {
                        lstMember.Items.Add(m.Fullname);
                    }
                }

                if (strFirstName == "")
                {
                    
                }
                else
                {
                    if (!lstMember.Items.Contains(m.Fullname))
                    {
                        lstMember.Items.Add(m.Fullname);
                    }
                }
                if (strEmail == "")
                {
                    
                }
                else
                {
                    if (!lstMember.Items.Contains(m.Fullname))
                    {
                        lstMember.Items.Add(m.Fullname);
                    }
                }

                if (strPhoneNumber == "")
                {
                    
                }
                else
                {
                    if (!lstMember.Items.Contains(m.Fullname))
                    {
                        lstMember.Items.Add(m.Fullname);
                    }
                }

            }
            //11.4 Updpate Search Count
            lblNumResults.Content = "(" + memberSearch.Count.ToString() + ")";
        }
        
        //12. Populate Member Details Textbox according to the information selected in the search list box
        private void lstMember_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (lstMember.SelectedIndex > -1)
            {
                string strSelectedItem = lstMember.SelectedItem.ToString();

                Member memberSelected = memberList.Where(m => m.Fullname == strSelectedItem).FirstOrDefault();
                
                txtMemberDetails.Text = memberSelected.ToString();
            }
        }

        
    }
}


﻿using System;
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
            memberList = GetDataSetFromFile();
        }

        public List<Member> GetDataSetFromFile()
        {
            List<Member> lstMember = new List<Member>();
            Files calFiles = new Files();
            string strFilePath = @"..\..\..\Data\Member.json";

             try
             {

                //3.use system.oi.file to read the entire data file
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();

                //4.serialize the json data to a list of customers
                
                lstMember = JsonConvert.DeserializeObject<List<Member>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Member from file: " + ex.Message);
            }

            return lstMember;
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


        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
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

            //search results is cleared when member details is blank
            txtMemberDetails.Text = "";
            lbxSearchResults.Items.Clear();


            memberSearch = memberList.Where(m =>
                m.LastName.StartsWith(strLastName) ||
                m.FirstName.StartsWith(strLastName) ||
                m.EmailAddress.StartsWith(strEmail) ||
                m.PhoneNumber.StartsWith(strPhoneNumber)).ToList();

            foreach (Member m in memberSearch)
            {
                lbxSearchResults.Items.Add(m.LastName + m.FirstName);
            }

            lblNumResults.Content = "(" + memberSearch.Count.ToString() + ")";

            }
            private void lstMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxSearchResults.SelectedIndex > -1)
            {
                string strSelectedName = lbxSearchResults.SelectedItem.ToString();

                Member memberSelected = memberList.Where(m => m.LastName + m.FirstName == strSelectedName).FirstOrDefault();
                txtMemberDetails.Text = memberSelected.ToString();
            }
        }







    }
    }


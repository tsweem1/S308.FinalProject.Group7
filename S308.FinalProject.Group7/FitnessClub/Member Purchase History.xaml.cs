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
    /// Interaction logic for Member_Purchase_History.xaml
    /// User gets to Member Purchase History page from the Membership Information page. Can navigate back to Membership Information and Main Menu pages.
    /// </summary>
    public partial class Member_Purchase_History : Window
    {
        List<Member> PurchaseHistory;

        public Member_Purchase_History()
        {
            InitializeComponent();

            // GetDataSetFromFile();

        }
        private void GetDataSetFromFile()
        {
            //List<Member> lstMember = new List<Member>();

            // string strFilePath = @"..\..\..\Data\Members.json";

            // try
            //  {

            //3.use system.oi.file to read the entire data file
            //  StreamReader reader = new StreamReader(strFilePath);
            // string jsonData = reader.ReadToEnd();
            //  reader.Close();


            //4.serialize the json data to a list of customers
            //  memberList = JsonConvert.DeserializeObject<List<Member>>(jsonData);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            // List<Member> memberSearch;


            //declare variables
            // string strFirstName;
            // string strLastName;


            //convert input fields
            //   strFirstName = Convert.ToString(txtFirstName.Text);
            //  strLastName = Convert.ToString(txtLastName.Text);



            //validate user input

            //user must enter at least one search field
            // if (strFirstName == "" && strLastName == "")
            // {
            //      MessageBox.Show("Please enter information in at least one search field.");
            //      return;
            // }

            //conduct member search 
            //  memberSearch = memberList.Where(m =>
            //     m.LastName.StartsWith(strLastName) &&
            //     m.FirstName.StartsWith(strFirstName) &&
            //    m.EmailAddress.StartsWith(strEmail) &&
            //     m.PhoneNumber.StartsWith(strPhoneNumber)).ToList();


            //display search items and results in listbox if field is not blank
            //  foreach (Member m in memberSearch)
            //  {
            //     if (strLastName == "")
            //   {
            //         lbxSearchResults.Items.Add("");
            //  }
            //  else
            //  {
            //      lbxSearchResults.Items.Add(m.LastName);
            //  }

            //   if (strFirstName == "")
            // {
            //      lbxSearchResults.Items.Add("");
            //  }
            //  else
            //  {
            //        lbxSearchResults.Items.Add(m.FirstName);
            //  }


            // }
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



        private void lstMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (lbxSearchResults.SelectedIndex > -1)
           // {
           //     string strSelectedName = lbxSearchResults.SelectedItem.ToString();
           
           //     Member memberSelected = memberList.Where(m => m.LastName + m.FirstName == strSelectedName).FirstOrDefault();
            //    dtgPurchaseHistory = memberSelected.ToString();
           // }
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
           // txtLastName.Text = "";
            //txtFirstName.Text = "";
        }
    }
}



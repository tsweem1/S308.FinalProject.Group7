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

       // PurchaseHistory = GetDataSetFromFile();

          }

        //public List<Member> GetDataSetFromFile()
        //{
        //    List<Member> lstPokemon = new List<Member>();

        //   // string strFilePath = @"../../../Data/MemberPurchaseHistory.json";

        //    //try
        //    //{
        //     //   string jsonData = File.ReadAllText(strFilePath);
        //      //  dtgPurchaseHistory = JsonConvert.DeserializeObject<List<Member>>(jsonData);
        //   // }
        //   // catch (Exception ex)
        //   // {
        //   //     Console.WriteLine("Error loading Member Purchase History from file: " + ex.Message);
        //  //  }

        //  //  return lstPokemon;
        //}


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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            //List<Member> purchaseSearch;

            //declare MemberId field
            //    //string strMemberID;

            //    ComboBoxItem cbiMemberID = (ComboBoxItem)cboMemberID.SelectedItem;
            //    string strMemberID = cbiMemberID.Content.ToString();

            //   // purchaseSearch = purchasehistoryIndex.Where(m =>
            //  //  m.MemberID.StartsWith(strMemberID).ToList());

            //   // foreach (Member m in purchaseSearch)
            //   // {
            //   //     dtgPurchaseHistory.Items.Add(m.MemberID);
            //   // }

            // }
            // }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtLastName.Text = "";
            txtFirstName.Text = "";
        }
    }
}


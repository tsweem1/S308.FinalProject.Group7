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
    ///Evelyn Delph, Tyler Sweem, Tiffany Pham
    /// <summary>
    /// image source: https://naotw-pd.s3.amazonaws.com/images/goldsgym-calvario.jpg
    /// Interaction logic for Window1.xaml
    /// Main Menu is first window, takes user to login, membership information, membership sales, pricing management, and merchandise pages
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            //creating memberList to add to jSon
            //List<Member> memberList = new List<Member>();
           // Member m1 = new Member("John","Doe","Male","123-123-1234","j.doe@iu.edu","180","45","Weight Loss",new CustomerPaymentInfo("Individual 1 Month","7/15/2017","2017,8,15","Personal Training Plan","9.99","14.99") ,"4090249764583478","Visa","1235 Main Street","Bloomington","47409");
            //Member m2 = new Member("Jane", "Dan", "Female", "245-355-2349", "j.dan@iu.edu", "150", "32", "Weight Loss", new CustomerPaymentInfo("Individual 12 Month", { 207, 9, 3 }, [2018,9,3], "Locker Rental", "100.00", "101.00"), "4929411036002979", "Visa","438 4th Street","Bloomington","47402");
           // Member m3 = new Member("")
          // m1.AdditionalFeatures.Add("Personal Training Plan");
            
          //  memberList.Add(m1);

            //serialize 

            
          //  JsonConvert.SerializeObject(memberlist);

           //  string strFilePath =  @"..\..\..\Data\Member.json";
          //   System.IO.File.WriteAllText(strFilePath, jsonData);


        }

        private void btnMerchandise_Click(object sender, RoutedEventArgs e)
        {
            Merchandise winMerch = new Merchandise();
            winMerch.Show();
            this.Close();
        }

        private void btnPricingManagement_Click(object sender, RoutedEventArgs e)
        {
            PricingManagement winPurchManage = new PricingManagement();
            winPurchManage.Show();
            this.Close();
        }

        private void btnMembershipSales_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales winMemberSales = new MembershipSales();
            winMemberSales.Show();
            this.Close();
        }

        private void btnMembershipInformation_Click(object sender, RoutedEventArgs e)
        {
            MembershipInformation winMemberInfo = new MembershipInformation();
            winMemberInfo.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
    



}

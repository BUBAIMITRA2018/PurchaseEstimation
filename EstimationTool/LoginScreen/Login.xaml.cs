using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EstimationTool.LoginScreen
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : System.Windows.Controls.UserControl
    {
        //string dbconnectionString = @"Data Source=database.db;Version=3;";
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SQLiteConnection sqliteCon = new SQLiteConnection(dbconnectionString);
            //try
            //{
            //    sqliteCon.Open();
            //    string Query = "select * from userinfo where username='" + this.txt_username.Text.ToUpper() + "' and password='" + this.txt_password.Password + "' ";
            //    SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);

            //    createCommand.ExecuteNonQuery();
            //    SQLiteDataReader dr = createCommand.ExecuteReader();

            //    int count = 0;
            //    while (dr.Read())
            //    {
            //        count++;
            //    }
            //    if (count == 1)
            //    {
            //System.Windows.MessageBox.Show("Username and password is correct");
            //Form  UserControlHome = new Form();
            //this.Close();
            //UserControlHome.Show();
            //    }
            //    if (count < 1)
            //    {
            //        MessageBox.Show("Username and password is not correct");
            //    }
            //    sqliteCon.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


        }


    }
}

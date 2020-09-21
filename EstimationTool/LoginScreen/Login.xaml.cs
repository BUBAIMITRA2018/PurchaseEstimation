using Estimationtool.ViewModels;
using EstimationTool.RegistrationScreen;
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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace EstimationTool.LoginScreen
{

    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    /// 
    public partial class LogIn : Window
    {

        //string dbconnectionString = (@" Data Source = WAP101478; Initial Catalog = EstimationDB; Persist Security Info = True; User ID = Estimation; Password = sms@123;");

        string dbconnectionString = (@"Data Source =(local)\SQLEXPRESS; Initial Catalog = Estimation; User ID = sa; Password = sms@123; ");

        public string pswd;

        public LogIn()
        {
            InitializeComponent();

            ////pwdbox.PasswordChanged += Pwdbox_PasswordChanged;


        }


        ////public void Pwdbox_PasswordChanged(object sender, RoutedEventArgs e)
        ////{

        ////    // throw new NotImplementedException();
        ////    pswd = pwdbox.Password;


        ////}





        //private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    Registration window = new Registration();
        //    window.Show();
        //    this.Close();

        //}

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection SqlConn = new SqlConnection(dbconnectionString);
            try
            {
                SqlConn.Open();
                string Query = "select * from users where username='" + this.Username.Text.ToUpper() + "' and password='" + this.pwdbox.Password + "' ";
                SqlCommand createCommand = new SqlCommand(Query, SqlConn);

                createCommand.ExecuteNonQuery();
                SqlDataReader dr = createCommand.ExecuteReader();

                int count = 0;
                while (dr.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    //System.Windows.MessageBox.Show("Username and password is correct");
                    
                   
                    MainWindow window = new MainWindow(this.Username.Text.ToUpper());


                    this.Close();
                    window.Show();
                }
                if (count < 1)
                {
                    System.Windows.MessageBox.Show("Username or password not correct");
                }
                SqlConn.Close();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }


        } }


    }


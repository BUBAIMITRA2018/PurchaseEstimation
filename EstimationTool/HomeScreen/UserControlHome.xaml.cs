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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EstimationTool.HomeScreen
{
    /// <summary>
    /// Interaction logic for UserControlHome.xaml
    /// </summary>
    public partial class UserControlHome : UserControl
    {
        public UserControlHome()
        {
            InitializeComponent();
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            //SQLiteConnection sqliteCon = new SQLiteConnection(dbconnectionString);
            //try
            //{
            //    sqliteCon.Open();
            //    string Query = "insert into OrderDetail (DocumentNo, Date, SuborderNo, PONo, POValue) Values('" + this.txt_DocumentNumber.Text + "', '" + this.txt_date.Text + "', '" + this.txt_suborder_no.Text + "', '" + this.txt_po_no.Text + "', '" + this.txt_po_value.Text + "')";
            //    SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);

            //    createCommand.ExecuteNonQuery();
            //    MessageBox.Show("Saved");

            //    sqliteCon.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void Btn_fetch_Click(object sender, RoutedEventArgs e)
        {
            //SQLiteConnection sqliteCon = new SQLiteConnection(dbconnectionString);

            //sqliteCon.Open();
            //string Query = "select Date, SuborderNo, PONo, POValue from OrderDetail where DocumentNO = '" + this.txt_DocumentNumber.Text + "'";
            //SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);

            //createCommand.ExecuteNonQuery();
            //SQLiteDataReader da = createCommand.ExecuteReader();

            //while (da.Read())
            //{
            //    txt_date.Text = da.GetValue(0).ToString();
            //    txt_suborder_no.Text = da.GetValue(1).ToString();
            //    txt_po_no.Text = da.GetValue(2).ToString();
            //    txt_po_value.Text = da.GetValue(3).ToString();

            //}
            //sqliteCon.Close();

        }

    }
}

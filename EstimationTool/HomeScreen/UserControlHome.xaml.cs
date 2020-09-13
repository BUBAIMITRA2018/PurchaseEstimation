using Estimationtool.Models;
using Estimationtool.Services;
using EstimationTool.Models;
using EstimationTool.Ninject;
using EstimationTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        HomeViewModel HV;
        ServiceLocator servicelocator = new ServiceLocator();
        CollectionViewSource vdata;
        private ObservableCollection<string> converprod;
        Dictionary<string, ObservableCollection<FilterObj>> filters;
        public UserControlHome()
        {
            InitializeComponent();

            filters = new Dictionary<string, ObservableCollection<FilterObj>>();

            var products = servicelocator.HomeViewModel.Products;

            vdata = new CollectionViewSource { Source = servicelocator.HomeViewModel.Products };

            vdata.Filter += Vdata_Filter;

            dataGrid.ItemsSource = vdata.View;     


        }

        private void Vdata_Filter(object sender, FilterEventArgs e)
        {
            ObservableCollection<FilterObj> fltcurrent;
            string colName = "";
            int count;
            try
            {
                e.Accepted = true;
                if(e.Item is Product p)
                {

                    foreach(var item in p.GetType().GetProperties())
                    {
                        colName = item.Name;
                        string value = p.GetType().GetProperty(colName).GetValue(p, null).ToString();

                        if (filters.ContainsKey(colName))
                        {
                            filters.TryGetValue(colName, out fltcurrent);
                            count = 0;
                            if(fltcurrent !=null)
                            {
                                count = fltcurrent.Where(w => w.Is_Check ).Count(w => w.Title == value);
                                if(count == 0)
                                {
                                    e.Accepted = false;
                                    return;

                                }
                            }
                        }
                    }




                }

            }

            catch (Exception ex)
            {
                e.Accepted = true;
                Debug.WriteLine(ex);
            }


        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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

        private void DataGrid_SelectionChanged()
        {

        }

        private void Btnfilter_Click(object sender, RoutedEventArgs e)
        {
            string colName = "";
            Button btn = sender as Button;
            ObservableCollection<FilterObj> fltcurrent;
            popExcel.PlacementTarget = btn;
            StackPanel sp = btn.Parent as StackPanel;
            foreach(var ch in sp.Children)
            {
                if(ch is TextBlock tb)
                {
                    colName = tb.Text;
                    break;
                }
            }

            fltcurrent = new ObservableCollection<FilterObj>();

            try
            {
                if (filters.ContainsKey(colName))
                {
                    filters.TryGetValue(colName, out fltcurrent);
                }
                else
                {                  


                    foreach (Product p in vdata.View)
                    {

                        string value = p.GetType().GetProperty(colName).GetValue(p, null).ToString();

                        if (value != null)
                        {
                            FilterObj f = new FilterObj() { Is_Check = true, Title = value };

                            bool is_new = true;
                            foreach (FilterObj flt in fltcurrent)
                            {
                                if (flt.Title == value)
                                {
                                    is_new = false;
                                    break;
                                }

                            }
                            if (is_new)
                            {
                                fltcurrent.Add(f);

                            }


                        }



                       
                            
                       

                    }                  


                }

                

            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                lbfilter.ItemsSource = fltcurrent;

                if (!filters.ContainsKey(colName))
                {
                    filters.Add(colName, fltcurrent);
                }          


            }


          
         

            popExcel.Uid = colName;
            popExcel.IsOpen = true;

        }

        private void Tbfilter_KeyDown(object sender, KeyEventArgs e)
        {

            string colName = popExcel.Uid;
            ObservableCollection<FilterObj> fltcurrent;

            if (e.Key == Key.Return)
            {

              if (filters.ContainsKey(colName))
                {
                    filters.TryGetValue(colName, out fltcurrent);
                    lbfilter.ItemsSource = fltcurrent.Where(w => w.Title.IndexOf(tbfilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                }

            }

        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            vdata.View.Refresh();

        }
    }
}

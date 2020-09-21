using Estimationtool.Models;
using Estimationtool.Services;
using EstimationTool.Models;
using EstimationTool.Ninject;
using EstimationTool.ViewModel;
using MaterialDesignThemes.Wpf;
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
        CollectionViewSource vdata_stor;
        
        string applyfiltercolname = null;
        bool filteraction_deactivate = false;
        private ObservableCollection<string> converprod;
        Dictionary<string, ObservableCollection<FilterObj>> filters;
        PackIcon wantedchild;
        IList<PackIcon> wantedchilds = new List<PackIcon>();

        ObservableCollection<Product> listofproduct;

        public UserControlHome()
        {
            InitializeComponent();

            filters = new Dictionary<string, ObservableCollection<FilterObj>>();

            listofproduct = new ObservableCollection<Product>();

            var products = servicelocator.HomeViewModel.Products;

            listofproduct = products;

            vdata = new CollectionViewSource { Source = servicelocator.HomeViewModel.Products };
            vdata_stor = vdata;

            vdata.Filter += Vdata_Filter;

            ////dataGrid.ItemsSource = vdata.View;
            this.DataContext = servicelocator.HomeViewModel;

            //dataGrid.ItemsSource = listofproduct;

          


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

                  
                    foreach (var item in p.GetType().GetProperties())
                    {
                        colName = item.Name;
                        string value = p.GetType().GetProperty(colName).GetValue(p, null).ToString();

                        if (filters.ContainsKey(colName))
                        {
                            filters.TryGetValue(colName, out fltcurrent);
                            count = 0;
                            if (fltcurrent != null)
                            {
                                count = fltcurrent.Where(w => w.Is_Check).Count(w => w.Title == value);
                                if (count == 0)
                                {
                                    e.Accepted = false;
                                    return;

                                }

                                else
                                {
                                    var a = vdata.View;
                                    e.Accepted = true;
                                    dataGrid.ItemsSource = vdata.View;
                                    if ((string)ApplyFilter.Content == "Apply Filter")
                                        ApplyFilter.Content = "Filter Applied";
                                    ApplyFilter.Background = new SolidColorBrush(Color.FromRgb(255, 187, 51));
                                    ApplyFilter.Foreground = new SolidColorBrush(Color.FromRgb(13, 13, 12));

                                    foreach (var child in wantedchilds)
                                    {
                                        child.Foreground = new SolidColorBrush(Color.FromRgb(255, 187, 51));

                                    }                               




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


            Button button = sender as Button;
            object wantedNode = button.FindName("FilterIcon");

            if (wantedNode is PackIcon)
            {
                wantedchild = wantedNode as PackIcon;

                wantedchilds.Add(wantedchild);


            }








            if (colName == "WBS Element")
            {
                colName = "WBSElement";
            }

            if (colName == "Product No")
            {
                colName = "ProductNo";
            }

            if (colName == "Item Desc")
            {
                colName = "ItemDescription";
            }

            if (colName == "Material No")
            {
                colName = "MatrialNo";
            }

            if (colName == "Qty Req")
            {
                colName = "QtyReq";
            }

            if (colName == "Unit")
            {
                colName = "UnitofMeasurment";
            }

            if (colName == "Purchasing Doc")
            {
                colName = "PurchasingDocument";
            }

            if (colName == "Purchase Date")
            {
                colName = "PurchaseOrderNo";
            }

            if (colName == "Unit Rate Price")
            {
                colName = "UnitRatePrice";
            }


            if (colName == "Net Order Price")
            {
                colName = "NetOrderPrice";
            }

            if (colName == "Supplier Name")
            {
                colName = "SupplierName";
            }


            applyfiltercolname = colName;



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
                            FilterObj f = new FilterObj() { Is_Check = false, Title = value };

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


      
            //(button.FindName("FilterIcon") as PackIcon).Kind = PackIconKind.Tick;
            //vdata.Filter += new FilterEventHandler(Vdata_Filter);
            //(button.FindName("FilterIcon") as PackIcon).Foreground = PackIconKind.Tick;



            vdata.Filter += Vdata_Filter;

            vdata.View.Refresh();
            


            //dataGrid.ItemsSource = vdata.View;



        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
          


            vdata.Filter -= new FilterEventHandler(Vdata_Filter);

            vdata = new CollectionViewSource { Source = servicelocator.HomeViewModel.Products };

            dataGrid.ItemsSource = vdata.View;

            if ((string)ApplyFilter.Content == "Filter Applied")
                ApplyFilter.Content = "Apply Filter";
            ApplyFilter.Background = new SolidColorBrush(Color.FromRgb(87, 87, 87));
            ApplyFilter.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            foreach (var child in wantedchilds)
            {
                child.Foreground = Brushes.White;

            }

            wantedchilds.Clear();
           

            filters.Clear();

            this.popExcel.IsOpen = false;




        }

        private void Vdata_clear_filter(object sender, FilterEventArgs e)
        {
            ObservableCollection<FilterObj> fltcurrent;
            string colName = "";
            int count;
            try
            {
                e.Accepted = false;



             

            }

            catch (Exception ex)
            {
                e.Accepted = true;
                Debug.WriteLine(ex);
            }

        }

        private void  applyfile()
        {

        }

        private void Tbfilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string colName = popExcel.Uid;
            ObservableCollection<FilterObj> fltcurrent;

            if (filters.ContainsKey(colName))
            {
                filters.TryGetValue(colName, out fltcurrent);
                lbfilter.ItemsSource = fltcurrent.Where(w => w.Title.IndexOf(tbfilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

          
        }

        private void RefreshData_Click(object sender, RoutedEventArgs e)
        {
            this.dataGrid.ItemsSource = servicelocator.HomeViewModel.Products;
            this.dataGrid.Items.Refresh();

        }
    }
}

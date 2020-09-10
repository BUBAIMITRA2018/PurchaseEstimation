using Estimationtool;
using Estimationtool.Models;
using Estimationtool.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EstimationTool.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private Product _selectedProduct;

        private bool _isRefreshing;
        private  IDataStore<Product> mockdata;

        public ObservableCollection<Product> Products { get; set; }
        public ICommand LoadItemsCommand { get; set; }


        public bool IsRefreshing
        {
            get { return this._isRefreshing; }
            set { this.SetProperty(ref this._isRefreshing, value); }
        }


        public Product SelectedProduct
        {
            get { return this._selectedProduct; }
            set { this.SetProperty(ref this._selectedProduct, value); }
        }

       

        public HomeViewModel(IDataStore<Product> Mockdata)
        {
            Products = new ObservableCollection<Product>();
            mockdata = Mockdata;


            try
            {

                ExecuteLoadItemsCommand();


            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {

            }


        }

        [Inject]
        public void SetDataService(IDataStore<Product> Mockdata)
        {
            mockdata = Mockdata;
        }

        async Task ExecuteLoadItemsCommand()
        {


            try
            {
                Products.Clear();
                var items = await mockdata.GetItemsAsync();
                foreach (var item in items)
                {
                    Products.Add(item);
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {

            }



        }
    }
}

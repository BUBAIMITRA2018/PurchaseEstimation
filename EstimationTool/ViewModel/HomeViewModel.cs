using Estimationtool;
using Estimationtool.Helper;
using Estimationtool.Models;
using Estimationtool.Services;
using EstimationTool.Helper;
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
        private bool _boolfilteractivate;
        private bool _isRefreshing;
        private  IDataStore<Product> mockdata;

        public ObservableCollection<Product> Products { get; set; }
     


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


        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { this.SetProperty(ref this._isSelected, value); }
          
        }

        public bool Boolfilteractivate
        {
            get => this._boolfilteractivate;
            set
            {
                this.SetProperty(ref this._boolfilteractivate, value);
            }
        }


        private ICommand applyFilterCommand;
        public ICommand ApplyFilterCommand
        {
            get
            {
                return applyFilterCommand ?? (applyFilterCommand = new DelegateCommand<object>(X =>
                {

                    Boolfilteractivate = true;

                }));
            }
        }


        private ICommand refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {

                return refreshCommand ?? (refreshCommand = new AsyncRelayCommand(X => AsyncRefreshCommand()));

            }

        }

        private async Task AsyncRefreshCommand()
        {
            await ExecuteLoadItemsCommand();
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

        //[Inject]
        //public void SetDataService(IDataStore<Product> Mockdata)
        //{
        //    mockdata = Mockdata;
        //}

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

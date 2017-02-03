using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SuiteXamarin
{
    public partial class MainPage : ContentPage
    {
        ProductExportViewModel model = new ProductExportViewModel();
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = model;
            model.barCode = "xxxxx";
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            //this.lbResult.Text = await DataService.getDataFromService("http://www.thomas-bayer.com/sqlrest/");
            //ProductExportService service = new ProductExportService();
            //var result = await service.GetData();
            //this.lbResult.Text = result;

            ProductExportViewModel a = base.BindingContext as ProductExportViewModel;
            DisplayAlert("aaa",a.BarCode + a.ProductID + a.Description,"accca");

        }
        void OnButtonClickedCapture(object sender, EventArgs args)
        {

        }
    }
}

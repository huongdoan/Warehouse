using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

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

            //ProductExportViewModel a = base.BindingContext as ProductExportViewModel;
            //DisplayAlert("aaa", a.BarCode + a.ProductID + a.Description, "accca");

        }

        async void OnButtonClickedCapture(object sender, EventArgs args)
        {

            //setup options
            var options = new MobileBarcodeScanningOptions
            {
                AutoRotate = false,
                UseFrontCameraIfAvailable = true,
                TryHarder = true,
                PossibleFormats = new List<ZXing.BarcodeFormat>
                {
                   ZXing.BarcodeFormat.EAN_8, ZXing.BarcodeFormat.EAN_13
                }
            };

            //add options and customize page
            var scanPage = new ZXingScannerPage(options)
            {
                DefaultOverlayTopText = "Align the barcode within the frame",
                DefaultOverlayBottomText = string.Empty,
                DefaultOverlayShowFlashButton = true
            };


            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");
                    model.BarCode = result.Text;

                });
            };
            // Navigate to our scanner page
           await Navigation.PushModalAsync(scanPage);
        }
    }
}

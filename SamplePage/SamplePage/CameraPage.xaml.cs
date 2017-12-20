using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace SamplePage
{

    public partial class CameraPage : ContentPage
    {
        private String sd2;
        private int no=0;
        // ObservableCollection<string> scanedData;
        public CameraPage()
        {
            InitializeComponent();
            //  scanedData = new ObservableCollection<string>();
            // this.BindingContext = scanedData;
        }

        async void ScanButtonClicked(object sender, EventArgs s)
        {
            var scanPage = new ZXingScannerPage()
            {
                DefaultOverlayTopText = "バーコードを読み取ります",
                DefaultOverlayBottomText = "",
            };

            // スキャナページを表示
            await Navigation.PushAsync(scanPage);

            scanPage.OnScanResult += (result) =>
            {
                // スキャン停止
                scanPage.IsScanning = false;

                // PopAsyncで元のページに戻り、結果をダイアログで表示
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    // await DisplayAlert("スキャン完了", result.Text, "OK");
                });

                // scanedData.Add(result.Text);
                no += 1;
                sd2 = result.Text;
                // LOL.Text = sd2;

                var InsertName = sd2;
                //Userテーブルに適当なデータを追加する
                UserModel.insertUser(1, InsertName,no);
            };

        }

        void SelectClicked(object sender, EventArgs e)
        {
           
            
            //Userテーブルの行データを取得
            var query = UserModel.selectUser(); //中身はSELECT * FROM [User]
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {

                //Userテーブルの名前列をLabelに書き出す
              layout.Children.Add(new Label { Text = user.Id.ToString() });
              layout.Children.Add(new Label { Text = user.Name });
              //layout.Children.Add(new Label { Text = user.No.ToString() });
              // LOL.Text = user.Name;

            }
           Content = layout;
        }
    }
}
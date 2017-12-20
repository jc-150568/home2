using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SamplePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        
        // ボタンとスイッチの判定
        bool hantei1 = true;
        bool hantei2 = true;
        bool hantei3 = true;

        public DetailPage(String x)
        {
            InitializeComponent();
            Name.Text = x;
        }

        // 読みたいボタンを点滅させる
        private void OnImageClicked1(object sender, EventArgs e)
        {
            if (hantei1 == true)
            {
                this.image1.Image = "blue_book_72.png";
                hantei1 = false;
            }

            else
            {
                this.image1.Image = "gray_book_72.png";
                hantei1 = true;
            }
        }

        // お気にいりボタンを点滅させる
        private void OnImageClicked2(object sender, EventArgs e)
        {
            if (hantei2 == true)
            {
                this.image2.Image = "red_star_72.png";
                hantei2 = false;
            }

            else
            {
                this.image2.Image = "gray_star_72.png";
                hantei2 = true;
            }
        }

        // ラベルを未読⇔既読にする
        private void OnToggled(object sender, ToggledEventArgs e)
        {
            if (unread1.IsToggled == true)
            {
                this.unread2.Text = "既読";
            }
            if (unread1.IsToggled == false)
            {
                this.unread2.Text = "未読";
            }
        }
    }
}
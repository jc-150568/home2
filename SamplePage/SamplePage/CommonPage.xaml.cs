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
    public partial class CommonPage : ContentPage
    {
        public CommonPage()
        {
            InitializeComponent();
        }

        private void OnToggled(object sender, ToggledEventArgs e)
        {
            if(sw1.On == true)
            {
                DisplayAlert("おんちぇんじ", "やったー", "くそ");
            }
            else if(sw1.On == false)
            {
                DisplayAlert("やっぱり", "VisualStudio", "くたばれ");
            }
                    
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SamplePage
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Common(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CommonPage());
        }
        private void Backup(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BackupPage());
        }
        private void Help(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpPage());
        }

    }
}
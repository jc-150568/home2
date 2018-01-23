using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SamplePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {
        public ObservableCollection<Book> items = new ObservableCollection<Book>();
        public BookPage()
        {
            InitializeComponent();

            if (UserModel.selectUser() != null)
            {
                var query = UserModel.selectUser();
                ObservableCollection<Book> items = new ObservableCollection<Book>();
                var List1 = new List<String>();
                //*をリストにぶち込んで個数分addするのでもいいのでは
                foreach (var user in query)
                {
                    List1.Add(user.Title);
                }
                for (var j = 0; j < query.Count; j++)
                {
                    items.Add(new Book { Name = List1[j], /*Value = 2.5*/ });

                }
            }
            else
            {
                items.Add(new Book { Name = "空やで" });
            }

           

            /*for (var j = 1; j == query2.Count; j++)
            {                
                foreach (var user in UserModel.countUser(j))
                {
                   items.Add(new Book { Name = user.Name, Value = 2.5 });
                }
            }*/

            /*foreach (var user in query2)
            {
                List1[0] = user.Name;
            }List1.Add = List1[0];*/



            /*for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Value <= 0.25)
                {
                    items[i].ValueImage = "value_0.gif";
                }
                else if (items[i].Value <= 0.75)
                {
                    items[i].ValueImage = "value_0.5.gif";
                }
                else if (items[i].Value <= 1.25)
                {
                    items[i].ValueImage = "value_1.gif";
                }
                else if (items[i].Value <= 1.75)
                {
                    items[i].ValueImage = "value_1.5.gif";
                }
                else if (items[i].Value <= 2.25)
                {
                    items[i].ValueImage = "value_2.gif";
                }
                else if (items[i].Value <= 2.75)
                {
                    items[i].ValueImage = "value_2.5.gif";
                }
                else if (items[i].Value <= 3.25)
                {
                    items[i].ValueImage = "value_3.gif";
                }
                else if (items[i].Value <= 3.75)
                {
                    items[i].ValueImage = "value_3.5.gif";
                }
                else if (items[i].Value <= 4.25)
                {
                    items[i].ValueImage = "value_4.gif";
                }
                else if (items[i].Value <= 4.75)
                {
                    items[i].ValueImage = "value_4.5.gif";
                }
                else
                {
                    items[i].ValueImage = "value_5.gif";
                }
                if (items[i].RedStar == true)
                {
                    items[i].RedStar2 = "red_star_72.png";
                }
                if (items[i].BlueBook == true)
                {
                    items[i].BlueBook2 = "blue_book_72.png";
                }
            }*/

            BookListView.ItemsSource = items;

        }


        public class Book
        {
            public string Name { get; set; }

            public double Value { get; set; }

            public string ValueImage { get; set; }

            public bool RedStar { get; set; }

            public string RedStar2 { get; set; }

            public bool BlueBook { get; set; }

            public string BlueBook2 { get; set; }

        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            string x = BookListView.SelectedItem.ToString();
            Navigation.PushAsync(new DetailPage(x));
            /*string x = new BookPage().BookListView.ItemsSource.ToString();
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            layout.Children.Add(new Label { Text = x });
             Content = layout;*/
        }

        /// <summary>
        /// リフレッシュ時に呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnRefreshing(object sender, EventArgs e)
        {
            //2秒処理を待つ
            await Task.Delay(2000);
            items.Clear();

            if (UserModel.selectUser() != null)
            {
                var query = UserModel.selectUser();
                var List1 = new List<String>();
                //*をリストにぶち込んで個数分addするのでもいいのでは
                foreach (var user in query)
                {
                    List1.Add(user.Title);
                }
                for (var j = 0; j < query.Count; j++)
                {
                    items.Add(new Book { Name = List1[j], /*Value = 2.5*/ });

                }
            }
            else
            {
                items.Add(new Book { Name = "空やで"});
            }

            BookListView.ItemsSource = items;
            

            //リフレッシュを止める
            this.BookListView.IsRefreshing = false;
        }


    }
}
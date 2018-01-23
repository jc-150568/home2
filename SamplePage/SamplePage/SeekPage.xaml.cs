using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

using System.Security.Principal;
using System.ComponentModel;

namespace SamplePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeekPage : ContentPage
    {
        private string url;
        static string requestUrl;
        public SeekPage()
        {
            InitializeComponent();

            //formatVersion=2にした
            url = "https://app.rakuten.co.jp/services/api/BooksBook/Search/20170404?format=json&formatVersion=2&applicationId=1051637750796067320&sort=sales&hits=30";
        }
        // 親カテゴリのプルダウンに応じて子カテゴリの内容を変更する
        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            try
            {

                if (this.picker2.SelectedIndex == 0)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("少年");
                    picker3.Items.Add("少女");
                    picker3.Items.Add("青年");
                    picker3.Items.Add("レディース");
                    Serch(picker2.SelectedIndex);
                }

                if (this.picker2.SelectedIndex == 1)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("語学学習");
                    picker3.Items.Add("語学辞書");
                    picker3.Items.Add("辞典");
                    picker3.Items.Add("語学関係資格");
                    picker3.Items.Add("学習参考書・問題書");
                }

                if (this.picker2.SelectedIndex == 2)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("児童書");
                    picker3.Items.Add("自動文庫");
                    picker3.Items.Add("絵本");
                    picker3.Items.Add("民話・昔話");
                    picker3.Items.Add("しかけ絵本");
                    picker3.Items.Add("図鑑・知識");
                }


                if (this.picker2.SelectedIndex == 3)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("ミステリー・サスペンス");
                    picker3.Items.Add("SF・ホラー");
                    picker3.Items.Add("エッセイ");
                    picker3.Items.Add("ノンフィクション");
                    picker3.Items.Add("日本の小説");
                    picker3.Items.Add("外国の小説");
                }

                if (this.picker2.SelectedIndex == 4)
                {
                    picker3.Items.Clear();
                    picker3.Items.Add("ハードウェア");
                    picker3.Items.Add("入門書");
                    picker3.Items.Add("インターネット・WEBデザイン");
                    picker3.Items.Add("ネットワーク");
                    picker3.Items.Add("プログラミング");
                    picker3.Items.Add("アプリケーション");
                    picker3.Items.Add("OS");
                    picker3.Items.Add("デザイン・グラフィックス");
                    picker3.Items.Add("ITパスポート");
                    picker3.Items.Add("MOUS・MOT");
                    picker3.Items.Add("パソコン検定");
                    picker3.Items.Add("IT・eコマース");
                }


            }
            catch (Exception e)
            {
                DisplayAlert("警告", e.ToString(), "OK");
            }
        }

        //--------------------------------Serchボタンイベントハンドラ-----------------------------------
        private async void Serch(int genreid)
        {
            try
            {
                var layout2 = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
                var scroll = new ScrollView { Orientation = ScrollOrientation.Vertical };
                layout2.Children.Add(scroll);
                var layout = new StackLayout { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
                scroll.Content = layout;
                requestUrl = url + "&booksGenreId=001" + genreid; //URLにISBNコードを挿入

                //HTTPアクセスメソッドを呼び出す
                string APIdata = await GetApiAsync(); //jsonをstringで受け取る

                //HTTPアクセス失敗処理(404エラーとか名前解決失敗とかタイムアウトとか)
                if (APIdata is null)
                {
                    await DisplayAlert("接続エラー", "接続に失敗しました", "OK");
                }

                /*
                //レスポンス(JSON)をstringに変換-------------->しなくていい
                Stream s = GetMemoryStream(APIdata); //GetMemoryStreamメソッド呼び出し
                StreamReader sr = new StreamReader(s);
                string json = sr.ReadToEnd();
                */
                /*
                //デシリアライズ------------------>しなくていい
                var rakutenBooks = JsonConvert.DeserializeObject<RakutenBooks>(json.ToString());
                */

                //パースする *重要*   パースとは、文法に従って分析する、品詞を記述する、構文解析する、などの意味を持つ英単語。
                var json = JObject.Parse(APIdata); //stringのAPIdataをJObjectにパース
                var Items = JArray.Parse(json["Items"].ToString()); //Itemsは配列なのでJArrayにパース

                //結果を出力
                foreach (JObject jobj in Items)
                {
                    //↓のように取り出す
                    JValue titleValue = (JValue)jobj["title"];
                    string title = (string)titleValue.Value;

                    JValue titleKanaValue = (JValue)jobj["titleKana"];
                    string titleKana = (string)titleKanaValue.Value;

                    JValue itemCaptionValue = (JValue)jobj["itemCaption"];
                    string itemCaption = (string)itemCaptionValue.Value;

                    JValue gazoValue = (JValue)jobj["largeImageUrl"];
                    string gazo = (string)gazoValue.Value;

                    //書き出し
                    layout.Children.Add(new Label { Text = $"title: { title }" });
                    layout.Children.Add(new Label { Text = $"titleKana: { titleKana }" });
                    layout.Children.Add(new Label { Text = $"itemCaption: { itemCaption }" });
                    layout.Children.Add(new Image { Source = gazo });
                    String A = gazo;

                };
                layout.Children.Add(new Label { Text = "読み取り終了", TextColor = Color.Black });

                layout.Children.Add(new Label { Text = "" });//改行

                layout.Children.Add(new Label { Text = "JSON形式で書き出す", TextColor = Color.Red });
                layout.Children.Add(new Label { Text = json.ToString() });

                Content = layout2;
            }
            catch (Exception x) { await DisplayAlert("警告", x.ToString(), "OK"); }
        }


        //HTTPアクセスメソッド
        public static async Task<string> GetApiAsync()
        {
            string APIurl = requestUrl;

            using (HttpClient client = new HttpClient())
                try
                {
                    string urlContents = await client.GetStringAsync(APIurl);
                    await Task.Delay(1000); //1秒待つ(楽天API規約に違反するため)
                    return urlContents;
                }
                catch (Exception e)
                {
                    string a = e.ToString();
                    return null;
                }
        }
    }
}
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
    public partial class SeekPage : ContentPage
    {
        public SeekPage()
        {
            InitializeComponent();
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
    }
}
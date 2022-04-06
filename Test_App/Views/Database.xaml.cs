using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test_App.Views
{
    /// <summary>
    /// Interaktionslogik für Database.xaml
    /// </summary>
    public partial class Database : Page
    {

        public Database()
        {
            InitializeComponent();

            OutputJson();

        }
        public void OutputJson()

        {
            string json = "";
            var webclient = new System.Net.WebClient();
            webclient.Encoding = Encoding.UTF8;
            try
            {
                json = webclient.DownloadString("https://git.weifer.org/weifer/Test_App/raw/branch/master/Test_App/Ressources/data.json");
            }
            catch
            {
                MainWindow.status.Fill = Brushes.Red;
                MessageBox.Show("Server nicht erreichbar");
            }


            datalist.ItemsSource = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ressources.Datas>>(json);
        }

        private void border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.Background = new SolidColorBrush(Colors.LightGray);
        }

        private void border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.Background = new SolidColorBrush(Colors.WhiteSmoke);
        }

        private void itemOnClick(object sender, MouseButtonEventArgs e)
        {
            Ressources.Datas current = datalist.SelectedItem as Ressources.Datas;
            Database_Info window = new Database_Info();
            window.Show();
            
            
            /*TextBox textBox = new TextBox();
            textBox.Style = (Style)FindResource("Custom_Window");
            textBox.Text = "Antwort: \n" + current.Answer + "\n";

            Window window = new Window();
            window.Width = 550;
            window.Height = 300;
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Content = textBox;
            window.Show();*/
        }
    }
}




using System;
using System.Collections.Generic;
using System.Configuration;
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
        public string content { get; set; }
        public Database()
        {
            InitializeComponent();

            OutputJson();

        }
        // Parst Json von der Webseite in eine Liste
        public void OutputJson()

        {
            string json = "";
            var webclient = new System.Net.WebClient();
            webclient.Encoding = Encoding.UTF8;
            try
            {
                json = webclient.DownloadString(ConfigurationManager.AppSettings.Get("JsonUrl"));
            }
            catch
            {
                MainWindow.status.Fill = Brushes.Red;
                MessageBox.Show("Server nicht erreichbar!");
            }

            datalist.ItemsSource = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ressources.Datas>>(json);
        }
        // Ändert die Hintergrundfarbe beim betreten mit der Maus
        private void border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.Background = new SolidColorBrush(Colors.LightGray);
        }
        // Ändert die Hintergrundfarbe beim verlassen der Maus
        private void border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            border.Background = new SolidColorBrush(Colors.WhiteSmoke);
        }
        // Öffnet neues Fenster (Database_Info) und übergibt die Antwort als string 
        private void itemOnClick(object sender, MouseButtonEventArgs e)
        {
            Ressources.Datas current = datalist.SelectedItem as Ressources.Datas;
            content = current.Answer;
            Database_Info window = new Database_Info(content);
            window.Show();
        }

    }
}





using Newtonsoft.Json;
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
    /// Interaktionslogik für Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        string json_url = ConfigurationManager.AppSettings.Get("JsonUrl"); //  Json File
        string get_questions = "";
        string get_answer = "";

        List<Ressources.Datas> dataList = new List<Ressources.Datas>();
        public Start()
        {
            InitializeComponent();
            //liste();
            get_jsonData(json_url);
        }
        // ### Buttons ###

        // Gibt eine Zufallsfrage aus
        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            get_question();
            question_textbox.Text = get_questions;
            answer_textbox.Text = "";
        }
        // Gibt antwort auf Zufallsfrage aus
        private void Get_Answer_Button(object sender, RoutedEventArgs e)
        {
            if (get_answer.Length < 100)
            {
                answer_textbox.FontSize = 20;
                answer_textbox.Text = get_answer;
            }
            answer_textbox.Text = get_answer;
        }

        // Convertiert Json von der Url in ein Listenobjekt
        private void get_jsonData(string url)
        {
            string json = "";
            var webclient = new System.Net.WebClient();
            webclient.Encoding = Encoding.UTF8; // Damit umlaute angezeigt werde
            try
            {
                json = webclient.DownloadString(url);
            }
            catch
            {
                var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
                window.Close();
                MessageBox.Show("Keine Verbindung zum Server möglich. Versuche es Später nocheinmal");

            }
            dataList = JsonConvert.DeserializeObject<List<Ressources.Datas>>(json);

        }
        // Erstellt die Zufallsfrage, entfernt sie dann von der Liste
        private void get_question()
        {
            int random_number = new Random().Next(0, dataList.Count); // Generiert eine Zufallsindex
          
            get_questions = dataList.ElementAt(random_number).Question; 
            get_answer = dataList.ElementAt(random_number).Answer;
            dataList.RemoveAt(random_number);

            // Wenn alle Fragen durch sind
            if (!dataList.Any())
            {
                MessageBox.Show("Alle Fragen erreicht!");
            }
        }


    }
}


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
        List<int> list = new List<int>();
        public Start()
        {
            InitializeComponent();
            liste();

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


        // Convertiert Json von der Url
        dynamic get_jsonData(string url)
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
            dynamic dynJson = JsonConvert.DeserializeObject(json);
            return dynJson;

        }
        // Erstellt die Zufallsfrage
        public void get_question()
        {
       
            dynamic json_data = get_jsonData(json_url);
            int random_number_counter = new Random().Next(0, list.Count); // Generiert eine Zufallsindex
            int random_number = list.ElementAt(random_number_counter); // Gibt die Zahl am Listindex aus
            
            get_questions = json_data[random_number]["Question"];
            get_answer = json_data[random_number]["Answer"];

            list.RemoveAt(random_number_counter); // Entfernt die Zahl aus der Liste um Wiederholungen zu vermeiden

            if (!list.Any())
            {
                MessageBox.Show("Alle Fragen erreicht!");
            }
        }

        // Erstellen der Zahlen Liste für die Zufallszahl
        public void liste()
        {
            dynamic json_data = get_jsonData(json_url);
            int count = json_data.Count;

            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }
        }
    }
}

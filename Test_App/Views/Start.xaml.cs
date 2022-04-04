
using Newtonsoft.Json;
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
    /// Interaktionslogik für Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        string json_url = "https://git.weifer.org/weifer/Pruefungskatalog/raw/branch/master/assets/questions_answers.json";

        string get_questions = "";
        string get_answer = "";
        //dynamic data = null;
        public Start()
        {
            InitializeComponent();
            // data = get_jsonData(json_url);
        }
        // Buttons
        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            get_question();
            question_textbox.Text = get_questions;
            answer_textbox.Text = "";
        }
        private void Get_Answer_Button(object sender, RoutedEventArgs e)
        {
            if (get_answer.Length < 100)
            {
                answer_textbox.FontSize = 20;
                answer_textbox.Text = get_answer;
            }
            answer_textbox.Text = get_answer;
        }


        // Json
        dynamic get_jsonData(string url)
        {
            string json = "";
            var webclient = new System.Net.WebClient();
            webclient.Encoding = Encoding.UTF8;
            try
            {
                json = webclient.DownloadString(url);
            }
            catch (System.Net.WebException e)
            {
                throw e;
            }
            dynamic dynJson = JsonConvert.DeserializeObject(json);
            return dynJson;

        }
        // Returns random String from a Random Json Object in JsonData
        public void get_question()
        {

            dynamic json_data = get_jsonData(json_url);
            int count = json_data.Count; // Count Json Objects
            int random_number = new Random().Next(0, 40); // Random number between 0, and all Json Objects
            get_questions = json_data[random_number][$"{random_number}"]["question"];

            get_answer = json_data[random_number][$"{random_number}"]["answer"];


        }

        private void question_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

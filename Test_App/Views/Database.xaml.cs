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
            catch (System.Net.WebException e)
            {
                throw e;
            }


            datalist.ItemsSource = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ressources.Datas>>(json);
        }

    }
}



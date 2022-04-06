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
using System.Windows.Shapes;

namespace Test_App.Views
{
    /// <summary>
    /// Interaktionslogik für Database_Info.xaml
    /// </summary>
    public partial class Database_Info : Window
    {
        public Database_Info(string text)
        {
            InitializeComponent();
            SetTextBlockText(text);
        }
        // Macht das fenster mit linkem Mausklick verschiebbar
        private void Drag_Window(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();

        }
        // Wird dem X Button zugewiesen um das Fenster zu schließen
        private void close_window(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            window.Close();
        }

        // Wird bei Fenster aufruf ausgeführt um den Parameter einzusetzen
        public void SetTextBlockText(string text)
        { 
            database_info_textblock.Text = text;
        }
    }
}

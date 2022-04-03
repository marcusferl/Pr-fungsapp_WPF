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

namespace Test_App
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(new Views.HomeView());

        }
      

        // Buttons
        private void home_on_click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Views.HomeView());
        }

        private void start_on_click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Views.Start());
        }

        private void exit_on_click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void datenbank_on_click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Views.Database());
        }

        private void info_on_click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Views.Info());
        }

        private void Drag_Window(object sender, MouseButtonEventArgs e)
        {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
         
        }


        // Json Parser

    }
}

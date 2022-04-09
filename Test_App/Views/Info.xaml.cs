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
    /// Interaktionslogik für Info.xaml
    /// </summary>
    public partial class Info : Page
    {
        public Info()
        {
            InitializeComponent();
            block.Text = "Diese App beinhaltet mögliche Prüfungsfragen zum Teil 1 der Abschlussprüfung.\n" + 
                "\nDie Fragen stammen aus einer Offiziellen Quelle sind abgeändert und sind sehr nah an die echten Prüfungsfragen angelehnt.\n\n" +
                "Die Fragen Datenbank ist hierbei Dynamisch, die Fragen und Antworten werden von einem Server abgerufen, deswegen ist eine Internetverbindung wichtig.\n\n" +
                "Bis zum Sommer 2022 werde ich alle Fragen zum Teil 1 der Abschlussprüfung hinzufügen.\n" +
                "Bis zum Sommer 2023 werde ich die Fragen mit Prüfungsrelevanten Fragen zur Abschlussprüfung Teil 2 ergänzen.\n\n" +
                "Bei Fragen, wendet euch an mich im FIAE Discord\n" +
                "Marcus Ferl\n\n" +
                "Oder eine Email an:\n" +
                "support@weifer.de\n" +
                "\nFalls jemand meine Arbeit unterstützen will, (die Fragen waren nicht kostenlos):\n\n" +
                "Paypal: marcus@weifer.de\n" +
                "Bitcoin: 17ruVoy3NXooM5yRbva9Kz898hB75XYqtx\n";

        }

    }
}


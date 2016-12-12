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

namespace SmartVideo
{
    /// <summary>
    /// Interaction logic for ChoixDialog.xaml
    /// </summary>
    public partial class ChoixDialog : Window
    {
        MainWindow parent;

        public ChoixDialog(MainWindow d)
        {
            InitializeComponent();
            parent = d;

        }

        private void OkSiteButton_Click(object sender, RoutedEventArgs e)
        {
            String NameBase = (string)BaseComboBox.Text;

            if (NameBase != null)
            {
                if (NameBase == "Chiroux")
                    parent.setNameBase("BD_VIDEOTHEQUE_LIEGE");
                else
                    parent.setNameBase("BD_VIDEOTHEQUE_WAREMME");
            }

            this.Close();
            
            parent.Visibility = Visibility.Visible;
            parent.Connexion();
        }
    }
}

using BLLBDVideo;
using System.Windows;
using DTOFilm;
using System.Collections.Generic;
using SmartVideo.MyWCFService;

namespace SmartVideo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BLLBDVid BLLVid;
        private SmartWCFServiceClient AccessBD;
        private string name_base;

        public MainWindow()
        {
            InitializeComponent();
            ChoixDialog ChoixFrame = new ChoixDialog(this);
            ChoixFrame.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
            AccessBD = new SmartWCFServiceClient();
            LocationButton.IsEnabled = false;
           

        }

        public void setNameBase(string bd)
        {
            name_base = bd;
        }

        public void Connexion()
        {

            List<FilmDTO> MyMovies,MyMovieBDLocale;


            MyMovies = AccessBD.SelectAllFilm();
            FilmDataGridView.ItemsSource = MyMovies;
            //FilmDataGridView.Columns[4].Visibility = Visibility.Hidden;
            /*FilmDataGridView.Columns[4].Visibility = Visibility.Hidden;
            FilmDataGridView.Columns[5].Visibility = Visibility.Hidden;
            FilmDataGridView.Columns[6].Visibility = Visibility.Hidden;
            FilmDataGridView.Columns[7].Visibility = Visibility.Hidden;
            FilmDataGridView.Columns[8].Visibility = Visibility.Hidden;*/
            LocationButton.IsEnabled = true;
            
            
                
            BLLVid = new BLLBDVid("LAPTOP-IQTHKHPT\\SQLEXPRESS", name_base);

            

            MyMovieBDLocale = BLLVid.SelectAllFilm();
            FilmBdLocalDataGrid.ItemsSource = MyMovieBDLocale;
            FilmBdLocalDataGrid.Columns[4].Visibility = Visibility.Hidden;
            //FilmDataGridView.Columns[5].Visibility = Visibility.Hidden;
            //FilmBdLocalDataGrid.Columns[6].Visibility = Visibility.Hidden;
            //FilmBdLocalDataGrid.Columns[7].Visibility = Visibility.Hidden;
            //FilmBdLocalDataGrid.Columns[8].Visibility = Visibility.Hidden;
            
            
        }

        private void LocationButton_Click(object sender, RoutedEventArgs e)
        {
            FilmDTO temp = (FilmDTO) FilmDataGridView.SelectedItem;
            BLLVid = new BLLBDVid("LAPTOP-IQTHKHPT\\SQLEXPRESS", name_base);

            bool success = BLLVid.InsertNewFilm(temp);
            if(success)
            {
                MessageBox.Show("Film en demande de location !", "Message");
            }
            else
            {
                MessageBox.Show("Erreur lors de la demande de locarion", "Message");
            }

        }
    }
}

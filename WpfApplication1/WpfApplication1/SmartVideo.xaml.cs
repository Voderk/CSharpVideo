using BLLBDVideo;
using System.Windows;
using DTOFilm;
using System.Collections.Generic;

using WpfApplication1.MyWCFService;
using System.ComponentModel;
using System.Windows.Media.Imaging;

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
        private int LocalMax;
        private int GlobalMax;
        int GlobalmaxPage, LocalmaxPage;
        List<FilmDTO> MyMovies, MyMovieBDLocale;
        DetailsFilm DF = new DetailsFilm();
        

        public MainWindow()
        {
            AccessBD = new SmartWCFServiceClient();
            InitializeComponent();
            ChoixDialog ChoixFrame = new ChoixDialog(this);
            ChoixFrame.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
           
            LocationButton.IsEnabled = false;
            this.Icon = new BitmapImage(new System.Uri(@"../../icone-video-2.png",System.UriKind.Relative));
                //(@"C:\Users\Gauvain Klug\CSharpVideo\WpfApplication1\WpfApplication1\icone-video-2.png", System.UriKind.Absolute));

        }

        public void setNameBase(string bd)
        {
            name_base = bd;
        }

        public void Connexion()
        {


            GlobalMax = AccessBD.SelectCountFilm();

            GlobalCurrent.Text = "1";
            GlobalmaxPage = GlobalMax / 50;
            if (GlobalMax % 50 != 0)
                GlobalmaxPage++;
            GlobalMaxLabel.Content = "/ " + GlobalmaxPage ;
            MyMovies = AccessBD.SelectSomeMovies(50, int.Parse(GlobalCurrent.Text)-1);
            FilmDataGridView.ItemsSource = MyMovies;
            LocationButton.IsEnabled = true;
                
            BLLVid = new BLLBDVid("LEOPARDGK\\SQLEXPRESS", name_base);

            LocalMax = BLLVid.SelectCountFilm();
            LocalmaxPage = LocalMax / 50;
            if (LocalMax % 50 != 0)
                LocalmaxPage++;

            LocalCurrent.Text = "1";
            LocalMaxLabel.Content = "/ " + LocalmaxPage;
            MyMovieBDLocale = BLLVid.SelectSomeMovies(50, int.Parse(LocalCurrent.Text)-1);
            FilmBdLocalDataGrid.ItemsSource = MyMovieBDLocale;            
        }

        private void LocationButton_Click(object sender, RoutedEventArgs e)
        {
            FilmDTO temp = (FilmDTO) FilmDataGridView.SelectedItem;
            BLLVid = new BLLBDVid("LEOPARDGK\\SQLEXPRESS", name_base);

            
            bool success = BLLVid.InsertNewFilm(temp);
            if(success)
            {
                MessageBox.Show("Film en demande de location !", "Message");

                LocalMax = BLLVid.SelectCountFilm();
                LocalmaxPage = LocalMax / 50;
                if (LocalMax % 50 != 0)
                    LocalmaxPage++;
                MyMovieBDLocale = BLLVid.SelectSomeMovies(50, int.Parse(LocalCurrent.Text) - 1);
                FilmBdLocalDataGrid.ItemsSource = MyMovieBDLocale;
            }
            else
            {
                MessageBox.Show("Erreur lors de la demande de locarion", "Message");
            }

        }

        private void GlobalPrevBT_Click(object sender, RoutedEventArgs e)
        {
            int page = (int.Parse(GlobalCurrent.Text) - 1);
            GlobalCurrent.Text = page.ToString();
        }

        private void GlobalCurrent_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            /*if (int.Parse(GlobalCurrent.Text) < 1)
                GlobalCurrent.Text = "1";
            if (int.Parse(GlobalCurrent.Text) > GlobalmaxPage)
                GlobalCurrent.Text = GlobalmaxPage.ToString();*/

            if(int.Parse(GlobalCurrent.Text) == 1)
            {
                GlobalPrevBT.IsEnabled = false;
            }
            else
            {
                GlobalPrevBT.IsEnabled = true;
            }
            if(int.Parse(GlobalCurrent.Text) == GlobalmaxPage)
            {
                GlobalNextBT.IsEnabled = false;
            }
            else
            {
                GlobalNextBT.IsEnabled = true;
            }

            MyMovies = AccessBD.SelectSomeMovies(50, int.Parse(GlobalCurrent.Text)-1);
            FilmDataGridView.ItemsSource = MyMovies;
            FilmDataGridView_Loaded(this, new RoutedEventArgs());
        }

        private void GlobalNextBT_Click(object sender, RoutedEventArgs e)
        {
            int page = (int.Parse(GlobalCurrent.Text) + 1);
            GlobalCurrent.Text = page.ToString();
        }



        private void LocalCurrent_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            /*if (int.Parse(LocalCurrent.Text) < 1)
                LocalCurrent.Text = "1";
            if (int.Parse(LocalCurrent.Text) > LocalmaxPage)
                LocalCurrent.Text = LocalmaxPage.ToString();*/

            if (int.Parse(LocalCurrent.Text) == 1)
            {
                LocalPrevBT.IsEnabled = false;
            }
            else
            {
                LocalPrevBT.IsEnabled = true;
            }
            if (int.Parse(LocalCurrent.Text) == LocalmaxPage)
            {
                LocalNextBT.IsEnabled = false;
            }
            else
            {
                LocalNextBT.IsEnabled = true;
            }
            BLLVid = new BLLBDVid("LEOPARDGK\\SQLEXPRESS", name_base);

            MyMovieBDLocale = BLLVid.SelectSomeMovies(50, int.Parse(LocalCurrent.Text) - 1);
            //FilmBdLocalDataGrid.ItemsSource = MyMovieBDLocale;
            //FilmBdLocalDataGrid_Loaded(this, new RoutedEventArgs());
        }

        private void FilmDataGridView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(FilmDataGridView.SelectedItem != null)
            {
                LocationButton.IsEnabled = true;
                FilmBdLocalDataGrid.SelectedItem = null;
            }
            
        }

        private void FilmBdLocalDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(FilmBdLocalDataGrid.SelectedItem != null)
            {
                LocationButton.IsEnabled = false;
                FilmDataGridView.SelectedItem = null;
            }
        }

        private void FilmBdLocalDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            /*FilmBdLocalDataGrid.Columns[4].Visibility = Visibility.Hidden;
            //FilmDataGridView.Columns[5].Visibility = Visibility.Hidden;
            FilmBdLocalDataGrid.Columns[6].Visibility = Visibility.Hidden;
            FilmBdLocalDataGrid.Columns[7].Visibility = Visibility.Hidden;
            FilmBdLocalDataGrid.Columns[8].Visibility = Visibility.Hidden;*/
        }

        private void FilmDataGridView_Loaded(object sender, RoutedEventArgs e)
        {
            /*FilmDataGridView.Columns[4].Visibility = Visibility.Hidden;
            FilmDataGridView.Columns[5].Visibility = Visibility.Hidden;
            FilmDataGridView.Columns[6].Visibility = Visibility.Hidden;
            FilmDataGridView.Columns[7].Visibility = Visibility.Hidden;
            FilmDataGridView.Columns[8].Visibility = Visibility.Hidden;*/
        }

        private void DetailMovieButton_Click(object sender, RoutedEventArgs e)
        {
            FilmDTO temp = (FilmDTO)FilmDataGridView.SelectedItem;
            if (temp == null)
            {
                temp = (FilmDTO)FilmBdLocalDataGrid.SelectedItem;
                if(temp == null)
                {
                    MessageBox.Show("Aucun Film Sélectionné");
                }
                else
                {
                    BLLVid = new BLLBDVid("LEOPARDGK\\SQLEXPRESS", name_base);
                    DF.Film = temp;
                    DF.FilmListActeurs = BLLVid.SelectActeurFilm(temp.Id);
                    DF.FilmListGenre = BLLVid.SelectGenreFilm(temp.Id);
                    DF.FilmListRealisateurs = BLLVid.SelectRealisateurFilm(temp.Id);
                    DF.Show();
                    DF.Focus();
                }
            }
            else
            {
                DF.Film = temp;
                DF.FilmListActeurs = AccessBD.SelectActeurFilm(temp.Id);
                DF.FilmListGenre = AccessBD.SelectGenreFilm(temp.Id);
                DF.FilmListRealisateurs = AccessBD.SelectRealisateurFilm(temp.Id);
                DF.Show();
                DF.Focus();
            }
        }

        private void LocalNextBT_Click(object sender, RoutedEventArgs e)
        {
            int page = (int.Parse(LocalCurrent.Text) + 1);
            LocalCurrent.Text = page.ToString();
        }

        private void LocalPrevBT_Click(object sender, RoutedEventArgs e)
        {
            int page = (int.Parse(LocalCurrent.Text) - 1);
            LocalCurrent.Text = page.ToString();
        }
    }
}

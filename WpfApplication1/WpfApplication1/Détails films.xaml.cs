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
using DTOFilm;


namespace SmartVideo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DetailsFilm : Window
    {
        public DetailsFilm()
        {
            InitializeComponent();
            this.Icon = new BitmapImage(new System.Uri(@"../../icone-video-2.png", System.UriKind.Relative));
        }
        public FilmDTO Film
        {
            set
            {
                PosterImage = value.Posterpath;
                FilmTitle = value.Title;
                FilmOriginalTitre = value.Original_title;
                FilmRuntime = (value.Runtime).ToString() + " minutes";
                if (value.Statut != null)
                {
                    FilmStatus = value.Statut.ToString();
                }
                else
                {
                    FilmStatus = "";
                }
                       
            }
        }
        private String PosterImage
        {
            set
            {
                if (value != null && !value.Equals(""))
                    Poster.Source = new BitmapImage(new Uri("http://image.tmdb.org/t/p/w185" + value));
                else
                {
                    Poster.Source = new BitmapImage(new Uri("https://ugotalksalot.files.wordpress.com/2016/06/no-thumb.jpg"));
                    Poster.Stretch = Stretch.Uniform;
                }
            }
        }
        private String FilmTitle {
            set
            {
                RealTitre.Content = value;
            }
        }
        private String FilmOriginalTitre
        {
            set
            {
                RealOriginalTitre.Content = value;
            }
        }
        private String FilmRuntime
        {
            set
            {
                RealRuntime.Content = value;
            }
        }
        private String FilmStatus
        {
            set
            {
                if (!value.Equals(""))
                    LabelStatut.Content = "Statut";
                else
                    LabelStatut.Content = "";
                RealStatus.Content = value;
            }
        }
        public List<ActeurDTO> FilmListActeurs
        {
            set
            {
                List<string> tempstr = new List<string>();
                foreach(ActeurDTO a in value)
                {
                    tempstr.Add(a.Name);
                }
                ListeActeurs.ItemsSource = tempstr;
            }
        }
        public List<RealisateurDTO> FilmListRealisateurs
        {
            set
            {
                List<string> tempstr = new List<string>();
                foreach (RealisateurDTO a in value)
                {
                    tempstr.Add(a.Name);
                }
                ListRealisateurs.ItemsSource = tempstr;
            }
        }
        public List<GenreDTO> FilmListGenre
        {
            set
            {
                List<string> tempstr = new List<string>();
                foreach (GenreDTO a in value)
                {
                    tempstr.Add(a.Name);
                }
                ListeGenres.ItemsSource = tempstr;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}

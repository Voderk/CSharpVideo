using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOFilm
{
    public class FilmDTO
    {
        private List<GenreDTO> _genrelist;
        private List<RealisateurDTO> _realisateurlist;
        private List<ActeurDTO> _acteurlist;

        private int _id;
        private string _title;
        private string _original_title;
        private int _runtime;
        private string _posterpath;
        private StatutDTO _statut;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public string Original_title
        {
            get
            {
                return _original_title;
            }

            set
            {
                _original_title = value;
            }
        }

        public int Runtime
        {
            get
            {
                return _runtime;
            }

            set
            {
                _runtime = value;
            }
        }

        public string Posterpath
        {
            get
            {
                return _posterpath;
            }

            set
            {
                _posterpath = value;
            }
        }

        public StatutDTO Statut
        {
            get
            {
                return _statut;
            }

            set
            {
                _statut = value;
            }
        }

        public List<GenreDTO> Genrelist
        {
            get
            {
                return _genrelist;
            }

            set
            {
                _genrelist = value;
            }
        }

        public List<RealisateurDTO> Realisateurlist
        {
            get
            {
                return _realisateurlist;
            }

            set
            {
                _realisateurlist = value;
            }
        }

        public List<ActeurDTO> Acteurlist
        {
            get
            {
                return _acteurlist;
            }

            set
            {
                _acteurlist = value;
            }
        }

        public FilmDTO()
        {
            Genrelist = new List<GenreDTO>();
            Realisateurlist = new List<RealisateurDTO>();
            Acteurlist = new List<ActeurDTO>();
        }

        
        public void AfficheFilm()
        {
            Console.WriteLine("ID : " + Id + " Titre: " + Title + " Original_Title : " + Original_title + " Runtime: " + Runtime);
            Console.WriteLine("Genres: ");
            if (Genrelist.Count != 0)
            {
                foreach (GenreDTO s in Genrelist)
                {
                    Console.WriteLine(s.Name);
                }
            }

            Console.WriteLine("Realisateurs: ");
            if (Realisateurlist.Count != 0)
            {
                foreach (RealisateurDTO s in Realisateurlist)
                {
                    Console.WriteLine(s.Name);
                }
            }

            Console.WriteLine("Acteurs: ");
            if (Acteurlist.Count != 0)
            {
                foreach (ActeurDTO s in Acteurlist)
                {
                    Console.WriteLine(s.Name);
                }
            }
        }
    }
}

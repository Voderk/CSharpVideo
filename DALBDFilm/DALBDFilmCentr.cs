using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOFilm;

namespace DALBDFilm
{
    public class DALBDFilmCentr
    {
        FilmDBManagementDataContext context = null;

        private static DALBDFilmCentr _instance;

        public static DALBDFilmCentr Singleton(String servername, String dbname)
        {
            return _instance ?? (_instance = new DALBDFilmCentr(servername, dbname));
        }
        private DALBDFilmCentr(String servername, String dbname)
        {
            if (dbname == null || dbname == "")
                context = new FilmDBManagementDataContext();
            else
            {
                String connectionstring = "Data Source = " + servername + " ; Initial Catalog =" + dbname + "; Integrated Security = True";
                context = new FilmDBManagementDataContext(connectionstring);
                if (!context.DatabaseExists())  // Vérifier si la DB existe
                    context.CreateDatabase();   // Si elle n'existe pas, on la crée
            }
        }

        #region Select
        public FilmDTO SelectFilm(int idFilm)
        {
            FilmDTO MyMovie = new FilmDTO();
            var query = from d in context.Films
                        where d.id == idFilm
                        select d;

            foreach (var a in query)
            {
                MyMovie.Id = a.id;
                MyMovie.Title = a.title;
                MyMovie.Original_title = a.original_title;
                MyMovie.Runtime = (int)a.runtime;
                MyMovie.Posterpath = a.posterpath;
            }

            return MyMovie;
        }

        public FilmDTO SelectFilm(String title)
        {
            FilmDTO MyMovie = new FilmDTO();
            var query = from d in context.Films
                        where d.title == title
                        select d;

            foreach (var a in query)
            {
                MyMovie.Id = a.id;
                MyMovie.Title = a.title;
                MyMovie.Original_title = a.original_title;
                MyMovie.Runtime = (int)a.runtime;
                MyMovie.Posterpath = a.posterpath;
            }

            return MyMovie;
        }

        public ActeurDTO SelectActeur(int IDActor)
        {
            ActeurDTO MyActor = new ActeurDTO();
            var query = from d in context.Actors
                        where d.id == IDActor
                        select d;

            foreach (var a in query)
            {
                MyActor.ID = a.id;
                MyActor.Name = a.name;
            }

            return MyActor;
        }

        public ActeurDTO SelectActeur(String Name)
        {
            ActeurDTO MyActor = new ActeurDTO();
            var query = from d in context.Actors
                        where d.name == Name
                        select d;

            foreach (var a in query)
            {
                MyActor.ID = a.id;
                MyActor.Name = a.name;
            }

            return MyActor;
        }

        public RealisateurDTO SelectRealisateur(int IDRealisateur)
        {
            RealisateurDTO MyRealisateur = new RealisateurDTO();
            var query = from d in context.Realisateurs
                        where d.id == IDRealisateur
                        select d;

            foreach (var a in query)
            {
                MyRealisateur.ID = a.id;
                MyRealisateur.Name = a.name;
            }

            return MyRealisateur;
        }

        public RealisateurDTO SelectRealisateur(String Name)
        {
            RealisateurDTO MyRealisateur = new RealisateurDTO();
            var query = from d in context.Realisateurs
                        where d.name == Name
                        select d;

            foreach (var a in query)
            {
                MyRealisateur.ID = a.id;
                MyRealisateur.Name = a.name;
            }

            return MyRealisateur;
        }

        public GenreDTO SelectGenre(int IDGenre)
        {
            GenreDTO MyGenre = new GenreDTO();
            var query = from d in context.Genres
                        where d.id == IDGenre
                        select d;

            foreach (var a in query)
            {
                MyGenre.ID = a.id;
                MyGenre.Name = a.name;
            }

            return MyGenre;
        }

        public GenreDTO SelectGenre(String Name)
        {
            GenreDTO MyGenre = new GenreDTO();
            var query = from d in context.Genres
                        where d.name == Name
                        select d;

            foreach (var a in query)
            {
                MyGenre.ID = a.id;
                MyGenre.Name = a.name;
            }

            return MyGenre;
        }

        public List<FilmDTO> SelectSomeMovies(int number, int skip)
        {

            List<FilmDTO> MyMovies = new List<FilmDTO>();
            FilmDTO temp;
            var query = ((from d in context.Films
                          select d).Skip(number * skip)).Take(number);

            foreach (var a in query)
            {
                temp = new FilmDTO();
                temp.Id = a.id;
                temp.Title = a.title;
                temp.Original_title = a.original_title;
                temp.Runtime = (int)a.runtime;
                temp.Posterpath = a.posterpath;
                MyMovies.Add(temp);
            }

            return MyMovies;
        }


        #endregion

        #region SelectAll
        public List<FilmDTO> SelectAllFilm()
        {
            List<FilmDTO> MyMovies = new List<FilmDTO>();
            FilmDTO temp;

            var query = (from d in context.Films
                         select d);
            

            foreach (var a in query)
            {
                temp = new FilmDTO();
                temp.Id = a.id;
                temp.Title = a.title;
                temp.Original_title = a.original_title;
                temp.Runtime = (int)a.runtime;
                temp.Posterpath = a.posterpath;
                MyMovies.Add(temp);
            }

            return MyMovies;
        }

        public List<GenreDTO> SelectAllGenre()
        {
            List<GenreDTO> MyGenres = new List<GenreDTO>();
            GenreDTO temp;
            var query = from d in context.Genres
                        select d;

            foreach (var a in query)
            {
                temp = new GenreDTO(a.id, a.name);
                MyGenres.Add(temp);
            }

            return MyGenres;
        }

        public List<RealisateurDTO> SelectAllRealisateur()
        {
            List<RealisateurDTO> MyRealisators = new List<RealisateurDTO>();
            RealisateurDTO temp;
            var query = from d in context.Realisateurs
                        select d;

            foreach (var a in query)
            {
                temp = new RealisateurDTO(a.id, a.name);
                MyRealisators.Add(temp);
            }

            return MyRealisators;
        }

        public List<ActeurDTO> SelectAllActeur()
        {
            List<ActeurDTO> MyActors = new List<ActeurDTO>();
            ActeurDTO temp; 
            var query = from d in context.Actors
                        select d;
            
            foreach(var a in query)
            {
                temp = new ActeurDTO(a.id,a.name);
                MyActors.Add(temp);
            }

            return MyActors;
        }

        public int SelectCountFilm()
        {
            var query = (from d in context.Films
                         select d).Count();

            return query;
        }

        #endregion

        #region SelectPerFilm
        public List<ActeurDTO> SelectActeurFilm(int IDFilm)
        {
            List<ActeurDTO> MyActors = new List<ActeurDTO>();
            ActeurDTO temp;
            var query = from d in context.Actors
                        join MovieActor in context.FilmActors
                        on d.id equals MovieActor.id_actor
                        where MovieActor.id_film == IDFilm
                        select d;

            foreach (var a in query)
            {

                temp = new ActeurDTO(a.id,a.name);
                MyActors.Add(temp);
            }

            return MyActors;
        }


        public List<RealisateurDTO> SelectRealisateurFilm(int IDFilm)
        {
            List<RealisateurDTO> MyRealisators = new List<RealisateurDTO>();
            RealisateurDTO temp;
            var query = from d in context.Realisateurs
                        join MovieReal in context.FilmRealisateurs
                        on d.id equals MovieReal.id_realisateur
                        where MovieReal.id_film == IDFilm
                        select d;

            foreach (var a in query)
            {

                temp = new RealisateurDTO(a.id, a.name);
                MyRealisators.Add(temp);
            }

            return MyRealisators;
        }

        public List<GenreDTO> SelectGenreFilm(int IDFilm)
        {
            List<GenreDTO> MyRealisators = new List<GenreDTO>();
            GenreDTO temp;
            var query = from d in context.Genres
                        join MovieGenre in context.FilmGenres
                        on d.id equals MovieGenre.id_genre
                        where MovieGenre.id_film == IDFilm
                        select d;

            foreach (var a in query)
            {
                temp = new GenreDTO(a.id, a.name);
                MyRealisators.Add(temp);
            }

            return MyRealisators;
        }
        #endregion

        #region SelectFilmPerCategory
        public List<FilmDTO> SelectFilmPerActor(int IDActor)
        {
            List<FilmDTO> MyMovies = new List<FilmDTO>();
            FilmDTO temp;
            var query = from d in context.FilmActors
                        where d.id_actor == IDActor
                        select d;

            foreach (var a in query)
            {
                temp = SelectFilm(a.id_film);
                MyMovies.Add(temp);
            }

            return MyMovies;
        }

        public List<FilmDTO> SelectFilmPerRealisateur(int IDReal)
        {
            List<FilmDTO> MyMovies = new List<FilmDTO>();
            FilmDTO temp;
            var query = from d in context.FilmRealisateurs
                        where d.id_realisateur == IDReal
                        select d;

            foreach (var a in query)
            {
                temp = SelectFilm(a.id_film);
                MyMovies.Add(temp);
            }

            return MyMovies;
        }

        public List<FilmDTO> SelectFilmPerGenre(int IDGenre)
        {
            List<FilmDTO> MyMovies = new List<FilmDTO>();
            FilmDTO temp;
            var query = from d in context.FilmGenres
                        where d.id_genre == IDGenre
                        select d;

            foreach (var a in query)
            {
                temp = SelectFilm(a.id_film);
                MyMovies.Add(temp);
            }

            return MyMovies;
        }
        #endregion


    }
}

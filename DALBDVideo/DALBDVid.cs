using DTOFilm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBDVideo
{
    public class DALBDVid
    {
        FilmDBVideoDataContext context = null;

        private static DALBDVid _instance;

        public static DALBDVid Singleton(String servername, String dbname)
        {
            return _instance ?? (_instance = new DALBDVid(servername, dbname));
        }

        private DALBDVid(String servername, String dbname)
        {
            if (dbname == null || dbname == "")
                context = new FilmDBVideoDataContext();
            else
            {
                String connectionstring = "Data Source = " + servername + " ; Initial Catalog =" + dbname + "; Integrated Security = True";
                context = new FilmDBVideoDataContext(connectionstring);
                if (!context.DatabaseExists())  // Vérifier si la DB existe
                    context.CreateDatabase();   // Si elle n'existe pas, on la crée
            }
        }

        #region Select
        public FilmDTO SelectFilm(int idFilm)
        {
            FilmDTO MyMovie = new FilmDTO();
            var query = from d in context.BD_Films
                        where d.ID == idFilm
                        select d;

            foreach (var a in query)
            {
                MyMovie.Id = a.ID;
                MyMovie.Title = a.title;
                MyMovie.Original_title = a.original_title;
                MyMovie.Runtime = (int)a.runtime;
                MyMovie.Posterpath = a.posterpath;
                MyMovie.Statut = SelectStatut((int)a.status);
            }

            return MyMovie;
        }

        public FilmDTO SelectFilm(String title)
        {
            FilmDTO MyMovie = new FilmDTO();
            var query = from d in context.BD_Films
                        where d.title == title
                        select d;

            foreach (var a in query)
            {
                MyMovie.Id = a.ID;
                MyMovie.Title = a.title;
                MyMovie.Original_title = a.original_title;
                MyMovie.Runtime = (int)a.runtime;
                MyMovie.Posterpath = a.posterpath;
                MyMovie.Statut = SelectStatut((int)a.status);
            }

            return MyMovie;
        }

        public ActeurDTO SelectActeur(int IDActor)
        {
            ActeurDTO MyActor = new ActeurDTO();
            var query = from d in context.BD_Actors
                        where d.ID == IDActor
                        select d;

            foreach (var a in query)
            {
                MyActor.ID = a.ID;
                MyActor.Name = a.Name;
            }

            return MyActor;
        }

        public ActeurDTO SelectActeur(String Name)
        {
            ActeurDTO MyActor = new ActeurDTO();
            var query = from d in context.BD_Actors
                        where d.Name == Name
                        select d;

            foreach (var a in query)
            {
                MyActor.ID = a.ID;
                MyActor.Name = a.Name;
            }

            return MyActor;
        }

        public RealisateurDTO SelectRealisateur(int IDRealisateur)
        {
            RealisateurDTO MyRealisateur = new RealisateurDTO();
            var query = from d in context.BD_Realisateurs
                        where d.Id == IDRealisateur
                        select d;

            foreach (var a in query)
            {
                MyRealisateur.ID = a.Id;
                MyRealisateur.Name = a.name;
            }

            return MyRealisateur;
        }

        public RealisateurDTO SelectRealisateur(String Name)
        {
            RealisateurDTO MyRealisateur = new RealisateurDTO();
            var query = from d in context.BD_Realisateurs
                        where d.name == Name
                        select d;

            foreach (var a in query)
            {
                MyRealisateur.ID = a.Id;
                MyRealisateur.Name = a.name;
            }

            return MyRealisateur;
        }

        public GenreDTO SelectGenre(int IDGenre)
        {
            GenreDTO MyGenre = new GenreDTO();
            var query = from d in context.BD_Genres
                        where d.Id == IDGenre
                        select d;

            foreach (var a in query)
            {
                MyGenre.ID = a.Id;
                MyGenre.Name = a.name;
            }

            return MyGenre;
        }

        public GenreDTO SelectGenre(String Name)
        {
            GenreDTO MyGenre = new GenreDTO();
            var query = from d in context.BD_Genres
                        where d.name == Name
                        select d;

            foreach (var a in query)
            {
                MyGenre.ID = a.Id;
                MyGenre.Name = a.name;
            }

            return MyGenre;
        }
        
        public StatutDTO SelectStatut(int IDStatut)
        {
            StatutDTO MyStatut = new StatutDTO();
            var query = from d in context.BD_STATUTs
                        where d.ID == IDStatut
                        select d;

            foreach (var a in query)
            {
                MyStatut.ID = a.ID;
                MyStatut.Name = a.Name;
            }

            return MyStatut;
        }
        #endregion

        #region SelectAll
        public List<FilmDTO> SelectAllFilm()
        {
            List<FilmDTO> MyMovies = new List<FilmDTO>();
            FilmDTO temp;
            var query = from d in context.BD_Films
                        select d;

            foreach (var a in query)
            {
                temp = new FilmDTO();
                temp.Id = a.ID;
                temp.Title = a.title;
                temp.Original_title = a.original_title;
                temp.Runtime = (int)a.runtime;
                temp.Posterpath = a.posterpath;
                temp.Statut = SelectStatut((int)a.status);
                MyMovies.Add(temp);
            }

            return MyMovies;
        }

        public List<GenreDTO> SelectAllGenre()
        {
            List<GenreDTO> MyGenres = new List<GenreDTO>();
            GenreDTO temp;
            var query = from d in context.BD_Genres
                        select d;

            foreach (var a in query)
            {
                temp = new GenreDTO(a.Id, a.name);
                MyGenres.Add(temp);
            }

            return MyGenres;
        }

        public List<RealisateurDTO> SelectAllRealisateur()
        {
            List<RealisateurDTO> MyRealisators = new List<RealisateurDTO>();
            RealisateurDTO temp;
            var query = from d in context.BD_Realisateurs
                        select d;

            foreach (var a in query)
            {
                temp = new RealisateurDTO(a.Id, a.name);
                MyRealisators.Add(temp);
            }

            return MyRealisators;
        }

        public List<ActeurDTO> SelectAllActeur()
        {
            List<ActeurDTO> MyActors = new List<ActeurDTO>();
            ActeurDTO temp;
            var query = from d in context.BD_Actors
                        select d;

            foreach (var a in query)
            {
                temp = new ActeurDTO(a.ID, a.Name);
                MyActors.Add(temp);
            }

            return MyActors;
        }
        #endregion

        #region SelectPerFilm
        public List<ActeurDTO> SelectActeurFilm(int ID)
        {
            List<ActeurDTO> MyActors = new List<ActeurDTO>();
            ActeurDTO temp;
            var query = from d in context.BD_Actors
                        join MovieActor in context.BD_FilmActors
                        on d.ID equals MovieActor.IDActor
                        where MovieActor.IDFilm == ID
                        select d;

            foreach (var a in query)
            {
                temp = new ActeurDTO(a.ID, a.Name);
                MyActors.Add(temp);
            }

            return MyActors;
        }


        public List<RealisateurDTO> SelectRealisateurFilm(int IDFilm)
        {
            List<RealisateurDTO> MyRealisators = new List<RealisateurDTO>();
            RealisateurDTO temp;
            var query = from d in context.BD_Realisateurs
                        join MovieReal in context.BD_FilmRealisateurs
                        on d.Id equals MovieReal.IDReal
                        where MovieReal.IDFilm == IDFilm
                        select d;

            foreach (var a in query)
            {

                temp = new RealisateurDTO(a.Id, a.name);
                MyRealisators.Add(temp);
            }

            return MyRealisators;
        }

        public List<GenreDTO> SelectGenreFilm(int ID)
        {
            List<GenreDTO> MyRealisators = new List<GenreDTO>();
            GenreDTO temp;
            var query = from d in context.BD_Genres
                        join MovieGenre in context.BD_FilmGenres
                        on d.Id equals MovieGenre.IDGenre
                        where MovieGenre.IDFilm == ID
                        select d;

            foreach (var a in query)
            {
                temp = new GenreDTO(a.Id, a.name);
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
            var query = from d in context.BD_FilmActors
                        where d.IDActor == IDActor
                        select d;

            foreach (var a in query)
            {
                temp = SelectFilm(a.IDFilm);
                MyMovies.Add(temp);
            }

            return MyMovies;
        }

        public List<FilmDTO> SelectFilmPerRealisateur(int IDReal)
        {
            List<FilmDTO> MyMovies = new List<FilmDTO>();
            FilmDTO temp;
            var query = from d in context.BD_FilmRealisateurs
                        where d.IDReal == IDReal
                        select d;

            foreach (var a in query)
            {
                temp = SelectFilm(a.IDFilm);
                MyMovies.Add(temp);
            }

            return MyMovies;
        }

        public List<FilmDTO> SelectFilmPerGenre(int IDGenre)
        {
            List<FilmDTO> MyMovies = new List<FilmDTO>();
            FilmDTO temp;
            var query = from d in context.BD_FilmGenres
                        where d.IDGenre == IDGenre
                        select d;

            foreach (var a in query)
            {
                temp = SelectFilm(a.IDFilm);
                MyMovies.Add(temp);
            }

            return MyMovies;
        }
        #endregion

        #region InsertNewFilm
        public bool InsertNewFilm(FilmDTO NewMovie)
        {
            var query = from d in context.BD_Films
                        where NewMovie.Id == d.ID
                        select d;

            if(query.Count() == 0)
            {
                BD_Film g = new BD_Film
                {
                    ID = NewMovie.Id,
                    title = NewMovie.Title,
                    original_title = NewMovie.Title,
                    runtime = NewMovie.Runtime,
                    posterpath = NewMovie.Posterpath,
                    status = 1
                };

                context.BD_Films.InsertOnSubmit(g);

                List<ActeurDTO> Actors = NewMovie.Acteurlist;
                foreach(ActeurDTO a in Actors)
                {
                    var queryact = from d in context.BD_Actors
                                where a.ID == d.ID
                                select d;

                    if (queryact.Count() == 0)
                    {
                        BD_Actor act = new BD_Actor
                        {
                            ID = a.ID,
                            Name = a.Name
                        };

                        context.BD_Actors.InsertOnSubmit(act);

                        
                    }

                    BD_FilmActor fact = new BD_FilmActor
                    {
                        IDActor = a.ID,
                        IDFilm = NewMovie.Id
                    };

                    context.BD_FilmActors.InsertOnSubmit(fact);
                }

                List<RealisateurDTO> Realisators = NewMovie.Realisateurlist;
                foreach (RealisateurDTO a in Realisators)
                {
                    var queryact = from d in context.BD_Realisateurs
                                   where a.ID == d.Id
                                   select d;

                    if (queryact.Count() == 0)
                    {
                        BD_Realisateur real = new BD_Realisateur
                        {
                            Id = a.ID,
                            name = a.Name
                        };

                        context.BD_Realisateurs.InsertOnSubmit(real);
                    }
                    BD_FilmRealisateur freal = new BD_FilmRealisateur
                    {
                        IDReal = a.ID,
                        IDFilm = NewMovie.Id
                    };

                    context.BD_FilmRealisateurs.InsertOnSubmit(freal);
                }

                List<GenreDTO> Genres = NewMovie.Genrelist;
                foreach (GenreDTO a in Genres)
                {
                    var querygen = from d in context.BD_Genres
                                   where a.ID == d.Id
                                   select d;

                    if (querygen.Count() == 0)
                    {
                        BD_Genre ggen = new BD_Genre
                        {
                            Id = a.ID,
                            name = a.Name
                        };

                        context.BD_Genres.InsertOnSubmit(ggen);
                    }
                    BD_FilmGenre fgen = new BD_FilmGenre
                    {
                        IDGenre = a.ID,
                        IDFilm = NewMovie.Id
                    };

                    context.BD_FilmGenres.InsertOnSubmit(fgen);
                }


                // Submit the change to the database.
                try
                {
                    context.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Make some adjustments.
                    // ...
                    // Try again.
                    //context.SubmitChanges();
                    return false;
                }
        }

            return false;
        }
        #endregion



    }
}

using DALBDFilm;
using DTOFilm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLBDFilm
{
    public class BLLBDFilmCentr
    {
        DALBDFilmCentr DALBDF;
        
        public BLLBDFilmCentr(String servername, String dbname)
        {
            DALBDF = DALBDFilmCentr.Singleton(servername, dbname);
        }

        #region Select
        public FilmDTO SelectFilm(int idFilm)
        {
            FilmDTO MyMovie = DALBDF.SelectFilm(idFilm);
            MyMovie.Acteurlist = DALBDF.SelectActeurFilm(MyMovie.Id);
            MyMovie.Realisateurlist = DALBDF.SelectRealisateurFilm(MyMovie.Id);
            MyMovie.Genrelist = DALBDF.SelectGenreFilm(MyMovie.Id);

            return MyMovie;
        }

        public FilmDTO SelectFilm(String title)
        {
            FilmDTO MyMovie = DALBDF.SelectFilm(title);
            MyMovie.Acteurlist = DALBDF.SelectActeurFilm(MyMovie.Id);
            MyMovie.Realisateurlist = DALBDF.SelectRealisateurFilm(MyMovie.Id);
            MyMovie.Genrelist = DALBDF.SelectGenreFilm(MyMovie.Id);

            return MyMovie;
        }

        public ActeurDTO SelectActeur(int IDActor)
        {
            return DALBDF.SelectActeur(IDActor);
        }

        public ActeurDTO SelectActeur(String Name)
        {
            return DALBDF.SelectActeur(Name);
        }

        public RealisateurDTO SelectRealisateur(int IDRealisateur)
        {
            return DALBDF.SelectRealisateur(IDRealisateur);
        }

        public RealisateurDTO SelectRealisateur(String Name)
        {
            return DALBDF.SelectRealisateur(Name);
        }

        public GenreDTO SelectGenre(int IDGenre)
        {
            return DALBDF.SelectGenre(IDGenre);
        }

        public GenreDTO SelectGenre(String Name)
        {
            return DALBDF.SelectGenre(Name);
        }

        public List<FilmDTO> SelectSomeMovies(int number, int skip)
        {
            List<FilmDTO> MyMovies = DALBDF.SelectSomeMovies(number, skip);
            foreach (FilmDTO s in MyMovies)
            {
                s.Acteurlist = DALBDF.SelectActeurFilm(s.Id);
                s.Realisateurlist = DALBDF.SelectRealisateurFilm(s.Id);
                s.Genrelist = DALBDF.SelectGenreFilm(s.Id);
            }

            return MyMovies;
        }

        #endregion

        #region SelectAll
        public List<FilmDTO> SelectAllFilm()
        {
            List<FilmDTO> MyMovies = DALBDF.SelectAllFilm();
            foreach(FilmDTO s in MyMovies)
            {
                s.Acteurlist = DALBDF.SelectActeurFilm(s.Id);
                s.Realisateurlist = DALBDF.SelectRealisateurFilm(s.Id);
                s.Genrelist = DALBDF.SelectGenreFilm(s.Id);
            }

            return MyMovies;
        }

        public List<GenreDTO> SelectAllGenre()
        {
            return DALBDF.SelectAllGenre();
        }

        public List<RealisateurDTO> SelectAllRealisateur()
        {
            return DALBDF.SelectAllRealisateur();
        }

        public List<ActeurDTO> SelectAllActeur()
        {
            return DALBDF.SelectAllActeur();
        }

        public int SelectCountFilm()
        {
            return DALBDF.SelectCountFilm();
        }
        #endregion

        #region SelectFilmPerCategory
        public List<FilmDTO> SelectFilmPerActor(ActeurDTO actor)
        {
            List<FilmDTO> MyMovies = DALBDF.SelectFilmPerActor(actor.ID);
            foreach (FilmDTO s in MyMovies)
            {
                s.Acteurlist = DALBDF.SelectActeurFilm(s.Id);
                s.Realisateurlist = DALBDF.SelectRealisateurFilm(s.Id);
                s.Genrelist = DALBDF.SelectGenreFilm(s.Id);
            }

            return MyMovies;

        }

        public List<FilmDTO> SelectFilmPerRealisateur(RealisateurDTO realisator)
        {
            List<FilmDTO> MyMovies = DALBDF.SelectFilmPerRealisateur(realisator.ID);
            foreach (FilmDTO s in MyMovies)
            {
                s.Acteurlist = DALBDF.SelectActeurFilm(s.Id);
                s.Realisateurlist = DALBDF.SelectRealisateurFilm(s.Id);
                s.Genrelist = DALBDF.SelectGenreFilm(s.Id);
            }

            return MyMovies;
        }

        public List<FilmDTO> SelectFilmPerGenre(GenreDTO genre)
        {
            List<FilmDTO> MyMovies = DALBDF.SelectFilmPerGenre(genre.ID);
            foreach (FilmDTO s in MyMovies)
            {
                s.Acteurlist = DALBDF.SelectActeurFilm(s.Id);
                s.Realisateurlist = DALBDF.SelectRealisateurFilm(s.Id);
                s.Genrelist = DALBDF.SelectGenreFilm(s.Id);
            }

            return MyMovies;
        }
        #endregion



    }
}

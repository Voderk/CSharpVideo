using DALBDVideo;
using DTOFilm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLBDVideo
{
    public class BLLBDVid
    {
        DALBDVid DALBDV;

        public BLLBDVid(String servername, String dbname)
        {
            DALBDV = DALBDVid.Singleton(servername, dbname);
        }

        #region Select
        public FilmDTO SelectFilm(int idFilm)
        {
            FilmDTO MyMovie = DALBDV.SelectFilm(idFilm);
            MyMovie.Acteurlist = DALBDV.SelectActeurFilm(MyMovie.Id);
            MyMovie.Realisateurlist = DALBDV.SelectRealisateurFilm(MyMovie.Id);
            MyMovie.Genrelist = DALBDV.SelectGenreFilm(MyMovie.Id);

            return MyMovie;
        }

        public FilmDTO SelectFilm(String title)
        {
            FilmDTO MyMovie = DALBDV.SelectFilm(title);
            MyMovie.Acteurlist = DALBDV.SelectActeurFilm(MyMovie.Id);
            MyMovie.Realisateurlist = DALBDV.SelectRealisateurFilm(MyMovie.Id);
            MyMovie.Genrelist = DALBDV.SelectGenreFilm(MyMovie.Id);

            return MyMovie;
        }

        public ActeurDTO SelectActeur(int IDActor)
        {
            return DALBDV.SelectActeur(IDActor);
        }

        public ActeurDTO SelectActeur(String Name)
        {
            return DALBDV.SelectActeur(Name);
        }

        public RealisateurDTO SelectRealisateur(int IDRealisateur)
        {
            return DALBDV.SelectRealisateur(IDRealisateur);
        }

        public RealisateurDTO SelectRealisateur(String Name)
        {
            return DALBDV.SelectRealisateur(Name);
        }

        public GenreDTO SelectGenre(int IDGenre)
        {
            return DALBDV.SelectGenre(IDGenre);
        }

        public GenreDTO SelectGenre(String Name)
        {
            return DALBDV.SelectGenre(Name);
        }

        public List<FilmDTO> SelectSomeMovies(int number, int skip)
        {
            List<FilmDTO> MyMovies = DALBDV.SelectSomeMovies(number, skip);
            foreach (FilmDTO s in MyMovies)
            {
                s.Acteurlist = DALBDV.SelectActeurFilm(s.Id);
                s.Realisateurlist = DALBDV.SelectRealisateurFilm(s.Id);
                s.Genrelist = DALBDV.SelectGenreFilm(s.Id);
            }

            return MyMovies;
        }


        #endregion

        #region SelectAll
        public List<FilmDTO> SelectAllFilm()
        {
            List<FilmDTO> MyMovies = DALBDV.SelectAllFilm();
            foreach (FilmDTO s in MyMovies)
            {
                s.Acteurlist = DALBDV.SelectActeurFilm(s.Id);
                s.Realisateurlist = DALBDV.SelectRealisateurFilm(s.Id);
                s.Genrelist = DALBDV.SelectGenreFilm(s.Id);
            }

            return MyMovies;
        }

        public List<GenreDTO> SelectAllGenre()
        {
            return DALBDV.SelectAllGenre();
        }

        public List<RealisateurDTO> SelectAllRealisateur()
        {
            return DALBDV.SelectAllRealisateur();
        }

        public List<ActeurDTO> SelectAllActeur()
        {
            return DALBDV.SelectAllActeur();
        }

        public int SelectCountFilm()
        {
            return DALBDV.SelectCountFilm();
        }

        #endregion

        #region SelectFilmPerCategory
        public List<FilmDTO> SelectFilmPerActor(ActeurDTO actor)
        {
            List<FilmDTO> MyMovies = DALBDV.SelectFilmPerActor(actor.ID);
            foreach (FilmDTO s in MyMovies)
            {
                s.Acteurlist = DALBDV.SelectActeurFilm(s.Id);
                s.Realisateurlist = DALBDV.SelectRealisateurFilm(s.Id);
                s.Genrelist = DALBDV.SelectGenreFilm(s.Id);
            }

            return MyMovies;

        }

        public List<FilmDTO> SelectFilmPerRealisateur(RealisateurDTO realisator)
        {
            List<FilmDTO> MyMovies = DALBDV.SelectFilmPerRealisateur(realisator.ID);
            foreach (FilmDTO s in MyMovies)
            {
                s.Acteurlist = DALBDV.SelectActeurFilm(s.Id);
                s.Realisateurlist = DALBDV.SelectRealisateurFilm(s.Id);
                s.Genrelist = DALBDV.SelectGenreFilm(s.Id);
            }

            return MyMovies;
        }

        public List<FilmDTO> SelectFilmPerGenre(GenreDTO genre)
        {
            List<FilmDTO> MyMovies = DALBDV.SelectFilmPerGenre(genre.ID);
            foreach (FilmDTO s in MyMovies)
            {
                s.Acteurlist = DALBDV.SelectActeurFilm(s.Id);
                s.Realisateurlist = DALBDV.SelectRealisateurFilm(s.Id);
                s.Genrelist = DALBDV.SelectGenreFilm(s.Id);
            }

            return MyMovies;
        }
        #endregion

        public bool InsertNewFilm(FilmDTO NewMovie)
        {
            return DALBDV.InsertNewFilm(NewMovie);
        }
    }
}

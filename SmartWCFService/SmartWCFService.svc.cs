using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DTOFilm;
using BLLBDFilm;

namespace SmartWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SmartWCFService: ISmartWCFService
    {

        BLLBDFilmCentr BLLBDF;
        public SmartWCFService()
        {
            BLLBDF = BLLBDF = new BLLBDFilmCentr("LAPTOP-IQTHKHPT\\SQLEXPRESS","FilmDB"); ;
        }

        public SmartWCFService(String servername, String dbname)
        {
            BLLBDF = new BLLBDFilmCentr(servername, dbname);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<ActeurDTO> SelectAllActeur()
        {
            return BLLBDF.SelectAllActeur();
        }

        public List<RealisateurDTO> SelectAllRealisateur()
        {
            return BLLBDF.SelectAllRealisateur();
        }

        public List<GenreDTO> SelectAllGenre()
        {
            return BLLBDF.SelectAllGenre();
        }

        public List<FilmDTO> SelectAllFilm()
        {
            return BLLBDF.SelectAllFilm();
        }

        public FilmDTO SelectFilmID(int idFilm)
        {
            return BLLBDF.SelectFilm(idFilm);
        }

        public FilmDTO SelectFilmTitle(string title)
        {
            return BLLBDF.SelectFilm(title);
        }

        public ActeurDTO SelectActeurID(int IDActor)
        {
            return BLLBDF.SelectActeur(IDActor);
        }

        public ActeurDTO SelectActeurName(string Name)
        {
            return BLLBDF.SelectActeur(Name);
        }

        public RealisateurDTO SelectRealisateurID(int IDRealisateur)
        {
            return BLLBDF.SelectRealisateur(IDRealisateur);
        }

        public RealisateurDTO SelectRealisateurName(string Name)
        {
            return BLLBDF.SelectRealisateur(Name);
        }

        public GenreDTO SelectGenreID(int IDGenre)
        {
            return BLLBDF.SelectGenre(IDGenre);
        }

        public GenreDTO SelectGenreName(string Name)
        {
            return BLLBDF.SelectGenre(Name);
        }

        public List<FilmDTO> SelectFilmPerActor(ActeurDTO actor)
        {
            return BLLBDF.SelectFilmPerActor(actor);
        }

        public List<FilmDTO> SelectFilmPerRealisateur(RealisateurDTO realisator)
        {
            return BLLBDF.SelectFilmPerRealisateur(realisator);
        }

        public List<FilmDTO> SelectFilmPerGenre(GenreDTO genre)
        {
            return BLLBDF.SelectFilmPerGenre(genre);
        }
    }
}

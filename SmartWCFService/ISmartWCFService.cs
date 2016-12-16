using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DTOFilm;

namespace SmartWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISmartWCFService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        #region SelectAll
        [OperationContract]
        List<ActeurDTO> SelectAllActeur();

        [OperationContract]
        List<FilmDTO> SelectAllFilm();

        [OperationContract]
        List<RealisateurDTO> SelectAllRealisateur();

        [OperationContract]
        List<GenreDTO> SelectAllGenre();
        #endregion

        [OperationContract]
        List<FilmDTO> SelectSomeMovies(int number,int skip);

        [OperationContract]
        FilmDTO SelectFilmID(int idFilm);

        [OperationContract]
        FilmDTO SelectFilmTitle(String title);

        [OperationContract]
        ActeurDTO SelectActeurID(int IDActor);

        [OperationContract]
        ActeurDTO SelectActeurName(String Name);

        [OperationContract]
        RealisateurDTO SelectRealisateurID(int IDRealisateur);

        [OperationContract]
        RealisateurDTO SelectRealisateurName(String Name);

        [OperationContract]
        GenreDTO SelectGenreID(int IDGenre);

        [OperationContract]
        GenreDTO SelectGenreName(String Name);

        [OperationContract]
        List<FilmDTO> SelectFilmPerActor(ActeurDTO actor);

        [OperationContract]
        List<FilmDTO> SelectFilmPerRealisateur(RealisateurDTO realisator);

        [OperationContract]
        List<FilmDTO> SelectFilmPerGenre(GenreDTO genre);

        [OperationContract]
        int SelectCountFilm();


    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}

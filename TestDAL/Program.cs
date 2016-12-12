
using DALBDVideo;
using DTOFilm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<FilmDTO> Films;

            FilmDTO movie;

            DALBDVid DALBDV = DALBDVid.Singleton("LAPTOP-IQTHKHPT\\SQLEXPRESS", "BD_VIDEOTHEQUE_LIEGE");
            //ActeurDTO actor = new ActeurDTO(138, "Quentin Tarantino");
            MySmartWCFService.SmartWCFServiceClient test = new MySmartWCFService.SmartWCFServiceClient();

            movie = test.SelectFilmID(27);

            movie.AfficheFilm();

            DALBDV.InsertNewFilm(movie);

            Console.ReadKey();

        }
    }
}


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
            List<FilmDTO> Films;

            //FilmDTO movie;

            DALBDVid DALBDV = DALBDVid.Singleton("LEOPARDGK\\SQLEXPRESS", "BD_VIDEOTHEQUE_LIEGE");
            //ActeurDTO actor = new ActeurDTO(138, "Quentin Tarantino");
            MySmartWCFService.SmartWCFServiceClient test = new MySmartWCFService.SmartWCFServiceClient();

            Films = test.SelectSomeMovies(50, 2);

            //movie.AfficheFilm();
            int i = 0;
            foreach(FilmDTO a in Films)
            {
                Console.WriteLine(i);
                a.AfficheFilm();
                i++;
            }

            //DALBDV.InsertNewFilm(movie);

            Console.ReadKey();

        }
    }
}

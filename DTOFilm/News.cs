using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DTOFilm
{
    public class NewsDTO
    {
        private int _id;
        private String _titre;
        private String _contenu;
        private DateTime _createdate;
        private DateTime _modifdate;
        private Bitmap _imagenews;


        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public String titre
        {
            get { return _titre; }
            set { _titre = value; }
        }

        public String Contenu
        {
            get { return _contenu; }
            set { _contenu = value; }
        }

        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

        public DateTime ModifDate
        {
            get { return _modifdate; }
            set { _modifdate = value; }
        }

        public Bitmap ImageNews
        {
            get { return _imagenews; }
            set { _imagenews = value; }
        }








    }
}

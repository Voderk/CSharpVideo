﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOFilm
{
    public class RealisateurDTO
    {
        private int _id;
        private String _name;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public RealisateurDTO()
        {
            ID = 0;
            Name = null;
        }

        public RealisateurDTO(int _id, String _name)
        {
            ID = _id;
            Name = _name;
        }
    }
}

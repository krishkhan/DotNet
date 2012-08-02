using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridSample
{

    public class Movie
    {
        public int _slNo;
        public String _name;
        public DateTime _releaseDate;
        public String _details;

        public Movie()
        {

        }

        public int SLNo
        {
            get;
            set;
        }

        public String Name 
        { 
            get { return _name; } 
            set { _name = value;} 
        }

        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; }
        }

        public String  Details 
        {
            get { return _details;}
            set {_details = value;} 
        }


        
    }
}

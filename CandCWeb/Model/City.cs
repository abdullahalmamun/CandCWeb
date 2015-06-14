using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CandCWeb.Model
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public int Dwellers { get; set; }
        public string Location{ get; set; }
        public string Weather { get; set; }

        public int CountryId { get; set; }

        public Country ACountry { get; set; }

        //public City()
        //{
         //   ACountry=new Country();
        //}

        public int Serial { get; set; }




    }
}
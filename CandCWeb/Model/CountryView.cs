using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CandCWeb.Model
{
    public class CountryView
    {
        public int CityCount { set; get; }
        public int TotalDwellers { set; get; }
        public Country MyCountry { set; get; }
    }
}
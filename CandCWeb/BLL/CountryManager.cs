using CandCWeb.DAL;
using CandCWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CandCWeb.BLL
{
    public class CountryManager
    {
       CountryGateway countryGateway = new CountryGateway();
       public string SaveCountry(Country aCountry)
       {

           int value = countryGateway.SaveCountry(aCountry);
           if (value > 0)
           {
               return "Save Successfull";

           }
           else
           {
               return "Save Failed";
           }

       }

       public List<Country> GetCountryList()
       {
           return countryGateway.GetCountryList();
       }


       public List<City> SearchCountryInformation(Country aCountry)
       {

           return countryGateway.SearchCountryInformation(aCountry);
       }

       public List<CountryView> GetNoOfCityAndPeople()
       {
           return countryGateway.ViewCountryInformation();
       }
       public List<CountryView> SearchAllCountryInformation(Country aCountry)
       {

           return countryGateway.SearchAllCountryInformation(aCountry);
       }


    }
}
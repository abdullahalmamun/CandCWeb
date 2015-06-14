using CandCWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



using CandCWeb.Model;namespace CandCWeb.BLL
{
    public class CityManager
    {
        CityGateway cityGateway = new CityGateway();
        public string SaveCity(City aCity)
        {

            int value = cityGateway.SaveCity(aCity);
            if (value > 0)
            {
                return "Save Successfull";

            }
            else
            {
                return "Save Failed";
            }

        }
        public List<City> GetAllCityInformation()
        {
            return cityGateway.GetAllCityInformation();
        }

        public bool IsCityNameExists(City aCity)
        {

            return cityGateway.IsCityNameExists(aCity);
        }
        public List<City> SearchCityInformation(City myCity)
        {
            return cityGateway.SearchCityInformation(myCity);
        }
    }
}
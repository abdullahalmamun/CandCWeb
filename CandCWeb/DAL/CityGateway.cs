using CandCWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
namespace CandCWeb.DAL
{
    public class CityGateway
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionDB"].ConnectionString;
        public int SaveCity(City aCity)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO CityTBL VALUES('" + aCity.Name + "','" + aCity.About + "','" + aCity.Dwellers + "','" + aCity.Location + "','" + aCity.Weather + "','" + aCity.CountryId+ "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;


        }
        public List<City> GetAllCityInformation()
        {
            int count = 0;
            List<City> cityList = new List<City>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM CityTBL";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                City aCity = new City();
                aCity.Id = int.Parse(reader["Id"].ToString());
                aCity.Name = reader["CityName"].ToString();
                aCity.About = reader["AboutCity"].ToString();
                aCity.Dwellers = int.Parse(reader["NoOfDwellers"].ToString());
                aCity.Location = reader["Location"].ToString();
                aCity.Weather = reader["Weather"].ToString();
                int id = int.Parse(reader["CountryId"].ToString());
                //aCity.CountryId = id;
                
                Country aCountry = GetCountryName(id);


                aCity.ACountry = new Country();
                //aCity.ACountry.Id = id;
                aCity.ACountry.countryName = aCountry.countryName;
                aCity.ACountry.aboutCountry = aCountry.aboutCountry;

                count++;

                aCity.Serial = count;

                cityList.Add(aCity);
            }
            reader.Close();
            connection.Close();
            return cityList;
        }


        public Country GetCountryName(int id)
        {

            Country aCountry = new Country();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM CountryTBL WHERE Id='" + id + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                aCountry.countryName = reader["CountryName"].ToString();
                aCountry.aboutCountry = reader["AboutCountry"].ToString();
            }
            reader.Close();
            connection.Close();
            return aCountry;
        }
        public bool IsCityNameExists(City aCity)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM CityTBL WHERE CityName='" + aCity.Name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                connection.Close();
                return true;
            }
            else
            {
                reader.Close();
                connection.Close();
                return false;
            }

        }
        public List<City> SearchCityInformation(City myCity)
        {
            int count = 0;
            List<City> cityList = new List<City>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM CityTBL WHERE CityName LIKE '" + myCity.Name + "%'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                City aCity = new City();
                aCity.Id = int.Parse(reader["Id"].ToString());
                aCity.Name = reader["CityName"].ToString();
                aCity.About = reader["AboutCity"].ToString();
                aCity.Dwellers = int.Parse(reader["NoOfDwellers"].ToString());
                aCity.Location = reader["Location"].ToString();
                aCity.Weather = reader["Weather"].ToString();
                int id = int.Parse(reader["CountryId"].ToString());
                aCity.CountryId = id;

                Country aCountry = GetCountryName(id);

                aCity.ACountry = new Country();
                aCity.ACountry.Id = aCountry.Id;
                aCity.ACountry.countryName = aCountry.countryName;
                aCity.ACountry.aboutCountry = aCountry.aboutCountry;

                count++;
                aCity.Serial = count;
                cityList.Add(aCity);
            }
            reader.Close();
            connection.Close();
            return cityList;
        }

    }



}
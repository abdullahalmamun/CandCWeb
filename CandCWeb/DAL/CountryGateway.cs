using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using CandCWeb.Model;
using System.Data.SqlClient;

namespace CandCWeb.DAL
{


    public class CountryGateway
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionDB"].ConnectionString;
        public int SaveCountry(Country aCountry)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO CountryTBL VALUES('"+aCountry.countryName+"','"+aCountry.aboutCountry+"')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected=command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;


        }
        public List<Country> GetCountryList()
        {
            List<Country> countryList = new List<Country>();

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM CountryTBL";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            int count = 1;
            while (reader.Read())
            {
                Country acountry = new Country();
                acountry.Id = (int) reader["Id"];
                acountry.countryName = reader["CountryName"].ToString();
                acountry.aboutCountry = reader["AboutCountry"].ToString();
                acountry.serial = count;
                count++;

                countryList.Add(acountry);
                
            }
            reader.Close();
            connection.Close();

            return countryList;



        }

        public List<City> SearchCountryInformation(Country myCountry)
        {
            int count = 0;
            List<City> cityList = new List<City>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM CityTBL WHERE CountryId='" + myCountry.Id + "'";
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
                aCity.ACountry.Id = id;
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

        public List<CountryView> ViewCountryInformation()
        {
            int count = 0;
            List<CountryView> countryList = new List<CountryView>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM CountryTBL ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CountryView countryView = new CountryView();
                countryView.MyCountry = new Country();
                countryView.MyCountry.countryName = reader["CountryName"].ToString();
                countryView.MyCountry.aboutCountry= reader["AboutCountry"].ToString();
                count++;
                countryView.MyCountry.serial = count;
                int id = int.Parse(reader["Id"].ToString());

                countryView.CityCount = GetNoOfCityAndPeople(id);
                countryView.TotalDwellers = totalDwellers;
                countryList.Add(countryView);


            }
            reader.Close();
            connection.Close();
            return countryList;
        }
        public List<CountryView> SearchAllCountryInformation(Country aCountry)
        {
            int count = 0;
            List<CountryView> countryList = new List<CountryView>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM CountryTBL WHERE CountryName LIKE '" + aCountry.countryName + "%' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CountryView countryView = new CountryView();
                countryView.MyCountry = new Country();
                countryView.MyCountry.countryName = reader["CountryName"].ToString();
                countryView.MyCountry.aboutCountry = reader["AboutCountry"].ToString();
                count++;
                countryView.MyCountry.serial = count;
                int id = int.Parse(reader["Id"].ToString());

                countryView.CityCount = GetNoOfCityAndPeople(id);
                countryView.TotalDwellers = totalDwellers;
                countryList.Add(countryView);


            }
            reader.Close();
            connection.Close();
            return countryList;
        }
        private int totalDwellers;
        public int GetNoOfCityAndPeople(int id)
        {
            int cityCount = 0;
            totalDwellers = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM CityTBL WHERE CountryId='" + id + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();



            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cityCount++;

                totalDwellers += int.Parse(reader["NoOfDwellers"].ToString());

            }

            reader.Close();
            connection.Close();
            return cityCount;
        }


    }
}
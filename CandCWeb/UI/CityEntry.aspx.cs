using CandCWeb.BLL;
using CandCWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CandCWeb.UI
{
    public partial class CityEntry : System.Web.UI.Page
    {
        CountryManager countryManager = new CountryManager();
        CityManager cityManager = new CityManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCountryNameDropDown();
            cityGridView.DataSource = cityManager.GetAllCityInformation();
            cityGridView.DataBind();
           
        }
        public void LoadCountryNameDropDown()
        {
            if (!IsPostBack)
            {

                countryDropDownList.DataSource = countryManager.GetCountryList();
                countryDropDownList.DataTextField = "countryName";
                countryDropDownList.DataValueField = "Id";
                countryDropDownList.DataBind();


            }
        }

        protected void saveCityButton_Click(object sender, EventArgs e)
        {
            City aCity = new City();
            aCity.Name = cityNameTextBox.Text;
            aCity.About = cityAboutTextBox.Text;
            aCity.Dwellers = int.Parse(dwellersTextBox.Text);
            aCity.Location = locationTextBox.Text;
            aCity.Weather = weatherTextBox.Text;

            if (aCity.Name == "" || aCity.About == ""  || aCity.Location == "" || aCity.Weather == "")
            {
                cityMagLabel.Text = "Please fill the blank field!";
                return;
            }

        
            aCity.CountryId = int.Parse(countryDropDownList.SelectedValue);

            if (cityManager.IsCityNameExists(aCity))
            {
                cityMagLabel.Text = "City Name Already Exists!";
                cityNameTextBox.Text = "";
                cityAboutTextBox.Text = "";
                dwellersTextBox.Text = "";
                locationTextBox.Text = "";
                weatherTextBox.Text = "";
                return;
            }


            cityMagLabel.Text = cityManager.SaveCity(aCity);

            cityGridView.DataSource = cityManager.GetAllCityInformation();
            cityGridView.DataBind();


            cityNameTextBox.Text = "";
            cityAboutTextBox.Text = "";
            dwellersTextBox.Text = "";
            locationTextBox.Text = "";
            weatherTextBox.Text = "";
        }
    }
}
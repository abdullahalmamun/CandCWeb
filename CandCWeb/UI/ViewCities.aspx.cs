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
    public partial class ViewCities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCountryNameDropDown();
            viewCitiesGridView.DataSource = cityManager.GetAllCityInformation();
            viewCitiesGridView.DataBind();

        }
        CityManager cityManager = new CityManager();
        CountryManager countryManager = new CountryManager();

        public void LoadCountryNameDropDown()
        {
            if (!IsPostBack)
            {
                viewCountryDropDownList.DataSource = countryManager.GetCountryList();
                viewCountryDropDownList.DataTextField = "countryName";
                viewCountryDropDownList.DataValueField = "Id";
                viewCountryDropDownList.DataBind();
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {

            if (cityRadioButton.Checked)
            {
                City aCity = new City();
                aCity.Name = viewCityNameTextBox.Text;
                viewCitiesGridView.DataSource = cityManager.SearchCityInformation(aCity);
                viewCitiesGridView.DataBind();
            }
            if (countryRadioButton.Checked)
            {
                Country aCountry = new Country();
                aCountry.Id = int.Parse(viewCountryDropDownList.SelectedItem.Value);
                viewCitiesGridView.DataSource = countryManager.SearchCountryInformation(aCountry);
                viewCitiesGridView.DataBind();
            }
            
        }

    }
}
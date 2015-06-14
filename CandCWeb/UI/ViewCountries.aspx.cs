using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CandCWeb.BLL;
using CandCWeb.Model;

namespace CandCWeb.UI
{
    public partial class ViewCountries : System.Web.UI.Page
    {

        CountryManager countryManager =new CountryManager(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            countryGridView.DataSource = countryManager.GetNoOfCityAndPeople();
            countryGridView.DataBind();

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
          


            Country aCountry = new Country();
            aCountry.countryName = countryNameTextBox.Text;
            countryGridView.DataSource = countryManager.SearchAllCountryInformation(aCountry);
            countryGridView.DataBind();
        }
    }
}
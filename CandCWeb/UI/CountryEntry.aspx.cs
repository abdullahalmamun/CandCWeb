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
    public partial class CountryEntry1 : System.Web.UI.Page
    {
         CountryManager aCountryManager = new CountryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            countryGridView.DataSource = aCountryManager.GetCountryList();
            countryGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Country aCountry = new Country();
            aCountry.countryName = nameTextBox.Text;
            aCountry.aboutCountry = aboutTextBox.Text;

            msgLabel.Text = aCountryManager.SaveCountry(aCountry);

            countryGridView.DataSource = aCountryManager.GetCountryList();
            countryGridView.DataBind();

        }



    }
}
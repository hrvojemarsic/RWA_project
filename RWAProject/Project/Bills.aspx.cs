using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Bills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowCountries();
                ShowCities();
                ShowBuyers();
                ShowBills(0);
                ShowBillDetails(0);
            }
        }
        private void ShowCountries()
        {
            ddlCountries.DataSource = Repo.GetCountries();
            ddlCountries.DataTextField = "Name";
            ddlCountries.DataValueField = "IDCountry";
            ddlCountries.DataBind();

        }

        /* filteri */

        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowCities();
            ShowBuyers();
            ShowBills(0);
            ShowBillDetails(0);
        }

        private void ShowCities()
        {
            int countryID = int.Parse(ddlCountries.SelectedValue);

            ddlCities.DataSource = Repo.GetCities(countryID);
            ddlCities.DataTextField = "Name";
            ddlCities.DataValueField = "IDCity";
            ddlCities.DataBind();
        }

        protected void ddlCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowBuyers();
            ShowBills(0);
            ShowBillDetails(0);
        }

        /* prikaz kupaca */

        private void ShowBuyers()
        {
            try
            {
                int cityID = int.Parse(ddlCities.SelectedValue);
                repeaterBuyers.DataSource = Repo.GetBuyersByCity(cityID);
                repeaterBuyers.DataBind();
                lblInfo.Text = "";
                if (repeaterBuyers.ItemType == repeaterBuyers.HeaderTemplate.ToString())
                {
                    repeaterBuyers.Visible = false;
                }
                repeaterBuyers.Visible = true;
            }
            catch (Exception ex)
            {
                repeaterBuyers.Visible = false;
                lblInfo.Text = ex.Message;
            }
        }

        /* ažuriranje kupca */

        protected void lbEditBuyer_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            int buyerID = int.Parse(button.CommandArgument);
            Response.Redirect($"~/EditBuyer/Edit/{buyerID}");
        }

        /* prikaz svih računa */

        protected void lbShowBills_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            int buyerID = int.Parse(button.CommandArgument);

            ShowBills(buyerID);
            ShowBillDetails(0);
        }

        private void ShowBills(int buyerID)
        {
            if (buyerID == 0)
            {
                repeaterBills.Visible = false;
                return;
            }
            try
            {
                repeaterBills.Visible = true;
                repeaterBills.DataSource = Repo.GetBillsByBuyer(buyerID);
                repeaterBills.DataBind();
                lblInfo.Text = "";
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        /* prikaz detalja računa */

        protected void lbShowBillDetails_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            int billID = int.Parse(button.CommandArgument);

            ShowBillDetails(billID);
        }

        private void ShowBillDetails(int billID)
        {
            if (billID == 0)
            {
                repeaterBillDetails.Visible = false;
                return;
            }
            try
            {
                repeaterBillDetails.Visible = true;
                repeaterBillDetails.DataSource = Repo.GetBillDetails(billID);
                repeaterBillDetails.DataBind();
                lblInfo.Text = "";
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }
    }
}
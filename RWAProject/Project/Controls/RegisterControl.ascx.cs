using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Controls
{
    public partial class RegisterControl : System.Web.UI.UserControl
    {
        Repo repo = new Repo();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.Visible = false;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (repo.CreateUser(txtUserName.Text, txtEmail.Text, txtConfirmUserPass.Text) == 0)
                {
                    emailExists.IsValid = false;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
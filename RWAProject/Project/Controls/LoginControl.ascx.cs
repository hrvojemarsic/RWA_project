using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Controls
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        Repo repo = new Repo();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (repo.CheckUser(txtEmail.Text, txtUserPass.Text))
                {
                    HttpCookie cookie = new HttpCookie("user");
                    cookie["loginTime"] = DateTime.Now.ToString("dd.MM.yyyy - HH:mm:ss");
                    cookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookie);

                    FormsAuthentication.RedirectFromLoginPage(txtEmail.Text, false);
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}
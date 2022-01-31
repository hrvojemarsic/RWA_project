using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                HttpCookie cookie = Request.Cookies["user"];
                FormsIdentity identity = (FormsIdentity)User.Identity;
                lblUser.Text = identity.Ticket.Name.ToString();
                if (cookie != null)
                {
                    lblDate.Text = cookie["loginTime"].ToString();
                }
                else
                {
                    lblDate.Text = identity.Ticket.IssueDate.ToString("dd.MM.yyyy - HH:mm:ss");
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Cookies["user"].Expires = DateTime.Now.AddDays(-1);
            FormsAuthentication.SignOut();
            Response.Redirect("Register.aspx", true);
        }
    }
}
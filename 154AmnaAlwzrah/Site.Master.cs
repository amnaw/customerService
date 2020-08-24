using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;

namespace _154AmnaAlwzrah
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ADMIN Page
            if (Roles.IsUserInRole("admin"))
            {
                adminOnly.Visible = true;
                finOnly.Visible = true;

            }
            if (!Roles.IsUserInRole("admin"))
            {
                //adminOnly.Visible = false;
                
            }

            //FIN Page
            if (Roles.IsUserInRole("finance"))
            {
                finOnly.Visible = true;
            }
            if (!Roles.IsUserInRole("finance") && !Roles.IsUserInRole("admin"))
            {
                //finOnly.Visible = false;
            }

            if (Page.User.Identity.Name != "")
            {
                //ChangeLabel("Welcome " + Page.User.Identity.Name + "!     ");
                lbLogOut.Visible = true;
               
                aUser.Text = "Welcome " + Page.User.Identity.Name + "!     ";

            }


        }
        public void ChangeLabel(string label)
        {
            lblUser.Text = label;
            
        }
        protected void lbLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            ChangeLabel(" ");
            Response.Redirect("~/MyNewFolder/Login.aspx");

        }
    } 
    
}
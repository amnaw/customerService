using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace _154AmnaAlwzrah
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var checkAdminv = 0;
            if (Page.User.Identity.Name != ""){
                
                //(this.Master as SiteMaster).ChangeLabel("Welcome " + Page.User.Identity.Name + "!     ");
            }
            if (!IsPostBack)
            {
               void checkAdmin() {
                   checkAdminv += 1;
                    Roles.CreateRole("admin");
                    Roles.AddUserToRole("amna", "admin");
               }

               if(checkAdminv == 1)
               {
                    checkAdmin();
               }
                
            }

            

        }

        protected void lbLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            (this.Master as SiteMaster).ChangeLabel(" ");
            Response.Redirect("~/MyNewFolder/Login.aspx");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;


namespace _154AmnaAlwzrah.MyNewFolder
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Session["Username"] = txtUserName.Text;
            var checkAdminv = 0;
            
            if (!IsPostBack)
            {
                void checkAdmin()
                {
                    checkAdminv += 1;
                    Roles.CreateRole("admin");
                    Roles.AddUserToRole("amna", "admin");
                    Roles.CreateRole("finance");
                }

                if (checkAdminv == 1)
                {
                    checkAdmin();
                }

            }
        }

        /*protected void LoginButton_Authenticate(object sender, AuthenticateEventArgs e)
        {
            // Validate the user against the Membership framework user store
            if (Membership.ValidateUser(txtUserName.Text, txtPwd.Text))
            {
                // Log the user into the site
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, cbRememberMe.Checked);
            }
            // If we reach here, the user's credentials were invalid
            txtInvalidCredentialsMessage.Visible = true;

            MembershipUser currentUser = Membership.GetUser();
            //Get Username of Currently logged in user
            //string username = currentUser.UserName;
            //Get UserId of Currently logged in user
            //string UserId = currentUser.ProviderUserKey.ToString();

            //Label1.Text = username + UserId;

            bool isLogin = Membership.ValidateUser(currentUser.UserName, currentUser.GetPassword());
            if (isLogin)
            {

                Session["user"] = User.Identity.Name;
                FormsAuthentication.RedirectFromLoginPage(currentUser.UserName, true);
                Response.Redirect("Default.aspx");
            }

        }*/

        protected void lgnUser_Click(object sender, EventArgs e)
        {
            //ValidateUser : This method of Membership class verifies that the supplied user name and password are valid, to check a user's credentials if you create your own custom logon controls.
            if (Membership.ValidateUser(txtUserName.Text, txtPwd.Text))
            {
                Session["Username"] = txtUserName.Text; //RedirectFromLoginPage : this method redirects an authenticated user back to the original protected URL that was requested
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text,
                cbRememberMe.Checked);

                Response.Redirect("~/Default.aspx");

            }
            else
                txtInvalidCredentialsMessage.Visible = true;


            /************ Eng ALI's Way***********************
             * Session["Username"] = txtUserName.Text;
            bool blnAuthenticate = AuthenticateUser(); //Authenticate(dicObjformValues);
            if (blnAuthenticate)
            {
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);
               
                // email admin when a user logged in the site
                DateTime myDate = DateTime.Now;
            }
            else
            {
                // this is important 
                txtInvalidCredentialsMessage.Visible = true;
            }
        }

        protected bool AuthenticateUser()
        {
            string userName = txtUserName.Text;
            string password = txtPwd.Text;
            bool userFound = false;
            try
            {
                userFound = Membership.ValidateUser(userName, password);
                Response.Redirect("Default.aspx");
                txtInvalidCredentialsMessage.ForeColor = Color.Green;
                txtInvalidCredentialsMessage.Text = "Welcome " + Session["Username"].ToString();
            }
            catch (Exception ex)
            {
                txtInvalidCredentialsMessage.Text = "Please take image snapshot and email it to support@wdbcs.com " + ex.Message.ToString();
            }
            return userFound;*/
        }

        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MyNewFolder/Registeration.aspx");
        }
    }
}
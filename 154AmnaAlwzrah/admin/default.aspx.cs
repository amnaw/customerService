using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _154AmnaAlwzrah.App_Code;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Security;

namespace _154AmnaAlwzrah.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var checkFin = 0;
            if (!IsPostBack)
            {
                void createFin()
                {
                    checkFin += 1;
                    Roles.CreateRole("finance");

                }
                if (checkFin == 1)
                {
                    createFin();
                }

            }
        }

        protected void postMsg(string msg)
        {
            lblMsg.Text = msg.ToString();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

            string conString = CRUD.conStr;
            string sqlCmd = "select  DISTINCT  UserName as [Users Names] from aspnet_Users";
            SqlDataAdapter dad = new SqlDataAdapter(sqlCmd, conString);
            DataTable allUsers = new DataTable();
            dad.Fill(allUsers);
            gvUsers.DataSource = allUsers;
            gvUsers.DataBind();
        }

        protected void btnFin_Click(object sender, EventArgs e)
        {
            if (Membership.GetUser(txtUserName.Text) != null)
            {
                if (!Roles.IsUserInRole(txtUserName.Text, "finance"))
                {
                    Roles.AddUserToRole(txtUserName.Text, "finance");
                    postMsg("User : \"" + txtUserName.Text + "\" assigned to Finance Role successfully");
                }
                else
                {
                    postMsg("User : \"" + txtUserName.Text + "\" has been already assigned to Finance Role");
                    return;

                }
            }
            else
            {
                postMsg("User : \"" + txtUserName.Text + "\" Doesn't Registered in the system");
                return;
            }
            
        }

        protected void btnFinancers_Click(object sender, EventArgs e)
        {
            var financeUsers = Roles.GetUsersInRole("finance");
            DataTable dt = new DataTable();
            dt.Columns.Add("Finance Users", Type.GetType("System.String"));

            foreach (string user in financeUsers)
            {
                if (Membership.GetUser(user) != null)
                {
                    DataRow dr = dt.NewRow();
                    dr = dt.NewRow();
                    dr["Finance Users"] = user; 
                    dt.Rows.Add(dr);
                }
            }
            gvFin.DataSource = dt;
            gvFin.DataBind();
            //postMsg(users);
        }
    }
   
}


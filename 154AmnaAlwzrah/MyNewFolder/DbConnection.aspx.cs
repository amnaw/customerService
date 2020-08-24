using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Configuration;
using System.Data.SqlClient;
using _154AmnaAlwzrah.App_Code;

namespace _154AmnaAlwzrah.MyNewFolder
{
    public partial class DbConnection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateGridv();
            }
        }

        protected void populateGridv()
        {
            CRUD myCrud = new CRUD();
            string mySql = "select * from customerInfo";
           
            SqlDataReader dr = myCrud.getDrPassSql(mySql);

            gvCustomer.DataSource = dr;
            gvCustomer.DataBind();
        }






        /*protected void btnShow_Click(object sender, EventArgs e)
        {
            string conString = WebConfigurationManager.ConnectionStrings["customerDbConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            string sqlCmd = "select * from cutomerInfo";
            SqlCommand cmd = new SqlCommand(sqlCmd, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            gvCustomer.DataSource = dr;
            gvCustomer.DataBind();
        }*/
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


namespace _154AmnaAlwzrah.App_Code
{
    public class CRUD
    {
        public static string myVar = "KSA";
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adp;
        DataSet ds;
        DataView dv;
        // istesd of pasting connection string in each page this refrence the connection on the webconfig  
        public static string conStr = WebConfigurationManager.ConnectionStrings["customerDbConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(conStr);

        public CRUD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public SqlDataReader getDrPassSql(string mySql, Dictionary<string, object> myPara)
        {
            //USING keyword means : if u want ur connection to be closed in timely fashion 
            //we are using 'using' block which ensures that the connection is automatically closed when
            //the connection object goes out of scope
            //(we don't have to explicitly call the closed method on the connection object)
            SqlDataReader dr;
            using (SqlCommand cmd = new SqlCommand(mySql, con))
            {
                foreach (KeyValuePair<string, object> p in myPara)
                {
                    // can put validation here to see if the value is empty or not 
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
                con.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
        }
        public SqlDataReader getDrPassSql(string mySql)
        {
            SqlDataReader dr;
            using (SqlCommand cmd = new SqlCommand(mySql, con))
            {
                //foreach (KeyValuePair<string, object> p in myPara)
                //{
                //    // can put validation here to see if the value is empty or not 
                //    cmd.Parameters.AddWithValue(p.Key, p.Value);
                //}
                con.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
        }
        public int InsertUpdateDelete(string sqlCmd)
        {
            int rtn = 0;
            using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
            {
                cmd.CommandType = CommandType.Text;
                using (con)
                {
                    con.Open();
                    rtn = cmd.ExecuteNonQuery();  // -1    > = 1 
                    con.Close();
                }
            }
            return rtn;
        }
        public int InsertUpdateDelete(string sqlCmd, Dictionary<string, object> myPara)
        {
            int rtn = 0;
            using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
            {
                cmd.CommandType = CommandType.Text;
                foreach (KeyValuePair<string, object> p in myPara)
                {
                    cmd.Parameters.AddWithValue(p.Key, p.Value);
                }
                using (con)
                {
                    con.Open();
                    try
                    {
                        rtn = cmd.ExecuteNonQuery();
                    }
                    catch {
                        return rtn;
                    }
                    con.Close();
                }
            }
            return rtn;
        }
    }
}
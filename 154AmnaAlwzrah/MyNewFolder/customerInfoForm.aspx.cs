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

namespace _154AmnaAlwzrah.MyNewFolder
{
    public partial class customerInfoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //means code inside this block will be called just for the first time 
            //we go and request the server side
            if (!IsPostBack)
            {
                populateCountryCombo();
                //populateHobbies();
            }
        }



        protected void btnRegister_Click(object sender, EventArgs e)
        {
            /* just to Make sure to grap the Data and print them
            NewCustomer myCustomer = new NewCustomer();
            myCustomer.CustomerFirstName = txtFirstName22.Text;
            myCustomer.CustomerLastName = txtLastName2.Text;
            //myCustomer.CountryID = ddlCountry2.SelectedIndex + 1;
            myCustomer.CountryID = Convert.ToInt32(ddlCountry2.SelectedItem.Value);
            myCustomer.Active = cbActive.Checked;*/

            //print(myCustomer); //LOOk how we passed an object not an attribute!
            registerNewCustomer2();
        }

        protected void registerNewCustomer()//this func Don't add the hobbies in the hobby table
        {
            CRUD myCrud = new CRUD(); //@ this sign in the begining means take the whole "text" even if it takes more than 1 line without use +
            // always write and test your SQL statments in the SQL server 
            string mySql = @"insert into customerInfo (customerFirstName, customerLastName, customerArabicName, budget, countryID, active, hobby) 
                           values(@customerFirstName, @customerLastName, @customerArabicName, @budget, @countryID, @active, @hobby)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            //Now define the Parameters ;)
            myPara.Add("@customerFirstName", txtFirstName2.Text);
            myPara.Add("@customerLastName", txtLastName2.Text);
            myPara.Add("@customerArabicName", txtArabic2.Text);
            myPara.Add("@budget", Convert.ToInt32(txtBudget2.Text));
            myPara.Add("@countryID", ddlCountry2.SelectedValue);
            myPara.Add("@active", rList2.SelectedValue);
            myPara.Add("@hobby", Storehobbies());

            myCrud.InsertUpdateDelete(mySql, myPara);//Check of the validation of this function by checking the return value

            //Show the updated Table
            selectCustomers();
            lblResult.Text = "Customer Registered Successfully ;)";
        }

        protected int getCusId() //Get Last inserted Customer ID
        {
            CRUD myCrud = new CRUD();
            string mySql2 = "select ident_current('customerInfo')";
            SqlDataReader dr = myCrud.getDrPassSql(mySql2);

            dr.Read();
            int id = Convert.ToInt32(dr[0]);
            return id;
        }

        protected string Storehobbies()// store Hobbies as one string in the main table
        {
            string chkboxselect = "";
            for (int i = 0; i < cbHoppy2.Items.Count; i++)
            {
                if (cbHoppy2.Items[i].Selected)
                {
                    if (chkboxselect == "")
                    {
                        chkboxselect = cbHoppy2.Items[i].Text;
                    }
                    else
                    {
                        chkboxselect += "," + cbHoppy2.Items[i].Text;
                    }
                }
            }
            return chkboxselect;

        }

        //this func Add hobbies in the hobbies table and link btw customer and its hobbies with one to many relationship(PK, FK),
        //this table also displays customer hobbies like the first func
        protected void registerNewCustomer2()
        {
            //server side validation, simple one with if conditions
           if (formValidation())
           {
                saveDate();
           }
        }


        // this func saves the new customer's data in "customerInfo table " 
        protected void saveDate()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"insert into customerInfo (customerFirstName, customerLastName, customerArabicName, budget, countryID, active, hobby) 
                           values(@customerFirstName, @customerLastName, @customerArabicName, @budget, @countryID, @active, @hobby)";
            //wait, why we need to grep PK now?, to use it as FK in hobby table
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            //Now define the Parameters ;)
            myPara.Add("@customerFirstName", txtFirstName2.Text);
            myPara.Add("@customerLastName", txtLastName2.Text);
            myPara.Add("@customerArabicName", txtArabic2.Text);
            myPara.Add("@countryID", ddlCountry2.SelectedValue);

            myPara.Add("@hobby", Storehobbies());

            int budget = 0;
            try
            {
                budget = Convert.ToInt32(txtBudget2.Text);
            }
            catch
            {
                lblResult.Text = "Please Enter an Integer to represent the budget";
                return;
            }
            myPara.Add("@budget", budget);
            myPara.Add("@active", rList2.SelectedValue);

            myCrud.InsertUpdateDelete(mySql, myPara);

            //Show the updated Table
            selectCustomers();


            //grep the customer ID 
            int customerID = getCusId();
            lblResult.Text = "Customer Registered Successfully ;) <br>  With ID No. " + customerID;

            StoreHobbiesInHobbyTable(getCusId());


        }

        //this func takes last inserted customer id to fill its hobbies in Hobby table
        //or takes the customer id provided to update its hobbies in Hobby table
        protected void StoreHobbiesInHobbyTable(int id)
        {
           
            registerHobby(id, getHobbiesList());
        }

         protected List<string> getHobbiesList()
        {
            //iterate checkBoxes collection and capture the selected values
            List<string> mySelectedHobbies = new List<string>();
            //"ListItem" Represents a data item in a data-bound list control.
            foreach (ListItem item in cbHoppy2.Items)
            {
                if (item.Selected)
                {
                    mySelectedHobbies.Add(item.Text);
                }
            }
            return mySelectedHobbies;
        }

        protected Boolean formValidation()
        {
            //System.Threading.Thread.Sleep(7000); to memic the latency of dealing with server
            //You could do : if (string.IsNullOrEmpty(txtFirstName2.Text)) from kudvenkat channel
          if (txtFirstName2.Text == "" || txtLastName2.Text == "" || txtArabic2.Text == "" || txtBudget2.Text == "" || rList2.SelectedIndex == -1)
            {
                lblResult.Text = "Please Fill All The Fields, To Register New Customer";
               return false;

            }
            else
           {
                return true;
            }
        }

        //Fills hobby table ,call this func after inserting into customerInfo table or when update customer
        protected void registerHobby(int customerID, List<string> mySelectedHobbies)
        {
            //iterate through the list which contains the hobbies from the checkboxes
            foreach (string item in mySelectedHobbies)
            {
                string mySql = @"insert into hobby values(@customerID, @hobbyName)";
                CRUD myCrud = new CRUD();
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@customerID", customerID);
                myPara.Add("@hobbyName", item);
                myCrud.InsertUpdateDelete(mySql, myPara);
            }
        }
        protected void populateCountryCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = "select country, countryId from country";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);

            ddlCountry2.DataValueField = "countryId"; //when select one country text, store its value from "countryId" column in database
            ddlCountry2.DataTextField = "country"; //the text dispayed in ddl is from the country column

            ddlCountry2.DataSource = dr;
            ddlCountry2.DataBind();
        }



        ///////// ADO Techniqe to access DB ////////// & Display Data in GridView
        protected void btnShow_Click(object sender, EventArgs e)
        {
            /*string conStr = WebConfigurationManager.ConnectionStrings["customerDbConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            string sqlCmd = "select * from customerInfo";
            SqlCommand cmd = new SqlCommand(sqlCmd, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            gvShow.DataSource = dr;
            gvShow.DataBind();
            con.Close();*/

            selectCustomers();
        }
        protected void selectCustomers()
        {
            CRUD myCrud = new CRUD();
            string conStr = WebConfigurationManager.ConnectionStrings["customerDbConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);

            string mySql = @"select customerID as [customer ID],	customerFirstName as [customer First Name],	customerLastName as [customer Last Name],	customerArabicName as 
                           [customer Arabic Name], [country],  active, registrationDate as [registration Date],budget,hobby as    [hobbies]  from customerInfo
                           inner join country
                           on customerInfo.countryID = country.countryId ";

            /*SqlDataAdapter ad = new SqlDataAdapter(mySql, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            gvShow.DataSource = dt;
            gvShow.DataBind();*/

            SqlDataReader dr = myCrud.getDrPassSql(mySql);

            gvShow.DataSource = dr;
            gvShow.DataBind();
            gvShow.Columns[8].ItemStyle.Width = 70;


        }
     

        protected void selectCustomer()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select customerID as [customer ID],	customerFirstName as [customer First Name],	customerLastName as [customer Last Name],	customerArabicName as 
                           [customer Arabic Name], [country],  [active], registrationDate as [Registration Date],budget,hobby as    [hobbies]  from customerInfo
                           inner join country
                           on customerInfo.countryID = country.countryId where customerID = @customerID";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            //Now define the Parameters ;)
            myPara.Add("@customerID", txtCustomerId2.Text);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            
            gvShow.DataSource = dr;
            gvShow.DataBind();

            lblResult.Text = "These are The Information of Customer with ID : " + txtCustomerId2.Text;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (deleteValidation())
            {
                deleteData();
                //Show the updated Table
                selectCustomers();
            }
        }

        protected Boolean deleteValidation()
        {
            if (txtCustomerId2.Text == "")
            {
                lblResult.Text = "Please Enter Customer ID To Delete its Information";
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void deleteData()
        {
            CRUD myCrud = new CRUD();
            string mySql = "DELETE FROM customerInfo WHERE customerID = @customerID";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@customerID", txtCustomerId2.Text);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if(rtn >= 1)
            {
                lblResult.Text = "Customer No." + txtCustomerId2.Text + " Deleted Successfully ;)";
            }
            else
            {
                lblResult.Text = "Delete Failed !";
            }
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (updateValidation())
            {
                updateData();
                //Show the updated Table
                selectCustomers();
            }
        }


        protected void updateData()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"UPDATE customerInfo
                           SET customerFirstName = @customerFirstName, customerLastName = @customerLastName, customerArabicName = @customerArabicName, budget = @budget, countryID = @countryID, active = @active, hobby = @hobby
                           WHERE customerID = @customerID";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            //Now define the Parameters ;)
            myPara.Add("@customerFirstName", txtFirstName2.Text);
            myPara.Add("@customerLastName", txtLastName2.Text);
            myPara.Add("@customerID", txtCustomerId2.Text);
            myPara.Add("@customerArabicName", txtArabic2.Text);
            myPara.Add("@countryID", ddlCountry2.SelectedValue);
            myPara.Add("@hobby", Storehobbies());

            myPara.Add("@budget", Convert.ToInt32(txtBudget2.Text));
            myPara.Add("@active", rList2.SelectedValue);//selectedItem.Value
           

            //if(DeleteHobbiesFromDb() >= 1){
                DeleteHobbiesFromDb();
            //}

            StoreHobbiesInHobbyTable(int.Parse(txtCustomerId2.Text));

            myCrud.InsertUpdateDelete(mySql, myPara);

            lblResult.Text = "Customer No." + txtCustomerId2.Text + " Updated Successfully ;)";
        }

        protected int DeleteHobbiesFromDb()//cuz we will add them again from the updated checkboxes, if we didnt delete hobbies, we will have dublicate hobbies in hobby T
        {
            CRUD myCrud = new CRUD();
            string mySql = "delete from hobby where customerID = @customerID";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@customerID", txtCustomerId2.Text);

            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            return rtn;
        }

        protected Boolean updateValidation()
        {
            if (txtFirstName2.Text == "" || txtLastName2.Text == "" || txtArabic2.Text == "" || txtBudget2.Text == "" || txtCustomerId2.Text == "" || rList2.SelectedItem.Value == null)
            {
                lblResult.Text = "Please Fill All The Text Fields, Including Customer ID To Update its Information!";
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void btnShowCustomer_Click(object sender, EventArgs e)
        {
            if (selectValidation())
            {
                selectCustomer();
            }
           
        }
        protected Boolean selectValidation()
        {
            if (txtCustomerId2.Text == "")
            {
                lblResult.Text = "Please Enter Customer ID To Show its Information";
                return false;
            }
            else
            {
                return true;
            }
        }

        // this func called when click on Linkbutton to fill the form with the specified customer info
        protected void populateForm_Click(object sender, EventArgs e)
        {
            //grep the customer id from the clicked object
            int customerId = int.Parse((sender as LinkButton).CommandArgument);
            //we will fech most of the data from the GridView to the form, instead from the Db
            int rowInd = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;

            txtCustomerId2.Text = customerId.ToString();
            txtFirstName2.Text = gvShow.Rows[rowInd].Cells[1].Text;
            txtLastName2.Text = gvShow.Rows[rowInd].Cells[2].Text;
            txtArabic2.Text = gvShow.Rows[rowInd].Cells[3].Text;
            txtBudget2.Text = gvShow.Rows[rowInd].Cells[7].Text;

            //clear the previously selection, so we can select again from the text in GridView
            ddlCountry2.ClearSelection();
            string ddlText = gvShow.Rows[rowInd].Cells[4].Text;
            ddlCountry2.Items.FindByText(ddlText).Selected = true;

            //so everytime we click on another ID, we clear the previous selected radioButton
            rList2.ClearSelection();

            //define a row, so we can 
            //GridViewRow row = ((GridViewRow)(sender as Control).NamingContainer);
            //CheckBox chk = row.Cells[5].Controls[0] as CheckBox;
            CheckBox chk = gvShow.Rows[rowInd].Cells[5].Controls[0] as CheckBox;
            if (chk.Checked)
            {
                //in DB we used 0, 1 as BIT not "True" or "False" as strings !
                rList2.Items.FindByValue("1").Selected = true;  
            }
            else
            {
                rList2.Items.FindByValue("0").Selected = true;
            }

            cbHoppy2.ClearSelection();

            // now fetch the hobbies from DB to the form
            CRUD myCrud = new CRUD();
            string mySql = "select hobbyName from hobby where customerID = "+customerId.ToString();
         
            SqlDataReader mdr = myCrud.getDrPassSql(mySql);
            // collect the hobbyName (s) from that column in DB
            List<string> list = new List<string>();
            while (mdr.Read())
            {
                list.Add(mdr.GetString(0));
            }
            string[] hobbiesArray = list.ToArray<string>();
            // iterate through the array of hibbies strings and check the checkBoxes 
            foreach(string hobby in hobbiesArray)
            {
                cbHoppy2.Items.FindByValue(hobby).Selected = true;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomerId2.Text = "";
            txtFirstName2.Text = "";
            txtLastName2.Text = "";
            txtArabic2.Text = "";
            txtBudget2.Text = "";
            ddlCountry2.ClearSelection();
            rList2.ClearSelection();
            cbHoppy2.ClearSelection();
        }
        
        /*rotected void Print(NewCustomer clint) //Here we are نفصفص the object ;)
        {
          // Boolean clintActive = clint.Active;
          // Lbl.Text = clintActive.ToString();
           int clintCountyId = clint.CountryID;
           Lbl.Text = clintCountyId.ToString();
        }*/
    }
}

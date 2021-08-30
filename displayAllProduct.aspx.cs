using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;

namespace Cloud
{
    // string cs = Global.CS;
    
    public partial class displayAllProduct : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            //addPro();
            showCloths();
        }
       // void addPro()
       // {
       //     SqlConnection con = new SqlConnection(strConnString);

       // }
        
        void showCloths()
        {

            string prodID = Request.QueryString["ProductId"];
            SqlConnection con = new SqlConnection(strConnString);

            string cmdText = "SELECT * FROM Pro";
           // string cmdText = "SELECT .id, Artists.profile_picture_path, Users.full_name FROM Users";
            // string cmdText = "SELECT Artists.profile_picture_path, Users.full_name, Artists.bio_text, Artists.total_earn,Products.id, Products.product_picture_path, Products.name, Products.stock_qty, Products.unit_price, Products.category, Products.description FROM ((Users INNER JOIN Artists on Users.id = Artists.user_id) INNER JOIN Products on  Artists.id = Products.upload_id) where upload_id LIKE @upload_id";
            //====== Providning information to SQL command object about which query to 
            //====== execute and from where to get database connection information.
            SqlCommand cmd = new SqlCommand(cmdText, con);
            //SqlDataReader reader = cmd.ExecuteReader();

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd = new SqlCommand(cmdText, con);
            SqlDataReader reader;


            reader = cmd.ExecuteReader();

            //===== Adding parameters/Values.
            cmd.Parameters.AddWithValue("@ProductId", prodID);

            //===== To check current state of the connection object. If it is closed open the connection
            //===== to execute the insert query.




            


            Repeater1.DataSource = reader;
            Repeater1.DataBind();


            
        //    Repeater1.DataSource = cmd.ExecuteReader();
        //    Repeater1.DataBind();
            //  con.Close();



        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                //==== This case will fire when link button placed
                //==== inside repeater having command name "Delete" is clicked.


                //==== This case will fire when link button placed
                //==== inside repeater having command name "Edit" is clicked.
                case ("productdetails"):

                    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                    int prodID = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect("productDisplay.aspx?id=" + prodID);
                    //==== Call delete method and pass id as argument.
                    // editdata(id);
                    break;

            }
        }
    }
}
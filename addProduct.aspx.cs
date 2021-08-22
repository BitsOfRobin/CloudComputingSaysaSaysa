

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace asn.html
{
    public partial class addProduct : System.Web.UI.Page
    {
        string cs = "Server=tcp:zleandb.database.windows.net,1433;Initial Catalog=zleandb;Persist Security Info=False;User ID=zleandb;Password=Martindb5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        //static string arIdFound;
        //static string arFound;
        private Byte[] pic;
        //public static void arIdParam(string aRidPass)
        //{

        //    addProduct.arIdFound = aRidPass;


        //}

        //public static void arParam(string arPass)
        //{

        //    addProduct.arFound = arPass;


        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            lblzlDateAdd.Text = DateTime.Now.ToString();

            String check = Session["type"] as String;
            String id = Session["Id"] as String;
            //if(check!="Artist" && id!= "Admin")
            //{
            //    Response.Redirect("Homepage.aspx");


            //}



            //else if(id=="Admin")
            //{

            //    btnAdd.Visible = true;
            //}

            //if(ImgUploadzl.HasFile==false)
            //{

            //    lblUpload.Visible = true;
            //    lblUpload.Text = "No image is uploaded";

            //}    



        }


        //static string idPass;

        //public static string paramPass(string idPass )
        //{
        //    testing.displayParam(idPass);

        //    return idPass;
        //}




        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string productId = createProductId();
            string artistAdd = "", arIdAdd = "", urlAdd = "";
            string nameAdd = txtzlNameAdd.Text;
            double priceAdd = Convert.ToDouble(txtzlPriceAdd.Text);
            DateTime dateAdd = DateTime.Now;
            int qtyAdd = Convert.ToInt32(txtzlQtyAdd.Text);
            //string urlAdd = txtUrlAdd.Text;
            txtzlDesAdd.TextMode = TextBoxMode.MultiLine;

            string DescriAdd = txtzlDesAdd.Text;
            txtzlDesAdd.Text.Replace(Environment.NewLine, "<br />");
            SqlConnection con = new SqlConnection(cs);

            byte[] imgarray = null;


            con.Open();


            if (ImgUploadzl.HasFile)
            {


                int imagefilelength = ImgUploadzl.PostedFile.ContentLength;
                imgarray = new byte[imagefilelength];
                HttpPostedFile image = ImgUploadzl.PostedFile;
                image.InputStream.Read(imgarray, 0, imagefilelength);


                string sql = @"INSERT INTO Pro(ProductId,Name,Price,Date,AvailableQty,PicUrl,Descri)
                VALUES(@ProductId,@Name,@Price,@Date,@AvailableQty,@PicUrl,@Descri,) ";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Parameters.AddWithValue("@Name", nameAdd);
                cmd.Parameters.AddWithValue("@Price", priceAdd);
                cmd.Parameters.AddWithValue("@Date", dateAdd);
                cmd.Parameters.AddWithValue("@AvailableQty", qtyAdd);
                cmd.Parameters.AddWithValue("@PicUrl", imgarray);
                cmd.Parameters.AddWithValue("@Descri", DescriAdd);

                //arIdAdd = Request.QueryString["ArtistId"];
                //arIdAdd = Session["Id"] as string;
                //cmd.Parameters.AddWithValue("@ArtistId", Session["Id"] as string);


                cmd.ExecuteNonQuery();






                string url = string.Format("productDisplay.aspx?ProductId={0}", productId);
                Response.Redirect(url);

            }


            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' NO image is uploaded')", true);

            }




            con.Close();


            String url2 = string.Format("productDisplay.aspx?ProductId={0}", productId);
            Response.Redirect(url2);



            //string idPass=addProduct.paramPass(proIdAdd);





        }





        protected string createProductId()
        {

            string newId = "";
            string sql = "SELECT TOP 1 Counter FROM Pro ORDER BY Counter DESC";
            string check = "SELECT COUNT(ProductId) FROM Pro";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand checkEmpty = new SqlCommand(check, con);
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();

            int dr = (int)checkEmpty.ExecuteScalar();
            con.Close();
            con.Open();
            if (dr > 0)
            {
                int tempId = (int)cmd.ExecuteScalar() + 1;
                newId = "P" + tempId.ToString();
            }
            else
            {
                newId = "P1";
            }
            con.Close();
            return newId;
        }

        private void Imageuploadzl()
        {
            if (ImgUploadzl.HasFile)
            {
                string proId = Request.QueryString["ProductId"] ?? "";
                int imagefilelength = ImgUploadzl.PostedFile.ContentLength;
                byte[] imgarray = new byte[imagefilelength];
                HttpPostedFile image = ImgUploadzl.PostedFile;
                image.InputStream.Read(imgarray, 0, imagefilelength);

                string sql = "UPDATE Product Set PicUrl = @PicUrl WHERE ProductId = @ProductId";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@PicUrl", imgarray);
                cmd.Parameters.AddWithValue("@ProductId", proId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string productId = createProductId();
            string artistAdd = "", arIdAdd = "", urlAdd = "";
            string nameAdd = txtzlNameAdd.Text;
            double priceAdd = Convert.ToDouble(txtzlPriceAdd.Text);
            DateTime dateAdd = DateTime.Now;
            int qtyAdd = Convert.ToInt32(txtzlQtyAdd.Text);
            //string urlAdd = txtUrlAdd.Text;
            txtzlDesAdd.TextMode = TextBoxMode.MultiLine;

            string DescriAdd = txtzlDesAdd.Text;
            txtzlDesAdd.Text.Replace(Environment.NewLine, "<br />");
            SqlConnection con = new SqlConnection(cs);

            byte[] imgarray = null;


            con.Open();


            if (ImgUploadzl.HasFile)
            {


                int imagefilelength = ImgUploadzl.PostedFile.ContentLength;
                imgarray = new byte[imagefilelength];
                HttpPostedFile image = ImgUploadzl.PostedFile;
                image.InputStream.Read(imgarray, 0, imagefilelength);


                string sql = @"INSERT INTO Pro(ProductId,Name,Price,Date,AvailableQty,PicUrl,Descri)
                VALUES(@ProductId,@Name,@Price,@Date,@AvailableQty,@PicUrl,@Descri) ";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Parameters.AddWithValue("@Name", nameAdd);
                cmd.Parameters.AddWithValue("@Price", priceAdd);
                cmd.Parameters.AddWithValue("@Date", dateAdd);
                cmd.Parameters.AddWithValue("@AvailableQty", qtyAdd);
                cmd.Parameters.AddWithValue("@PicUrl", imgarray);
                cmd.Parameters.AddWithValue("@Descri", DescriAdd);

                //arIdAdd = Request.QueryString["ArtistId"];
                //arIdAdd = Session["Id"] as string;
                //cmd.Parameters.AddWithValue("@ArtistId", "a15");


                cmd.ExecuteNonQuery();






                string url = string.Format("productDisplay.aspx?ProductId={0}", productId);
                Response.Redirect(url);

            }


            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' NO image is uploaded')", true);

            }




            con.Close();


            String url2 = string.Format("productDisplay.aspx?ProductId={0}", productId);
            Response.Redirect(url2);



            //string idPass=addProduct.paramPass(proIdAdd);
        }
    }
}

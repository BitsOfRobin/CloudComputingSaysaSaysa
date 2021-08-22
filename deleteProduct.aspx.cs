using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace asn
{
    public partial class deleteProduct : System.Web.UI.Page
    {
        string cs = "Server=tcp:zleandb.database.windows.net,1433;Initial Catalog=zleandb;Persist Security Info=False;User ID=zleandb;Password=Martindb5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        //static string proIdFind;  //// uncomment this pass the productId dynamically here
        //public static void displayParam(string idPass)
        //{
        //    customerDisplay.proIdFind = idPass;
        //}

        private Byte[] pic;
        protected void Page_Load(object sender, EventArgs e)
        {
            String artistId = Session["Id"] as String;
            String arId = " ";
            if (!Page.IsPostBack)
            {
              



                string proIdFind = Request.QueryString["ProductId"];

                if (proIdFind != null)
                {
                    bool found = false;
                    string sql = "SELECT * FROM Pro WHERE ProductId=@ProductId";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ProductId", proIdFind);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    string name = "", date = "", descri = "", nameAR = "", price = "", qty = "";
                    if (dr.Read())
                    {
                        name = string.Format("{0}", dr["Name"]);
                        price = string.Format("{0}", dr["Price"]);
                        date = string.Format("{0}", dr["Date"]);
                        descri = string.Format("{0}", dr["Descri"]);
                        pic = ((Byte[])dr["PicUrl"]);
                        qty = string.Format("{0}", dr["AvailableQty"]);
                        //arId = string.Format("{0}", dr["ArtistId"]);
                        //imgDisplay.Attributes["src"] = "../Handlers/ImgHandler.ashx?id=" + proIdFind;
                        //id = string.Format("{0}", dr["ProductId"]);
                    }
                    dr.Close();
                    lblzlName.Text = name;
                    lblzlPrice.Text = price;
                    lblzlDes.Text = descri;
                    lblzlDate.Text = date;
                    lblzlQty.Text = qty;
                    lblzlArId.Text = arId;
                    lblzlProId.Text = proIdFind;
                    //string imgPath = Path.GetPathRoot(pic);
                    //imgDisplay.ImageUrl= "~/ assets / bck.jpg" ;
                    string imgByte = Convert.ToBase64String(pic, 0, pic.Length);
                    imgDisplay.ImageUrl = "data:image/jpg;base64," + imgByte;
                    //string sqlArt = "SELECT * FROM Artist";
                    //SqlCommand cmdArt = new SqlCommand(sqlArt, con);
                    //SqlDataReader drArt = cmdArt.ExecuteReader();
                    //if (drArt.Read())
                    //{
                    //    nameAR = string.Format("{0}", drArt["Name"]);
                    //}
                    //lblzlArtist.Text = nameAR;
                    //drArt.Close();
                    //con.Close();
                    //if (!found)
                    //{
                    //}
                    con.Close();
                }
                //else
                //{
                //    Response.Redirect("Homepage.aspx");


                //}

                //if(artistId!=arId &&artistId != "Admin")
                //{


                //    Response.Redirect("Homepage.aspx");

                //}
                //else if (artistId == "Admin")
                //{
                //    btnDel.Visible = true;

                //}


            }

            //else
            //{


            //    //if (artistId != lblzlArId.Text && artistId != "Admin")
            //    //{


            //    //    Response.Redirect("Homepage.aspx");

            //    //}
            //    //else if (artistId == "Admin")
            //    //{
            //    //    btnDel.Visible = true;

            //    //}


            //}

        }
        protected void btnDel_Click(object sender, EventArgs e)
        {
            string id = lblzlProId.Text;
            string sql = "DELETE FROM Pro WHERE ProductId=@ProductId";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ProductId", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Success.aspx?type=deleteProduct");
        }
        protected void btnccl_Click(object sender, EventArgs e)
        {
            Response.Redirect("Success.aspx?type=deleteProduct");
        }
    }
}

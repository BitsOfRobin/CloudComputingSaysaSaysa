using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace asn
{
    public partial class testing : System.Web.UI.Page
    {
        string cs =  "Server=tcp:zleandb.database.windows.net,1433;Initial Catalog = ZLeanDatabase; Persist Security Info=False;User ID = zlean; Password=Martindb5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";
        //static string proIdFound;
        private Byte[] pic;
        //public static void displayParam(string idPass)
        //{
        //    testing.proIdFound = idPass;
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            //String artistId = Session["Id"] as String;
            //String arId = " ";
            if (!Page.IsPostBack)
            {
                //string proIdFound = Session["id"] as string;
                //string proIdFound = Session["ProductId"] as string;
                string proIdFound = Request.QueryString["ProductId"];

                if (proIdFound != null)
                {
                    string sql = "SELECT * FROM Pro" +
                        " WHERE ProductId=@ProductId";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@ProductId", proIdFound);
                    SqlDataReader dr = cmd.ExecuteReader();
                    string name = "", date = "", descri = "", price = "", qty = "";
                    if (dr.Read())
                    {
                        name = string.Format("{0}", dr["Name"]);
                        price = string.Format("{0}", dr["Price"]);
                        date = string.Format("{0}", dr["Date"]);
                        descri = string.Format("{0}", dr["Descri"]);
                        pic = ((Byte[])dr["PicUrl"]);
                        qty = string.Format("{0}", dr["AvailableQty"]);
                        //arId = string.Format("{0}", dr["ArtistId"]);
                        //id = string.Format("{0}", dr["ProductId"]);
                    }
                    dr.Close();
                    lblzlName.Text = name;
                    lblzlPrice.Text = price;
                    lblzlDes.Text = descri;
                    lblzlDate.Text = date;
                    lblzlQty.Text = qty;
                    //lblzlArId.Text = arId;
                    lblzlProId.Text = proIdFound;
                    txtzlName.Text = name;
                    txtzlPrice.Text = price;
                    txtzlDes.Text = descri;
                    txtzlQty.Text = qty;

                    string imgByte = Convert.ToBase64String(pic, 0, pic.Length);
                    imgDisplay.ImageUrl = "data:image/jpg;base64," + imgByte;


                    //imgDisplay.Attributes["src"] = "../Handlers/ImgHandler.ashx?id=" + proIdFound;
                    //string imgPath = Path.GetPathRoot(pic);
                    //imgDisplay.ImageUrl = "~/ assets / bck.jpg";
                    //string imgByte = Convert.ToBase64String(pic, 0, pic.Length);
                    //imgDisplay.ImageUrl = "data:image/jpg;base64," + imgByte;
                    //string sqlArt = "SELECT * FROM Artist";
                    //SqlCommand cmdArt = new SqlCommand(sqlArt, con);
                    //SqlDataReader drArt = cmdArt.ExecuteReader();
                    //if(drArt.Read())
                    //{
                    //    nameAR = string.Format("{0}", drArt["Name"]);
                    //}
                    ////lblzlArtist.Text = nameAR;
                    //drArt.Close();
                    con.Close();
                }

                else
                {

                    //Response.Redirect("Homepage.aspx");

                }

                //if(artistId!=arId && artistId != "Admin")
                //{

                //    //Response.Redirect("Homepage.aspx");

                //}

                //else if(artistId == "Admin")
                //{
                //    btnDelete.Visible = true;
                //    btnEdit.Visible = true;
                //    btnSave.Visible = true;

                //}

            }


        //else
            //{

            //    if (artistId != arId && artistId != "Admin")
            //    {

            //        Response.Redirect("Homepage.aspx");

            //    }

            //    //else if (artistId == "Admin")
            //    //{
            //    //    btnDelete.Visible = true;
            //    //    btnEdit.Visible = true;
            //    //    btnSave.Visible = true;

            //    //}

            //}
        }
        private void Imageupload()
        {
            if (ImgUpload.HasFile)
            {
                string id = Request.QueryString["ProductId"] ?? "";
                int imagefilelength = ImgUpload.PostedFile.ContentLength;
                byte[] imgarray = new byte[imagefilelength];
                HttpPostedFile image = ImgUpload.PostedFile;
                image.InputStream.Read(imgarray, 0, imagefilelength);
                string sql;
                sql = "UPDATE Pro Set PicUrl = @image WHERE ProductId = @id";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@image", imgarray);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtzlName.Visible = true;
            txtzlPrice.Visible = true;
            txtzlQty.Visible = true;
            txtzlDes.Visible = true;
            btnEdit.Visible = false;
            btnSave.Visible = true;
            ImgUpload.Visible = true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Pro SET Name=@Name,Price=@Price, AvailableQty=@AvailableQty,Descri=@Descri WHERE ProductId=@ProductId";
            string editName = txtzlName.Text;
            string proId = lblzlProId.Text;
            double price = Convert.ToDouble(txtzlPrice.Text);
            txtzlDes.TextMode = TextBoxMode.MultiLine;
            string descri = txtzlDes.Text;
            txtzlDes.Text.Replace(Environment.NewLine, "<br />");
            //DateTime date = Convert.ToDateTime(txtzlDate.Text);
            double qty = Convert.ToDouble(txtzlQty.Text);
            //Byte imgByte = Convert.ToByte( imgDisplay.ImageUrl);
            //string arId = lblzlArId.Text;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ProductId", proId);
            cmd.Parameters.AddWithValue("@Name", editName);
            cmd.Parameters.AddWithValue("@Price", price);
            //cmd.Parameters.AddWithValue("@Date", date);
            cmd.Parameters.AddWithValue("@AvailableQty", qty);
            //cmd.Parameters.AddWithValue("@PicUrl", imgByte);
            cmd.Parameters.AddWithValue("@Descri", descri);
            //cmd.Parameters.AddWithValue("@ArtistId", arId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Imageupload();
            string url = string.Format("productDisplay.aspx?ProductId={0}", Request.QueryString["ProductId"]);
            Response.Redirect(url);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["ProductId"];
            string direct;
            direct = "deleteProduct.aspx?ProductId=" + id;
            Response.Redirect(direct);
        }
    }
}

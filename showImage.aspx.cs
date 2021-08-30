using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace Cloud
{
    public partial class showImage : System.Web.UI.Page
    {
        string strConnString = "Server=tcp:zleandb.database.windows.net,1433;Initial Catalog = ZLeanDatabase; Persist Security Info=False;User ID = zlean; Password=Martindb5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30";
        string str;
        SqlCommand com;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            str = "select PicUrl from Pro where ProductId = '" + Request.QueryString["ProductId"] + "'";
            com = new SqlCommand(str, con);
            MemoryStream stream = new MemoryStream();
            byte[] image = (byte[])com.ExecuteScalar();
            stream.Write(image, 0, image.Length);
            Bitmap bitmap = new Bitmap(stream);
            Response.ContentType = "image/Jpeg";
            bitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
            con.Close();
            stream.Close();
        }
    }
}
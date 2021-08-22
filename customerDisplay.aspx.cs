




//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.IO;

//namespace asn
//{
//    public partial class customerDisplay : System.Web.UI.Page
//    {

//    }


//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace asn
{
    public partial class customerDisplay : System.Web.UI.Page
    {

        string cs = "Server=tcp:zleandb.database.windows.net,1433;Initial Catalog=zleandb;Persist Security Info=False;User ID=zleandb;Password=Martindb5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        //static string proIdFind;  ///Dummy Data can work eg, P15
        //static string cartFind;  ///Dummy Data can work eg, P15
        //static string custFind;  ///Dummy Data can work eg, P15
        //static string cartDeFind;  ///Dummy Data can work eg, P15

        //private Boolean found;
        private Byte[] pic;

        //public static void displayParam(string idPass)
        //{

        //    customerDisplay.proIdFind = idPass;


        //}

        //public static void displayCart(string idPass)
        //{

        //    customerDisplay.cartFind = idPass;


        //}
        //public static void displayCartDe(string idPass)
        //{

        //    customerDisplay.cartDeFind = idPass;


        //}
        //public static void displayCust(string idPass)
        //{

        //    customerDisplay.custFind = idPass;


        //}

        protected void Page_Load(object sender, EventArgs e)
        {

            string check = Session["type"] as String;


            if (!Page.IsPostBack)
            {
                //found = true;

                //if (check == "Artist")
                //{

                //    btncart.Visible = false;
                //    btnWishList.Visible = false;
                //    ddlStdQty.Visible = false;
                //    //found = true;
                //}





                string proIdFind = Request.QueryString["ProductId"];


                String sqlDetect = "SELECT ProductId FROM Pro";
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmdDetect = new SqlCommand(sqlDetect, con);
                con.Open();

                SqlDataReader drDetect = cmdDetect.ExecuteReader();
                List<String> listDetect = new List<string>();
                while (drDetect.Read())
                {
                    listDetect.Add(string.Format("{0}", drDetect["ProductId"]));

                }
                drDetect.Close();
                con.Close();


                if (listDetect.Contains(proIdFind))
                {
                    string sql = "SELECT * FROM Pro WHERE ProductId=@ProductId";




                    //SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue(
                        "@ProductId", proIdFind);

                    con.Open();


                    SqlDataReader dr = cmd.ExecuteReader();

                    string name = "", date = "", descri = "", nameAR = "", price = "", qty = "", arId = " ";



                    if (dr.Read())
                    {
                        name = string.Format("{0}", dr["Name"]);
                        price = string.Format("{0}", dr["Price"]);
                        date = string.Format("{0}", dr["Date"]);
                        descri = string.Format("{0}", dr["Descri"]);
                        pic = ((Byte[])dr["PicUrl"]);
                        qty = string.Format("{0}", dr["AvailableQty"]);
                        arId = string.Format("{0}", dr["ArtistId"]);
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


                    //string sqlArt = "SELECT * FROM Artist WHERE ArtistId=@ArtistId";
                    //SqlCommand cmdArt = new SqlCommand(sqlArt, con);
                    //cmdArt.Parameters.AddWithValue("@ArtistId", arId);
                    //SqlDataReader drArt = cmdArt.ExecuteReader();

                    //if (drArt.Read())
                    //{
                    //    nameAR = string.Format("{0}", drArt["Name"]);

                    //}

                    //lblzlArtist.Text = nameAR;

                    //drArt.Close();


                    con.Close();


                    for (int i = 1; i <= Convert.ToInt32(qty); i++)
                    {

                        ddlStdQty.Items.Add(i.ToString());



                    }

                    string custId = Session["Id"] as String;

                    //Boolean choice = false;
                    //if (custId != null)
                    //{

                    //    int first;




                    //    try{
                    //        choice = int.TryParse(custId.Substring(0, 1), out first);
                    //        choice = true;
                    //    }

                    //    catch
                    //    {
                    //        choice = false;

                    //    }

                    //}


                    if (custId != null && check == "Customer")
                    {
                        //con.Open();
                        //string sqlFind = "SELECT CartId FROM Cart WHERE CustomerId=@CustomerId";
                        //List<String> cartId = new List<string>();
                        ////Boolean found = false;
                        //SqlCommand cmdFind = new SqlCommand(sqlFind, con);

                        //cmdFind.Parameters.AddWithValue("@CustomerId", custId);


                        //SqlDataReader drFind = cmdFind.ExecuteReader();

                        ////if(drCart.HasRows)
                        ////   {
                        ////if(drFind.HasRows)
                        ////{
                        //int m = 0;
                        //while (drFind.Read())
                        //{

                        //    cartId.Insert(m,string.Format("{0}", drFind["CartId"]));


                        //    m++;
                        //}


                        ////}

                        //drFind.Close();

                        //int i = cartId.Count;

                        //String cartId = Session["CartId"] as String;
                        ////int k = 0;
                        ////int w = 0;
                        //List<String> proIdCart = new List<string>();
                        ////Boolean reduce = false;
                        ////while ( k!=cartId.Count)
                        ////{

                        //string sqlCartId = "SELECT ProductId FROM Cart_Detail WHERE CartId=@CartId";

                        ////Boolean found = false;
                        //SqlCommand cmdCartId = new SqlCommand(sqlCartId, con);

                        //cmdCartId.Parameters.AddWithValue("@CartId", cartId);

                        //con.Open();
                        //SqlDataReader drCart = cmdCartId.ExecuteReader();


                        //while (drCart.Read())
                        //{

                        //    proIdCart.Add(string.Format("{0}", drCart["ProductId"]));



                        //}

                        ////}

                        //if (proIdCart.Contains(proIdFind))
                        //{

                        //    //String url = String.Format("Cart.aspx?CartId={0}", cartId.ElementAt(k));
                        //    String url = String.Format("Cart.aspx?");
                        //    Response.Redirect(url);
                        //}

                        //proIdCart.Clear();


                        ////k++;
                        ////proIdCart.Clear();
                        //drCart.Close();
                        ////}
                        //string wishIdFind = Session["WishListId"] as String;

                        ////String custIdWish = Session["Id"] as String;
                        ////int k = 0;
                        ////int w = 0;
                        //List<String> proIdWish = new List<string>();
                        ////Boolean reduce = false;
                        ////while ( k!=cartId.Count)
                        ////{

                        //string sqlwishId = "SELECT ProductId  FROM WishList_Detail  WHERE WishListId=@WishListId";

                        ////Boolean found = false;
                        //SqlCommand cmdWishId = new SqlCommand(sqlwishId, con);

                        //cmdWishId.Parameters.AddWithValue("@WishListId", wishIdFind);

                        ////con.Open();
                        //SqlDataReader drWishId = cmdWishId.ExecuteReader();


                        //while (drWishId.Read())
                        //{

                        //    proIdWish.Add(string.Format("{0}", drWishId["ProductId"]));



                        //}

                        //}

                        //if (proIdWish.Contains(proIdFind))
                        //{
                        //    btnWishList.Visible = false;
                        //    //String url = String.Format("Cart.aspx?CartId={0}", cartId.ElementAt(k));
                        //    //String urlWish = String.Format("WishList.aspx?");
                        //    //Response.Redirect(urlWish);
                        //}




                        ////k++;
                        //proIdWish.Clear();
                        //drWishId.Close();
                        ////}


                        con.Close();

                    }


                    //if (check == "Artist")
                    //{

                    //    btncart.Visible = false;
                    //    btnWishList.Visible = false;
                    //    ddlStdQty.Visible = false;
                    //    //found = true;
                    //}

                    //if (Convert.ToInt32(qty) == 0)
                    //{

                    //    btncart.Visible = false;
                    //    btnWishList.Visible = true;
                    //    ddlStdQty.Visible = false;


                    //}


                    //////SqlConnection con = new SqlConnection(cs);
                    //////string proIdFind = Request.QueryString["ProductId"];
                    //string sqlSame = "SELECT ProductId FROM Pro";

                    ////Boolean found = false;
                    //SqlCommand cmdSame = new SqlCommand(sqlSame, con);

                    //cmdSame.Parameters.AddWithValue("@ProductId", proIdFind);

                    //con.Open();
                    //String artistId = "";
                    //SqlDataReader drSame = cmdSame.ExecuteReader();

                    ////if(drCart.HasRows)
                    ////   {
                    ////if(drFind.HasRows)
                    ////{

                    //if (drSame.Read())
                    //{

                    //    artistId = string.Format("{0}", drSame["ArtistId"]);



                    //}


                    ////}

                    //drSame.Close();

                    int k = 0;
                    List<String> proIdList = new List<String>();
                    List<int> randomNum = new List<int>();
                    List<String> sameArt = new List<String>();
                    for (int i = 0; i < 5; i++)
                    {

                        sameArt.Add(null);
                        proIdList.Add(null);
                        randomNum.Add(i);
                    }


                
                   

                    string sqlPic = "SELECT PicUrl,ProductId FROM Pro";


                    SqlCommand cmdPic = new SqlCommand(sqlPic, con);

                    //cmdPic.Parameters.AddWithValue("@ArtistId", arId);
                    con.Open();

                    SqlDataReader drPic = cmdPic.ExecuteReader();

                    //if (drPic.Read())
                    //{

                    //    pic = ((Byte[])drPic["PicUrl"]);
                    //    string img = Convert.ToBase64String(pic, 0, pic.Length);

                    //    Imagez1.ImageUrl = "data:image/jpg;base64," + img;

                    //    //sameArt.Insert(k,pic);
                    //    //k++;

                    //}
                    int f = 0;
                    while (drPic.Read())
                    {

                        pic = ((Byte[])drPic["PicUrl"]);
                        string img = Convert.ToBase64String(pic, 0, pic.Length);
                        if (img != imgByte)
                        {
                            sameArt.Insert(f, img);
                            proIdList.Insert(f, string.Format("{0}", drPic["ProductId"]));


                            f++;
                        }





                    }



                    drPic.Close();


                    //List<String> proIdList = new List<String>();
                    //for (int i = 0; i < 5; i++)
                    //{

                    //    proIdList.Add(null);

                    //}




                    //string sqlPro = "SELECT ProductId FROM Product WHERE ArtistId=@ArtistId";
                    //int t = 0;
                    ////Boolean found = false;
                    //SqlCommand cmdPro = new SqlCommand(sqlPro, con);






                    //cmdPro.Parameters.AddWithValue("@ArtistId", arId);


                    //SqlDataReader drPro = cmdPro.ExecuteReader();

                    //while (drPro.Read())
                    //{

                    //    proIdList.Insert(t, string.Format("{0}", drPro["ProductId"]));

                    //    t++;
                    //}

                    //drPro.Close();
                   




                    //int[] randomNum= new int[5];
                    for (int i=0;i<5;i++)
                    {
                        Random rnd = new Random();

                       int num = rnd.Next(0,sameArt.Count);

                        if(!randomNum.Contains(num))
                        {
                            randomNum.Insert(i,num);


                        }

                    }




                    


                    if (sameArt.ElementAt(randomNum[0]) != null && proIdList.ElementAt(randomNum[0]) != null)
                    {
                        Imagez1.ImageUrl = "data:image/jpg;base64," + sameArt.ElementAt(randomNum[0]);

                        hykImage1.NavigateUrl = String.Format("customerDisplay.aspx?ProductId={0}", proIdList.ElementAt(randomNum[0]));
                    }
                    else
                    {
                        Imagez1.ImageUrl = "~/assets/ProductImg/Product1.jpg";

                    }


                    if (sameArt.ElementAt(randomNum[1]) != null && proIdList.ElementAt(randomNum[1]) != null)
                    {
                        Imagez2.ImageUrl = "data:image/jpg;base64," + sameArt.ElementAt(randomNum[1]);

                        hykImage2.NavigateUrl = String.Format("customerDisplay.aspx?ProductId={0}", proIdList.ElementAt(randomNum[1]));

                    }
                    else
                    {
                        Imagez2.ImageUrl = "~/assets/ProductImg/Product1.jpg";

                    }

                    if (sameArt.ElementAt(randomNum[2]) != null && proIdList.ElementAt(randomNum[2]) != null)
                    {
                        Imagez3.ImageUrl = "data:image/jpg;base64," + sameArt.ElementAt(randomNum[2]);

                        hykImage3.NavigateUrl = String.Format("customerDisplay.aspx?ProductId={0}", proIdList.ElementAt(randomNum[2]));

                    }
                    else
                    {

                        Imagez3.ImageUrl = "~/assets/ProductImg/Product1.jpg";
                    }



                    if (sameArt.ElementAt(randomNum[3]) != null && proIdList.ElementAt(randomNum[3]) != null)
                    {
                        Imagez4.ImageUrl = "data:image/jpg;base64," + sameArt.ElementAt(randomNum[3]);

                        hykImage4.NavigateUrl = String.Format("customerDisplay.aspx?ProductId={0}", proIdList.ElementAt(randomNum[3]));

                    }
                    else
                    {
                        Imagez4.ImageUrl = "~/assets/ProductImg/Product1.jpg";

                    }



                    if (sameArt.ElementAt(randomNum[4]) != null && proIdList.ElementAt(randomNum[4]) != null)
                    {
                        Imagez5.ImageUrl = "data:image/jpg;base64," + sameArt.ElementAt(randomNum[4]);

                        hykImage5.NavigateUrl = String.Format("customerDisplay.aspx?ProductId={0}", proIdList.ElementAt(randomNum[4]));

                    }
                    else
                    {
                        Imagez5.ImageUrl = "~/assets/ProductImg/Product1.jpg";

                    }

















                    //con.Close();
                }




                else
                {

                    Response.Redirect("Homepage.aspx?");


                }

            }


            else
            {

                //if (check == "Artist")
                //{

                //    btncart.Visible = false;
                //    btnWishList.Visible = false;
                //    ddlStdQty.Visible = false;
                //    //found = true;
                //}
                //if (Convert.ToInt32(lblzlQty.Text) == 0)
                //{

                //    btncart.Visible = false;
                //    btnWishList.Visible = true;
                //    ddlStdQty.Visible = false;


                //}



            }
        }

        protected void btncart_Click(object sender, EventArgs e)
        {






            string proId = lblzlProId.Text;
            int sltQty = Convert.ToInt32(ddlStdQty.SelectedValue);

            /////link to customer display require CustomerId parameter
            //string custId = Request.QueryString["custId"];
            //String custId ="none";

            String custId = Session["Id"] as String;

            //Boolean choice = false;
            //if (custId != null)
            //{

            //    int first;




            //    try
            //    {
            //        choice = int.TryParse(custId.Substring(0, 1), out first);
            //        choice = true;
            //    }

            //    catch
            //    {
            //        choice = false;

            //    }

            //}


            //if (custId != null && choice)
            if (custId != null)
            {



                //SqlConnection con = new SqlConnection(cs);
                // string sqlCart = @"INSERT INTO Cart(CustomerId,CartId)
                //VALUES(@CustomerId,@CartId) ";

                // SqlCommand cmdCart = new SqlCommand(sqlCart, con);



                // con.Open();
                // cmdCart.ExecuteNonQuery();


                // con.Close();





                // string sql = @"INSERT INTO Cart_Detail(CartDetailId,CartId,ProductId,SelectedQty)
                //VALUES(@CartDetailId,@CartId,@ProductId,@SelectedQty) ";



                // SqlCommand cmd = new SqlCommand(sql, con);
                // cmd.Parameters.AddWithValue("@ProductId", proId);
                // cmd.Parameters.AddWithValue("@SelectedQty", sltQty);

                // con.Open();
                // cmd.ExecuteNonQuery();
                // con.Close();

                //String urlcart = String.Format("cart.aspx?");
                //String urlcart = String.Format("Cart.aspx");

                //Response.Redirect(urlcart);



                //Response.Redirect("Cart.aspx?");
                //Server.Transfer("Cart.aspx?");

            }

            else
            {

                Response.Redirect("Login.aspx?");


            }




        }

        //protected void btnWishList_Command(object sender, CommandEventArgs e)
        //{


        //    String custId = Session["Id"] as String;
        //    //string custId = Request.QueryString["custId"];
        //    String cartId = Session["CartId"] as String;
        //    String wishId = Session["WishListId"] as String;
        //    String check = Session["type"] as String;

        //    //String custId = "none";
        //    //custId.Replace( custId,Session["Id"] as String);

        //    //if (String.Compare(custId, "none") == 0)
        //    //{
        //    //    Response.Redirect("Login.aspx?");

        //    //}



        //    //Boolean choice = false;

        //    //if (custId != null)
        //    //{
        //    //  int first;

        //    //    try
        //    //    {
        //    //        choice = int.TryParse(custId.Substring(0, 1), out first);
        //    //        choice = true;
        //    //    }

        //    //    catch
        //    //    {
        //    //        choice = false;
        //    //    }

        //    //}

        //    if (custId != null && check == "Customer")
        //    {
        //        SqlConnection con = new SqlConnection(cs);
        //        string sql = "";

        //        switch (e.CommandName)
        //        {


        //            case "Cart":
        //                sql = "INSERT INTO Cart_Detail(CartDetailId, CartId, ProductId, SelectedQty )VALUES(@CartDetailId, @CartId,  @ProductId,  @SelectedQty)";

        //                SqlCommand cmd = new SqlCommand(sql, con);
        //                cmd.Parameters.Add("@CartDetailId", CartListId());
        //                //cmd.Parameters.Add("@CartId", Session["CartId"] as string);
        //                cmd.Parameters.Add("@CartId", cartId);
        //                cmd.Parameters.Add("@ProductId", Request.QueryString["ProductId"]);
        //                cmd.Parameters.Add("@SelectedQty", ddlStdQty.SelectedItem.Text.ToString());


        //                con.Open();

        //                cmd.ExecuteNonQuery();

        //                con.Close();
        //                String urlcart = String.Format("Cart.aspx");

        //                Response.Redirect(urlcart);


        //                break;
        //            default:
        //                sql = "INSERT INTO WishList_Detail(WLDetailId, WishListId, ProductId )VALUES(@WLDetailId, @WishListId,  @ProductId)";

        //                SqlCommand cmd1 = new SqlCommand(sql, con);
        //                cmd1.Parameters.Add("@WLDetailId", WishListId());
        //                //cmd1.Parameters.Add("@WishListId", Session["WishListId"] as string);
        //                cmd1.Parameters.Add("@WishListId", wishId);
        //                cmd1.Parameters.Add("@ProductId", Request.QueryString["ProductId"]);


        //                con.Open();

        //                cmd1.ExecuteNonQuery();

        //                con.Close();

        //                String urlWish = String.Format("WishList.aspx");

        //                Response.Redirect(urlWish);

        //                break;
        //        }



        //    }



        //    else
        //    {

        //        Response.Redirect("Login.aspx?");


        //    }

        //}
        //protected string WishListId()
        //{
        //    string newId = "";
        //    string sql = "SELECT TOP 1 Counter FROM WishList_Detail ORDER BY Counter DESC";
        //    string check = "SELECT COUNT(WLDetailId) FROM WishList_Detail";
        //    SqlConnection con = new SqlConnection(cs);
        //    SqlCommand checkEmpty = new SqlCommand(check, con);
        //    SqlCommand cmd = new SqlCommand(sql, con);

        //    con.Open();

        //    int dr = (int)checkEmpty.ExecuteScalar();
        //    con.Close();
        //    con.Open();
        //    if (dr > 0)
        //    {
        //        int tempId = (int)cmd.ExecuteScalar() + 1;
        //        newId = "WD" + tempId.ToString();
        //    }
        //    else
        //    {
        //        newId = "WD1";
        //    }
        //    con.Close();
        //    return newId;









        //}

        //protected string CartListId()
        //{
        //    string newId = "";
        //    string sql = "SELECT TOP 1 Counter FROM Cart_Detail ORDER BY Counter DESC";
        //    string check = "SELECT COUNT(CartDetailId) FROM Cart_Detail";
        //    SqlConnection con = new SqlConnection(cs);
        //    SqlCommand checkEmpty = new SqlCommand(check, con);
        //    SqlCommand cmd = new SqlCommand(sql, con);

        //    con.Open();

        //    int dr = (int)checkEmpty.ExecuteScalar();
        //    con.Close();
        //    con.Open();
        //    if (dr > 0)
        //    {
        //        int tempId = (int)cmd.ExecuteScalar() + 1;
        //        newId = "CD" + tempId.ToString();
        //    }
        //    else
        //    {
        //        newId = "CD1";
        //    }
        //    con.Close();
        //    return newId;
        //}




        //protected void sameArtist()
        //{

        //    SqlConnection con = new SqlConnection(cs);
        //    string proIdFind = Request.QueryString["ProductId"];
        //    string sqlSame = "SELECT ArtistId FROM Product WHERE ProductId=@ProductId";

        //    //Boolean found = false;
        //    SqlCommand cmdSame = new SqlCommand(sqlSame, con);

        //    cmdSame.Parameters.AddWithValue("@ProductId", proIdFind);

        //    con.Open();
        //    String artistId = "";
        //    SqlDataReader drSame = cmdSame.ExecuteReader();

        //    //if(drCart.HasRows)
        //    //   {
        //    //if(drFind.HasRows)
        //    //{

        //    if (drSame.Read())
        //    {

        //       artistId=string.Format("{0}", drSame["ArtistId"]);



        //    }


        //    //}

        //    drSame.Close();

        //    int k = 0;
        //    List<String> sameArt = new List<String>();
        //    //Boolean reduce = false;
        //    //do
        //    //{

        //        string sqlPic = "SELECT PicUrl FROM Product WHERE ArtistId=@ArtistId";

        //        //Boolean found = false;
        //        SqlCommand cmdPic = new SqlCommand(sqlPic, con);

        //        cmdPic.Parameters.AddWithValue("@ ArtistId",artistId);


        //        SqlDataReader drPic = cmdPic.ExecuteReader();

        //    if (drPic.Read())
        //    {

        //        pic = ((Byte[])drPic["PicUrl"]);
        //        string imgByte = Convert.ToBase64String(pic, 0, pic.Length);

        //        Imagez1.ImageUrl = "data:image/jpg;base64," + imgByte;

        //        //sameArt.Insert(k,pic);
        //        //k++;

        //    }

        //    while (drPic.Read())
        //    {

        //            pic = ((Byte[])drPic["PicUrl"]);
        //        string imgByte = Convert.ToBase64String(pic, 0, pic.Length);
        //        sameArt.Add(imgByte);


        //            //sameArt.Insert(k,pic);
        //            //k++;

        //    }

        //    //}


        //    //}



        //    drPic.Close();
        //    //} while (sameArt.ElementAt(k)!=null);




        //        //Imagez1.ImageUrl = "data:image/jpg;base64," + sameArt.ElementAt(0);
        //        Imagez2.ImageUrl = "data:image/jpg;base64," + sameArt.ElementAt(0);
        //        Imagez3.ImageUrl = "data:image/jpg;base64," + sameArt.ElementAt(0);
        //        Imagez4.ImageUrl = "data:image/jpg;base64," + sameArt.ElementAt(0);
        //        Imagez5.ImageUrl = "data:image/jpg;base64," + sameArt.ElementAt(0);




        //    lblzlDate.Text = artistId;






        //    con.Close();

        //}






    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;
using System.Web.Services;
using System.Threading;

namespace Cart
{
    public partial class Cart : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["webConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Double total = 0;
            if(!IsPostBack)
            {
                //retrive cart info
                DataTable cartInfo = this.GetData(
                    "SELECT C.id, C.product_id, C.quantity as quantity, C.user_id, P.id AS id, P.Name as Name, P.PicUrl as PicUrl, P.Price as Price, P.AvailableQty as AvailableQty, P.user_id AS author_id, U.user_name, U.id AS user_id, (P.Price*C.quantity) as subtotal FROM Cart AS C INNER JOIN PRO AS P ON P.id = C.product_id INNER JOIN [User] AS U ON U.id = C.user_id WHERE(C.user_id like @CustId)");
                RepeaterCartInfo.DataSource = cartInfo;
                RepeaterCartInfo.DataBind();

                //calculate total
                foreach(DataRow row in cartInfo.Rows)
                {
                    total += row.Field<Double>("subtotal");
                    lblTotalPrice.Text = total.ToString("F");
                }

                //validation for allowing to checkout when contain cart item
                if(total > 0)
                {
                    lblTotalPrice.Visible = true;
                    lblTotalPriceTxt.Visible = true;
                    btnCheckout.Visible = true;
                }
            }
        }

        //create and return data table
        private DataTable GetData(string query)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.SelectCommand.Parameters.AddWithValue("@CustId", Session["UserId"]);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        //minus qty of product
        protected void minusQty(object sender, EventArgs e)
        {
            RepeaterItem qtyItem = (sender as Button).NamingContainer as RepeaterItem;
            int displayQty = Convert.ToInt32((qtyItem.FindControl("txtQty") as TextBox).Text);
            int prodId = Convert.ToInt32((qtyItem.FindControl("txtProdId") as TextBox).Text);

            //validation qty not less than 1
            if(displayQty > 1)
            {
                int updateQty = displayQty - 1;

                //update qty product in db
                string updateCartQuery =
                    "update [Cart] set [quantity] = @UpdateQty where user_id like @CustId and product_id like @ProdId";

                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(updateCartQuery, conn);
                    cmd.Parameters.AddWithValue("@CustId", (String)Session["UserId"].ToString());
                    cmd.Parameters.AddWithValue("@ProdId", prodId);
                    cmd.Parameters.AddWithValue("@UpdateQty", updateQty);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect(Request.RawUrl);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Successful Message",
                    "alert('Minimum value is 1.')", true);
            }
        }

        //add qty product
        protected void plusQty(Object sender, EventArgs e)
        {
            RepeaterItem qtyItem = (sender as Button).NamingContainer as RepeaterItem;
            int displayQty = Convert.ToInt32((qtyItem.FindControl("txtQty") as TextBox).Text);
            int prodId = Convert.ToInt32((qtyItem.FindControl("txtProdId") as TextBox).Text);
            int stockAvailable = Convert.ToInt32((qtyItem.FindControl("txtAvailable") as TextBox).Text);

            //product qty cannot more than stock available
            if(displayQty < stockAvailable)
            {
                int updateQty = displayQty + 1;

                //update qty in db
                string updateCartQuery =
                    "update [CartItems] set [quantity] = @UpdateQty where user_id like @CustId and product_id like @ProdId";
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(updateCartQuery, conn);
                    cmd.Parameters.AddWithValue("@CustId", (String)Session["UserId"].ToString());
                    cmd.Parameters.AddWithValue("@ProdId", prodId);
                    cmd.Parameters.AddWithValue("@UpdateQty", updateQty);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect(Request.RawUrl);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Successful Message",
                    "alert('The maximum stock available is " + stockAvailable + " piece(s).')", true);
            }
        }

        //checkout
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                Response.Redirect("Payment.aspx");
            }
            else
            {
                //not allow to checkout if qty invalid
                btnCheckout.Enabled = false;
            }
        }

        //retrieve transaction id of newly added transaction
        protected void getTransacID()
        {
            string getTransIdQuery = "select TOP(1) id from [Transaction] ORDER BY id DESC";
            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(getTransIdQuery, conn);

                conn.Open();

                if(cmd.ExecuteScalar() != null)
                {
                    Session["TransacId"] = cmd.ExecuteScalar();
                }

                conn.Close();
            }
        }

        //delete product
        protected void deleteItem(object sender, EventArgs e)
        {
            RepeaterItem deleteItem = (sender as Button).NamingContainer as RepeaterItem;
            int prodId = Convert.ToInt32((deleteItem.FindControl("txtProdId") as TextBox).Text);
            SqlConnection con = new SqlConnection(conString);

            string removeCartProd = "Delete from [Cart] where product_id like @ProdId and user_id like @CustId";
            SqlCommand cmd = new SqlCommand(removeCartProd, con);
            cmd.Parameters.AddWithValue("@ProdId", prodId);
            cmd.Parameters.AddWithValue("@CustId", Convert.ToInt32(Session["UserId"]));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }

        //update db when the changes of qty
        protected void txtQtyChg(object sender, EventArgs e)
        {
            RepeaterItem chgQtyProd = (sender as TextBox).NamingContainer as RepeaterItem;
            int qtyInput = Convert.ToInt32((chgQtyProd.FindControl("txtQty") as TextBox).Text);
            int prodId = Convert.ToInt32((chgQtyProd.FindControl("txtProdId") as TextBox).Text);
            int qtyAvailable = Convert.ToInt32((chgQtyProd.FindControl("txtAvailable") as TextBox).Text);

            if(qtyInput <= qtyAvailable && qtyInput != 0)
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                string updateQtyQuery =
                    "update [CartItems] set quantity = @QtyInput where user_id like @CustId and product_id like @ProdId";
                using (SqlCommand cmd = new SqlCommand(updateQtyQuery, con))
                {
                    cmd.Parameters.AddWithValue("@QtyInput", qtyInput);
                    cmd.Parameters.AddWithValue("@ProdId", prodId);
                    cmd.Parameters.AddWithValue("@CustId", Convert.ToInt32(Session["UserId"]));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        //click on img to go to product page
        protected void viewProdDetailImg(object sender, EventArgs e)
        {
            RepeaterItem clickImgProd = (sender as ImageButton).NamingContainer as RepeaterItem;
            string prodId = (clickImgProd.FindControl("txtProdId") as TextBox).Text;
            Response.Redirect("ProdDetails.aspx?id=" + prodId); //change ProdDetails to the product details page
        }

        //click on name to go to product page
        protected void viewProdDetailName(object sender, EventArgs e)
        {
            RepeaterItem clickNameProd = (sender as LinkButton).NamingContainer as RepeaterItem;
            string prodId = (clickNameProd.FindControl("txtProdId") as TextBox).Text;
            Response.Redirect("ProdDetails.aspx?id=" + prodId); //change ProdDetails to the product details page
        }
    }
}

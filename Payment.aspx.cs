using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

using System.IO;

namespace Cart
{
    public partial class Payment : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["WebConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Double total = 0;
            if(!IsPostBack)
            {
                btnConfirm.Enabled = true;
                DataTable paymentInfo = this.GetData(
                    "SELECT C.id, C.product_id, C.quantity, C.user_id, P.id AS Expr1, P.Name, P.PicUrl, P.Price AS Expr2, U.user_name, U.id AS Expr3 FROM Cart AS C INNER JOIN Product AS P ON P.id = C.product_id INNER JOIN [User] AS U ON U.id = C.user_id WHERE (C.user_id like @CustId)");
                lvPaymentItem.DataSourceID = null;
                lvPaymentItem.DataSource = paymentInfo;
                lvPaymentItem.DataBind();

                //calculate total price
                foreach(DataRow row in paymentInfo.Rows)
                {
                    total += row.Field<Double>("subtotal");
                }
                if(total == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There is no product for you to purchase.')", true);
                    btnConfirm.Enabled = false;
                }

                lblTotalPrice.Text = total.ToString("F");
            }
            else
            {
                if(rblCardType.SelectedItem.Value.Equals("Visa Card"))
                {
                    revCardNum.ValidationExpression = "^([4]\\d{3}-)(\\d{4}-){2}\\d{4}$|^([4]\\d{3} )(\\d{4} ){2}\\d{4}$|^[4]\\d{15}$";
                }
                else
                {
                    revCardNum.ValidationExpression = "^([5]\\d{3}-)(\\d{4}-){2}\\d{4}$|^([5]\\d{3} )(\\d{4} ){2}\\d{4}$|^[5]\\d{15}$";
                }

                if(!txtExpYr.Text.Equals("") && !txtExpMth.Text.Equals(""))
                {
                    if (int.Parse(txtExpYr.Text) == DateTime.Now.Year)
                    {
                        if (int.Parse(txtExpYr.Text) <= DateTime.Now.Month)
                        {
                            txtExpYr.Text = "";
                            txtExpMth.Text = "";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Card Expiration Date should be greater than today or onward ')", true);
                        }
                    }
                    else if (int.Parse(txtExpYr.Text) < DateTime.Now.Year)
                    {
                        txtExpYr.Text = "";
                        txtExpMth.Text = "";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Card Expiration Date should be greater than today or onward ')", true);
                    }
                }
            }
        }

        //create and return data table
        private DataTable GetData(string query)
        {
            using(SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx"); //cancel payment go back to homepage
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                if(chkPolicy.Checked)
                {
                    //create new transaction
                    SqlConnection con = new SqlConnection(conString);

                    string createTransacQuery =
                        "insert into [Transaction] (user_id, date_order, delivery_id, delivery_fees, card_num, payment_method, payment_amount, recv_name, recv_contactnum,recv_address)" +
                        " VALUES (@CustId, @DateOrder, @DeliveryID, @DeliveryFees, @CardNum, @PayMethod, @PayAmount, @Name, @ContactNum, @Address)";
                    SqlCommand cmd = new SqlCommand(createTransacQuery, con);
                    cmd.Parameters.AddWithValue("@CustId", Convert.ToInt32(Session["UserId"]));
                    cmd.Parameters.AddWithValue("@DateOrder", DateTime.Now);
                    cmd.Parameters.AddWithValue("@DeliveryID", ddlDeliveryMethod.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@DeliveryFees", lblDeliveryFee.Text);
                    cmd.Parameters.AddWithValue("@CardNum", txtCardNum.Text);
                    cmd.Parameters.AddWithValue("@PayMethod", rblCardType.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@PayAmount", lblTotalPrice.Text);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@ContactNum", txtContactNum.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //insert order into transaction
                    //read data from cart
                    con = new SqlConnection(conString);
                    string getCartQuery =
                        "SELECT C.product_id as prod_id, C.quantity as cart_quantity, P.AvailableQty as available_stock FROM Cart AS C JOIN Prod P on C.product_id = P.id where C.user_id = @CustId";
                    SqlDataAdapter sda = new SqlDataAdapter(getCartQuery, con);
                    sda.SelectCommand.Parameters.AddWithValue("@CustId", Session["UserId"]);
                    DataTable cartItem = new DataTable();
                    sda.Fill(cartItem);

                    //retrieve newly added transaction id
                    getTransacID();

                    // for each of the item recorded in the cart insert as orders
                    foreach(DataRow row in cartItem.Rows)
                    {
                        con.Open();
                        string insertOrdersQuery =
                            "insert into [Order] (product_id,quantity,delivery_id,order_status,transaction_id) VALUES (@ProdId, @Qty,@DeliverId,@OrderStatus,@TransacId)";
                        cmd = new SqlCommand(insertOrdersQuery, con);
                        cmd.Parameters.AddWithValue("@ProdId", row.Field<Int32>("prod_id"));
                        cmd.Parameters.AddWithValue("@Qty", row.Field<Int32>("cart_quantity"));
                        cmd.Parameters.AddWithValue("@DeliverId", row.Field<Int32>("delivery_id"));
                        cmd.Parameters.AddWithValue("@OrderStatus", "Pending");
                        cmd.Parameters.AddWithValue("@TransacId", Convert.ToInt32(Session["TransacId"]));

                        cmd.ExecuteNonQuery();
                        con.Close();

                        //deduct stock qty
                        con.Open();
                        string updateProdStockQuery =
                            "update [Prod] set AvailableQty = @UpdatedAvailableQty where id like @ProdId";
                        using (SqlCommand cmdSales = new SqlCommand(updateProdStockQuery, con))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                                "alert('success update product info')", true);
                            int cartQty = row.Field<Int32>("cart_quantity");
                            int availableQty = row.Field<Int32>("available_stock");
                            int updateQty = availableQty - cartQty;
                            int prodId = row.Field<Int32>("prod_id");
                            cmdSales.Parameters.AddWithValue("@UpdatedAvailableQty", updateQty);
                            cmdSales.Parameters.AddWithValue("@ProdId", row.Field<Int32>("prod_id"));
                            cmdSales.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                    //remove all from cart &minus the stock
                    clearCart();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please confirm you read the privacy and policy before proceed.')", true);
                }
            }
        }

        //retrieve the transaction id of newly added transaction
        protected void getTransacID()
        {
            string getTransIdQuery = "select TOP(1) id from [Transaction] ORDER BY id Desc";
            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(getTransIdQuery, conn);

                conn.Open();

                if (cmd.ExecuteScalar() != null)
                {
                    Session["TransacId"] = cmd.ExecuteScalar();
                }

                conn.Close();
            }
        }

        //clear all item from cart after checkout
        protected void clearCart()
        {
            SqlConnection con = new SqlConnection(conString);

            string clearCartQuery = "Delete from [Cart] where user_id like @CustId";
            SqlCommand cmd = new SqlCommand(clearCartQuery, con);
            cmd.Parameters.AddWithValue("@CustId", Convert.ToInt32(Session["UserId"]));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Successful Message", "alert('Pay successfully.')", true);
            Response.Redirect("Receipt.aspx");
        }
    }
}

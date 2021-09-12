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

namespace Payment
{
    public partial class Payment : System.Web.UI.Page
    {
        //add database connection
        string conString = ConfigurationManager.ConnectionStrings["WebConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnConfirm.Enabled = true;
            }
            else
            {
                if (rblCardType.SelectedItem.Value.Equals("Visa Card"))
                {
                    revCardNum.ValidationExpression = "^([4]\\d{3}-)(\\d{4}-){2}\\d{4}$|^([4]\\d{3} )(\\d{4} ){2}\\d{4}$|^[4]\\d{15}$";
                }
                else
                {
                    revCardNum.ValidationExpression = "^([5]\\d{3}-)(\\d{4}-){2}\\d{4}$|^([5]\\d{3} )(\\d{4} ){2}\\d{4}$|^[5]\\d{15}$";
                }

                if (!txtExpYr.Text.Equals("") && !txtExpMth.Text.Equals(""))
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
                    SqlConnection con = new SqlConnection(conString);
                    string createPaymentQuery =
                        "insert into [Payment] (pay_name, pay_contactnum, pay_address, pay_cardtype, pay_cardnum)" +
                        "VALUES (@PayName, @PayContactNum, @PayAddress, @PayCardType, @PayCardNum)";
                    SqlCommand cmd = new SqlCommand(createPaymentQuery, con);
                    cmd.Parameters.AddWithValue("@PayName", txtName.Text);
                    cmd.Parameters.AddWithValue("@PayContactNum", txtContactNum.Text);
                    cmd.Parameters.AddWithValue("@PayAddress", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@PayCardType", rblCardType.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@PayCardNum", txtCardNum.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    confirmPayment();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please confirm you read the privacy and policy before proceed.')", true);
                }
            }
        }

        protected void confirmPayment()
        {
            Response.Redirect("ConfirmPayment.aspx");
        }
    }
}

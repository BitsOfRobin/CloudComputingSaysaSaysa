using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Cart
{
    public partial class Receipt : System.Web.UI.Page
    {
        string conString = ConfigurationManager.ConnectionStrings["WebConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                for(int i=0; i<TransactionIDDetailView.Rows.Count;i++)
                {
                    Label transacId = (Label)TransactionIDDetailView.Rows[i].FindControl("id");
                    SqlDataSource2.SelectParameters.Add("id", transacId.Text.ToString());
                    break;
                }
                calcTotal();
            }
        }

        protected void calcTotal()
        {
            Double total = 0;

            foreach (GridViewRow row in GridView1.Rows)
            {
                Label subtotal = (Label)row.FindControl("subtotal");
                total += Convert.ToDouble(subtotal.Text.ToString());
            }
            lblTotal.Text = total.ToString("F");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}

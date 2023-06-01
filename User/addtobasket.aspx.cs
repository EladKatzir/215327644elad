using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class addtobasket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        txtPay.Text = Session["price"].ToString();
        DataSet dscontent = new DataSet();
        contents contentDT = new contents();
        contentDT.contentsName = Session["name"].ToString();
        contentDT.contentsType = Session["type"].ToString();

        dscontent = contentDT.idbytypeandname(contentDT);
        txtid.Text = dscontent.Tables[0].Rows[0][0].ToString();
    }

    protected void btnCart_Click(object sender, EventArgs e)
    {
        cart addto = new cart();
        addto.UserName = Session["user"].ToString();
        addto.contentsId = txtid.Text;
        addto.Total = txtPay.Text;
        addto.OrderAmount = "1"; //will always be 1 since you can only order a show one time
        addto.addToCart(addto);
        lblsucc.Visible = true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      
        ServiceReference1.coupon c = new ServiceReference1.coupon();
        c.MainCoupon = txtcoup.Text;
        ServiceReference1.ServiceSoapClient co = new ServiceReference1.ServiceSoapClient();
        //check if cpun exist
        if (co.chkCoupon(c))
        {
            DataSet x = co.copbyname(c);
            int discount = (int.Parse(txtPay.Text) * int.Parse(x.Tables[0].Rows[0][1].ToString())) / 100;
            int y = int.Parse(txtPay.Text) - discount;
            Session["price"] = y.ToString();
            co.DeleteCoupon(c); //delete the copun after we used it
            Response.Redirect("~/User/addtobasket.aspx");
            lblcopfail.Visible = true;
            lblcopfail.Text = "changed the price succesfully";
            lblcopfail.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lblcopfail.Visible = true;
            lblcopfail.ForeColor = System.Drawing.Color.Red;
        }
    }
}
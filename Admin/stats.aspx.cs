using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Admin_stats : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //userpnl:
        users user = new users();
        //age
        DataSet a = user.avgagey(user);
        txtAge.Text = a.Tables[0].Rows[0][0].ToString();
        //gender
        string male = "זכר";
        DataSet b = user.gendercount(male);
        txtManCount.Text = b.Tables[0].Rows[0][0].ToString();
        string female = "נקבה";
        DataSet c = user.gendercount(female);
        txtWomanCount.Text = c.Tables[0].Rows[0][0].ToString();
        if (int.Parse(txtManCount.Text) > int.Parse(txtWomanCount.Text))
        {
            txtGender.Text = "male";
        }
        else if (int.Parse(txtManCount.Text) < int.Parse(txtWomanCount.Text))
        {
            txtGender.Text = "female";
        }
        else
        {
            txtGender.Text = "equal";
        }
        //most order
        orders ord = new orders();
        DataSet d = ord.usermostorder();
        txtMostOrder.Text = d.Tables[0].Rows[0][0].ToString();

        //pnl prod
        //mostwatchedshow
        contents shw = new contents();
        DataSet f = shw.mostwatchedid();
        int idd = int.Parse(f.Tables[0].Rows[0][0].ToString());
        DataSet g = shw.mostwatchedname(idd);
        txtMostcontent.Text = g.Tables[0].Rows[0][0].ToString();
        DataSet h = shw.mostexpensive();
        txtexpcontent.Text = h.Tables[0].Rows[0][0].ToString();





    }
    protected void btnmenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Admin/atype.aspx");
    }
}
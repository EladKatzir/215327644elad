using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_atype : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnuser_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Admin/usermenu.aspx");
    }

    protected void btnprod_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Admin/productmenu.aspx");
    }

    protected void btnstat_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Admin/stats.aspx");
    }

    protected void btnrev_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Admin/reviewmenu.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class amaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Add your custom logic here
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        // Handle the back button click event
        Response.Redirect(Request.UrlReferrer.ToString());
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        // Handle the home button click event
        Response.Redirect("~/User/homepage.aspx");
    }

    protected void btnAType_Click(object sender, EventArgs e)
    {
        // Handle the AType button click event
        Response.Redirect("~/Admin/atype.aspx");
        // Implement your specific functionality
    }
}

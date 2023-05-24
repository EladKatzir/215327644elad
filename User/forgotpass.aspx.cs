using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class User_forgotpass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ResetPasswordButton_Click(object sender, EventArgs e)
    {
        users x = new users();
        x.User_Name = nametextbox.Text;
        DataSet tmail = x.mailbyuser(x);
      
        string mail = tmail.Tables[0].Rows[0][0].ToString();
        string typemail = EmailTextBox.Text;
        
        if ((mail.Trim() == typemail.Trim()))
        {
            newpass.Text = "123";
        }
        else
        {
            newpass.Text = "the mail you  provided dosent match the mail linked to account";
        }
        x.resetpass(x);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ulogin.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class User_upage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //chck if session exist
        if (Session["user"] == null || string.IsNullOrEmpty(Session["user"].ToString()))
        {
            // Do something here
            Response.Redirect("ulogin.aspx");
        }
        //done
        //if its first time page run
        if (!IsPostBack)
        {
            // hide all panels on initial load
            btninfo.Visible = false;
            pnlProfilePic.Visible = false;
            pnlPassword.Visible = false;
            pnlEmail.Visible = false;
            pnlBirthday.Visible = false;
            btninfo.Visible = true;
            Btnchange.Visible = true;
        }
      
    }

    protected void ddlUserOptions_SelectedIndexChanged(object sender, EventArgs e)
    {
        // hide all panels
        pnlProfilePic.Visible = false;
        pnlPassword.Visible = false;
        pnlEmail.Visible = false;
        pnlBirthday.Visible = false;

        // show the selected panel
        switch (ddlUserOptions.SelectedValue)
        {
            case "pic":
                {
                    pnlProfilePic.Visible = true;
                    break;
                }
            case "password":
                {
                    pnlPassword.Visible = true;
                    break;
                }
            case "email":
                {
                    pnlEmail.Visible = true;
                    break;
                }
            case "birthday":
                {
                    pnlBirthday.Visible = true;
                    break;
                }
        }
    }

    protected void btnUpdateProfilePic_Click(object sender, EventArgs e)
    {
        // handle profile picture upload
        users user = new users();
        user.User_Name = Session["user"].ToString();
        //show current photo
        DataSet x = user.photobyuser(user);
        Session["photo"] = x.Tables[0].Rows[0][0].ToString();
        if (Session["photo"] != null)
        {
            imgavatar.ImageUrl = Session["photo"].ToString();
        }
        //done, prepeare to change photo
        string filePath = HttpContext.Current.Server.MapPath("~/images/" + FileUpload1.FileName);
        FileUpload1.SaveAs(filePath);
        string fileUpInto = "~/images/" + FileUpload1.FileName;
        user.changephoto(user, fileUpInto);
        Response.Redirect("upage.aspx");
        Session["photo"] = fileUpInto;
        btninfo.Visible = true;



    }

    protected void btnUpdateEmail_Click(object sender, EventArgs e)
    {
        // handle email change
    }

    protected void calBirthday_SelectionChanged(object sender, EventArgs e)
    {
        // handle birthday change using asp:Calendar control
    }

    protected void Btnchange_Click(object sender, EventArgs e)
    {
        ddlUserOptions.Visible = true;
        pnlProfileInfo.Visible = false;
    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        string oldPassword = txtCurrentPassword.Text;
        string newPassword = txtNewPassword.Text;
        string confirm = txtConfirmPassword.Text;
       
        users user = new users();
      
        user.User_Name = Session["user"].ToString();
        DataSet t = user.passbyuser(user);
        string realpass = t.Tables[0].Rows[0][0].ToString();


        if ((newPassword.Trim() == confirm.Trim())&& (realpass.Trim()==oldPassword.Trim()))
        {
            user.changepass(user, newPassword);
            lblPasswordMessage.Visible = true;
            lblPasswordMessage.Text = "Password changed successfully";
            lblPasswordMessage.ForeColor = System.Drawing.Color.Green;
            Response.Redirect("upage.aspx");
        }
        lblPasswordMessage.Text = "panick";
       
        
    }


    protected void Btninfo_Click(object sender, EventArgs e)
    {
        pnlProfileInfo.Visible = true;
        users user = new users();
        user.User_Name = Session["user"].ToString();
        DataSet x = user.photobyuser(user);
        DataSet y = user.mailbyuser(user);
        DataSet z = user.birthbyuser(user);
        DataSet t = user.passbyuser(user);
       
        //set current info
        imgProfilePic.ImageUrl = x.Tables[0].Rows[0][0].ToString();
        lblEmail.Text = y.Tables[0].Rows[0][0].ToString();
        lblPassword.Text = t.Tables[0].Rows[0][0].ToString();
        lblBirthday.Text = z.Tables[0].Rows[0][0].ToString();
    }
}
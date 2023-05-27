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
            pnlProfileInfo.Visible = false;
            btninfo.Visible = true;
            Btnchange.Visible = true;
        }
        //setting mail for mailpnl
        users user = new users();
        user.User_Name = Session["user"].ToString();
        DataSet y = user.mailbyuser(user);
        lblCurrentEmail.Text = y.Tables[0].Rows[0][0].ToString();
        lblCurrentEmail.ForeColor = System.Drawing.Color.White;

    }

    protected void ddlUserOptions_SelectedIndexChanged(object sender, EventArgs e)
    {
        // hide all panels
        pnlProfilePic.Visible = false;
        pnlPassword.Visible = false;
        pnlEmail.Visible = false;
        pnlProfileInfo.Visible = false;
        pnlBirthday.Visible = false;

        // show the selected panel
        switch (ddlUserOptions.SelectedValue)
        {
            case "pic":
                {
                   
                    pnlPassword.Visible = false;
                    pnlEmail.Visible = false;
                    pnlBirthday.Visible = false;
                    pnlProfilePic.Visible = true;
                    break;
                }
            case "password":
                {
                    pnlProfilePic.Visible = false;
                    pnlEmail.Visible = false;
                    pnlBirthday.Visible = false;
                    pnlPassword.Visible = true;
                    break;
                }
            case "email":
                {
                    pnlProfilePic.Visible = false;
                    pnlPassword.Visible = false;
                    pnlBirthday.Visible = false;
                    pnlEmail.Visible = true;
                    break;
                }
            case "birthday":
                {
                    pnlProfilePic.Visible = false;
                    pnlPassword.Visible = false;
                    pnlEmail.Visible = false;
                    pnlBirthday.Visible = true;
                    break;
                }

            default:
                throw new Exception("Unexpected Case");
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
        string newEmail = txtNewEmail.Text;

        // Perform the necessary logic to update the email
        // You can use the 'Session["user"]' value to identify the user
       
        // Example code to update the email
        users user = new users();
        user.User_Name = Session["user"].ToString();
        user.changemail(user, newEmail);
        
       // Display a success message
       lblEmailMessage.Visible = true;
        lblEmailMessage.ForeColor = System.Drawing.Color.Green;
        lblEmailMessage.Text = "Email updated successfully";

        // Hide other panels
        pnlProfilePic.Visible = false;
        pnlPassword.Visible = false;
        pnlBirthday.Visible = false;
        pnlProfileInfo.Visible = false;

        // Show the pnlEmail panel
        pnlEmail.Visible = true;

        // Update the displayed email
        lblCurrentEmail.Text = newEmail;
    }
    protected void calBirthday_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        pnlProfileInfo.Visible = false; // Hide the pnlProfileInfo panel
        pnlBirthday.Visible = true;

        // Display a message or perform other operations
        lblBirthdayMessage.Text = "The selected month has changed. Update the birthday if needed.";
        lblBirthdayMessage.Visible = true;
    }
    protected void calBirthday_SelectionChanged(object sender, EventArgs e)
    {
        // Hide all panels except pnlBirthday
        pnlProfilePic.Visible = false;
        pnlPassword.Visible = false;
        pnlEmail.Visible = false;
        pnlProfileInfo.Visible = false;
        pnlBirthday.Visible = true;

        // Update the selected date label
        lblBirthdayMessage.Text = "date is :" + calBirthday.SelectedDate.ToShortDateString();
        Session["newdate"] = calBirthday.SelectedDate.ToShortDateString();

    }

    protected void btnChangeBirthday_Click(object sender, EventArgs e)
    {

        // Perform your logic to update the birthday using the selectedDate

        // Example: Update the user's birthday in the database
        users user = new users();
        user.User_Name = Session["user"].ToString();
        DateTime dati = DateTime.Parse(Session["newdate"].ToString());
       
        user.changebirth(user,dati );

        // Display a success message
        lblBirthdayMessage.Text = "Birthday updated successfully.";
        lblBirthdayMessage.ForeColor = System.Drawing.Color.Green;
        lblBirthdayMessage.Visible = true;

        // Add additional logic or database operations here

        // Hide other panels and show pnlProfileInfo
        pnlProfilePic.Visible = false;
        pnlPassword.Visible = false;
        pnlEmail.Visible = false;
        pnlBirthday.Visible = true;
        pnlProfileInfo.Visible = false;
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

        if ((newPassword.Trim() == confirm.Trim()) && (realpass.Trim() == oldPassword.Trim()))
        {
            user.changepass(user, newPassword);
            lblPasswordMessage.Visible = true;
            lblPasswordMessage.Text = "Password changed successfully";
            lblPasswordMessage.ForeColor = System.Drawing.Color.Green;
            // Create a link to perform an action
            HyperLink lnkPasswordMessage = new HyperLink();
            lnkPasswordMessage.Text = "refresh the hpage";
            lnkPasswordMessage.ForeColor = System.Drawing.Color.White;
            lnkPasswordMessage.NavigateUrl = "~/User/upage.aspx";

            // Add the hyperlink next to the label
            pnlPassword.Controls.Add(new LiteralControl("<br />"));
            pnlPassword.Controls.Add(lnkPasswordMessage);

            // Hide other panels
            pnlProfilePic.Visible = false;
            pnlEmail.Visible = false;
            pnlBirthday.Visible = false;
            pnlProfileInfo.Visible = false;
        }
        else if ((newPassword.Trim() == confirm.Trim()) && (realpass.Trim() != oldPassword.Trim()))
        {
            lblPasswordMessage.Visible = true;
            lblPasswordMessage.ForeColor = System.Drawing.Color.Red;
            lblPasswordMessage.Text = "Old and new password don't match";

            // Hide other panels
            pnlProfilePic.Visible = false;
            pnlEmail.Visible = false;
            pnlBirthday.Visible = false;
            pnlProfileInfo.Visible = false;
        }
        else if ((newPassword.Trim() != confirm.Trim()) && (realpass.Trim() == oldPassword.Trim()))
        {
            lblPasswordMessage.Visible = true;
            lblPasswordMessage.ForeColor = System.Drawing.Color.Red;
            lblPasswordMessage.Text = "confirm   and new password don't match";

            // Hide other panels
            pnlProfilePic.Visible = false;
            pnlEmail.Visible = false;
            pnlBirthday.Visible = false;
            pnlProfileInfo.Visible = false;
        }
        else
        {
            lblPasswordMessage.Visible = true;
            lblPasswordMessage.ForeColor = System.Drawing.Color.Red;
            lblPasswordMessage.Text = "An error occurred while changing the password";

            // Hide other panels
            pnlProfilePic.Visible = false;
            pnlEmail.Visible = false;
            pnlBirthday.Visible = false;
            pnlProfileInfo.Visible = false;
        }

        // Show the pnlPassword panel
        pnlPassword.Visible = true;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.OleDb;

public partial class User_regi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnStep1_Click(object sender, EventArgs e)
    {
        // Validate input for step 1
        if (Regex.IsMatch(txtFirstName.Text, @"^[a-zA-Zא-ת\s]+$") && Regex.IsMatch(txtLastName.Text, @"^[a-zA-Zא-ת\s]+$"))
        {
            // Save data to session
            Session["FirstName"] = txtFirstName.Text;
            Session["LastName"] = txtLastName.Text;
            Session["Gender"] = ddlg.SelectedValue;

            // Show next panel
            ShowStep2Panel();
        }
        else
        {
            // Show error message
            lblError.Text = "First and last name should only contain letters.";
        }
    }

    protected void btnStep2_Click(object sender, EventArgs e)
    {
        // Validate input for step 2
        if (Regex.IsMatch(txtPhoneNumber.Text, @"^[0-9]+$") && txtEmail.Text.Contains("@"))
        {
            // Save data to session
            Session["Address"] = txtAddress.Text;
            Session["City"] = ddlc.SelectedValue;
            Session["PhoneNumber"] = txtPhoneNumber.Text;
            Session["Email"] = txtEmail.Text;

            // Show next panel
            pnlStep1.Visible = false;
            pnlStep2.Visible = false;
            pnlStep3.Visible = true;
        }
        else
        {
            // Show error message
            lblError.Text = "Phone number should only contain numbers and email should contain @.";
        }
    }



    protected void btnRegister_Click(object sender, EventArgs e)
    {
        // Check that all session variables have been set
        if (Session["FirstName"] == null || Session["LastName"] == null || Session["Address"] == null || ddlc.SelectedItem == null || ddlg.SelectedItem == null || txtPhoneNumber.Text == null || txtEmail.Text == null || txtUsername.Text == null || txtPassword.Text == null)
        {
            lblError.Text = "Please fill out all fields before registering.";
            return;
        }

        // Save data to session
        Session["Username"] = txtUsername.Text;
        Session["Password"] = txtPassword.Text;

        users User = new users(Session["FirstName"].ToString(), Session["LastName"].ToString(), Session["Address"].ToString(), ddlc.SelectedItem.Value, ddlg.SelectedItem.Value, txtPhoneNumber.Text, txtEmail.Text, txtUsername.Text, txtPassword.Text);

        if (User.ifexist(User))
        {
            lblError.Text = "User already exists.";
        }
        else
        {
            User.newuser();
            Session["user"] = Session["FirstName"].ToString();
            lblSuccess.Visible = true;
            lblSuccess.Text = "Registration successful!";
            pnlStep1.Visible = false;
            pnlStep2.Visible = false;
            pnlStep3.Visible = false;
            pnlRegistrationSuccess.Visible = true;
        }
    }








    protected void ShowStep2Panel()
    {
        // Hide step 1 panel and show step 2 panel
        pnlStep1.Visible = false;
        pnlStep2.Visible = true;
        pnlStep3.Visible = false;
        lblError.Text = "all good, procedd";
    }

    protected void ShowStep3Panel()
    {
        // Hide step 1 and step 2 panels and show step 3 panel
        pnlStep1.Visible = false;
        pnlStep2.Visible = false;
        pnlStep3.Visible = true;
        lblError.Text = "all good, procedd";
    }

    protected void btnlog_Click(object sender, EventArgs e)
    {
        string message = "you have registerd in succesfully and being moved to login";
        Session["Message"] = message;
        Response.Redirect("ulogin.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_usermenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Generate and bind the buttons
            GenerateButtons();
        }

    }
    private void GenerateButtons()
    {
        // Define the buttons data source with unique Id, Text, and Description
        var buttons = new[]
        {
                new { ButtonId = "button1", ButtonText = "user list", ButtonDescription = "in here you could see a list of all users" },
                new { ButtonId = "button2", ButtonText = "users by gender", ButtonDescription = "in here you could see a list of users orignized by gender" },
                 new { ButtonId = "button3", ButtonText = "users by city", ButtonDescription = " in here you could see a list of users orignized by city" },
                new { ButtonId = "button4", ButtonText = "user info", ButtonDescription = "in here you could see all of a user information by name" },
                // Add more buttons as needed
            };

        rptButtons.DataSource = buttons;
        rptButtons.DataBind();
    }
    protected void rptButtons_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "ButtonClick")
        {
            string buttonId = e.CommandArgument.ToString();

            // Handle the button click based on the buttonId
            switch (buttonId)
            {
                case "button1":
                    // Handle button 1 click event
                    Response.Redirect("../Admin/userlist.aspx");
                    break;
                case "button2":
                    Response.Redirect("../Admin/userListByGender.aspx");
                    break;
                case "button3":
                    Response.Redirect("../Admin/userListByCity.aspx");
                    break;
                case "button4":
                    Response.Redirect("../Admin/userInfoByName.aspx");
                    break;
                default:
                    throw new Exception("Unexpected Case");
                    // Add cases for other buttons
                    // Implement your specific functionality here
            }
        }
    }
}
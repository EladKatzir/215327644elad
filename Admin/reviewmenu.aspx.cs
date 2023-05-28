using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_reviewmenu : System.Web.UI.Page
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
                new { ButtonId = "button1", ButtonText = "rate list", ButtonDescription = "show a list of all rates" },
                new { ButtonId = "button2", ButtonText = "comments list", ButtonDescription = "show a list of all comments" },
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
                    Response.Redirect("../Admin/ratelist.aspx");
                    break;
                case "button2":
                    Response.Redirect("../Admin/commentslist.aspx");
                    break;
                default:
                    throw new Exception("Unexpected Case");
                    // Add cases for other buttons
                    // Implement your specific functionality here
            }
        }
    }
}
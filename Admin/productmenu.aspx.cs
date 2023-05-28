using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class productmenu : System.Web.UI.Page
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
                new { ButtonId = "button1", ButtonText = "offer", ButtonDescription = "all items price change, copuons" },
                new { ButtonId = "button2", ButtonText = "show by type", ButtonDescription = "show all shows by generes" },
                 new { ButtonId = "button3", ButtonText = "movie by type", ButtonDescription = "show all movies by generes" },
                new { ButtonId = "button4", ButtonText = "song by type", ButtonDescription = "show all songs by generes" },
                 new { ButtonId = "button5", ButtonText = "change price", ButtonDescription = "change one item price" },
                 new { ButtonId = "button6", ButtonText = "add product", ButtonDescription = "add a new product" },
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
                    Response.Redirect("../Admin/offer.aspx");
                    break;
                case "button2":
                    Response.Redirect("../Admin/showbytype.aspx");
                    break;
                case "button3":
                    Response.Redirect("../Admin/moviebytype.aspx");
                    break;
                case "button4":
                    Response.Redirect("../Admin/songbytype.aspx");
                    break;
                case "button5":
                    Response.Redirect("../Admin/changeprice.aspx");
                    break;
                case "button6":
                    Response.Redirect("../Admin/addnewcontent.aspx");
                    break;
                default:
                    throw new Exception("Unexpected Case");
                    // Add cases for other buttons
                    // Implement your specific functionality here
            }
        }
    }
}

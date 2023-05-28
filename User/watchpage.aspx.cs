using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class User_watchpage : System.Web.UI.Page
{// Create an instance of the 'orders' class
    orders ord = new orders();

    // Create an instance of the 'users' class (assuming it exists)
    users us = new users();

    contents cn = new contents();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || (IsPostBack && ddlOptions.SelectedValue == "1"))
        {
            // Hide all panels except for pnlMovies
            pnlMovies.Visible = true;
            pnlSongs.Visible = false;
            pnlShows.Visible = false;
        }

        if (Session["user"] == null)
        {
            Response.Write("<script language='javascript'>window.alert('You aren't logged in.')</script>");
            Response.Redirect("ulogin.aspx");
        }
    }

    protected void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOptions.SelectedValue == "1")
        {
            pnlMovies.Visible = true;
            LoadMovies();

            // Set the selected index of ddlMovies based on the stored session variable
            if (Session["SelectedMovieIndex"] != null)
            {
                ddlMovies.SelectedIndex = (int)Session["SelectedMovieIndex"];
            }
        }
        else if (ddlOptions.SelectedValue == "3")
        {
            pnlSongs.Visible = true;
            LoadSongs();
        }
        else
        {
            // Handle other options if needed
        }
    }


    protected void LoadMovies()
    {
        if (ddlOptions.SelectedValue != "1")
        {
            return; // Exit the method if the selected option is not "Movies"
        }

        ddlMovies.Items.Clear();
        ddlMovies.Items.Add(new ListItem("Choose", ""));

        DataSet moviedata = cn.contentlistbytype("movies");
        for (int i = 0; i < moviedata.Tables[0].Rows.Count; i++)
        {
            string tmp = moviedata.Tables[0].Rows[i][0].ToString();
            ddlMovies.Items.Add(new ListItem(tmp, tmp));
        }
    }


    protected void ddlMovies_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Store the selected index of ddlMovies in a session variable
        Session["SelectedMovieIndex"] = ddlMovies.SelectedIndex;

        // Rest of your code
        us.User_Name = Session["user"].ToString();
        cn.contentsId = ddlMovies.SelectedValue;
        if (!ord.chkown(cn, us))
        {
            lblown.Visible = true;
        }
        else
        {
            DataSet a = ord.countown(cn, us);
            txtMovieCount.Text = a.Tables[0].Rows[0][0].ToString();
        }
        // Get the number of times the selected movie has been purchased by the user
        //DataSet movieCount = ord.AmountByIdName(ddlMovies.SelectedValue, x);

        //if (movieCount.Tables[0].Rows.Count > 0)
        //{
        //    int count = Convert.ToInt32(movieCount.Tables[0].Rows[0]["SumOforderAmount"]);
        //    txtMovieCount.Text = count.ToString();
        //}
        //else
        //{
        //    txtMovieCount.Text = "0";
        //}
    }

    protected void btnPlayMovie_Click(object sender, EventArgs e)
    {
        // Add code to play the selected movie
        // You can retrieve the selected movie ID from ddlMovies.SelectedValue
    }

    protected void LoadSongs()
    {
        //// Get the content IDs for songs owned by the user
        //DataSet songContentIds = ord.GetContentIdByName("Songs");

        //ddlSongs.DataSource = songContentIds;
        //ddlSongs.DataTextField = "contentname";
        //ddlSongs.DataValueField = "contentID";
        //ddlSongs.DataBind();
    }

    protected void ddlSongs_SelectedIndexChanged(object sender, EventArgs e)
    {
        //// Get the number of times the selected song has been purchased by the user
        //DataSet songCount = ord.AmountByIdName(ddlSongs.SelectedValue, x);

        //if (songCount.Tables[0].Rows.Count > 0)
        //{
        //    int count = Convert.ToInt32(songCount.Tables[0].Rows[0]["SumOforderAmount"]);
        //    txtSongCount.Text = count.ToString();
        //}
        //else
        //{
        //    txtSongCount.Text = "0";
        //}
    }

    protected void btnPlaySong_Click(object sender, EventArgs e)
    {
        // Add code to play the selected song
        // You can retrieve the selected song ID from ddlSongs.SelectedValue
    }

    protected void btnPlay_Click(object sender, EventArgs e) //movies
    {
        // Add code to play the selected song
        // You can retrieve the selected song ID from ddlSongs.SelectedValue
    }
}


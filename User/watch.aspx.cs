using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class User_watch : System.Web.UI.Page
{
    orders ord = new orders();

    // Create an instance of the 'users' class (assuming it exists)
    users us = new users();

    contents cn = new contents();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Write("<script language='javascript'>window.alert('You aren't logged in.')</script>");
            Response.Redirect("ulogin.aspx");
        }
        if(!IsPostBack)
        {
            Session["l"] = "LINK";
        }
    }

    protected void ddlOptions_SelectedIndexChanged1(object sender, EventArgs e)
    {
        switch (ddlOptions.SelectedValue)
        {
            case "movies":
                pnlmovie.Visible = true;
                fillmovie();
                break;
            case "songs":
                pnlsong.Visible = true;
                fillsong();
                break;
            case "shows":
                pnlshow.Visible = true;
                lbls.Visible = true;
                fillshow();
                break;
            default:
                throw new Exception("Unexpected Case");
        }
    }
    protected void fillshow()
    {
        shows sh = new shows();
        DataSet c = sh.showlist();
        ddlshow.Items.Clear();
        string tmpsh = "";
        ddlshow.Items.Add("choose");
        for (int i = 0; i < c.Tables[0].Rows.Count; i++)
        {
            tmpsh = c.Tables[0].Rows[i][0].ToString();
            ddlshow.Items.Add(tmpsh);
        }
    }
    protected void btnmenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("../user/homepage.aspx");
    }
    protected void ddlshow_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbls.Visible = true;
        us.User_Name = Session["user"].ToString();
        cn.contentsName = ddlshow.SelectedValue;
        if (!cn.chkown(cn, us))
        {
            lblown.Visible = true;
        }
        else
        {
            DataSet a = cn.sumown(cn, us);
            lblown.Visible = false;

        }
    }
    protected void fillmovie()
    {
        movies m = new movies();
        DataSet a = m.movielist();
        ddlmovie.Items.Clear();
        string tmp = "";
        ddlmovie.Items.Add("choose");
        for(int i=0;i<a.Tables[0].Rows.Count;i++)
        {
            tmp=a.Tables[0].Rows[i][0].ToString();
            ddlmovie.Items.Add(tmp);
        }
    }
    protected void fillsong()
    {
        songs s = new songs();
        DataSet b = s.songlist();
        ddlsong.Items.Clear();
        string tmps = "";
        ddlsong.Items.Add("choose");
        for (int i = 0; i <b.Tables[0].Rows.Count; i++)
        {
            tmps = b.Tables[0].Rows[i][0].ToString();
            ddlsong.Items.Add(tmps);
        }
    }
    protected void ddlsong_SelectedIndexChanged(object sender, EventArgs e)
    {
        us.User_Name = Session["user"].ToString();
        cn.contentsName = ddlsong.SelectedValue;
        if (!cn.chkown(cn, us))
        {
            lblown.Visible = true;
        }
        else
        {
            DataSet a = cn.sumown(cn, us);

            lblown.Visible = false;

        }
    }
    protected void btnwatchsong_Click(object sender, EventArgs e)
    {
        lblown.Visible = false;
        us.User_Name = Session["user"].ToString();
        cn.contentsName = ddlsong.SelectedValue;
        btnwatch.Visible = false;
        cn.updatewa(0, cn, us);
        songs cool = new songs();
        cool.sgnamey = ddlsong.SelectedValue;
        DataSet LINK = cool.songbyname(cool);
        if (LINK.Tables[0].Rows.Count < 0)
        {
            lble.Visible = true;
        }
        Session["l"] = LINK.Tables[0].Rows[0][7].ToString();
    }
    protected void ddlmovie_SelectedIndexChanged(object sender, EventArgs e)
    {
        us.User_Name = Session["user"].ToString();
        cn.contentsName = ddlmovie.SelectedValue;
        if (!cn.chkown(cn, us))
        {
            lblown.Visible = true;
        }
        else
        {
            DataSet a = cn.sumown(cn, us);
            lblown.Visible = false;

        }
    }

    protected void btnwatch_Click(object sender, EventArgs e)
    {
        lblown.Visible = false;
        us.User_Name = Session["user"].ToString();
        cn.contentsName = ddlmovie.SelectedValue;
        btnwatch.Visible = false;
        cn.updatewa(0, cn, us);
        movies cool = new movies();
        cool.sgnamem = ddlmovie.SelectedValue;
        DataSet LINK = cool.linkbyname(cool);
        if(LINK.Tables[0].Rows.Count<0)
        {
            lble.Visible = true;
        }
       
        Session["l"]= LINK.Tables[0].Rows[0][2].ToString();
    }
    protected void ddlseason_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void ddlepisode_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void btnwatchshow_Click(object sender, EventArgs e)
    {
        lblownshow.Visible = false;
        us.User_Name = Session["user"].ToString();
        cn.contentsName = ddlshow.SelectedValue;
        btnwatch.Visible = false;
        cn.updatewa(0, cn, us);
        episodes s = new episodes();
        shows show = new shows();
        show.sgnames = ddlshow.SelectedValue;
        s.gsepisodenum = int.Parse(ddlepisode.SelectedValue);
        s.gsseasonnum = int.Parse(ddlseason.SelectedValue);
        DataSet link = s.linkbysse(s, show);
        if (link.Tables[0].Rows.Count < 0)
        {
            lble.Visible = true;
        }
        Session["l"] = link.Tables[0].Rows[0][2].ToString();
    }

   
}
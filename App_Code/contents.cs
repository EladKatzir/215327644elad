﻿using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for contents
/// </summary>
public class contents
{
    sqlDb sql = new sqlDb();
    //תכונות
    private string contentId;
    private string contentName;  // שם ספר
    private string contentPrice;//מחיר ספר
    private string contentType;//סוג הספר
    public contents()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public contents(string bId, string bname, string bprice, string btype)
    {
        this.contentId = bId;
        this.contentName = bname;
        this.contentPrice = bprice;
        this.contentType = btype;

    }
    public contents(string name, string type)
    {
        this.contentName = name;
        this.contentType = type;
    }
    public string contentsId
    {
        get { return this.contentId; }
        set { this.contentId = value; }
    }
    public string contentsName
    {
        get { return this.contentName; }
        set { this.contentName = value; }
    }
    public string contentsPrice
    {
        get { return this.contentPrice; }
        set { this.contentPrice = value; }
    }
    public string contentsType
    {
        get { return this.contentType; }
        set { this.contentType = value; }
    }
    public DataSet idbytypeandname(contents cool)
    {
        DataSet dscontentDt = new DataSet();
        string stcontentDt = "SELECT tblcontent.contectId FROM tblcontenttype INNER JOIN tblcontent ON tblcontenttype.contenttypeid = tblcontent.contenttype WHERE(((tblcontent.contentname) ='" + cool.contentsName + "') AND((tblcontenttype.contenttype) ='" + cool.contentsType + "'));";


        //

        //'" + cool.sggens + "'));";

        dscontentDt = sql.chkData(stcontentDt);
        return dscontentDt;
    }
    public DataSet contentbytype(contents cool)
    {
        DataSet dscontentDt = new DataSet();
        string stcontentDt = "SELECT tblcontent.contectId, tblcontent.contentprice, tblcontent.contentname FROM tblcontenttype INNER JOIN tblcontent ON tblcontenttype.contenttypeid = tblcontent.contenttype WHERE(((tblcontenttype.contenttype) ='" + cool.contentsType + "'));";

        //

        //'" + cool.sggens + "'));";

        dscontentDt = sql.chkData(stcontentDt);
        return dscontentDt;
    }
    public DataSet pricebytype(contents cool)
    {
        DataSet dscontentDt = new DataSet();
        string stcontentDt = "SELECT tblcontent.contentprice FROM tblcontenttype INNER JOIN tblcontent ON tblcontenttype.contenttypeid = tblcontent.contenttype WHERE(((tblcontenttype.contenttype) ='" + cool.contentsType + "'));";

        //'" + cool.contentsType + "'));";

        //

        //'" + cool.sggens + "'));";

        dscontentDt = sql.chkData(stcontentDt);
        return dscontentDt;
    }
    public void ReductionSpecific(contents a, int redPrecent)
    {
        int reduc = int.Parse(a.contentsPrice) * redPrecent / 100;
        int newpr = int.Parse(a.contentsPrice) - reduc;
        string stry = "UPDATE tblcontent SET tblcontent.contentprice = " + newpr + " WHERE(((tblcontent.contentname) ='" + a.contentsName + "'));";
        sql.udi(stry);
    }

    public void IncreasmentSpecific(contents a, int incPrecent)
    {
        int incrs = int.Parse(a.contentsPrice) * incPrecent / 100;
        int newpr = int.Parse(a.contentsPrice) + incrs;
        string stry = "UPDATE tblcontent SET tblcontent.contentprice = " + newpr + " WHERE(((tblcontent.contentname) ='" + a.contentsName + "'));";
        sql.udi(stry);
    }
    public DataSet pricebyname(contents cool)
    {
        DataSet dscontentDt = new DataSet();
        string stcontentDt = "SELECT tblcontent.contentprice, tblcontent.contentname FROM tblcontenttype INNER JOIN tblcontent ON tblcontenttype.contenttypeid = tblcontent.contenttype WHERE(((tblcontent.contentname) ='" + cool.contentsName + "'));";

        //'" + cool.contentsType + "'));";

        //

        //'" + cool.sggens + "'));";

        dscontentDt = sql.chkData(stcontentDt);
        return dscontentDt;
    }
    public DataSet list(contents cool)
    {
        DataSet dscontentDt = new DataSet();
        string stcontentDt = "SELECT tblcontent.contectId, tblcontenttype.contenttype, tblcontent.contentprice, tblcontent.contentname FROM tblcontenttype INNER JOIN tblcontent ON tblcontenttype.contenttypeid = tblcontent.contenttype;";


        dscontentDt = sql.chkData(stcontentDt);
        return dscontentDt;
    }
    public string Average()
    {
        DataSet ds = new DataSet();
        string strs = "SELECT Avg(tblcontent.contentprice) AS Avgמתוךcontentprice FROM tblcontent;";
        ds = sql.chkData(strs);
        return ds.Tables[0].Rows[0][0].ToString();
    }

    public void GeneralIncreasment(int prec)
    {
        string sr = "UPDATE tblcontent SET tblcontent.contentprice = [tblcontent]![contentprice] + (" + prec + " *[tblcontent]![contentprice] / 100);";
        sql.udi(sr);
    }

    public void GeneralDecreasment(int prec)
    {
        string sr = "UPDATE tblcontent SET tblcontent.contentprice = [tblcontent]![contentprice] - (" + prec + " *[tblcontent]![contentprice] / 100);";
        sql.udi(sr);
    }
    public void addto(contents ncontent)
    {

            string stcontent = "insert into tblcontent (contentName,contentprice,contentType) Values('" + ncontent.contentName + "','" + ncontent.contentPrice + "','" + ncontent.contentType + "')";

            //INSERT INTO tblcontent(user_Name,productId,contentprice,total) VALUES('" +  + "'," + ct.contentsId + "," + ct.contentprice + "," + ct.Total + ");";
            sql.udi(stcontent);
       
    }
    public DataSet mostwatchedid()
    {
        DataSet i = new DataSet();
        string s = "SELECT TOP 1 contentId FROM tblSubOrders GROUP BY contentId ORDER BY COUNT(*) DESC; ";
        i = sql.chkData(s);
        return i;
    }
    public DataSet mostexpensive()
    {
        DataSet i = new DataSet();
        string s = "SELECT tblcontent.contentname FROM tblcontent ORDER BY tblcontent.contentprice DESC;";
        i = sql.chkData(s);
        return i;
    }
    public DataSet mostwatchedname(int x)
    {
        DataSet i = new DataSet();
        string s = "SELECT tblcontent.contentname FROM tblcontent WHERE(((tblcontent.contectId) =" + x + "));";
        i = sql.chkData(s);
        return i;
    }
    public DataSet contentlistbytype(string x)
    {
        DataSet i = new DataSet();
        string s = "SELECT tblcontent.contentname, tblcontent.contectId FROM tblcontenttype INNER JOIN tblcontent ON tblcontenttype.contenttypeid = tblcontent.contenttype WHERE(((tblcontenttype.contenttype) ='"+x+"'));";
        i = sql.chkData(s);
        return i;
    }
    public bool chkown(contents y, users x)
    {
        DataSet i = new DataSet();
        string s = "SELECT tblcontent.contectId FROM tblcontent INNER JOIN tblSubOrders ON tblcontent.contectId = tblSubOrders.contentId WHERE(((tblcontent.contentname) ='"+y.contentsName+"') AND((tblSubOrders.user) ='"+x.User_Name+"'));";
        i = sql.chkData(s);
        if (i.Tables[0].Rows.Count > 0)
        {
            return true;
        }
        return false;
    }
    public DataSet sumown(contents y, users x)
    {
        DataSet i = new DataSet();
        string s = "SELECT Sum(tblSubOrders.orderAmount) AS SumOforderAmount FROM tblcontent INNER JOIN tblSubOrders ON tblcontent.contectId = tblSubOrders.contentId GROUP BY tblcontent.contentname, tblSubOrders.user HAVING(((tblcontent.contentname) ='"+y.contentsName+"') AND((tblSubOrders.user) ='"+x.User_Name+"'));";
        i = sql.chkData(s);
        return i;
    }
    public DataSet updatewa(int a, contents y, users x)
    {
        DataSet i = new DataSet();
        string s = "UPDATE tblcontent INNER JOIN tblSubOrders ON tblcontent.contectId = tblSubOrders.contentId SET tblSubOrders.orderAmount = " + a + " WHERE tblSubOrders.user = '" + x.User_Name + "' AND tblcontent.contentname = '" + y.contentsName + "';";
        i = sql.chkData(s);
        return i;
    }

}
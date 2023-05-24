<%@ Page Language="C#" AutoEventWireup="true" CodeFile="atype.aspx.cs" Inherits="Admin_atype" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  style="background-image:url(../images/atypeb.png)">
    <form id="form1" runat="server">
    <div>
    
    </div>

        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 300px; top: 135px; position: absolute" Text="commands by" ForeColor="White" Font-Size="60pt"></asp:Label>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 770px; top: 135px; position: absolute" Text="type" ForeColor="#B4E4FF" Font-Size="60pt"></asp:Label>
        <asp:ImageButton ID="btnuser" ImageUrl="../images/userb.png" runat="server" style="z-index: 1; left: 150px; top: 325px; height:150px; width:150px; position: absolute;" OnClick="btnuser_Click" />
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 185px; top: 470px; position: absolute" Text="user" ForeColor="white" Font-Size="30pt" Font-Bold="true"></asp:Label>
        
         <asp:ImageButton ID="btnprod" ImageUrl="../images/prodb.png" runat="server" style="z-index: 1; left: 400px; top: 325px; height:150px; width:170px; position: absolute;" OnClick="btnprod_Click" />
        <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 410px; top: 470px; position: absolute" Text="products" ForeColor="white" Font-Size="30pt" Font-Bold="true"></asp:Label>

         <asp:ImageButton ID="btnstat" ImageUrl="../images/statsb.png" runat="server" style="z-index: 1; left: 650px; top: 325px; height:150px; width:150px; position: absolute;" OnClick="btnstat_Click" />
        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 670px; top: 470px; position: absolute" Text="stats" ForeColor="white" Font-Size="30pt" Font-Bold="true"></asp:Label>

         <asp:ImageButton ID="btnrev" ImageUrl="../images/revb.png" runat="server" style="z-index: 1; left: 850px; top: 325px; height:150px; width:150px; position: absolute;" OnClick="btnrev_Click" />
        <asp:Label ID="Label7" runat="server" style="z-index: 1; left: 840px; top: 470px; position: absolute" Text="reviews" ForeColor="white" Font-Size="30pt" Font-Bold="true"></asp:Label>

        <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 143px; top: 550px; position: absolute; width: 1305px;" Text="press on image to see commands" ForeColor="White" Font-Size="50pt" Font-Overline="True"></asp:Label>
        
    </form>
</body>
</html>

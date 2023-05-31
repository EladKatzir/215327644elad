<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userInfoByName.aspx.cs" Inherits="userListByName" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            z-index: 1;
            position: absolute;
            top: 78px;
            left: 611px;
        }
        .auto-style3 {
            z-index: 1;
            left: 560px;
            top: 171px;
            position: absolute;
            height: 332px;
            width: 476px;
        }
    </style>
</head>
<body>

    <script src="https://unpkg.com/ionicons@5.4.0/dist/ionicons.js"></script>
    <button runat="server" type="button" class="button" onclick="goBack()">
               <span class="button__text">go back</span>
               <span class="button__icon">
                   <ion-icon name="arrow-redo-outline"></ion-icon>
               </span>
           </button>
    <div style="position: fixed; bottom: 10px; left: 10px;">
    <button onclick="location.href='usermenu.aspx';">
        <img src="../images/men.jpg" width=50px height="50px" alt="Icon" />
    </button>
</div>
    <form id="form1" runat="server">
    <div style="width: 1400px; margin: 0 auto;">
        <asp:Button ID="btnmenu" runat="server" Text="menu" OnClick="btnmenu_Click"  />
   
        <asp:Label ID="Label1" runat="server" style="font-size: xx-large; font-weight: bold" Text="פרטי משתמש לפי שם משתמש" CssClass="auto-style1"></asp:Label>
        <asp:Label ID="lbleu" runat="server" Font-Size="30pt" style="z-index: 1; left: 9px; top: 173px; position: absolute; height: 82px; width: 500px" Text="no user in that name"></asp:Label>

         </div>
    
   
        <asp:GridView ID="grdlist" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="auto-style3" OnSelectedIndexChanged="grdlist_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:DropDownList ID="ddlun" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="User_Name" DataValueField="UserID" OnSelectedIndexChanged="ddlun_SelectedIndexChanged" style="z-index: 1; left: 662px; top: 133px; position: absolute; right: 662px; height: 30px; width:30px;">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:newconnect %>" ProviderName="<%$ ConnectionStrings:newconnect.ProviderName %>" SelectCommand="SELECT [User_Name], [UserID] FROM [tblUsers]"></asp:SqlDataSource>
    </form>
</body>
     <script>
    function goBack() {
      window.history.back();
    }
  </script>
</html>

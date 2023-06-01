<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userlist.aspx.cs" Inherits="Admin_userlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  style="background-color:blueviolet">
  
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
        <asp:GridView ID="grdlist" runat="server" style="z-index: 1; width: 422px; height: 257px; position: absolute; top: 205px; left: 528px" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        <asp:Label ID="Label1" runat="server" style="z-index: 1; position: absolute; top: 72px; left: 613px; font-size: xx-large; font-weight: bold" Text="רשימת משתמשים"></asp:Label>
        </div>
    </form>
</body>
    <script>
function goBack() {
  window.history.back();
}
</script>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="stats.aspx.cs" Inherits="Admin_stats" %>
<!DOCTYPE html>
<html>
<head>
    <style>
        .body{
            background-color: blueviolet;
            color: white;
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        .container {
            display: flex;
            justify-content: space-between;
            padding: 20px;
        }

        .panel {
            background-color: black;
            padding: 20px;
            width: 45%;
            border-radius: 5px;
        }

        .panel h2 {
            font-size: 18px;
            margin-bottom: 10px;
        }

        .panel label {
            display: block;
            margin-bottom: 5px;
        }

        .panel input[type="text"] {
            width: 100%;
            padding: 5px;
            margin-bottom: 10px;
            border-radius: 3px;
        }
    </style>
</head>
<body class="body">
    <form runat="server">
       
        <script src="https://unpkg.com/ionicons@5.4.0/dist/ionicons.js"></script>
     <button runat="server" type="button" class="button" onclick="goBack()">
               <span class="button__text">go back</span>
               <span class="button__icon">
                   <ion-icon name="arrow-redo-outline"></ion-icon>
               </span>
           </button>
                <a href="../Admin/atype.aspx">
               <span class="button__text">go menu</span>
               <span class="button__icon">
                   <ion-icon name="arrow-redo-outline"></ion-icon>
               </span>
           </a>
        <div class="container">
              <asp:Button ID="btnmenu" runat="server" Text="menu" OnClick="btnmenu_Click"  />
            <asp:Panel runat="server" CssClass="panel">
                <h2>User Panel</h2>
                <label for="txtAge">Average Age:</label>
                <asp:TextBox runat="server" ID="txtAge" ReadOnly="true"></asp:TextBox>
                <label for="txtGender">Gender with Most Users:</label>
                <asp:TextBox runat="server" ID="txtGender" ReadOnly="true"></asp:TextBox>
                <label for="txtMostOrder">User with Most Orders:</label>
                <asp:TextBox runat="server" ID="txtMostOrder" ReadOnly="true"></asp:TextBox>
                <label for="txtManCount">Number of Men:</label>
                <asp:TextBox runat="server" ID="txtManCount" ReadOnly="true"></asp:TextBox>
                <label for="txtWomanCount">Number of Women:</label>
                <asp:TextBox runat="server" ID="txtWomanCount" ReadOnly="true"></asp:TextBox>
            </asp:Panel>
            <asp:Panel runat="server" CssClass="panel">
                <h2>Product Panel</h2>
                <label for="txtMostShow">Most Watched content:</label>
                <asp:TextBox runat="server" ID="txtMostcontent" ReadOnly="true"></asp:TextBox>
                <label for="txtMostMovie">Most expensive content:</label>
                <asp:TextBox runat="server" ID="txtexpcontent" ReadOnly="true"></asp:TextBox>
            </asp:Panel>
        </div>
    </form>
</body>
      <script>
    function goBack() {
      window.history.back();
    }
  </script>
</html>

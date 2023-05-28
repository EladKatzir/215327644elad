<%@ Page Language="C#" AutoEventWireup="true" CodeFile="watch.aspx.cs" Inherits="User_watch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
    background-image: url('../images/orderb.jpg');
    background-size: cover;
    background-repeat: no-repeat;
}
        .center-dropdown {
            display: flex;
            align-items: center;
            justify-content: center;
            position: fixed;
            top: 10%;
            left: 50%;
            transform: translate(-50%, -50%);
        }
  /* Rainbow effect */
  @keyframes rainbow {
    0%   { color: red; }
    14%  { color: orange; }
    28%  { color: yellow; }
    42%  { color: green; }
    57%  { color: blue; }
    71%  { color: indigo; }
    85%  { color: violet; }
    100% { color: red; }
  }

  /* Glow on hover */
  a:hover {
    animation: glow 1s infinite alternate;
  }

  @keyframes glow {
    0%   { box-shadow: 0 0 5px rgba(255, 255, 255, 0.8); }
    100% { box-shadow: 0 0 20px rgba(255, 255, 255, 0.8); }
  }

  /* Reverse rainbow for visited links */
  a:visited {
    animation: reverse-rainbow 3s infinite;
  }

  @keyframes reverse-rainbow {
    0%   { color: red; }
    14%  { color: violet; }
    28%  { color: indigo; }
    42%  { color: blue; }
    57%  { color: green; }
    71%  { color: yellow; }
    85%  { color: orange; }
    100% { color: red; }
  }
  
  /* Rainbow effect for individual letters */
  .rainbow-link {
    background: linear-gradient(to right, red, orange, yellow, green, blue, indigo, violet);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    animation: rainbow 7s infinite;
  }

    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnhome" runat="server" Text="menu" OnClick="btnmenu_Click"  />

    <asp:DropDownList ID="ddlOptions" runat="server" AutoPostBack="true" CssClass="center-dropdown" OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged1">
                <asp:ListItem Text="Choose" Value="choose"></asp:ListItem>
                <asp:ListItem Text="Movies" Value="movies"></asp:ListItem>
                <asp:ListItem Text="Shows" Value="shows"></asp:ListItem>
                <asp:ListItem Text="Songs" Value="songs"></asp:ListItem>
            </asp:DropDownList>
        <asp:Label ID="lbls" runat="server" BackColor="White" style="z-index: 1; left: 429px; top: 124px; position: absolute" Text="every show has 1 episodes in season 1! nothing else. limit of drive size" Visible="false"></asp:Label>
        <asp:Panel ID="pnlmovie" runat="server" Visible="False"  BackImageUrl="../images/adminback.png">
    <!-- email change controls -->
    <h2>movies</h2>
    <hr />
    <table>
        <tr>
            <td><b>choose movie</b></td>
            <td>
                <asp:DropDownList ID="ddlmovie" runat="server" OnSelectedIndexChanged="ddlmovie_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><b>watch it</b></td>
            <td>
                <asp:Button ID="btnwatch" runat="server" Text="press to watch" OnClick="btnwatch_Click" />
                <a href="<%= Session["l"].ToString() %>" class="rainbow-link">see movie</a>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="lblown" runat="server" Visible="False" Text="you dont own it" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            <asp:Label ID="lble" runat="server" BackColor="White" style="z-index: 1; left: 802px; top: 199px; position: absolute" Text="content dont exist" Visible="false"></asp:Label>
            
</asp:Panel>
  <asp:Panel ID="pnlsong" runat="server" Visible="False"  BackImageUrl="../images/adminback.png">      
              <h2>songs</h2>
    <hr />
    <table>
        <tr>
            <td><b>choose song</b></td>
            <td>
                <asp:DropDownList ID="ddlsong" runat="server" OnSelectedIndexChanged="ddlsong_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><b>watch it</b></td>
            <td>
                <asp:Button ID="btnwatchsong" runat="server" Text="press to watch" OnClick="btnwatchsong_Click" />
                <a href="<%= Session["l"].ToString() %>" class="rainbow-link">see song</a>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="Label1" runat="server" Visible="False" Text="you dont own it" Font-Size="XX-Large" ForeColor="White"></asp:Label>
        </asp:Panel>


        <asp:Panel ID="pnlshow" runat="server" Visible="False"  BackImageUrl="../images/adminback.png">      
              <h2>shows</h2>
    <hr />
    <table>
        <tr>
            <td><b>choose show</b></td>
            <td>
                <asp:DropDownList ID="ddlshow" runat="server" OnSelectedIndexChanged="ddlshow_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><b>watch it</b></td>
            <td>
                <asp:Button ID="btnwatchshow" runat="server" Text="press to watch" OnClick="btnwatchshow_Click" />
                <a href="<%= Session["l"].ToString() %>" class="rainbow-link">see show</a>
            </td>
        </tr>
        <tr>
            <td><b>season</b></td>
            <td>
                <asp:DropDownList ID="ddlseason" runat="server" AutoPostBack="True">
                    <asp:ListItem Selected="True">select</asp:ListItem>
                    <asp:ListItem Value="1">season 1</asp:ListItem>
                    <asp:ListItem Value="2">season 2</asp:ListItem>
                    <asp:ListItem Value="3">season 3</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td><b>episode</b></td>
            <td>
               <asp:DropDownList ID="ddlepisode" runat="server" OnSelectedIndexChanged="ddlepisode_SelectedIndexChanged" AutoPostBack="True">
                   <asp:ListItem>select</asp:ListItem>
                   <asp:ListItem Value="1">episode 1</asp:ListItem>
                   <asp:ListItem Value="2">episode 2</asp:ListItem>
                   <asp:ListItem Value="3">episode 3</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="lblownshow" runat="server" Visible="False" Text="you dont own it" Font-Size="XX-Large" ForeColor="White"></asp:Label>
        </asp:Panel>


      
    </div>
    </form>
</body>
</html>

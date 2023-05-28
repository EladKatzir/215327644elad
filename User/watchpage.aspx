<%@ Page Title="" Language="C#" MasterPageFile="~/User/Masterorder.master" AutoEventWireup="true" CodeFile="watchpage.aspx.cs" Inherits="User_watchpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .watch-container {
            text-align: center;
            margin-top: 50px;
        }

        .panel {
            background-color: black;
            color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
            margin-bottom: 20px;
        }

        .panel h2 {
            font-size: 24px;
            margin-bottom: 10px;
        }

        .panel p {
            font-size: 18px;
        }

        .panel button {
            background-color: white;
            color: black;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .panel button:hover {
            background-color: #eaeaea;
        }
    </style>

    <div class="watch-container">
        <asp:DropDownList ID="ddlOptions" runat="server" CssClass="ddl-options" AutoPostBack="true"
            OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
            <asp:ListItem Text="Select" Value=""></asp:ListItem>
            <asp:ListItem Text="Movies" Value="1"></asp:ListItem>
            <asp:ListItem Text="Shows" Value="2"></asp:ListItem>
            <asp:ListItem Text="Songs" Value="3"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <asp:Panel ID="pnlMovies" runat="server" CssClass="panel" Visible="false">
        <h2>Movies</h2>
        <asp:Label ID="lblMovieSelection" runat="server" Text="Select a movie:"></asp:Label>
        <asp:DropDownList ID="ddlMovies" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMovies_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <asp:Label ID="lblMovieCount" runat="server" Text="Number of times purchased:"></asp:Label>
        <asp:TextBox ID="txtMovieCount" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Button ID="btnPlayMovie" runat="server" Text="Play Movie" OnClick="btnPlayMovie_Click" />
        <br />
        <video id="moviePlayer" runat="server" style="width: 100%; height: auto;"></video>
    </asp:Panel>

    <asp:Panel ID="pnlShows" runat="server" CssClass="panel" Visible="false">
        <h2>Shows</h2>
        <!-- Add your show content here -->
    </asp:Panel>

    <asp:Panel ID="pnlSongs" runat="server" CssClass="panel" Visible="false">
        <h2>Songs</h2>
        <asp:Label ID="lblSongSelection" runat="server" Text="Select a song:"></asp:Label>
        <asp:DropDownList ID="ddlSongs" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSongs_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <asp:Label ID="lblSongCount" runat="server" Text="Number of times purchased:"></asp:Label>
        <asp:TextBox ID="txtSongCount" runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Button ID="btnPlaySong" runat="server" Text="Play Song" OnClick="btnPlaySong_Click" />
        <br />
        <video id="songPlayer" runat="server" style="width: 100%; height: auto;"></video>
    </asp:Panel>
     <asp:Label ID="lblown" runat="server" Text="you dont own this content" ForeColor="white" Font-Size="40px" Visible="false"></asp:Label>
</asp:Content>

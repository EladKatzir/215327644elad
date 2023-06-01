<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="homepage.aspx.cs" Inherits="User_homepage" %>


   
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <script type="text/javascript">
    window.onload = function () {
     
        if (performance.navigation.type === 2) { // 2 is a redirected page
              var message = '<%= Session["Message"] %>';
        if (message !== "") {
            alert(message);
        }
        Session["Message"] = "";

        }
    };
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <br />
    <h1 style="color:white; width: 337px; z-index: 1; left: 731px; top: 126px; position: absolute; height: 32px;"> Watch Infinity Content</h1>
    <h1 style="color:purple; width: 334px; z-index: 1; left: 732px; top: 160px; position: absolute; height: 34px;"> Only On Infinity.Tv</h1>
    <asp:Label ID="Label1" runat="server" Text="Label" BackColor="#6a4da6" style="z-index: 1; left: 725px; top: 285px; position: absolute; height: 68px; width: 343px;" ForeColor="White" Font-Size="X-Large"></asp:Label>
<br />
    <div style="position:relative;width:fit-content;height:fit-content;">
            <a style="position:absolute;top:20px;right:1rem;opacity:0.8;" href="https://clipchamp.com/watch/gcU3F2zfDaK?utm_source=embed&utm_medium=embed&utm_campaign=watch">
            </a>
            <iframe allow="autoplay;" allowfullscreen style="border:none" src="https://clipchamp.com/watch/gcU3F2zfDaK/embed" width="250" height="250"></iframe>
        </div>
        <p>
            
            <asp:Label ID="Label2" runat="server" BackColor="#6a4da6" ForeColor="White"  Font-Size="Large"  style="z-index: 1; left: -7px; top: -5px; position: absolute; height: 45px; width: 356px" Text="Label"></asp:Label>
    </p>
</asp:Content>


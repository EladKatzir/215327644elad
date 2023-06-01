<%@ Page Language="C#" AutoEventWireup="true" CodeFile="regi.aspx.cs" Inherits="User_regi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="../css/masterstyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:city %>" ProviderName="<%$ ConnectionStrings:city.ProviderName %>" SelectCommand="SELECT [CityID], [CityName] FROM [tblUsersCities]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:city %>" ProviderName="<%$ ConnectionStrings:city.ProviderName %>" SelectCommand="SELECT [GenderID], [Gender] FROM [tblUsersGender]"></asp:SqlDataSource>
        <div style="background-color:white">
    <asp:Panel ID="pnlStep1" runat="server">
    <h3>Step 1: Personal Information</h3>
    <table>
        <tr>
            <td>First Name:</td>
            <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Last Name:</td>
            <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Gender:</td>
            <td>
                    
    
        <asp:DropDownList ID="ddlg" runat="server" DataSourceID="SqlDataSource2" DataTextField="Gender" DataValueField="GenderID">
        </asp:DropDownList>
         
            </td>
        </tr>
    </table>
    <asp:Button ID="btnStep1" runat="server" Text="Next" OnClick="btnStep1_Click" />
</asp:Panel>
        <asp:Panel ID="pnlStep2" runat="server" Visible="false">
    <h3>Step 2: Contact Information</h3>
    <table>
        <tr>
            <td>Address:</td>
            <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>City:</td>
            <td>
                   
    
        <asp:DropDownList ID="ddlc" runat="server"  DataSourceID="SqlDataSource1" DataTextField="CityName" DataValueField="CityID" Height="20px" style="z-index: 1; left: 200px; top: 85px; position: absolute">
        </asp:DropDownList>
         
            </td>
        </tr>
        <tr>
            <td>Phone Number:</td>
            <td><asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Email:</td>
            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Button ID="btnStep2" runat="server" Text="Next" OnClick="btnStep2_Click" />
</asp:Panel>
<asp:Panel ID="pnlStep3" runat="server" Visible="false">
    <h3>Step 3: Login Information</h3>
    <table>
        <tr>
            <td>Username:</td>
            <td><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password:</td>
            <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
</asp:Panel>


        <asp:Label ID="lblSuccess" runat="server" style="z-index: 1; left: 498px; top: 162px; position: absolute" Text="Label" Font-Size="XX-Large" visible="false"></asp:Label>
           <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 512px; top: 257px; position: absolute"  ForeColor="White" text="everything is alright, procedd" Font-Size="XX-Large"></asp:Label>
            <asp:Panel ID="pnlRegistrationSuccess" runat="server" Visible="False">
    <p>Registration successful!</p>
                  <asp:Button ID="btnlog" runat="server" style="z-index: 1; left: 10px; top: 100px; font-size:large; position: absolute" Text="log in" OnClick="btnlog_Click" />

                
</asp:Panel>


          

</div>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="forgotpass.aspx.cs" Inherits="User_forgotpass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
         
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="background-color:white; height: 330px; top:10px">
            <h1>Forgot Password</h1>
            <p>Please enter your email address and we'll give you to a new temporary password.</p>
            <asp:Label ID="EmailLabel" runat="server" Text="Email Address:"></asp:Label>
            <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
            <br />
         <br />
         <br />
             <asp:Label ID="newpass" runat="server" Text="the new password will apear here"></asp:Label>
         <asp:Button ID="Button1" runat="server" Text="go to login" OnClick="Button1_Click"/>
             <br />
        <br />
         <br />
        
             <asp:Label ID="namelabel" runat="server" Text="user name:"></asp:Label>
            <asp:TextBox ID="nametextbox" runat="server"></asp:TextBox>

            <asp:Button ID="ResetPasswordButton" runat="server" Text="Reset Password" OnClick="ResetPasswordButton_Click" />
        </div>
</asp:Content>


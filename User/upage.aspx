<%@ Page Title="" Language="C#" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="true" CodeFile="upage.aspx.cs" Inherits="User_upage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlProfileInfo" runat="server" BackImageUrl="../images/adminback.png">
    <h2>Profile Information</h2>
    <hr />
    <table>
        <tr>
            <td><b>Current Profile Picture:</b></td>
            <td><asp:Image ID="imgProfilePic" runat="server" Height="150" Width="150" /></td>
        </tr>
        <tr>
            <td><b>Email:</b></td>
            <td><asp:Label ID="lblEmail" style="color:white"  runat="server" /></td>
        </tr>
        <tr>
            <td><b>Password:</b></td>
            <td><asp:Label ID="lblPassword" runat="server" style="color:white"  Text="********" /></td>
        </tr>
        <tr>
            <td><b>Birthday:</b></td>
            <td><asp:Label ID="lblBirthday" style="color:white" runat="server" /></td>
        </tr>
    </table>
</asp:Panel>

   <asp:Button ID="Btnchange" runat="server" Text="Update account info" OnClick="Btnchange_Click" />
    <asp:Button ID="btninfo" runat="server" Text="show info" OnClick="Btninfo_Click" />
<asp:DropDownList ID="ddlUserOptions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUserOptions_SelectedIndexChanged" Visible="false">
    <asp:ListItem Value="">-- Select an option --</asp:ListItem>
    <asp:ListItem Value="pic">Change profile picture</asp:ListItem>
    <asp:ListItem Value="password">Change password</asp:ListItem>
    <asp:ListItem Value="email">Change email</asp:ListItem>
    <asp:ListItem Value="birthday">Change birthday</asp:ListItem>
</asp:DropDownList>

<asp:Panel ID="pnlProfilePic" runat="server" Visible="False" BackImageUrl="../images/adminback.png">
    <!-- profile picture upload controls -->
     <h2>Change Profile Picture</h2>
    <hr />
    <asp:Image ID="imgavatar" runat="server" style="position: absolute;height: 125px; width: 149px;border-radius: 50%; top: 173px; left: 353px;" BackColor="White" BorderColor="White" BorderStyle="Solid" BorderWidth="0.5px" />
                    <asp:FileUpload ID="FileUpload1" runat="server" style="position: absolute; direction: ltr;" /> 
    <br /><br />
    <asp:Button ID="btnUpdateProfilePic" runat="server" Text="Update Profile Picture" OnClick="btnUpdateProfilePic_Click" />
</asp:Panel>

<asp:Panel ID="pnlPassword" runat="server" Visible="False" BackImageUrl="../images/adminback.png">
    <!-- password change controls -->
    <asp:Panel ID="Panel1" runat="server">
    <h2>Change Password</h2>
    <hr />
        <asp:Label ID="lblPasswordMessage" text="hi" runat="server">
        </asp:Label>
        <table>
            <tr>
                <td><b>Current Password:</b></td>
                <td>
                    <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td><b>New Password:</b></td>
                <td>
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td><b>Confirm Password:</b></td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
                </td>
            </tr>
        </table>
    <br />
    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
</asp:Panel>

</asp:Panel>
<asp:Panel ID="pnlEmail" runat="server" Visible="False"  BackImageUrl="../images/adminback.png">
    <!-- email change controls -->
    <h2>Change Email</h2>
    <hr />
    <table>
        <tr>
            <td><b>Current Email:</b></td>
            <td><asp:Label ID="lblCurrentEmail" runat="server" Text="" /></td>
        </tr>
        <tr>
            <td><b>New Email:</b></td>
            <td><asp:TextBox ID="txtNewEmail" runat="server" /></td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnUpdateEmail" runat="server" Text="Update Email" OnClick="btnUpdateEmail_Click" />
    <br />
    <asp:Label ID="lblEmailMessage" runat="server" Visible="false"></asp:Label>
</asp:Panel>
   


<asp:Panel ID="pnlBirthday" runat="server" Visible="False"  BackImageUrl="../images/adminback.png">>
    <h2>Change Birthday</h2>
    <hr />
    <asp:Label ID="lblBirthdayMessage" runat="server"></asp:Label>
    <br /><br />
    <asp:Calendar ID="calBirthday" runat="server" OnSelectionChanged="calBirthday_SelectionChanged"
    OnVisibleMonthChanged="calBirthday_VisibleMonthChanged" AutoPostBack="False">
</asp:Calendar>


    <br /><br />
    <asp:Button ID="btnChangeBirthday" runat="server" Text="Change Birthday" OnClick="btnChangeBirthday_Click" />
</asp:Panel>




</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/amaster.master" AutoEventWireup="true" CodeFile="productmenu.aspx.cs" Inherits="productmenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phButtons" runat="server">
    <style>
        .button-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
        }

        .button-wrapper {
            margin: 10px;
            text-align: center;
        }

        .cool-button {
            background-color: black;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-size: 18px;
            cursor: pointer;
        }

        .button-description {
            display: none;
            background-color: white;
            color: black;
            padding: 5px;
            border-radius: 5px;
        }

        .button-wrapper:hover .button-description {
            display: block;
        }
    </style>
  <div>
          <asp:Repeater ID="rptButtons" runat="server" OnItemCommand="rptButtons_ItemCommand">
            <ItemTemplate>
                <div class="button-wrapper">
                   <asp:Button ID="btnButton" runat="server" CssClass="cool-button" Text='<%# Eval("ButtonText") %>'
                    CommandName="ButtonClick" CommandArgument='<%# Eval("ButtonId") %>' />
                    <div class="button-description">
                        <%# Eval("ButtonDescription") %>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
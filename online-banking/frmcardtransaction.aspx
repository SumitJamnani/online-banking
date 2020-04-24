<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmcardtransaction.aspx.cs" Inherits="frmcardtransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblaccountno" runat="server" Text="Account No"> </asp:Label> <asp:TextBox ID="txtaccountno" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblcardtype" runat="server" Text="Card type"></asp:Label><asp:RadioButtonList ID="rblcardtype" runat="server">
        <asp:ListItem>credit</asp:ListItem>
        <asp:ListItem>debit</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="lblcardno" runat="server" Text="Card No"></asp:Label>&nbsp;<asp:TextBox ID="txtcardno" runat="server"></asp:TextBox>
    &nbsp;<br />
    <asp:Label ID="lblapplydate" runat="server" Text="Apply Date"></asp:Label><asp:TextBox ID="txtapplydate" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblissuedate" runat="server" Text="Issue Date"></asp:Label><asp:TextBox ID="txtissuedate" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label><asp:RadioButtonList ID="rblstatus" runat="server">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>0</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="lblempid" runat="server" Text="Emp id"></asp:Label><asp:DropDownList ID="drpempid" runat="server"></asp:DropDownList>
    &nbsp;<br />
    <asp:Button ID="btncancel" runat="server" Text="cancel" />
    <asp:Button ID="btnsave" runat="server" Text="save" onclick="btnsave_Click" />


    <br />
    <asp:GridView ID="grdcardtransaction" runat="server">
    </asp:GridView>


</asp:Content>


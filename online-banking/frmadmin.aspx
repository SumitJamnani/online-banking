<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true"
    CodeFile="frmadmin.aspx.cs" Inherits="frmadmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblrequestofchequebook" runat="server" Text="Select Transaction Type">
    </asp:Label>
    <asp:DropDownList ID="drpcheque" runat="server" OnSelectedIndexChanged="changed1" AutoPostBack="true">
        <asp:ListItem Text="Cheque" Value="C"></asp:ListItem>
        <asp:ListItem Text="Passbook" Value="P"></asp:ListItem>
        <asp:ListItem Text="demanddraft" Value="D"></asp:ListItem>
         <asp:ListItem Text="customerloan" Value="CL"></asp:ListItem>
          <asp:ListItem Text="stoppayment" Value="S"></asp:ListItem>
        
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblrequest" runat="server" Text="Select Account Number : "></asp:Label>
    &nbsp;&nbsp;
    <asp:DropDownList ID="drprequest" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnissue" runat="server" Text="Issue" OnClick="btnsubmit_Click" />
    <br />
    <br />
</asp:Content>

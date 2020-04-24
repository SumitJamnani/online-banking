<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmaccountnominee.aspx.cs" Inherits="frmaccountnominee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblaccountno" runat="server" Text="Enter account no"></asp:Label><asp:DropDownList ID="drpaccountno" runat="server">
    </asp:DropDownList>
    &nbsp;<br />
    <br />
    <asp:Label ID="lblnomineeid" runat="server" Text="enter Nominee id"></asp:Label><asp:DropDownList ID="drpnomineeid" runat="server">  </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lbldate" runat="server" Text="Enter Date"></asp:Label><asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" />
    <asp:Button ID="btnupdate" runat="server" Text="update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnaccount" runat="server" />
    <br />
    <br />
    <br />
    <asp:GridView ID="grdaccountnominee" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText="account_no">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('account_no') %>"
                                    CommandName="account_no" CommandArgument='<%#Bind("account_no") %>'></asp:LinkButton>
     </ItemTemplate>
    </asp:TemplateField>
     <asp:BoundField DataField="nominee_id" HeaderText="Nominee_Id" />
      <asp:BoundField DataField="date" HeaderText="Date" />
    </Columns>
    </asp:GridView>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmstate.aspx.cs" Inherits="frmstate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblstate" runat="server" Text="Enter State Name"></asp:Label>  <asp:TextBox ID="txtstatename" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblcountryid" runat="server" Text=" Country id"></asp:Label>
    <asp:DropDownList ID="drpcountry" runat="server">
    </asp:DropDownList>
     <br />
     <asp:Button ID="btncancel" runat="server" Text="Cancel"  onclick="btncancel_Click" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" />
    <asp:Button ID="btnupdate" runat="server" Text="Update" onclick="btnupdate_Click"   />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click"  />
    <asp:HiddenField ID="hdnid" runat="server" />
    <br />
    <asp:GridView ID="grdstate" runat="server" OnRowCommand="grdstate_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText="state_id">
    <ItemTemplate>
     <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('state_id') %>"
                                    CommandName="state_id" CommandArgument='<%#Bind("state_id") %>'></asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
     <asp:BoundField DataField="state_name" HeaderText="State_Name" />
    </Columns>
    </asp:GridView>
</asp:Content>


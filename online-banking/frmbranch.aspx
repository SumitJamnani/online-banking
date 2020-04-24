<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmbranch.aspx.cs" Inherits="frmbranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblbranch" runat="server" Text="Enter Branch Name"></asp:Label><asp:TextBox ID="txtbranchname" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtbranchname" ErrorMessage="plz Enter Branch Name" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblbranchphoneno" runat="server" Text="Enter Branch Phoneno"></asp:Label><asp:TextBox ID="txtbranchphoneno" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblbranchaddress1" runat="server" Text="Address1"></asp:Label><asp:TextBox ID="txtaddress1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtaddress1" ErrorMessage="Address Required" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblbranchaddress2" runat="server" Text="Address2"></asp:Label><asp:TextBox ID="txtaddress2" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblbranchaddress3" runat="server" Text="Address3"></asp:Label><asp:TextBox ID="txtaddress3" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblbranchpincode" runat="server" Text="PINcode"></asp:Label><asp:TextBox ID="txtpincode" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtpincode" ErrorMessage="plz enter 6 digits only" 
        ValidationExpression="\d{6}" ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="Update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click" />

    <br />
    <asp:HiddenField ID="hdnid" runat="server" />
    <asp:GridView ID="grdbranch" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false" Width="99%">
    <Columns>
      <asp:TemplateField HeaderText ="branch_id">
       <ItemTemplate> 
            <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('branch_id') %>"
                                    CommandName="Branch_id" CommandArgument='<%#Bind("branch_id") %>'></asp:LinkButton>


       </ItemTemplate>
       </asp:TemplateField> 
       <asp:BoundField DataField="branch_name" HeaderText="Branch Name" />
       <asp:BoundField DataField="branch_phone_no" HeaderText="Branch Phone No" />
       <asp:BoundField DataField="branch_address1" HeaderText="Branch Address1" />
       <asp:BoundField DataField="branch_address2" HeaderText="Branch Address2" />
       <asp:BoundField DataField="branch_address3" HeaderText="Branch Address3" />
       <asp:BoundField DataField="pincode" HeaderText="Branch Pincode" />

    </Columns>
    </asp:GridView>
</asp:Content>


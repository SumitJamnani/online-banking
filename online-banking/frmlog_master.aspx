<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmlog_master.aspx.cs" Inherits="frmlog_master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblemail_id" runat="server" Text="Enter email id"></asp:Label><asp:TextBox ID="txtemail_id" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtemail_id" ErrorMessage="plz enter proper email id" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="lbldatetime" runat="server" Text="Enter date and time"></asp:Label><asp:TextBox  ID="txtdatetime" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblip_address" runat="server" Text="Ip_address"></asp:Label><asp:TextBox ID="txtip_address" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbllogout_time" runat="server" Text="Logout time"></asp:Label><asp:TextBox ID="txtlogout_time" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbllogintime" runat="server" Text="Login time"></asp:Label><asp:TextBox ID="txtlogin_time" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" />
    <asp:Button ID="btnupdate" runat="server" Text="Update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnemailid" runat="server" />
    <br />
    <asp:GridView ID="grdlog_master" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
     <asp:TemplateField HeaderText="email_id">
     <ItemTemplate>
         <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('email_id') %>"
                                    CommandName="email_id" CommandArgument='<%#Bind("email_id") %>'></asp:LinkButton>
     </ItemTemplate>
     </asp:TemplateField>
     <asp:BoundField DataField="datetime" HeaderText="datetime" />
      <asp:BoundField DataField="ip_address" HeaderText="ip_address" />
      <asp:BoundField DataField="logout_time" HeaderText="logout_time" />
        <asp:BoundField DataField="login_time" HeaderText="login_time" />

    </Columns>
    </asp:GridView>
    <br />
</asp:Content>


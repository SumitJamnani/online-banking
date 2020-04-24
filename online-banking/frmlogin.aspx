<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmlogin.aspx.cs" Inherits="frmlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblemail_id" runat="server" Text="enter email_id"></asp:Label>  <asp:TextBox ID="txtemail_id" runat="server"></asp:TextBox> 
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtemail_id" ErrorMessage="plz enter proper email id" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="lblpassword" runat="server" Text="enter password"></asp:Label> <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblsec_q_id" runat="server" Text="enter sec_q_id"></asp:Label> <asp:DropDownList ID="drpaecqid" runat="server"> </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblsec_q_ans" runat="server" Text="enter sec_q_ans"></asp:Label><asp:TextBox ID="txtsec_q_ans" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbluser_type" runat="server" Text="select user type"></asp:Label>   
    <asp:RadioButtonList ID="rbluser_type" runat="server">
        <asp:ListItem>C</asp:ListItem>
        <asp:ListItem>E</asp:ListItem>
        <asp:ListItem>A</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
    <asp:Button ID="btnupdate" runat="server" Text="Update"  onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnemailid" runat="server" />
    <br />
    <asp:GridView ID="grdlogin" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText="email_id">
     <ItemTemplate>
         <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('email_id') %>"
                                    CommandName="email_id" CommandArgument='<%#Bind("email_id") %>'></asp:LinkButton>
     </ItemTemplate>
     </asp:TemplateField>
     <asp:BoundField DataField="password" HeaderText="password" />
      <asp:BoundField DataField="sec_q_id" HeaderText="sec_q_id" />
      <asp:BoundField DataField="sec_q_ans" HeaderText="sec_q_ans" />
        <asp:BoundField DataField="user_type" HeaderText="user_type" />

    </Columns>
    </asp:GridView>
</asp:Content>


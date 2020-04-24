<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmfeedback.aspx.cs" Inherits="frmfeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblaccountno" runat="server" Text="Enter Account No"></asp:Label><asp:DropDownList ID="drpaccountno" runat="server">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="drpaccountno" ErrorMessage="Account no Required" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lbldatetime" runat="server" Text="Enter date and Time"></asp:Label><asp:TextBox ID="txtdatetime" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtdatetime" ErrorMessage="mm/dd/yyyy" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblfeedback" runat="server" Text="Enter your feedback"></asp:Label><asp:TextBox ID="txtfeedback" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnCancle" runat="server" Text="Cancle" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" onclick="btnUpdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnaccount" runat="server" />
    <br />
    <asp:GridView ID="grdfeedback" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText="account_no">
     <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('account_no') %>"
                                    CommandName="account_no" CommandArgument='<%#Bind("account_no") %>'></asp:LinkButton>
     </ItemTemplate>
    </asp:TemplateField>
    
      <asp:BoundField DataField="datetime" HeaderText="datetime" />
      <asp:BoundField DataField="feedback" HeaderText="feedback" />
    </Columns>
    </asp:GridView>

</asp:Content>


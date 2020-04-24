<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmpayback_transaction.aspx.cs" Inherits="frmpayback_transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:Label ID="lblpayback_id" runat="server" Text="Payback id"></asp:Label>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="drppayback_id" runat="server"> </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblaccountno" runat="server" Text="Account_No"></asp:Label>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtaccountno" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtaccountno" ErrorMessage="Required Account No" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lbldatetime" runat="server" Text="Datetime"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtdatetime" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
        ControlToValidate="txtdatetime" ErrorMessage="mm/dd/yyyy" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblpaybackamount" runat="server" Text="Payback_Amount"></asp:Label>  &nbsp;  <asp:TextBox ID="txtpaybackamount" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btncancel" runat="server" Text="cancel" />
    <asp:Button ID="btnsave" runat="server" Text="save" onclick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="update" onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="delete" onclick="btndel_Click"  />
    <br />
    <br />
    <br />
    <asp:HiddenField ID="hdnaccount" runat="server" />
    <asp:GridView ID="grdtransaction" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText="account_no">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('account_no') %>"
                                    CommandName="account_no" CommandArgument='<%#Bind("account_no") %>'></asp:LinkButton>
     </ItemTemplate>
    </asp:TemplateField>
     <asp:BoundField DataField="payback_id" HeaderText="Payback_Id" />
      <asp:BoundField DataField="datetime" HeaderText="Datetime" />
      <asp:BoundField DataField="payback_amount" HeaderText="Payback Amount" />
    </Columns>
    </asp:GridView>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmaccounttransation.aspx.cs" Inherits="frmaccounttransation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblaccount_no" runat="server" Text="Enter Account no"></asp:Label> <asp:DropDownList ID="drpaccountno" runat="server">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="drpaccountno" ErrorMessage="Enter Account Number" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblamount" runat="server" Text="Amount"></asp:Label> <asp:TextBox ID="txtamount" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtamount" ErrorMessage="Enter Current Balance" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lbltransaction_datetime" runat="server" Text="Enter Trasaction Datetime"></asp:Label> -<asp:TextBox ID="txttransaction_datetime" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txttransaction_datetime" ErrorMessage=" MM/DD/YYYY" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lbldescription" runat="server" Text="Description"></asp:Label> <asp:TextBox ID="txtdescription" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblcharges_id" runat="server" Text="charges Name"></asp:Label>  <asp:DropDownList ID="drpcharges_id" runat="server"> </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lbltransaction_type" runat="server" Text="Trasaction Type"></asp:Label> 
    <asp:RadioButtonList ID="rbltransaction_type" runat="server">
        <asp:ListItem Value="c">Credit</asp:ListItem>
        <asp:ListItem Value="d">Debit</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="Update" 
        onclick="btnupdate_Click"  />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnaccountno" runat="server" />
    <br />
    <br />
    <asp:GridView ID="grdaccount" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
       <Columns>
    <asp:TemplateField HeaderText="account_no">
     <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('account_no') %>"
                                    CommandName="account_no" CommandArgument='<%#Bind("account_no") %>'></asp:LinkButton>
     </ItemTemplate>
    </asp:TemplateField>
      <asp:BoundField DataField="amount" HeaderText="Amount" />
     <asp:BoundField DataField="transaction_datetime" HeaderText="Transaction_Datetime" />
     <asp:BoundField DataField="description" HeaderText="Description" />
      <asp:BoundField DataField="charges_id" HeaderText="Charges_Id" />
     <asp:BoundField DataField="transaction_type" HeaderText="Transaction_Type" />
    </Columns>
    </asp:GridView>
    <br />
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmrepayment.aspx.cs" Inherits="frmrepayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblaccountno" runat="server" Text="Enter Account No"></asp:Label><asp:DropDownList ID="drpaccountno" runat="server"> </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="drpaccountno" ErrorMessage="Required Account No" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblloanid" runat="server" Text="Loan Id"></asp:Label> <asp:DropDownList ID="drploanid" runat="server"> </asp:DropDownList>
    <br />
    <asp:Label ID="lbldate" runat="server" Text="Date"></asp:Label><asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
        ControlToValidate="txtdate" ErrorMessage="mm/dd/yyyy" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblamount" runat="server" Text="Amount"></asp:Label><asp:TextBox ID="txtamount" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblpayby" runat="server" Text="Payby"></asp:Label><asp:TextBox ID="txtpayby" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblchequeno" runat="server" Text="Cheque No"></asp:Label><asp:TextBox ID="txtchequeno" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ControlToValidate="txtchequeno" ErrorMessage="Required ChequeNo" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtchequeno" ErrorMessage="10 digits only" 
        ValidationExpression="\d{10}" ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <asp:Label ID="lblcardno" runat="server" Text="Card No"></asp:Label><asp:TextBox ID="txtcardno" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
        ControlToValidate="txtcardno" ErrorMessage="required Card No" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ControlToValidate="txtcardno" ErrorMessage="12 digits only" 
        ValidationExpression="\d{12}" ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <asp:Label ID="lbldescription" runat="server" Text="Description"></asp:Label><asp:TextBox ID="txtdescription" runat="server"></asp:TextBox>
    <br />
     <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" 
        ValidationGroup="abc"  />
    <asp:Button ID="btnupdate" runat="server" Text="Update" onclick="btnupdate_Click"   />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click"  />
    <asp:HiddenField ID="hdnid" runat="server" />
    <br />
    <asp:GridView ID="grdrepayment" runat="server" OnRowCommand="grdrepayment_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText="Account_No">
    <ItemTemplate>
     <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('account_no') %>"
                                    CommandName="account_no" CommandArgument='<%#Bind("account_no") %>'></asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
     <asp:BoundField DataField="loan_id" HeaderText="Loan Id" />
      <asp:BoundField DataField="date" HeaderText="Date" />
      <asp:BoundField DataField="amount" HeaderText="Amount" />
       <asp:BoundField DataField="payby" HeaderText="Payby" />
       <asp:BoundField DataField="cheque_no" HeaderText="Cheque No" />
       <asp:BoundField DataField="card_no" HeaderText="Card_No" />
       <asp:BoundField DataField="description" HeaderText="Description" />
    </Columns>
    </asp:GridView>
    <br />

</asp:Content>


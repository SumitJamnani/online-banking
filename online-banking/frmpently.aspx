<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmpently.aspx.cs" Inherits="frmpently" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblaccountno" runat="server" Text="Account_no"></asp:Label><asp:DropDownList ID="drpaccountno" runat="server">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="drpaccountno" ErrorMessage="Required Account No" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblloanid" runat="server" Text="Loan_id"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="drploanid" runat="server"> </asp:DropDownList>
    <br />
    <asp:Label ID="lblamount" runat="server" Text="Amount"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtamount" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lbldescription" runat="server" Text="Description"></asp:Label>&nbsp; <asp:TextBox ID="txtdescription" runat="server"></asp:TextBox>
    <br />
&nbsp;<asp:Label ID="lbldate" runat="server" Text="Date"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
        ControlToValidate="txtdate" ErrorMessage="mm/dd/yyyy" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
&nbsp;&nbsp;
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="Update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnaccountno" runat="server" />
    <br />
    <asp:GridView ID="grdpently" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText ="account_no">
    <ItemTemplate>
      <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('account_no') %>"
                                    CommandName="account_no" CommandArgument='<%#Bind("account_no") %>'></asp:LinkButton>
    </ItemTemplate>
     </asp:TemplateField>
      <asp:BoundField DataField="loan_id" HeaderText="Loan_id" />
      <asp:BoundField DataField="amount" HeaderText="Amount" />
      <asp:BoundField DataField="description" HeaderText="Description" />
       <asp:BoundField DataField="date" HeaderText="Date" />
    </Columns>
    </asp:GridView>
</asp:Content>


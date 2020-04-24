<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmloan.aspx.cs" Inherits="frmloan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblloan_type" runat="server" Text="Enter loan type"></asp:Label> <asp:TextBox ID="txtloan_type" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtloan_type" ErrorMessage="Enter Loan type" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblmax_loan" runat="server" Text="Max_loan Amount"></asp:Label> <asp:TextBox ID="txtmax_loan" runat="server"></asp:TextBox> 
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtmax_loan" ErrorMessage="Max Loan Amount" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblmin_loan" runat="server" Text="Min_loan Amount"></asp:Label> 
    <asp:TextBox ID="txtmin_loan" runat="server"> </asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtmin_loan" ErrorMessage="Min Loan Amount" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblinterest_rate" runat="server" Text="loan Interest"></asp:Label> <asp:TextBox ID="txtinterest_rate" runat="server"></asp:TextBox>

    <br />

    <br />

    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="Update"  onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnid" runat="server" />
    
   
    <br />
    <asp:GridView ID="grdloan" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText="loan_id">
    <ItemTemplate>
     <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('loan_id') %>"
                                    CommandName="loan_id" CommandArgument='<%#Bind("loan_id") %>'></asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
     <asp:BoundField DataField="loan_type" HeaderText="Loan Type" />
      <asp:BoundField DataField="max_loan" HeaderText="Max Loan" />
      <asp:BoundField DataField="min_loan" HeaderText="Min Loan" />
       <asp:BoundField DataField="interest_rate" HeaderText="Interest Rate" />
    </Columns>
    </asp:GridView>

    
   
</asp:Content>


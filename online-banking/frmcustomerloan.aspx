<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmcustomerloan.aspx.cs" Inherits="frmcustomerloan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblaccount_no" runat="server" Text="Account No"></asp:Label> <asp:DropDownList ID="drpaccountno" runat="server">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="drpaccountno" ErrorMessage="Enter Account Number" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblloan_id" runat="server" Text="Loan Id"></asp:Label><asp:DropDownList ID="drploan_id" runat="server"> </asp:DropDownList>
     <br />
     <br />
     <asp:Label ID="lblloanapply_date" runat="server" Text=" Enter Loanapply Date"></asp:Label> <asp:TextBox ID="txtloanapply_date" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtloanapply_date" ErrorMessage=" MM/DD/YYYY" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
      <br />
      <br />
      <asp:Label ID="lblapproval_date" runat="server" Text=" Enter Approval Date"></asp:Label> <asp:TextBox ID="txtapproval_date" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtapproval_date" ErrorMessage=" MM/DD/YYYY" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
       <br />
       <br />
       <asp:Label ID="lblloan_amount" runat="server" Text="Enter Loan Amount"></asp:Label> <asp:TextBox ID="txtloan_amount" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtloan_amount" ErrorMessage="Loan Amount" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
        <br />
         <br />
         <asp:Label ID="lbldurationinmonth" runat="server" Text="Enter Durationinmonth"></asp:Label> <asp:TextBox ID="txtdurationinmonth" runat="server"></asp:TextBox>
          <br />
          <br />
          <asp:Label ID="lblclosing_date" runat="server" Text="Enter Closing Date"></asp:Label> <asp:TextBox ID="txtclosing_date" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtclosing_date" ErrorMessage=" MM/DD/YYYY" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
           <br />
           <br />
           <asp:Label ID="lbldescription" runat="server" Text="Enter Description"></asp:Label> <asp:TextBox ID="txtdescription" runat="server"></asp:TextBox>
             <br />
             <br />
             <asp:Label ID="lblemp_id" runat="server" Text="Emp id"></asp:Label> <asp:DropDownList ID="drpemp_id" runat="server"> </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btncancel" runat="server" Text="cancel" />
    <asp:Button ID="btnsave" runat="server" Text="save" onclick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="delete" onclick="btndel_Click" />
    <br />
    <br />
    <asp:HiddenField ID="hdnid" runat="server" />
    <br />
    <asp:GridView ID="grdcustomerloan" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText="loan_id">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('loan_id') %>"
                                    CommandName="loan_id" CommandArgument='<%#Bind("loan_id") %>'></asp:LinkButton>
     </ItemTemplate>
    </asp:TemplateField>
     <asp:BoundField DataField="account_no" HeaderText="account_no" />
      <asp:BoundField DataField="loanapply_date" HeaderText="loanapply_date" />
      <asp:BoundField DataField="approval_date" HeaderText="approval_date" />
      <asp:BoundField DataField="loan_amount" HeaderText="loan_amount" />
      <asp:BoundField DataField="durationinmonth" HeaderText="durationinmonth" />
      <asp:BoundField DataField="closing_date" HeaderText="closing_date" />
      <asp:BoundField DataField="description" HeaderText="description" />
      <asp:BoundField DataField="emp_id" HeaderText="emp_id" />
      
    </Columns>
    </asp:GridView>
    
</asp:Content>


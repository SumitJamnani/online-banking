<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmpassbook.aspx.cs" Inherits="frmpassbook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblaccountno" runat="server" Text="Account_No"></asp:Label>
    <asp:DropDownList ID="drpaccountno" runat="server">
    </asp:DropDownList>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="drpaccountno" ErrorMessage="Required Account No" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lbldate" runat="server" Text="Date"> </asp:Label>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ControlToValidate="txtdate" ErrorMessage="mm/dd/yyyy" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblissuedate" runat="server" Text="Issue_Date"> </asp:Label> &nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtissuedate" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
        ControlToValidate="txtissuedate" ErrorMessage="mm/dd/yyyy" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblapplydate" runat="server" Text="Apply_Date"></asp:Label> &nbsp;&nbsp; <asp:TextBox ID="txtapplydate" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
        ControlToValidate="txtapplydate" ErrorMessage="mm/dd/yyyy" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <br />
    <asp:Label ID="lblempid" runat="server" Text="Emp_id"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="drpempid" runat="server"> </asp:DropDownList>
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnaccountno" runat="server" />
    <br />
    <br />
    <asp:GridView ID="grdpassbook" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
     <Columns>
    <asp:TemplateField HeaderText="account_no">
     <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('account_no') %>"
                                    CommandName="account_no" CommandArgument='<%#Bind("account_no") %>'></asp:LinkButton>
     </ItemTemplate>
    </asp:TemplateField>
      <asp:BoundField DataField="date" HeaderText="Issue_Date" />
     <asp:BoundField DataField="issue_Date" HeaderText="Issue_Date" />
     <asp:BoundField DataField="apply_date" HeaderText="Apply_Date" />
     <asp:BoundField DataField="status" HeaderText="status" />
     <asp:BoundField DataField="emp_id" HeaderText="Emp Id" />
    </Columns>
    </asp:GridView>
</asp:Content>


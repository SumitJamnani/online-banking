<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmchequebook.aspx.cs" Inherits="frmchequebook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblaccountno" runat="server" Text="Account_No"></asp:Label>&nbsp;&nbsp; 
    <asp:DropDownList ID="drpaccount" runat="server">
    </asp:DropDownList>
    &nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ErrorMessage="Enter Account No" ControlToValidate="drpaccount" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblissuedate" runat="server" Text="Issue_Date"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtissuedate" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtissuedate" ErrorMessage=" MM/DD/YYYY" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblstartnumber" runat="server" Text="Start_Number"></asp:Label><asp:TextBox ID="txtstartnumber" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblendnumber" runat="server" Text="End_Number"></asp:Label>&nbsp; <asp:TextBox ID="txtendnumber" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblapplydate" runat="server" Text="Apply_Date"></asp:Label>&nbsp;&nbsp; <asp:TextBox ID="txtapplydate" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtapplydate" ErrorMessage=" MM/DD/YYYY" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblempid" runat="server" Text="Emp_Id"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="drpempid" runat="server"> </asp:DropDownList>
    <br />
    <br />
    
    <br />
    <br />
    <br />
  
    <asp:Button ID="btncancel" runat="server" Text="Cancel"/>
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="Update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnaccountno" runat="server" />
    <br />
    <br />
    <asp:GridView ID="grdcheque" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
     <Columns>
    <asp:TemplateField HeaderText="account_no">
     <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('account_no') %>"
                                    CommandName="account_no" CommandArgument='<%#Bind("account_no") %>'></asp:LinkButton>
     </ItemTemplate>
    </asp:TemplateField>
     <asp:BoundField DataField="issue_Date" HeaderText="Issue_Date" />
    <asp:BoundField DataField="start_number" HeaderText="Start_Number" />
    <asp:BoundField DataField="end_number" HeaderText="End_Number" />
     <asp:BoundField DataField="apply_date" HeaderText="Apply_Date" />
     <asp:BoundField DataField="emp_id" HeaderText="Emp Id" />
     <asp:BoundField DataField="status" HeaderText="status" />
    </Columns>
    </asp:GridView>
</asp:Content>


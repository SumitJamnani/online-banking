<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmdemanddraft.aspx.cs" Inherits="frmdemanddraft" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblaccount_no" runat="server" Text="Enter Account No"></asp:Label>  <asp:DropDownList ID="drpaccountno" runat="server">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="drpaccountno" ErrorMessage="Enter Account Number" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblamount" runat="server" Text="Enter Amount"></asp:Label>  <asp:TextBox ID="txtamount" runat="server"></asp:TextBox>
    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtamount" ErrorMessage="Enter Amount" 
        ValidationGroup="amount"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblapply_date" runat="server" Text="Enter Apply Date"></asp:Label> <asp:TextBox ID="txtapply_date" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtapply_date" ErrorMessage=" MM/DD/YYYY" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblapprove_date" runat="server" Text="Enter Approve Date"></asp:Label> <asp:TextBox ID="txtapprove_date" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtapprove_date" ErrorMessage=" MM/DD/YYYY" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblemp_id" runat="server" Text=" emp id"></asp:Label>  <asp:DropDownList ID="drpemp_id" runat="server"> </asp:DropDownList>
    <br />
    <asp:Label ID="lblstatus" runat="server" Text="status"></asp:Label>
    <br />
    <asp:RadioButtonList ID="rblstatus" runat="server">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>0</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="Upadte" 
        onclick="btnupdate_Click" style="height: 26px" />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnaccountno" runat="server" />
    <br />
    <br />
    <asp:GridView ID="grddemanddraft" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText="account_no">
     <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('account_no') %>"
                                    CommandName="account_no" CommandArgument='<%#Bind("account_no") %>'></asp:LinkButton>
     </ItemTemplate>
    </asp:TemplateField>
     <asp:BoundField DataField="amount" HeaderText="Amount" />
    <asp:BoundField DataField="apply_date" HeaderText="Apply_date" />
    <asp:BoundField DataField="approve_date" HeaderText="Approve_Date" />
    <asp:BoundField DataField="emp_id" HeaderText="Emp Id" />
    <asp:BoundField DataField="status" HeaderText="status" />
    </Columns>
    </asp:GridView>
    <br />
</asp:Content>


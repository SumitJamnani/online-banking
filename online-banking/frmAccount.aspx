<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmAccount.aspx.cs" Inherits="frmAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblaccount_no" runat="server" Text="Enter Account No"></asp:Label>
    <asp:TextBox ID="txtaccountno" runat="server" ></asp:TextBox>
    
    <br />
    <br />
   <asp:Label ID="lblaccount_type_id" runat="server" Text="Enter Account_type_id"></asp:Label><asp:DropDownList ID="drpaccounttypeid" runat="server">
   </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblcust_id" runat="server" Text="Cust_id"></asp:Label><asp:DropDownList ID="drpcustid" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblopen_date" runat="server" Text="Enter Open Date"></asp:Label><asp:TextBox ID="txtopendate" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblbalance" runat="server" Text="Enter Balance"></asp:Label><asp:TextBox ID="txtbalance" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblstatus" runat="server" Text="Enter Status"> </asp:Label> 
    <asp:RadioButtonList ID="rblstatus" runat="server" AutoPostBack="True">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>0</asp:ListItem>
    </asp:RadioButtonList>
     <br />
    <br />
     <asp:Label ID="lblbranch_id" runat="server" Text="Enter Branch Id"></asp:Label><asp:DropDownList ID="drpbranchid" runat="server">
     </asp:DropDownList>
        <br />
    <br />
        <asp:Button ID="btncancel" runat="server" Text="Cancel" />
        <asp:Button ID="btnsave" runat="server" Text="Save"  onclick="btnsave_Click" />
    <asp:Button ID="btnupdate" runat="server" Text="update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnaccount" runat="server" />
    <br />
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
     <asp:BoundField DataField="account_type_id" HeaderText="Account_Type_Id" />
      <asp:BoundField DataField="cust_id" HeaderText="Cust_Id" />
      <asp:BoundField DataField="open_date" HeaderText="Open_Date" />
        <asp:BoundField DataField="balance" HeaderText="Balance" />
          <asp:BoundField DataField="status" HeaderText="Status" />
            <asp:BoundField DataField="branch_id" HeaderText="Branch_Id" />
    </Columns>
    </asp:GridView>
    <br />

    </asp:Content>


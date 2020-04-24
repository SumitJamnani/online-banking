<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmpayment.aspx.cs" Inherits="frmstoppayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblaccountno" runat="server" Text="Account_no"></asp:Label><asp:DropDownList  ID="drpaccountno" runat="server"> </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblchequeno" runat="server" Text="Cheque_no"></asp:Label><asp:TextBox  ID="txtchequeno" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtchequeno" ErrorMessage="10 digits only" 
        ValidationExpression="\d{10}" ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="lblstopdate" runat="server" Text="Stop_date"></asp:Label><asp:TextBox ID="txtstopdate" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbldescription" runat="server" Text="Description"></asp:Label><asp:TextBox ID="txtdescription" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblempid" runat="server" Text="Emp_id"></asp:Label><asp:DropDownList ID="drpempid" runat="server"> </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblrequestdate" runat="server" Text="Request_date"></asp:Label><asp:TextBox ID="txtrequestdate" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblamount" runat="server" Text="Amount"></asp:Label><asp:TextBox ID="txtamount" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
    <asp:RadioButtonList ID="rblstatus" runat="server" AutoPostBack="True">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>0</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <br />
    <asp:Label ID="lblchequeissuedate" runat="server" Text="Cheque_Issue_date"></asp:Label><asp:TextBox ID="txtchequeissuedate" runat="server"></asp:TextBox>
    <br />
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
    <br />
    <asp:GridView ID="grdpayment" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
     <asp:TemplateField HeaderText="Account_no">
     <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('Account_no') %>"
                                    CommandName="Account_no" CommandArgument='<%#Bind("Account_no") %>'></asp:LinkButton>
     </ItemTemplate>
    </asp:TemplateField>
      <asp:BoundField DataField="cheque_no" HeaderText="Cheque_No" />
     <asp:BoundField DataField="stop_date" HeaderText="Stop_Date" />
     <asp:BoundField DataField="description" HeaderText="Description" />
      <asp:BoundField DataField="emp_id" HeaderText="Emp_id" />
     <asp:BoundField DataField="request_date" HeaderText="Request_Date" />
     <asp:BoundField DataField="amount" HeaderText="Amount" />
     <asp:BoundField DataField="status" HeaderText="Status" />
     <asp:BoundField DataField="cheque_issue_date" HeaderText="Cheque_Issue_Date" />
    </Columns>
</asp:GridView>
</asp:Content>




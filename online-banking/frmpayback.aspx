<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmpayback.aspx.cs" Inherits="frmpayback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblvouchar" runat="server" Text="Enter Vouchar Name"></asp:Label><asp:TextBox ID="txtvoucharname" runat="server"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtvoucharname" 
        ErrorMessage="Enter Proper name of vouchar" ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblpaybackdetail" runat="server" Text="Enter Detail"></asp:Label><asp:TextBox ID="txtpaybackdetail" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblpaybackamount" runat="server" Text="Enter Payback Amount"></asp:Label> <asp:TextBox ID="txtpaybackamount" runat="server" > </asp:TextBox>
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" 
        ValidationGroup="abc"  />
    <asp:Button ID="btnupdate" runat="server" Text="Update" onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnid" runat="server" />
    <br />
    <asp:GridView ID="grdpayback" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText="payback_id">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('payback_id') %>"
                                    CommandName="payback_id" CommandArgument='<%#Bind("payback_id") %>'></asp:LinkButton>
     </ItemTemplate>
    </asp:TemplateField>
     <asp:BoundField DataField="vouchar_name" HeaderText="Vouchar Name" />
      <asp:BoundField DataField="payback_detail" HeaderText="Payback Detail" />
      <asp:BoundField DataField="payback_amount" HeaderText="Payback Amount" />
    </Columns>
    </asp:GridView>
</asp:Content>


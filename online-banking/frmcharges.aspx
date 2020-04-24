<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmcharges.aspx.cs" Inherits="frmcharges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblchargestype" runat="server" Text="Enter Charges Type"></asp:Label> <asp:TextBox ID="txtchargestype" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtchargestype" ErrorMessage="Enter Charges type" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>

    <br />

    <br />

    <asp:Label ID="lblchargesamount" runat="server" Text="Enter Charges Amount"></asp:Label><asp:TextBox ID="txtchargesamount" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtchargesamount" ErrorMessage="Enter Charges Amount" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>

    <br />

    <br />

    <asp:Label ID="lbldescription" runat="server" Text="Enter Description"></asp:Label> <asp:TextBox ID="txtdescription" runat="server"></asp:TextBox>
    
    <br />
    
    <br />
    
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />

    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="Update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="Deleted" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnid" runat="server" />

    <br />
    <asp:GridView ID="grdcharges" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
     <asp:TemplateField HeaderText="charges_id">
      <ItemTemplate>
          <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('charges_id') %>"
                                    CommandName="charges_id" CommandArgument='<%#Bind("charges_id") %>'></asp:LinkButton>
      </ItemTemplate>
     </asp:TemplateField>
      <asp:BoundField DataField="charge_type" HeaderText="Charge type" />
      <asp:BoundField DataField="charge_amount" HeaderText="Charge Amount" />
      <asp:BoundField DataField="description" HeaderText="Description" />
    </Columns>
    </asp:GridView>


    <br />
    <br />


  </asp:Content>


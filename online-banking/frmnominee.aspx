<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmnominee.aspx.cs" Inherits="frmnominee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Label ID="lblnominee_f_name" runat="server" Text="Enter nominee first name"></asp:Label><asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtfname" ErrorMessage="plz  Enter fFrst Name" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblnominee_m_name" runat="server" Text="Enter nominee middle name"></asp:Label><asp:TextBox  ID="txtmname" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtmname" ErrorMessage=" plz Enter middle name" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblnominee_l_name" runat="server" Text="Enter nominee last name"></asp:Label><asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtlname" ErrorMessage="plz enter last name" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    
    <br />
    <br />
    <asp:Label ID="lblaccount_no" runat="server" Text="Enter account no"></asp:Label><asp:TextBox  ID="txtaccountno" runat="server"></asp:TextBox>
    &nbsp;<br />
    <br />
    <asp:Label ID="lbladdress1" runat="server" Text="Enter nominee address1"></asp:Label><asp:TextBox ID="txtaddress1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtaddress1" ErrorMessage="plz  Enter Address" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lbladdress2" runat="server" Text="Enter nominee address2"></asp:Label> <asp:TextBox   ID="txtaddress2" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbladdress3" runat="server" Text="Enter nominee address3"></asp:Label><asp:TextBox ID="txtaddress3" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblrelationshipwith" runat="server" Text="Enter relationship with nominee "></asp:Label><asp:TextBox ID="txtrelationshipwith" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblnomineedateofbirth" runat="server" Text="Enter nominee date of birth"></asp:Label><asp:TextBox ID="txtdateofbirth" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnid" runat="server" />
    <br />
    <br />
    <asp:GridView ID="grdnominee" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText="nominee_id">
     <ItemTemplate>
         <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('nominee_id') %>"
                                    CommandName="nominee_id" CommandArgument='<%#Bind("nominee_id") %>'></asp:LinkButton>
     </ItemTemplate>
      </asp:TemplateField>
       <asp:BoundField DataField="Nominee_f_name" HeaderText="Nominee_F_Name" />
      <asp:BoundField DataField="Nominee_m_Name" HeaderText="Nominee_M_Name" />
      <asp:BoundField DataField="Nominee_l_Name" HeaderText="Nominee_L_Name" />
      <asp:BoundField DataField="Account_no" HeaderText="Account_No" />
      <asp:BoundField DataField="Address1" HeaderText="Address1" />
      <asp:BoundField DataField="Address2" HeaderText="Address2" />
      <asp:BoundField DataField="Address3" HeaderText="Address3" />
      <asp:BoundField DataField="Relationshipwith" HeaderText="Relationshipwith" />
      <asp:BoundField DataField="Nominee_dateofbirth" HeaderText="Nominee_Dateofbirth" />
      
    </Columns>
    </asp:GridView>
</asp:Content>


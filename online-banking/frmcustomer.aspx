<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmcustomer.aspx.cs" Inherits="frmcustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblf_name" runat="server" Text="Enter First Name"></asp:Label><asp:TextBox
        ID="txtf_name" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtf_name" ErrorMessage="Enter First Name" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>

    <br />
    <br />

    <asp:Label ID="lblm_name" runat="server" Text="Enter Middle Name"></asp:Label><asp:TextBox
        ID="txtm_name" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtm_name" ErrorMessage="Plz Enter Middle Name" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lbll_name" runat="server" Text="Enter Last Name"></asp:Label><asp:TextBox
        ID="txtl_name" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtl_name" ErrorMessage="plz Enter Last Name" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblemail_id" runat="server" Text="Enter Email ID"></asp:Label><asp:TextBox ID="txtemail_id"
        runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtemail_id" ErrorMessage="Enter propper email_id" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="lbladdress1" runat="server" Text="Enter Address1"></asp:Label><asp:TextBox ID="txtaddress1"
        runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtaddress1" ErrorMessage="plz Enter Address" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lbladdress2" runat="server" Text="Enter Address2"></asp:Label><asp:TextBox ID="txtaddress2"
        runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbladdress3" runat="server" Text="Enter Address3"></asp:Label><asp:TextBox ID="txtaddress3"
        runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblpincode" runat="server" Text="Enter PINcode"></asp:Label><asp:TextBox ID="txtpincode"
        runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ControlToValidate="txtpincode" ErrorMessage="enter 6 digits" 
        ValidationExpression="\d{6}" ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="lblcity_id" runat="server" Text="Enter city_id"></asp:Label>
    <asp:DropDownList ID="drpcity_id" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lbladhar_no" runat="server" Text="Enter Adhar No"></asp:Label><asp:TextBox ID="txtadhar_no"
        runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtadhar_no" ErrorMessage="plz Enter Aadhar no" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
        ControlToValidate="txtadhar_no" ErrorMessage="12 Digits only" 
        ValidationExpression="\d{12}" ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="lblbranch_id" runat="server" Text="Enter branch id"></asp:Label>
    <asp:DropDownList ID="drpbranch_id" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblgender" runat="server" Text="choice Gender"></asp:Label>
    <asp:RadioButtonList ID="rblgender" runat="server">
        <asp:ListItem>F</asp:ListItem>
        <asp:ListItem>M</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:Label ID="lblbirth_date" runat="server" Text="Enter Birth Date"></asp:Label><asp:TextBox ID="txtbirth_date"
        runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtbirth_date" ErrorMessage="mm/dd/yyyy" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblcontact_no" runat="server" Text="Enter Phone Number"></asp:Label><asp:TextBox ID="txtcontact_no"
        runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
        ControlToValidate="txtcontact_no" ErrorMessage="plz enter 10 digit" 
        ValidationExpression="\d{10}" ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    &nbsp;<asp:Button ID="btnsave" runat="server" Text="Save" 
        onclick="btnsave_Click" ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="Update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnid" runat="server" />
    
    <br />
    <asp:GridView ID="grdcustomer" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText="cust_id">
    <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('cust_id') %>"
                                    CommandName="cust_id" CommandArgument='<%#Bind("cust_id") %>'></asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="f_name" HeaderText="First Name" />
    <asp:BoundField DataField="m_name" HeaderText="Middle Name" />
    <asp:BoundField DataField="l_name" HeaderText="last Name" />
    <asp:BoundField DataField="email_id" HeaderText="Email Id" />
    <asp:BoundField DataField="address1" HeaderText="Address1" />
    <asp:BoundField DataField="address2" HeaderText="Address2" />
    <asp:BoundField DataField="address3" HeaderText="Address3" />
    <asp:BoundField DataField="pincode" HeaderText="PIN code" />
    <asp:BoundField DataField="city_id" HeaderText="city_id" />
    <asp:BoundField DataField="adhar_no" HeaderText="Adhar No" />
    <asp:BoundField DataField="branch_id" HeaderText="branch_id" />
    <asp:BoundField DataField="gender" HeaderText="Gender" />
    <asp:BoundField DataField="birth_date" HeaderText="Birth Date" />
    <asp:BoundField DataField="contact_no" HeaderText="contact_no" />
    </Columns>
    </asp:GridView>
    <br />

    
    </asp:Content>


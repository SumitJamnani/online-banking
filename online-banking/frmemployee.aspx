<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmemployee.aspx.cs" Inherits="frmemployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblf_name" runat="server" Text="Enter First Name"></asp:Label><asp:TextBox ID="txtf_name" runat="server"></asp:TextBox>
    &nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtf_name" ErrorMessage="Enter First Name" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblm_name" runat="server" Text="Enter middle Name"></asp:Label><asp:TextBox ID="txtm_name" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtm_name" ErrorMessage="Enter Middle Name" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lbll_name" runat="server" Text="Enter last Name"></asp:Label><asp:TextBox ID="txtl_name" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtl_name" ErrorMessage="Enter Last Name" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblemail_id" runat="server" Text="Enter Email ID"></asp:Label><asp:TextBox ID="txtemail_id" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtemail_id" ErrorMessage="Enter Proper Emailid" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="lbladdress1" runat="server" Text="Enter Address1"></asp:Label><asp:TextBox ID="txtaddress1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtaddress1" ErrorMessage="Enter Address1" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lbladdress2" runat="server" Text="Enter Address2"></asp:Label><asp:TextBox ID="txtaddress2" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbladdress3" runat="server" Text="Enter Address3"></asp:Label><asp:TextBox ID="txtaddress3" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblpincode" runat="server" Text="Enter PINcode"></asp:Label><asp:TextBox ID="txtpincode" runat="server"></asp:TextBox>
    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
        runat="server" ControlToValidate="txtpincode" ErrorMessage="Enter only 6 digit" 
        ValidationExpression="\d{6}" ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="lblcity_id" runat="server" Text="Enter city_id"></asp:Label>
    <asp:DropDownList ID="drpcity_id" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblgender" runat="server" Text="choice Gender"></asp:Label>
    <asp:RadioButtonList ID="rblgender" runat="server">
        <asp:ListItem>F</asp:ListItem>
        <asp:ListItem>M</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <br />
    <asp:Label ID="lblbirth_date" runat="server" Text="Enter Birth Date"></asp:Label><asp:TextBox ID="txtbirth_date" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtbirth_date" ErrorMessage="mm/dd/yyyy" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblcontact_no" runat="server" Text="Enter Phone Number"></asp:Label><asp:TextBox ID="txtcontact_no" runat="server"></asp:TextBox>
    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
        runat="server" ControlToValidate="txtcontact_no" 
        ErrorMessage="Enter 10 digit number" ValidationExpression="\d{10}" 
        ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="lbladhar_no" runat="server" Text="Enter Adhar No"></asp:Label><asp:TextBox ID="txtadhar_no" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtadhar_no" ErrorMessage="Plz Enter Adhar No" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator4" 
        runat="server" ControlToValidate="txtadhar_no" ErrorMessage="12 Digit only" 
        ValidationExpression="\d{12}" ValidationGroup="abc"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="lbljoin_date" runat="server" Text="Enter Join Date"></asp:Label><asp:TextBox ID="txtjoin_date" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblbranch_id" runat="server" Text="Enter branch id"></asp:Label>
    <asp:DropDownList ID="drpbranch_id" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="Update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="Delete" onclick="btndel_Click" />
    <br />
    <asp:HiddenField ID="hdnid" runat="server" />
    <asp:GridView ID="grdemployee" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">

     <Columns>
    <asp:TemplateField HeaderText="emp_id">
    <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('emp_id') %>"
                                    CommandName="emp_id" CommandArgument='<%#Bind("emp_id") %>'></asp:LinkButton>
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
    <asp:BoundField DataField="gender" HeaderText="Gender" />
     <asp:BoundField DataField="birth_date" HeaderText="birth Date" />
     <asp:BoundField DataField="contact_no" HeaderText="contact_no" />
    <asp:BoundField DataField="adhar_no" HeaderText="Adhar No" />
    <asp:BoundField DataField="join_date" HeaderText="join_date" />
    <asp:BoundField DataField="branch_id" HeaderText="branch_id" />
    
   
    
    </Columns>
    </asp:GridView>

</asp:Content>


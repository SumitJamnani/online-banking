<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmcountry.aspx.cs" Inherits="frmcity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Label ID="lblcountry" runat="server" Text="Enter Country Name"></asp:Label><asp:TextBox  ID="txtcountryname" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtcountryname" ErrorMessage="plz enter Name" 
        ValidationGroup="abc"></asp:RequiredFieldValidator>
    <br />
    <br />
<asp:Button ID="btncancel"    runat="server" Text="Cancel"  OnClick="btncancel_Click" />
<asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" 
        ValidationGroup="abc" />
    <asp:Button ID="btnupdate" runat="server" Text="Update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="Deleted" onclick="btndel_Click" />
    <br />
    <br />
    <asp:GridView ID="grdcountry" runat="server"  OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
     <Columns>
           <asp:TemplateField HeaderText="country id">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('country_id') %>"
                                    CommandName="country_id" CommandArgument='<%#Bind("country_id") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                          
    <asp:BoundField DataField="country_name" HeaderText="country" />
             </Columns>           
    </asp:GridView>
    <asp:HiddenField ID="hdnid" runat="server" />


</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmcity.aspx.cs" Inherits="frmcity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:Label ID="lblcity" runat="server" Text="Enter City Name"></asp:Label><asp:TextBox ID="txtcityname" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtcityname" ErrorMessage="enter Name" 
        groupname="samename" ValidationGroup="abc"></asp:RequiredFieldValidator>
<br />    
    <br />
    <asp:Label ID="lblstate" runat="server" Text="Enter State Id"></asp:Label><asp:DropDownList ID="drpstate" runat="server"></asp:DropDownList>
<br />
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel"  />
    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_click" 
        ValidationGroup="abc"/>
    <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_click"/>
<asp:Button ID="btndel" runat="server" Text="Delete" OnClick="btndel_click"/>

    <br />
    <asp:HiddenField ID="hdnid" runat="server" />
    <asp:GridView ID="grdcity" runat="server"  OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%" >
           <Columns>
           <asp:TemplateField HeaderText="City Id">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('city_id') %>"
                                    CommandName="City_Id" CommandArgument='<%#Bind("city_id") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                          
    <asp:BoundField DataField="city_Name" HeaderText="City" />
             </Columns>           
    </asp:GridView>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmaccounttype.aspx.cs" Inherits="frmaccounttype" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblaccounttype" runat="server" Text="Enter Account Type "></asp:Label>
    <asp:CheckBoxList ID="cblaccounttype" runat="server">
        <asp:ListItem Value="S">Saving Account</asp:ListItem>
        <asp:ListItem Value="F">Fixed Account</asp:ListItem>
        <asp:ListItem Value="C">Current Account</asp:ListItem>
        <asp:ListItem Value="R">Recurring Account</asp:ListItem>
    </asp:CheckBoxList>
    <br />
    <asp:Button ID="btncancel" runat="server" Text="Cancle" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" />
    <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_click"/>
    <asp:Button ID="btndel" runat="server" Text="Delete" OnClick="btndel_click" />
    <br />
    <asp:HiddenField ID="hdnid" runat="server" />
    <br />
    <asp:GridView ID="grdaccounttype" runat="server" OnRowCommand="grdaccounttype_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
           <asp:TemplateField HeaderText="Account Type Id">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('account_type_id') %>"
                                    CommandName="Account_Type_Id" CommandArgument='<%#Bind("account_type_id") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                          
    <asp:BoundField DataField="Account_type_name" HeaderText="Account Type Name" />
             </Columns>
    </asp:GridView>
</asp:Content>


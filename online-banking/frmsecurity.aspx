<%@ Page Title="" Language="C#" MasterPageFile="~/onlinebankMasterPage.master" AutoEventWireup="true" CodeFile="frmsecurity.aspx.cs" Inherits="frmsecurity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblsecurity" runat="server" Text="Enter Security Question"></asp:Label><asp:TextBox ID="txtsecurityquestion" runat="server"></asp:TextBox>
    &nbsp;<br />
    <asp:Button ID="btncancel" runat="server" Text="Cancel" />
    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" />
    <asp:Button ID="btnupdate" runat="server" Text="Update" 
        onclick="btnupdate_Click" />
    <asp:Button ID="btndel" runat="server" Text="delete" onclick="btndel_Click" />
    <asp:HiddenField ID="hdnid" runat="server" />
    <br />
    <asp:GridView ID="grdsecurity" runat="server" OnRowCommand="grd2_RowCommand" AutoGenerateColumns="false"  Width="99%">
    <Columns>
    <asp:TemplateField HeaderText="s_q_id">
    <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server"  Text="<%#Bind('s_q_id') %>"
                                    CommandName="s_q_id" CommandArgument='<%#Bind("s_q_id") %>'></asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="s_q_que" HeaderText="security question" />
    </Columns>
    </asp:GridView>
</asp:Content>


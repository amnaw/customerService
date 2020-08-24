<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DbConnection.aspx.cs" Inherits="_154AmnaAlwzrah.MyNewFolder.DbConnection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /> this is the demonstration of data base connection ;)<br />
    <asp:GridView ID="gvCustomer" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="customerID" OnRowDataBound="gvCustomer_RowDataBound">
       
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <hr />
<br />
  
    <br />
&nbsp;
</asp:Content>

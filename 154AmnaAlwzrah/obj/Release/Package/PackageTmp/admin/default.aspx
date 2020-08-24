<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="_154AmnaAlwzrah.admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    ADMIN<br />
    <br />
    <asp:Label ID="lblMsg" runat="server" ForeColor="#339966"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show All Users" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnFinancers" runat="server" OnClick="btnFinancers_Click" Text="Show Financers" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
&nbsp;&nbsp;
    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:Button ID="btnFin" runat="server" OnClick="btnFin_Click" Text="Finance Role" />
&nbsp; <div class="row">
     <div class="col-md-2">
       <asp:GridView ID="gvUsers" runat="server" CssClass="table table-striped" Width="100px" BorderStyle="Solid">
    </asp:GridView>
         </div>
     <div class="col-md-1">
    <asp:GridView ID="gvFin" runat="server" CssClass="table table-striped" Width="100px" BorderStyle="Solid">
    </asp:GridView> </div></div>
    <br />
&nbsp;
</asp:Content>

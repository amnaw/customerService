<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_154AmnaAlwzrah.MyNewFolder.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-4 mx-auto"><!-- mx auto is what makes the div with size of 6 coumns in the center-->
                <div class="card">
                    <div class="card-body" wrap="True">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Log in</h3>
                                </center>
                            </div>
                         </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                         </div>
                         <div class="row">
                            <div class="col">
                          
                                <div class="form-group">
                                    <label for="txtUserName">User Name</label>
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="user name"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtPwd">Password</label>
                                    <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control" placeholder="password" TextMode="Password"></asp:TextBox>
                                </div>
                                <asp:CheckBox ID="cbRememberMe" runat="server" Text="Remember Me" /><br />
                                <asp:Label ID="txtInvalidCredentialsMessage" runat="server" Text="Please Fill User Name and Password Correctly" Visible="False" ForeColor="Red"></asp:Label>
                                <br />
                              
                                <br />
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                    <asp:Button ID="lgnUser" runat="server" Text="Login" CssClass="btn btn-secondary btn-block btn-lg" OnClick="lgnUser_Click"/>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="register" runat="server" Text="Register" CssClass="btn btn-secondary btn-block btn-lg" OnClick="register_Click"/>
                                </div>

                                <div class="form-group">
                     </div>
                         </div>
                     </div>
                 </div>
             </div>
        </div>
    </div>

</asp:Content>

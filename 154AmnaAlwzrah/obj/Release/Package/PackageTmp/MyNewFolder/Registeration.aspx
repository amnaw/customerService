<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registeration.aspx.cs" Inherits="_154AmnaAlwzrah.MyNewFolder.Registeration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto"><!-- mx auto is what makes the div with size of 6 coumns in the center-->
                <div class="card">
                    <div class="card-body" wrap="True">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Registeration</h3>
                                </center>
                            </div>
                         </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                         </div>
                         <div class="row">
                            <div class="col-md-6">
                          
                                <div class="form-group">
                                    <label for="txtUserName">User Name</label>
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="user name"></asp:TextBox>
                                </div>
                                 <div class="form-group">
                                    <label for="txtPwd">Password</label>
                                    <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control" placeholder="password" TextMode="Password"></asp:TextBox>
                                </div>
                               
                                <div class="form-group">
                                    <label for="usrPassCon">Confirm Password</label>
                                    <asp:TextBox ID="usrPassCon" runat="server" CssClass="form-control" placeholder="Confirm password" TextMode="Password"></asp:TextBox>
                                </div>
                                </div>
                             <div class="col-md-6">
                               
                                 <div class="form-group">
                                    <label for="txtEmail">E-mail</label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="E-mail"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtQuestion">Security Question</label>
                                    <asp:TextBox ID="txtQuestion" runat="server" CssClass="form-control" placeholder="Security Question"></asp:TextBox>
                                </div>
                                 <div class="form-group">
                                    <label for="txtAnswer">Security Answer</label>
                                    <asp:TextBox ID="txtAnswer" runat="server" CssClass="form-control" placeholder="Security Answer"></asp:TextBox>
                                </div>

                                
                                 </div>
                            
                               </div>
                              <asp:Label ID="lblResult" runat="server" Text=""></asp:Label><br />
                        <br />
                         <div class="row">
                            <div class="col-md-12">
                                 <div class="form-group">
                                    <asp:Button ID="registeruser" runat="server" Text="Register" CssClass="btn btn-secondary btn-block btn-lg" OnClick="registeruser_Click"/>
                                </div>
                                </div>
                                
                                
                                <br />
                               
                                
                            
                         </div>
                     </div>
                 </div>
             </div>
        </div>
    </div>
</asp:Content>

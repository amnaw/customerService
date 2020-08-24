<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="customerInfoForm.aspx.cs" Inherits="_154AmnaAlwzrah.MyNewFolder.customerInfoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> <br />

<script type="text/javascript">
  //JS client side validation //what made it work is the the "< followed by %"
               function formValidation() {
    console.log("func called yaay")


    if (document.getElementById('<%=txtFirstName2.ClientID%>').value == "" || document.getElementById('<%=txtLastName2.ClientID%>').value == "" || document.getElementById('<%=txtArabic2.ClientID%>').value == "" || document.getElementById('<%=txtBudget2.ClientID%>').value == "") {
        document.getElementById('<%=lblResult.ClientID%>').innerText = "Please Fill All The Fields, To Register New Customer, JS";
        console.log("false")
        return false;
    }
    else {
        document.getElementById('<%=lblResult.ClientID%>').innerText = "";
        return true;
    }

}


function deleteValidation() {
    if (document.getElementById('<%=txtCustomerId2.ClientID%>').value == "") {
        document.getElementById('<%=lblResult.ClientID%>').innerText = "Please Enter Customer ID To Delete its Information, JS";
        return false;

    }
    else {
        return true;
    }
}


function updateValidation() {
    if (document.getElementById('<%=txtFirstName2.ClientID%>').value == "" || document.getElementById('<%=txtLastName2.ClientID%>').value == "" || document.getElementById('<%=txtArabic2.ClientID%>').value == "" || document.getElementById('<%=txtBudget2.ClientID%>').value == "" || document.getElementById('<%=txtCustomerId2.ClientID%>').value == "") {
        document.getElementById('<%=lblResult.ClientID%>').innerText = "Please Fill All The Text Fields, Including Customer ID To Update its Information!, JS";
        return false;
    }
    else {
        return true;
    }
}


function selectValidation() {
    if (document.getElementById('<%=txtCustomerId2.ClientID%>').value == "") {
        document.getElementById('<%=lblResult.ClientID%>').innerText = "Please Enter Customer ID To Show its Information, JS";
        return false;

    }
    else {
        return true;
    }
}
    
            </script>
       
    <style type="text/css">
        .WordWrap {
            width: 100%;
            word-break: break-all;
        }
    </style>
  
    
    <h4>Register a New Customer</h4>
    <div class="row">
        <div class="col-md-4">
     <div class="form-group">
         <label ID="id" for="txtCustomerId2">Customer ID</label>
         <asp:TextBox ID="txtCustomerId2" runat="server" BorderColor="#E0E0E0" BorderStyle="Ridge" Height="23px" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
         <label for="txtFirstName2">First Name</label>
         <asp:TextBox ID="txtFirstName2" runat="server"  BorderColor="#E0E0E0" BorderStyle="Ridge" Height="23px" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
         <label for="txtLastName2">Last Name</label>
         <asp:TextBox ID="txtLastName2" runat="server" BorderColor="#E0E0E0" BorderStyle="Ridge" Height="23px" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
         <label for="txtArabic2">Full Arabic Name</label>
         <asp:TextBox ID="txtArabic2" runat="server" BorderColor="#E0E0E0" BorderStyle="Ridge" style="margin-top: 3" Height="23px" CssClass="form-control"></asp:TextBox>
    </div>
   
    <div class="form-group">
         <label for="txtBudget2">Budget</label>
         <asp:TextBox ID="txtBudget2" runat="server" BorderColor="#E0E0E0" BorderStyle="Ridge" Height="23px" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
         <label for="ddlCountry2">Country</label>
         <asp:DropDownList ID="ddlCountry2" runat="server" autopostback="false">
                </asp:DropDownList>
    </div>
    <div class="form-group">
         <label for="rList2">Active</label>
        <asp:RadioButtonList ID="rList2" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" style="margin-left: 25px" Width="149px">
                    <asp:ListItem CssClass="form-check-input" Text=" Yes" Value=1></asp:ListItem>
                    <asp:ListItem CssClass="form-check-input" Text=" No" Value=0></asp:ListItem>
                </asp:RadioButtonList>
    </div>
    <div class="form-group">
         <label for="cbHoppy2">Hobbies</label>
         <asp:CheckBoxList ID="cbHoppy2" runat="server" Height="16px" RepeatDirection="Horizontal" Width="385px" style="margin-left: 25px" >
                <asp:ListItem>Reading</asp:ListItem>
                <asp:ListItem>Swimming</asp:ListItem>
                <asp:ListItem>Baking</asp:ListItem>
                <asp:ListItem>Drawing</asp:ListItem>
            </asp:CheckBoxList>

    </div>
           
         
   <!-- <table class="nav-justified">
        
        <tr>
            <td class="modal-sm" style="width: 180px; text-align: right; height: 38px;">Customer ID</td>
            <td style="width: 911px; height: 38px;">
                <asp:TextBox ID="txtCustomerId" runat="server" BorderColor="#E0E0E0" BorderStyle="Ridge" Height="23px"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 180px; text-align: right; height: 38px;">First Name</td>
            <td style="width: 911px; height: 38px;">
                <asp:TextBox ID="txtFirstName" runat="server"  BorderColor="#E0E0E0" BorderStyle="Ridge" Height="23px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 180px; text-align: right; height: 38px;">Last Name</td>
            <td style="height: 38px; width: 911px;">
                <asp:TextBox ID="txtLastName" runat="server" BorderColor="#E0E0E0" BorderStyle="Ridge" Height="23px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 180px; text-align: right; height: 38px;">Full Arabic Name</td>
            <td style="height: 38px; width: 911px;">
                <asp:TextBox ID="txtArabic" runat="server" BorderColor="#E0E0E0" BorderStyle="Ridge" style="margin-top: 3" Height="23px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 180px; text-align: right; height: 38px;">Budget</td>
            <td style="height: 38px; width: 911px;">
                <asp:TextBox ID="txtBudget" runat="server" BorderColor="#E0E0E0" BorderStyle="Ridge" Height="23px"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td style="width: 180px; text-align: right; height: 38px;">Country</td>
            <td class="modal-sm" style="width: 911px; height: 38px;">
                <asp:DropDownList ID="ddlCountry" runat="server">
                </asp:DropDownList>
                </td>
            <td style="height: 38px">
                <asp:SqlDataSource ID="customerCountry" runat="server" ConnectionString="<%$ ConnectionStrings:customerDbConnectionString %>" SelectCommand="SELECT [country] FROM [country]"></asp:SqlDataSource>
            </td>
        </tr>
         <tr>
            <td style="width: 180px; text-align: right;">Active:</td>
            <td style="height: 39px; width: 911px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButtonList ID="rList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" style="margin-left: 25px" Width="149px">
                    <asp:ListItem CssClass="form-check-input" Text=" Yes" Value="1"></asp:ListItem>
                    <asp:ListItem CssClass="form-check-input" Text=" No" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 180px; text-align: right;">Hobbies</td>
            <td style="height: 39px; width: 911px;">
                <br />
            <asp:CheckBoxList ID="cbHoppy" runat="server" Height="16px" RepeatDirection="Horizontal" Width="385px" style="margin-left: 25px">
                <asp:ListItem>Reading</asp:ListItem>
                <asp:ListItem>Swimming</asp:ListItem>
                <asp:ListItem>Baking</asp:ListItem>
                <asp:ListItem>Drawing</asp:ListItem>
            </asp:CheckBoxList>
                &nbsp;</td>
        </tr>-->
       
          
             
                 <asp:Label ID="lblResult" runat="server" BackColor="#FFCCFF"></asp:Label>
                <br />
                 <asp:Button ID="btnRegister" runat="server" Text="Register" OnClientClick="return formValidation();" OnClick="btnRegister_Click" style="margin-left: 48" Width="84px" CssClass="btn btn-light"/>
                 <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" OnClientClick="return deleteValidation()" Text="Delete " Width="70px" CssClass="btn btn-light"/>
                 <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" OnClientClick="return updateValidation()" Text="Update" Width="76px" CssClass="btn btn-light"/>
                 <asp:Button ID="btnShowcustomer" runat="server" OnClick="btnShowCustomer_Click" OnClientClick="return selectValidation()" Text="Show Customer" Width="117px" CssClass="btn btn-light" />
                 <asp:Button ID="btnShow" runat="server" Text="Show all customers" OnClick="btnShow_Click" Width="159px" CssClass="btn btn-light" />
                 <asp:Button ID="clear" runat="server" Text="Clear Form" OnClick="btnClear_Click" Width="159px" CssClass="btn btn-light" />
                 <br /></div> <br />
                  
               
                 <div class="col-md-4" style="left: 0px; top: 0px">

                
                

                     <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" CssClass="table table-striped"  RowStyle-Wrap="True" CellPadding="7" CellSpacing="5">
                        
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="customer ID">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbCustomerId" Text='<%# Eval("customer ID") %>' runat="server" CommandArgument='<%# Eval("customer ID") %>' OnClick="populateForm_Click"></asp:LinkButton>
                                </ItemTemplate>

                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                           
                           
                              <asp:BoundField DataField="customer First Name" HeaderText="First Name" SortExpression="customerFirstName" />
                              <asp:BoundField DataField="customer Last Name" HeaderText="Last Name" SortExpression="customerLastName" />
                              <asp:BoundField DataField="customer Arabic Name" HeaderText="Arabic Name" SortExpression="customerArabicName" />
                              <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
                              <asp:CheckBoxField DataField="active" HeaderText="Active" SortExpression="active" />
                              <asp:BoundField DataField="registration Date" HeaderText="registration Date" SortExpression="registrationDate" />
                              <asp:BoundField DataField="budget" HeaderText="Budget" SortExpression="budget" />
                              <asp:BoundField DataField="hobbies" HeaderText="hobbies" SortExpression="hobby"/>
                             
                        
                        </Columns>
                         <HeaderStyle CssClass="&quot;table table-striped&quot;" />
                    </asp:GridView>
                     <!--itemstyle-wrap="true" ItemStyle-CssClass="WordWrap"--> 
                 </div>
           
                

       
 
        </div>
    
   
            
   
    
  
</asp:Content>

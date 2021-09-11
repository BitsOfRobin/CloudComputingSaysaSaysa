<%@ Page Title="" Language="C#" MasterPageFile="~/Cart.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Cart.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">  
        .TableCSS   
        {   
            border-style:none;   
            background-color:azure;   
            width: 850px;   
        }   
        .TableHeader   
        {   
            background-color:floralwhite;   
            color:#0066FF;   
            font-size:medium; 
            text-align:center;
        }   
        .TableData   
        {   
            background-color:cornsilk;  
            color:black;    
            font-size:medium;   
            font-weight:bold;   
            text-align:center;
            padding-top:0.5em;
        }  
         .auto-style1 {
             width: 247px;
         }
         .auto-style2 {
             width: 279px;
         }
         .auto-style3 {
             margin-left: 31px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <div class="row justify-content-center heading">
            <h1 class="orderHistoryHeader">Payment</h1>
        </div>
    </header>

    <!--display the purchase product for payment-->
    <div class="container">
        <asp:ListView ID="lvPaymentItem" runat="server" DataSourceID="SqlDataSource1">
            <LayoutTemplate>
                <table id="tblProdItem" runat="server" class="TableCSS">
                    <tr id="tr_head" runat="server" class="TableHeader">
                        <td id="Td1" runat="server">Product</td>
                        <td id="Td2" runat="server">Name</td>
                        <td id="Td3" runat="server">Quantity</td>
                        <td id="Td4" runat="server">Subtotal</td>
                    </tr>

                    <tr id="ItemPlaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr class="TableData">
                    <td>
                        <asp:ImageButton ID="BtnProdImg" runat="server" style="max-height: 50px;max-width: 50px"
                            ImageUrl='<%#"data:image/jpg;base64," + Convert.ToBase64String((byte[]) Eval("PicUrl"))%>' />
                    </td>

                    <td>
                        <asp:Label ID="lblProdName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    </td>

                    <td>   
                        <asp:Label  ID="lblProdQty" runat="server" Text='<%# Eval("quantity")%>'></asp:Label>   
                    </td>

                    <td>
                        RM <asp:Label ID="lblProdTotal" runat="server"><%#DataBinder.Eval(Container.DataItem, "subtotal", "{0:f}") %></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

        <br />
        <br />

        <table id="tblDelivery" class="TableCSS">
            <tr class="TableHeader">
                <td colspan="2">
                    <b>Delivery Information</b>
                </td>
            </tr>

            <!--insert receiver name-->
            <tr class="TableData">
                <td style="text-align:left; padding:0.5em" class="auto-style1">
                    <asp:Label ID="lblName" runat="server" Text="Receiver Name:" ></asp:Label>
                </td>

                <td style="text-align:left; padding:0.5em">
                    <asp:TextBox ID="txtName" runat="server" Width="90%" placeholder="Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Receiver Name is required"
                        ControlToValidate="txtName" ForeColor="Red" Font-Size="Small">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revName" runat="server" ErrorMessage="Name only accept alphabet"
                        ValidationExpression="^[a-zA-Z ]*$" ControlToValidate="txtName" ForeColor="Red" Font-Size="Small">*</asp:RegularExpressionValidator>
                </td>
            </tr>

            <!--insert contact number-->
            <tr class="TableData">
                <td style="text-align:left; padding:0.5em" class="auto-style1">
                    <asp:Label ID="lblContactNum" runat="server" Text="Contact Number : "></asp:Label>
                </td>

                <td style="text-align:left; padding:0.5em">
                    <asp:TextBox ID="txtContactNum" runat="server" Width="90%" placeholder="Eg 0123456789" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContactNum" runat="server" ErrorMessage="Contact Number is required"
                        ControlToValidate="txtContactNum" ForeColor="Red" Font-Size="Small">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revContactNum" runat="server" ErrorMessage="Invalid Contact Number Format"
                        ControlToValidate="txtContactNum" ForeColor="Red" ValidationExpression="^(\+?6?01)[0-46-9]-*[0-9]{7,8}$" Font-Size="Small">*</asp:RegularExpressionValidator>
                </td>
            </tr>

            <!--insert address-->
            <tr class="TableData">
                <td style="text-align:left; padding:0.5em" class="auto-style1">
                    <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
                </td>

                <td style="text-align:left; padding:0.5em">
                    <asp:TextBox ID="txtAddress" runat="server" Width="90%" placeholder="Address"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Address is required" 
                   ControlToValidate="txtAddress" ForeColor="Red" Font-Size="Small">*</asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>

        <br />

        <!--display total price-->
        <table class="TableCSS" id="tblTotalPrice">
            <tr>
                <td style="text-align: right; padding-right:2em">
                    <b>
                        <asp:Label ID="lblTotalPriceTxt" runat="server" Text="Total Product Price: RM"></asp:Label><asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                    </b>
                </td>
            </tr>
        </table>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebConnectionString %>"
            SelectCommand="SELECT C.id, C.product_id, C.quantity, C.user_id, P.id AS Expr1, P.Name, P.PicUrl, P.Price AS Expr2, U.user_name, U.id AS Expr3 FROM Cart AS C INNER JOIN Product AS P ON P.id = C.product_id INNER JOIN [User] AS U ON U.id = C.user_id WHERE (U.id = 1)"></asp:SqlDataSource>

        <br />

        <!--insert payment details-->
        <table id="tblPaymentInfo" class="TableCSS">
            <tr class="TableHeader">
                <td colspan="2">
                    <b>Payment Information</b>
                </td>
            </tr>

            <!--Card Type-->
            <tr class="TableData">
                <td class="auto-style2" style="text-align:left; padding:0.5em">
                    <asp:Label ID="lblCardType" runat="server" Text="Card Type :" ></asp:Label>
                </td>

                <td style="text-align:left; padding:0.5em">
                    <asp:RadioButtonList ID="rblCardType" runat="server" CssClass="auto-style3" Width="499px" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">Master Card</asp:ListItem>
                        <asp:ListItem>Visa Card</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>

            <!--cardNum-->
            <tr class="TableData">
                <td class="auto-style2" style="text-align:left; padding:0.5em">
                    <asp:Label ID="lblCardNum" runat="server" Text="Card Number :"></asp:Label>
                </td>

                <td style="text-align:left; padding:0.5em">
                    <asp:TextBox ID="txtCardNum" runat="server" Width="90%" MaxLength="16" placeholder="Card Number" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCardNum" runat="server" ErrorMessage="Card Number is required" 
                        ControlToValidate="txtCardNum" ForeColor="Red" Font-Size="Small">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCardNum" runat="server" ErrorMessage="Invalid Credit Card Number" 
                        ControlToValidate="txtCardNum" ForeColor="Red" Font-Size="Small">*</asp:RegularExpressionValidator>
                </td>
            </tr>

            <!--card expired year-->
            <tr class="TableData">
                <td class="auto-style2" style="text-align:left; padding:0.5em">
                    <asp:Label ID="lblCardExpYr" runat="server" Text="Card Expiration Year :" ></asp:Label> 
                </td>

                <td style="text-align:left; padding:0.5em">
                    <asp:TextBox ID="txtExpYr" runat="server" Width="90%" placeholder="Year" MaxLength="4" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvExpYr" runat="server" ErrorMessage="Expiration Year is required" 
                        ControlToValidate="txtExpYr" ForeColor="Red" Font-Size="Small">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revExpYr" runat="server"
                        ErrorMessage="Expiration Year only accept integer value"
                        ValidationExpression="^[1-9]\d*(\.\d+)?$" ControlToValidate="txtExpYr" ForeColor="Red" Font-Size="Small">*
                    </asp:RegularExpressionValidator>
                </td>
            </tr>

            <!--card expired month-->
            <tr class="TableData">
                <td class="auto-style2" style="text-align:left; padding:0.5em">
                    <asp:Label ID="lblCardExpMth" runat="server" Text="Card Expiration Month :" ></asp:Label>
                </td>

                <td style="text-align:left; padding:0.5em">
                    <asp:TextBox ID="txtExpMth" runat="server" placeholder="Month" MaxLength="2" Width="90%" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvExpMth" runat="server" ErrorMessage="Expiration Month is required" 
                        ControlToValidate="txtExpMth" ForeColor="Red" Font-Size="Small">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvExpMth" runat="server" ErrorMessage="Expiration Month should within 1-12" 
                        MinimumValue="1" MaximumValue="12" Type="Integer" ControlToValidate="txtExpMth" ForeColor="Red" Font-Size="Small">*</asp:RangeValidator>
                </td>
            </tr>

            <!--Security code-->
            <tr class="TableData">
                <td class="auto-style2" style="text-align:left; padding:0.5em">
                    <asp:Label ID="lblSecurityCode" runat="server" Text="Security Code :" ></asp:Label>
                </td>

                <td style="text-align:left; padding:0.5em">
                    <asp:TextBox ID="txtSecurityCode" runat="server" Width="90%" placeholder="Eg: 1234" MaxLength="4"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSecurityCode" runat="server" ErrorMessage="Security Code is required"
                        ControlToValidate="txtSecurityCode" ForeColor="Red" Font-Size="Small" >*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revSecurityCode" runat="server"
                        ErrorMessage="Security Code only accept integer value"
                        ValidationExpression="^[1-9]\d*(\.\d+)?$" ControlToValidate="txtSecurityCode" ForeColor="Red" Font-Size="Small">*
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>

        <br />

        <asp:CheckBox ID="chkPolicy" runat="server" Text=" I have read and understand the privacy and policy" Checked="true" />

        <br />
        <br />

        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnConfirm" runat="server" Text="Confirm Purchase" CausesValidation="true" OnClick="btnConfirm_Click" />

        <br />

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="The following problems have been encountered" ShowSummary="true" ShowMessageBox="false" ShowValidationErrors="true" ForeColor="Red"/>

        <br />
    </div>

</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Payment.Payment" %>
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
            background-color:lightgoldenrodyellow;   
            color:darkblue;   
            font-size:large; 
            text-align:center;
        }   
        .TableData   
        {   
            background-color:lavender;  
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

    <table id="tblDelivery" class="TableCSS">
        <tr class="TableHeader">
            <td colspan="2">
                <b>Purchase Information</b>
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
    
    <br />
    <asp:CheckBox ID="chkPolicy" runat="server" Text=" I have read and understand the privacy and policy" Checked="true" />

    <br />
    <br />

    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" style="background-color:red;color:white"/>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnConfirm" runat="server" Text="Confirm Purchase" CausesValidation="true" OnClick="btnConfirm_Click" style="background-color:limegreen;color:white"/>

    <br />
</asp:Content>

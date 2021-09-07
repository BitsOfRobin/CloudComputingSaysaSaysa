<%@ Page Title="" Language="C#" MasterPageFile="masterPage.Master" AutoEventWireup="true" CodeBehind="productDisplay.aspx.cs" Inherits="asn.testing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <link href="../css/lzlCss.css" rel="stylesheet" />
    <script>
        function ShowPreview(input) {
            if (input.files && input.files[0]) {
                var ImageDir = new FileReader();
                ImageDir.onload = function (e) {
                    //Jquery
                    //$('#impPrev').attr('src', e.target.result);  
                    var image = document.getElementById("main_imgDisplay");
                    image.src = e.target.result;
                }
                ImageDir.readAsDataURL(input.files[0]);
            }
        } 
    </script>
    <div id="lzldiv">
        <asp:Table ID="Tablez" runat="server" Height="781px" float="right" ForeColor="Black" Font-Size="Larger">
            <asp:TableRow Width="500px">
                <asp:TableCell HorizontalAlign="Right" ColumnSpan="3" Height="300px" RowSpan="15" Width="500px" VerticalAlign="Middle">
                    <asp:Image ID="imgDisplay" runat="server" Width="400px" Height="386px"  />
                    <asp:FileUpload ID="ImgUpload" runat="server" onchange="ShowPreview(this)" Visible="false"/>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="400px">
                    <asp:Label ID="Label1" runat="server" Text="Product Name:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="400px">
                    <asp:Label ID="lblzlName" runat="server" Text="" CssClass="labelzl"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtzlName" runat="server" Visible="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter valid product name" ControlToValidate="txtzlName" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="200px">
                    <asp:Label ID="Label2" runat="server" Text="Price(RM):"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="400px">
                    <asp:Label ID="lblzlPrice" runat="server" Text="" CssClass="labelzl"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtzlPrice" runat="server" Visible="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter valid price" ControlToValidate="txtzlPrice" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>

                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                    
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Maximum price is 10 million , minimum is RM1" ControlToValidate="txtzlPrice" CssClass="error" Display="Dynamic" MaximumValue="10000000" MinimumValue="10" Type="Currency"></asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="200px">
                    <asp:Label ID="Label8" runat="server" Text="Product ID:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="400px">
                    <asp:Label ID="lblzlProId" runat="server" Text="" CssClass="labelzl"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="200px">
                    <asp:Label ID="Label4" runat="server" Text="Description:"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left" Width="400px" Height="120px">
                    <asp:Label ID="lblzlDes" runat="server"   Text="" CssClass="labelzl"></asp:Label>
                </asp:TableCell>
                <asp:TableCell >
                    <asp:TextBox ID="txtzlDes" TextMode="MultiLine" runat="server" Visible="false" Height="80px" width="400px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please enter valid description" ControlToValidate="txtzlDes" CssClass="error" Display="Dynamic" EnableTheming="False"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="200px">
                    <asp:Label ID="Label6" runat="server" Text="Date(mm/dd/yyyy):"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="400px">
                    <asp:Label ID="lblzlDate" runat="server" Text="" CssClass="labelzl"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="200px">
                    <asp:Label ID="lbl5" runat="server" Text="Quantity:" CssClass="labelzl"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left" Width="400px" >
                    <asp:Label ID="lblzlQty" runat="server" Text=""></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtzlQty" runat="server" Visible="false" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please enter valid quantity" ControlToValidate="txtzlQty" CssClass="error" Display="Dynamic" EnableTheming="False"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                    <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Maximum quantity is 100" ControlToValidate="txtzlQty" CssClass="error" Display="Dynamic" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="200px">
                    
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass="button" Visible="true"/>

                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="button" Visible="false" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow >
                <asp:TableCell HorizontalAlign="Right" >
                    
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="button" Visible="true"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>


        <asp:Table ID="Tablep" runat="server" Height="481px" Width="1668px" ForeColor="Black" Font-Size="Larger">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" Width="500px" ColumnSpan="2">
                    <asp:Label ID="lbl6" runat="server" Text="15 Days of Appreciation period" CssClass="labelzl1"></asp:Label>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left" Width="800px">
                    <asp:Label ID="lbl7" runat="server" Text=" 100% Pure & Original Artifact " CssClass="labelzl1"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell BackColor="Black" Height="2px" ColumnSpan="5">
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="300px" HorizontalAlign="Center" VerticalAlign="Top">
                    <asp:Image ID="Imagez6" runat="server" ImageUrl="~/assets/bck.jpg" Width="300px" Height="386px" />
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" Height="300px" Width="400px" VerticalAlign="Top">
                    <asp:Image ID="Imagez2" runat="server" ImageUrl="~/assets/art1.jpg" Width="400px" Height="386px" />
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" Height="300px" Width="400px" VerticalAlign="Top">
                    <asp:Image ID="Imagez3" runat="server" ImageUrl="~/assets/art1.jpg" Width="400px" Height="386px" />
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" Height="300px" Width="400px" VerticalAlign="Top">
                    <asp:Image ID="Imagez4" runat="server" ImageUrl="~/assets/art1.jpg" Width="400px" Height="386px" />
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" Height="300px" Width="400px" VerticalAlign="Top">
                    <asp:Image ID="Imagez5" runat="server" ImageUrl="~/assets/art1.jpg" Width="400px" Height="386px" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        
<%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter valid product name" ControlToValidate="txtzlName" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter valid price" ControlToValidate="txtzlPrice" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>


        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter valid description" ControlToValidate="txtzlDes" CssClass="error" Display="Dynamic" EnableTheming="False"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter valid quantity" ControlToValidate="txtzlQty" CssClass="error" Display="Dynamic" EnableTheming="False"></asp:RequiredFieldValidator>

        

        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Maximum price is 10 million , minimum is RM1" ControlToValidate="txtzlPrice" CssClass="error" Display="Dynamic" MaximumValue="10000000" MinimumValue="10" Type="Currency"></asp:RangeValidator>--%>

    </div>
</asp:Content>

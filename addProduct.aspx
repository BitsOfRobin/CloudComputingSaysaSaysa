<%@ Page Title="" Language="C#" MasterPageFile="masterPage.Master" AutoEventWireup="true" CodeBehind="addProduct.aspx.cs" Inherits="asn.html.addProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <link href="../css/lzlCss.css" rel="stylesheet" />


    <div id="lzlAddDiv">
        <asp:Table ID="TablezAdd" runat="server" Height="781px" float="right" ForeColor="Black" Font-Size="Larger">
            <asp:TableRow Width="500px">
                <asp:TableCell HorizontalAlign="Center" ColumnSpan="3" Height="300px" RowSpan="16" Width="500px" VerticalAlign="Middle">
                    <asp:Image ID="imgDisplayAdd" runat="server" Width="400px" Height="386px" />
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="400px">
                    <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtzlNameAdd" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter valid product name" ControlToValidate="txtzlNameAdd" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="200px">
                    <asp:Label ID="Label2" runat="server" Text="Price(RM):"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtzlPriceAdd" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please enter valid price" ControlToValidate="txtzlPriceAdd" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                     <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Maximum price is 10 million , minimum is RM10" ControlToValidate="txtzlPriceAdd" CssClass="error" Display="Dynamic" MaximumValue="10000000" MinimumValue="10" Type="Currency"></asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
            <%--    <asp:TableRow width="1400px" >
             <asp:TableCell HorizontalAlign="Right" width="200px" >
                 <asp:Label ID="Label8" runat="server" Text="Product ID:"></asp:Label>
             </asp:TableCell>
             <asp:TableCell >
                 <asp:TextBox ID="txtProIdAdd" runat="server"></asp:TextBox>
             </asp:TableCell>
        </asp:TableRow>--%>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="200px">
                    <asp:Label ID="Label4" runat="server" Text="Description:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtzlDesAdd" TextMode="MultiLine" runat="server" width="400px" Height="120px" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

             <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please enter valid description" ControlToValidate="txtzlDesAdd" CssClass="error" Display="Dynamic" EnableTheming="False"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <%--<asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="200px">
                    <asp:Label ID="Label5" runat="server" Text="The masterpiece of artist:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblArNameDb" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>--%>
            <%--  <asp:TableRow  width="1400px" >
             <asp:TableCell HorizontalAlign="Right" width="200px">
                 <asp:Label ID="Label7" runat="server" Text=" artist ID:"></asp:Label>
             </asp:TableCell>
             <asp:TableCell>
                 <asp:TextBox ID="txtArIdAdd" runat="server"></asp:TextBox>
             </asp:TableCell>
        </asp:TableRow>--%>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="200px">
                    <asp:Label ID="Label6" runat="server" Text="Date(mm/dd/yyyy):"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblzlDateAdd" runat="server" ></asp:Label>
                  <%--  <asp:TextBox ID="txtzlDateAdd" runat="server"></asp:TextBox>--%>
                </asp:TableCell>
            </asp:TableRow>
            <%-- <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please enter valid Date" ControlToValidate="txtzlDateAdd" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
               <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                     <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Year should not exceed 2021" ControlToValidate="txtzlDateAdd" CssClass="error" Display="Dynamic" MaximumValue="12/31/2021" MinimumValue="1/1/0001" Type="Date"></asp:RangeValidator>

                </asp:TableCell>
            </asp:TableRow>--%>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="200px">
                    <asp:Label ID="lbl5" runat="server" Text="Quantity:" CssClass="labelzl"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtzlQtyAdd" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please enter valid quantity" ControlToValidate="txtzlQtyAdd" CssClass="error" Display="Dynamic" EnableTheming="False"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>

                <asp:TableCell>
                           <asp:RangeValidator ID="RangeValidator6" runat="server" ErrorMessage="Maximum quantity is 100" ControlToValidate="txtzlQtyAdd" CssClass="error" Display="Dynamic" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="200px">
                    <asp:Label ID="Label3" runat="server" Text="Image Url"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:FileUpload ID="ImgUploadzl" runat="server" onchange="ShowPreview(this)"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Width="1400px">
                <asp:TableCell HorizontalAlign="Right" Width="200px">
                </asp:TableCell>
                <asp:TableCell>
                   <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" />


                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>




       <%-- <asp:Table ID="TablepAdd" runat="server" Height="481px" Width="1668px" ForeColor="Black" Font-Size="Larger">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" Width="500px" ColumnSpan="3">
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
        </asp:Table>--%>

  

    
        


    </div>
</asp:Content>

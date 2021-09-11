<%@ Page Title="" Language="C#" MasterPageFile="~/Cart.Master" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="Cart.Receipt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .heading {
            margin-top: 40px;
            margin-bottom: 30px;
            color: black;
            padding-left: 17rem;
        }

        table#ContentPlaceHolder1_delieryFeeDetailView {
            margin-left:610px;
        }

        table#ContentPlaceHolder1_GridView1 {
            text-align: center;
        }

        span#ContentPlaceHolder1_lblTxtTotal {
            margin-left: 613px;
        }

        span#ContentPlaceHolder1_lblTotal {
            margin-left: 220px;
            margin-block-start: 220px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <div class="row justify-content-center heading">
            <h1 class="clientReceiptHeader">Purchase Details</h1>
            <asp:DetailsView ID="TransactionIDDetailView" runat="server" AutoGenerateRows="false" DataKeyNames="id" DataSourceID="SqlDataSource1" Height="50px" Width="565px" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                <EditRowStyle BackColor="#CC3333" Font-Bold="true" ForeColor="White"/>
                <Fields>
                    <asp:TemplateField HeaderText="Transaction ID">
                        <ItemTemplate>
                            <asp:Label ID="id" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Payment Date">
                        <ItemTemplate>
                            <asp:Label ID="date_order" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "date_order", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="payment_method" HeaderText="Payment Method" SortExpression="payment_method" />
                </Fields>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            </asp:DetailsView>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Horizontal">
                <Columns>
                    <asp:TemplateField HeaderText="No. ">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Product Name">
                        <ItemStyle Width="550" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Image ID="prodImage" runat="server" width="200px" Height="200px" ImageUrl='<%#"data:image/jpg;base64," + Convert.ToBase64String((byte[]) Eval("image")) %>'/>
                                <br />
                                <asp:Label ID="prodName" runat="server" Text='<%# Eval("name") %>' style="font-weight:bold"></asp:Label> 
                            </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Quantity">
                         <ItemStyle Width="200" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="quantity" runat="server" Text='<%# Eval("quantity") %>'></asp:Label> 
                            </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Subtotal (RM)">
                        <ItemStyle Width="200" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="subtotal" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "subtotal", "{0:f}") %>'></asp:Label> 
                            </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>

            <asp:Label ID="lblTxtTotal" runat="server" Text="Total: "></asp:Label>

            <asp:Label ID="lblTotal" runat="server"></asp:Label>

            <br />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back To HomePage"/>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebConnectionString %>" 
                    SelectCommand="SELECT TOP 1 id, date_order, payment_method, user_id FROM [Transaction] as t WHERE user_id = @UserId ORDER BY id DESC">
                    <SelectParameters>
                        <asp:SessionParameter Name="UserId" SessionField="UserId"/>
                    </SelectParameters>
            </asp:SqlDataSource>
            
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:WebConnectionString %>" 
                    SelectCommand="SELECT O.quantity as quantity, P.Name as name, P.PicUrl as image, (P.Price * O.quantity) as subtotal FROM [Order] AS O INNER JOIN Prod AS P ON O.product_id = P.id WHERE (O.transaction_id = @id)">
            </asp:SqlDataSource>

            
        </div>
    </header>
</asp:Content>

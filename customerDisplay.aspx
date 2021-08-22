<%@ Page Title="" Language="C#" MasterPageFile="masterPage.Master" AutoEventWireup="true" CodeBehind="customerDisplay.aspx.cs" Inherits="asn.customerDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">





        <link href="../css/lzlCss.css" rel="stylesheet" />
     

<div id="lzldivCust" >

    

       <asp:Table ID="TablezCust" runat="server" Height="781px" Width="1668px" float="right" ForeColor="Black" Font-Size="Larger">

      <asp:TableRow   width="500px" >
        <asp:TableCell HorizontalAlign="Center" columnspan="3" Height="300px" RowSpan="10" Width="500px" VerticalAlign="Middle">
             
         
            <asp:Image ID="imgDisplay"  runat="server" Width="400px" Height="386px"  />
          
        </asp:TableCell>


             <asp:TableCell columnspan="3" >
       
             </asp:TableCell>


             <asp:TableCell columnspan="3">
                 
             </asp:TableCell>

         </asp:TableRow>

                
      <asp:TableRow  width="1400px" >


             <asp:TableCell HorizontalAlign="Right" width="400px" >
                 <asp:Label ID="Label1" runat="server" Text="Product Name:"></asp:Label>

                
     
              

             </asp:TableCell>


             <asp:TableCell >
                  <asp:Label ID="lblzlName" runat="server" Text="" CssClass="labelzl"></asp:Label>
                

             </asp:TableCell>

           

        </asp:TableRow>


        <asp:TableRow width="1400px" >



             <asp:TableCell HorizontalAlign="Right" width="200px" >

                 <asp:Label ID="Label2" runat="server" Text="Price(RM):"></asp:Label>
                  
                 
                
                 
             </asp:TableCell>


             <asp:TableCell >
                <asp:Label ID="lblzlPrice" runat="server" Text="" CssClass="labelzl"></asp:Label>

                

             </asp:TableCell>

           

        </asp:TableRow>

            <asp:TableRow width="1400px" >



             <asp:TableCell HorizontalAlign="Right" width="200px" >

                 <asp:Label ID="Label8" runat="server" Text="Product ID:"></asp:Label>
                  
                 
             </asp:TableCell>


             <asp:TableCell >
                <asp:Label ID="lblzlProId" runat="server" Text="" CssClass="labelzl"></asp:Label>

                 
             </asp:TableCell>
        </asp:TableRow>


        <asp:TableRow  width="1400px" >

             <asp:TableCell HorizontalAlign="Right" width="200px">


                 <asp:Label ID="Label4" runat="server" Text="Description:"></asp:Label>
                
                 
                  
                
             </asp:TableCell>


             <asp:TableCell HorizontalAlign="Left">
                <asp:Label ID="lblzlDes" runat="server" Text="" CssClass="labelzl"></asp:Label>

                 

             </asp:TableCell>

           


        </asp:TableRow>

          <asp:TableRow  width="1400px" >


             <asp:TableCell HorizontalAlign="Right" width="200px">
                 <asp:Label ID="Label5" runat="server" Text="The masterpiece of artist:"></asp:Label>

              
                 
             </asp:TableCell>


             <asp:TableCell>
                <asp:Label ID="lblzlArtist" runat="server" Text="" CssClass="labelzl"></asp:Label>

                

             </asp:TableCell>

        </asp:TableRow>


           
         <asp:TableRow  width="1400px" >


             <asp:TableCell HorizontalAlign="Right" width="200px">
                 <asp:Label ID="Label7" runat="server" Text=" artist ID:"></asp:Label>

              
                 
             </asp:TableCell>


             <asp:TableCell>
                <asp:Label ID="lblzlArId" runat="server" Text="" CssClass="labelzl"></asp:Label>

                

             </asp:TableCell>

        </asp:TableRow>


               <asp:TableRow  width="1400px" >

             <asp:TableCell HorizontalAlign="Right" width="200px">

                 <asp:Label ID="Label6" runat="server" Text="Date(mm/dd/yyyy):"></asp:Label>
                  
                    

                

             </asp:TableCell>


             <asp:TableCell >
                <asp:Label ID="lblzlDate" runat="server" Text="" CssClass="labelzl"></asp:Label>


                 
             </asp:TableCell>


           

        </asp:TableRow>
         
        <asp:TableRow  width="1400px">


             <asp:TableCell HorizontalAlign="Right" width="200px" >
                
             

                  <asp:Label ID="lbl5" runat="server" Text="Quantity Available:" CssClass="labelzl"></asp:Label>
                
                
             </asp:TableCell>


             <asp:TableCell HorizontalAlign="Left" width="800px">
                 <asp:Label ID="lblzlQty" runat="server" Text=""></asp:Label>

                 
             </asp:TableCell>

          


        </asp:TableRow>

        <asp:TableRow  width="1400px" >


     
                         <%--<asp:TableCell HorizontalAlign="Right" width="200px">
             <asp:Button ID="btnWishList" runat="server" Text="Add to WishList" BackColor="Black" ForeColor="White" CssClass="button" OnCommand="btnWishList_Command" CommandName="WishList" Visible="true"/>
             </asp:TableCell>--%>


             <asp:TableCell >
                
                  <%--<asp:TableCell HorizontalAlign="Right" width="200px">
             <asp:Button ID="btncart" runat="server" Text="Add to Cart" BackColor="Black" ForeColor="White" CssClass="button" OnCommand="btnWishList_Command" CommandName="Cart" Visible="true"  />
             </asp:TableCell>--%>


            <asp:DropDownList ID="ddlStdQty" Visible="true" runat="server" ></asp:DropDownList>

             </asp:TableCell>


        </asp:TableRow>



        



        




    </asp:Table>


     
    <asp:Table ID="Tablep" runat="server" Height="481px" Width="1668px" ForeColor="Black" Font-Size="Larger" >



        <asp:TableRow   >


             <asp:TableCell HorizontalAlign="Center" width="500px" columnspan="3">

                  
          
             <asp:Label ID="lbl6" runat="server" Text="15 Days of Appreciation period" CssClass="labelzl1"></asp:Label>

             </asp:TableCell>
             


             <asp:TableCell  HorizontalAlign="Left" width="800px" >
                  <asp:Label ID="lbl7" runat="server" Text=" 100% Pure & Original Artifact " CssClass="labelzl1"></asp:Label>
               
             </asp:TableCell>
          

        </asp:TableRow>



        <asp:TableRow >
            <asp:TableCell BackColor="Black" Height="2px" ColumnSpan="5">




            </asp:TableCell>




        </asp:TableRow>

        <asp:TableRow>

            <asp:TableCell Width="300px" HorizontalAlign="Center" VerticalAlign="Top" >

                <asp:HyperLink ID="hykImage1" runat="server">
            <asp:Image ID="Imagez1" runat="server"  Width="300px" Height="386px"/>
           </asp:HyperLink> 
            </asp:TableCell>
            
            <asp:TableCell HorizontalAlign="Center"  Height="300px"  Width="400px" VerticalAlign="Top">
             
                <asp:HyperLink ID="hykImage2" runat="server">
            <asp:Image ID="Imagez2" runat="server"  Width="400px" Height="386px" />
                </asp:HyperLink> 
        </asp:TableCell>

           

             <asp:TableCell HorizontalAlign="Center"  Height="300px"  Width="400px" VerticalAlign="Top">
             
                 <asp:HyperLink ID="hykImage3" runat="server">
            <asp:Image ID="Imagez3" runat="server"  Width="400px" Height="386px" />
                 </asp:HyperLink> 


            </asp:TableCell>



            <asp:TableCell HorizontalAlign="Center"  Height="300px"  Width="400px" VerticalAlign="Top">
             
                <asp:HyperLink ID="hykImage4" runat="server"> 
            <asp:Image ID="Imagez4" runat="server"  Width="400px" Height="386px" />
                </asp:HyperLink>

            </asp:TableCell>



            <asp:TableCell HorizontalAlign="Center"  Height="300px"  Width="400px" VerticalAlign="Top">
             


                <asp:HyperLink ID="hykImage5" runat="server">      <asp:Image ID="Imagez5" runat="server"  Width="400px" Height="386px" />
                </asp:HyperLink> 
            </asp:TableCell>
        </asp:TableRow>
            
    

       </asp:Table>
                 
    
     
        




</div>



















</asp:Content>

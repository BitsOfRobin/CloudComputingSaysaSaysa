<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="displayAllShopProduct.aspx.cs" Inherits="Cloud.displayAllShopProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #container {
            margin-top:30px;
            width: 250px;
            position: relative; 
            display: inline-block;
            margin-left: 1.5%;
            margin-right: 1.5%;
            margin-bottom:10px;
            background-color: white;
            border-radius: 5px;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
            transition: 0.3s;
            width: 250px;
            border-radius: 5px;
        }
         #container:hover {
           box-shadow: 0 18px 16px 0 rgba(0,0,0,0.2);
        }

        .card{
            background-color: white;
            border-radius: 5px;
            margin-bottom: 5%;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
            transition: 0.3s;
            width: 1135px;
            border-radius: 5px;
        }
/*         .card:hover {
           box-shadow: 0 18px 16px 0 rgba(0,0,0,0.2);
        }*/
        .uploadbutton{
            margin-left:10%; 
            margin-right:10%; 
            height:35px; 
            width:115px;
            background: black;
            color:white;
            
        }
        .uploadbutton:hover{
            opacity:0.7;
        }

                
        #container a:hover{
            color: #2BB3C0 !important;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div style="margin-left: 15px; background-color:white; ">
       
        
        
        
    </div>

    <div>
       <asp:HiddenField ID="hfSelectedRecord" runat="server" />
    <asp:Repeater ID="Repeater1" runat="server"  OnItemCommand="Repeater1_ItemCommand" >
    <ItemTemplate> 
    <div id="container">
    <tr>
        
        <td>
            
         <%--<asp:ImageButton ID="ImageButton1" style="margin:15px; height: 220px; width: 220px;border:none;outline:none;" CommandName="productdetails" runat="server" CommandArgument='<%#Eval("ProductId") %>'/>--%>             
        <img src="showImage.aspx?ProductId=<%# Eval("ProductId") %>" style="margin:15px; height: 220px; width: 220px;border:none;outline:none;"/>
        </td>
    </tr>
      
    <table style="background-color:white; width:250px;" >  
    <tr>  
        <td >  
            <%--<asp:HyperLink runat="server" ID="HyperLink1"  Text='<%#Eval("Name").ToString().Length>15? Eval("Name").ToString().Substring(0,15) + "...": Eval("Name")  %>' style="font-family:Calibri;font-size:28px;color:#666666;margin-left:10px;font-weight:bold;text-transform:capitalize;text-decoration:none;" NavigateUrl='<%# Eval("ProductId","testing.aspx?ProductId={0}") %>'/>--%>
            <asp:Label ID="HyperLink1" runat="server" Text='<%#Eval("Name").ToString().Length>15? Eval("Name").ToString().Substring(0,15) + "...": Eval("Name")  %>' style="font-family:Calibri;font-size:28px;color:#666666;margin-left:10px;font-weight:bold;text-transform:capitalize;text-decoration:none;"/>
        <%--<asp:Label ID="Labelname" runat="server" Text='<%#Eval("name") %>' Font-Bold="true" Font-Names="Calibri" Font-Size="24px" ForeColor="#6F707A" Style=" margin-left:12px;"/>--%>  
        </td> 
    </tr>
    </table>

    

    <table style="background-color:white; width:250px" >  
    <tr>  
        <td >  
            <div style="font-family:Calibri;font-size:20px;color:#6F707A;margin-left:10px">
                 RM<asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Price") %>' Font-Names="Calibri" Font-Size="20px" ForeColor="#6F707A" style=" margin-left:10px"/>
            </div>
        </td>  
    </tr>  
    </table> 
     


    <table style="background-color:white; width:250px">
    <tr>
        <td >
            <asp:Label ID="Label3" runat="server" Text="Stock left: " Font-Names="Calibri" Font-Size="20px" ForeColor="#6F707A" Style=" margin-left:12px;"></asp:Label>
        
        <asp:Label ID="lblDate" runat="server"  Font-Names="Calibri" Text='<%#Eval("AvailableQty") %>' Font-Size="20px" ForeColor="#6F707A" Style=" margin-left:12px;"/>
        </td>
    </tr>
    </table>
    <div style="margin-left:120px">
        <asp:Button ID="deleteBtn" runat="server" Text="Delete" Font-Bold="true" Font-Size="10" Font-Names="helvetica" Width="55" Height="30" BackColor="white" ForeColor="#6F707A" OnClick="deleteBtn_Click"/>
        <asp:Button ID="editBtn" runat="server" Text="Edit" Font-Bold="true" Font-Size="10" Font-Names="helvetica" Width="55" Height="30" BackColor="white" ForeColor="#6F707A" OnClick="editBtn_Click"/>
    </div>
        

    
    </div>
      
     
    </ItemTemplate>  
   
    </asp:Repeater> 
        

    </div>
    <div style="text-align:center">
        <asp:Button ID="Button1" runat="server" Text="Add Product" Font-Bold="true" Font-Size="15" Font-Names="helvetica" Width="180" Height="45" BackColor="black" ForeColor="white" OnClick="Button1_Click"/>
    </div>
    
</asp:Content>

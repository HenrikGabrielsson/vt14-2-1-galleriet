<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gallery.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/style/style.css" rel="stylesheet" />
    <title>Bildgalleri</title>
</head>
<body>
   
    <h1>Bildgalleri</h1>

    <%-- Om allt går bra --%>   
    <asp:Panel ID="SuccessPanel" runat="server" Visible="false">
        <asp:Label ID="UploadSuccess" runat="server"></asp:Label>
        <a href="#" id="closePanelButton"><img src="script/close.jpg" /></a>
    </asp:Panel>
                              
    <%-- Bilden som visas --%>
    <div id="imageDisplayDiv">
        <asp:Image ID="ImageDisplay" visible="false" runat="server" />
    </div>

    <%-- Galleriet --%>
        <asp:Repeater ID="GalleryRepeater" runat="server" ItemType="System.String" SelectMethod="GalleryRepeater_GetData">
            <HeaderTemplate>
                <ul id="thumbGallery">
            </HeaderTemplate>

            <ItemTemplate>
                <li>
                    <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl='<%# String.Format("?Name={0}",Item)  %>'>
                        <asp:Image ID="Image" CssClass="thumbnail" runat="server" ImageUrl='<%# String.Format(@"~/Content/Images/Thumbnails/{0}", Item) %>' />                        
                    </asp:HyperLink>
                    
                </li>
            </ItemTemplate>


            <FooterTemplate>
                </ul>
            </FooterTemplate>
            

        </asp:Repeater>

    <form id="form1" runat="server">
        <%-- Här visas fel-meddelanden --%>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />     
    
        <div>
            <%-- Upload--%>
            <asp:FileUpload ID="FileUpload" runat="server" />  
            <asp:Button ID="UploadButton" runat="server" Text="Ladda upp" OnClick="UploadButton_Click" />
            
            <%-- Validering --%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" Text="Fel!" ErrorMessage="Du måste välja en fil att ladda upp!" ControlToValidate="FileUpload" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Fel filformat!" Display="Dynamic" Text="Fel!" ControlToValidate="FileUpload" ValidationExpression="^.*\.(jpg|gif|png)$"></asp:RegularExpressionValidator>             
            
          
        </div>
    </form>
    <script type="text/javascript" src="script/galleryJS.js"></script>
</body>
</html>

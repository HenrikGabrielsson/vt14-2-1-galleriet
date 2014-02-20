<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gallery.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/style/style.css" rel="stylesheet" />
    <title>Bildgalleri</title>
</head>
<body>
    <form id="form1" runat="server">

        <%-- Här visas fel-meddelanden --%>
        <asp:ValidationSummary ID="ValidationSummary" runat="server" />    
    <div>
                              
    <%-- Bilden som visas --%>
        <asp:Image ID="ImageDisplay" visible="false" runat="server" />

    <%-- Galleriet --%>
        <asp:Repeater ID="GalleryRepeater" runat="server" ItemType="System.String" SelectMethod="GalleryRepeater_GetData">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>


            <ItemTemplate>
                <li>
                    <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl='<%# String.Format("?Name={0}",Item)  %>'>
                        <asp:Image ID="Image" runat="server" ImageUrl='<%# String.Format(@"~/Content/Images/Thumbnails/{0}", Item) %>' />                        
                    </asp:HyperLink>
                    
                </li>
            </ItemTemplate>


            <FooterTemplate>
                </ul>
            </FooterTemplate>
            

        </asp:Repeater>

        <asp:Label runat="server" Text="Label" ID="Label"></asp:Label>
    <%-- Upload--%>
        <asp:FileUpload ID="FileUpload" runat="server" />  
    <%-- Validering --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" Text="Fel!" ErrorMessage="Du måste välja en fil att ladda upp!" ControlToValidate="FileUpload"></asp:RequiredFieldValidator>

        <asp:Button ID="UploadButton" runat="server" Text="Ladda upp" OnClick="UploadButton_Click" />
          
    </div>
    </form>
</body>
</html>

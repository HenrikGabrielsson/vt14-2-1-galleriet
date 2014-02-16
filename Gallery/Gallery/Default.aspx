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
                                                                             <%--DEN HÄR SKA BORT --%>        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <%-- Bilden som visas --%>
        <asp:Image ID="ImageDisplay" runat="server" />

    <%-- Galleriet --%>
        <asp:Repeater ID="GalleryRepeater" runat="server" ItemType="System.IO.FileInfo" SelectMethod="GalleryRepeater_GetData">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>


            <ItemTemplate>
                <li>

                </li>
            </ItemTemplate>


            <FooterTemplate>
                </ul>
            </FooterTemplate>


        </asp:Repeater>


    <%-- Upload--%>
        <asp:FileUpload ID="FileUpload" runat="server" />  
        <asp:Button ID="UploadButton" runat="server" Text="Ladda upp" OnClick="UploadButton_Click" />
          
    </div>
    </form>
</body>
</html>

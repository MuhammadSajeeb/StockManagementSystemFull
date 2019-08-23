<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testingImages.aspx.cs" Inherits="StockManagementSystem.testingImages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<asp:FileUpload ID="FileUpload1" runat="server" />
<br /><br />
<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
<br /><br />
<asp:Label ID="lblMessage" runat="server"></asp:Label>
<br /><br />
<asp:HyperLink ID="hyperlink" runat="server">View Uploaded Image</asp:HyperLink>
</asp:Content>

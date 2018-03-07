<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CountryNew.aspx.cs" Inherits="POSW.CountryNew" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
<br />
<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Required JS"></asp:RequiredFieldValidator>
<asp:Label ID="lblEName" runat="server" ForeColor="Red"></asp:Label>
<br />
<br />
<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CityNew.aspx.cs" Inherits="POSW.CityNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            Please wait...
            <img alt="" src="images/special.gif" style="width: 280px; height: 13px" />
        </ProgressTemplate>
    </asp:UpdateProgress>
&nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
            <asp:Label ID="Label3" runat="server" Text="Country"></asp:Label>
<br />
            <asp:DropDownList ID="ddlCountry" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="id">
                <asp:ListItem Value="0">Select</asp:ListItem>
            </asp:DropDownList>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlCountry" ErrorMessage="Select One" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
            <asp:Label ID="lblECountry" runat="server" ForeColor="Red"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT * FROM [country]"></asp:SqlDataSource>
<br />
<br />
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

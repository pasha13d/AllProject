<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="POSW.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/Products.css" rel="stylesheet" />
    <div class="summery">Total : <%# "in : " + Eval("category") + " by " + Eval("brand")  %>Item, Price : <%# Eval("price") %>BDT/= <a href="mycart.aspx">go to cart</a></div>
    <div class="search">

        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Price From"></asp:Label>
        <asp:TextBox ID="txtPriceFrom" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Price To"></asp:Label>
        <asp:TextBox ID="txtPriceTo" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Unit"></asp:Label>
        <asp:DropDownList ID="ddlUnit" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource3" DataTextField="name" DataValueField="id">
            <asp:ListItem Value="0">All Unit</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT * FROM [unit]"></asp:SqlDataSource>
        <asp:Label ID="Label4" runat="server" Text="Brand"></asp:Label>
        <asp:DropDownList ID="ddlBrand" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="id">
            <asp:ListItem Value="0">All Brand</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT * FROM [brand]"></asp:SqlDataSource>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />

    </div>
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <div class="product">
                <h2><%# Eval("name") + ", " + Eval("code") %></h2>
                <img src="uploads/productImages/<%# Eval("image") %>" />
                <div>
                    <span><%# "in : " + Eval("category") + " by " + Eval("brand")  %></span>
                    <span>Price : <%# Eval("price") %> BDT/=</span>
                   <asp:Button ID="btnAdd" runat="server" CommandArgument='<%# Eval("id") %>' Text="Add" OnClick="btnAdd_Click" />
                </div>
                 <p>
                    <%# Eval("description") %>
                 </p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT [id], [name], [code], [description], [brand], [category], [createDate], [price], [image], [brandId], [categoryId] FROM [vwProductImage]"></asp:SqlDataSource>
</asp:Content>



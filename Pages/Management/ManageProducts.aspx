<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageProducts.aspx.cs" Inherits="Pages_Management_ManageProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        Name:<br />
        <asp:TextBox ID="txtName" placeholder="Name" runat="server" CssClass="inputs"></asp:TextBox><br />

        Type:<br />
        <asp:DropDownList ID="ddlType" runat="server" CssClass="inputs" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id"></asp:DropDownList><br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GarageDBConnectionString %>" SelectCommand="SELECT * FROM [ProductTypes] ORDER BY [Name]"></asp:SqlDataSource>

    
        Price:<br />    
        <asp:TextBox ID="txtPrice" CssClass="inputs" TextMode="Number" min="1" placeholder="Price $" runat="server"></asp:TextBox><br />
        
        Image:<br />    
        <asp:DropDownList ID="ddlImage" runat="server" CssClass="inputs"></asp:DropDownList><br />
    
        Description:<br />    
        <asp:TextBox ID="txtDescription" CssClass="inputs" placeholder="Description" runat="server" Rows="10" Columns="10" TextMode="MultiLine"></asp:TextBox><br />
        
        <asp:Button ID="btnSubmit" CssClass="button" runat="server" OnClick="btnSubmit_Click" Text="Submit" /><br />
        
        <asp:Label ID="lblResult" runat="server"></asp:Label><br />
    
</asp:Content>


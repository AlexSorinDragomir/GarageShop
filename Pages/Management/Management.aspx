<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Management.aspx.cs" Inherits="Pages_Management_Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="button" PostBackUrl="~/Pages/Management/ManageProducts.aspx">Add new product</asp:LinkButton>
    <br />
    <div style="margin-top:20px">
        <asp:GridView ID="grdProducts" CssClass="table table-bordered table-hover table-responsive" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="sdsProducts" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowEditing="grdProducts_RowEditing">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="TypeId" HeaderText="TypeId" SortExpression="TypeId" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
    <asp:SqlDataSource ID="sdsProducts" runat="server" ConnectionString="<%$ ConnectionStrings:GarageDBConnectionString %>" DeleteCommand="DELETE FROM [Product] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Product] ([TypeId], [Name], [Price], [Description], [Image]) VALUES (@TypeId, @Name, @Price, @Description, @Image)" SelectCommand="SELECT * FROM [Product]" UpdateCommand="UPDATE [Product] SET [TypeId] = @TypeId, [Name] = @Name, [Price] = @Price, [Description] = @Description, [Image] = @Image WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="TypeId" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Price" Type="Int32" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Image" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="TypeId" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Price" Type="Int32" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Image" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="button" PostBackUrl="~/Pages/Management/ManageProductTypes.aspx">Add new product type</asp:LinkButton>
    <br />
    <div style="margin-top:20px">
        <asp:GridView ID="grdProductTypes" CssClass="table table-bordered table-hover table-responsive" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="sdsProductTypes" Width="40%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
    <asp:SqlDataSource ID="sdsProductTypes" runat="server" ConnectionString="<%$ ConnectionStrings:GarageDBConnectionString %>" DeleteCommand="DELETE FROM [ProductTypes] WHERE [Id] = @Id" InsertCommand="INSERT INTO [ProductTypes] ([Name]) VALUES (@Name)" SelectCommand="SELECT * FROM [ProductTypes]" UpdateCommand="UPDATE [ProductTypes] SET [Name] = @Name WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br /><h3>Users feedback</h3>
    <div style="margin-top:20px">
        <asp:GridView ID="feedbackGrid" CssClass="table table-bordered table-hover table-responsive" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ssdFeedback">        
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Raiting" HeaderText="Raiting" SortExpression="Raiting" />
                <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                <asp:BoundField DataField="UserGUID" HeaderText="UserGUID" SortExpression="UserGUID" />
                <asp:BoundField DataField="SubmissionDate" HeaderText="SubmissionDate" SortExpression="SubmissionDate" />
            </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="ssdFeedback" runat="server" ConnectionString="<%$ ConnectionStrings:GarageDBConnectionString %>" DeleteCommand="DELETE FROM [Feedback] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Feedback] ([Email], [Raiting], [Text], [UserGUID], [SubmissionDate]) VALUES (@Email, @Raiting, @Text, @UserGUID, @SubmissionDate)" SelectCommand="SELECT * FROM [Feedback]" UpdateCommand="UPDATE [Feedback] SET [Email] = @Email, [Raiting] = @Raiting, [Text] = @Text, [UserGUID] = @UserGUID, [SubmissionDate] = @SubmissionDate WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Raiting" Type="Int32" />
                    <asp:Parameter Name="Text" Type="String" />
                    <asp:Parameter Name="UserGUID" Type="String" />
                    <asp:Parameter Name="SubmissionDate" Type="DateTime" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Raiting" Type="Int32" />
                    <asp:Parameter Name="Text" Type="String" />
                    <asp:Parameter Name="UserGUID" Type="String" />
                    <asp:Parameter Name="SubmissionDate" Type="DateTime" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>        
    </div>
    
</asp:Content>


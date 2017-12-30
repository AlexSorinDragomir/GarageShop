<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Pages_Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h4>Please let us know your feedback</h4><hr />
    <div style="display:flex">
        <div>
            <asp:Literal runat="server" ID="litFeedbackMessage" />

            Email:<br />
            <asp:TextBox runat="server" ID="txtEmail" CssClass="inputs" /><br />
    
            How satisfied were you with Garage Shop (1-10):<br />
            <asp:textbox runat="server" id="txtRaiting" cssclass="inputs" /><br />
            <%--<asp:RangeValidator runat="server" Type="Integer" 
            MinimumValue="1" MaximumValue="10" ControlToValidate="txtRaiting" 
            ErrorMessage="Only Numbers between 1 and 10 allowed!" /><br />--%>

            Feel free to add any other comments or suggestions:<br />
            <asp:TextBox runat="server" ID="txtFeedback" TextMode="MultiLine" Rows="10" Columns="10" CssClass="inputs" /><br />

            <asp:Button ID="btnSubmitFeedback" runat="server" Text="Submit" OnClick="btnSubmitFeedback_Click" CssClass="button" Width="150px" />
        </div>
        <div style="margin-left:20%">
            <h4>Your submitted feedback</h4>
            <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover table-responsive" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ssdFeedback">
                <Columns>
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Raiting" HeaderText="Raiting" SortExpression="Raiting" />
                    <asp:BoundField DataField="Text" HeaderText="Text" SortExpression="Text" />
                    <asp:BoundField DataField="SubmissionDate" HeaderText="SubmissionDate" SortExpression="SubmissionDate" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="ssdFeedback" runat="server" ConnectionString="<%$ ConnectionStrings:GarageDBConnectionString %>">
            </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>


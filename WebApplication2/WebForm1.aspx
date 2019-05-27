<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetPeople" TypeName="WebApplication2.BLL.PersonBLL"></asp:ObjectDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:BoundField DataField="PersonID" HeaderText="PersonID" SortExpression="PersonID" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="ChineseName" HeaderText="ChineseName" SortExpression="ChineseName" />
                    <asp:BoundField DataField="HireDate" HeaderText="HireDate" SortExpression="HireDate" />
                    <asp:BoundField DataField="EnrollmentDate" HeaderText="EnrollmentDate" SortExpression="EnrollmentDate" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

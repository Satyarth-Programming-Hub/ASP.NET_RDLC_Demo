<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ASP.NET_RDLC_Demo.UI.Index" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:TextBox ID="txtCountry" runat="server" /><br />
            <asp:Button ID="btnLoadReport" Text="Load Report" runat="server" OnClick="btnLoadReport_Click" />
        </div>
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="489px" Width="1380px"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
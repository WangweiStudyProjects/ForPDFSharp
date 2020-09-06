<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Defaut.aspx.cs" Inherits="UrlRewritingForShowPDF.Defaut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Demo</h1>
        <div>
            <ul>
                <li><a href="ShowPDF.aspx" target="_blank">Show Error</a></li>
                <li><a href="ShowPDF.aspx?category=books" target="_blank">Books</a></li>
                <li><a href="ShowPDF/DVDs.aspx" target="_blank">DVDs</a></li>
            </ul>
        </div>
    </form>
</body>
</html>
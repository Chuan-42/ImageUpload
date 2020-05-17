<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ImageUpload.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>无刷新上传图片</title>
    <script src="js/jquery-3.3.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="img" runat="server" Width="100px" Height="100px"/>
            <asp:FileUpload ID="fuImg" runat="server" />
        </div>
    </form>
</body>
<script src="js/Default.js"></script>
</html>

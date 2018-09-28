<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hello How Are You?            
            <a href="https://accounts.google.com/o/oauth2/auth?response_type=code&redirect_uri=http://localhost:17017/LoginSuccess.aspx&scope=https://www.googleapis.com/auth/userinfo.email%20https://www.googleapis.com/auth/userinfo.profile&client_id=645346265016-09bade801ee8s618m5ng54cn9b0pi8qt.apps.googleusercontent.com">Gmail Login</a>
        </div>
    </form>
</body>
</html>

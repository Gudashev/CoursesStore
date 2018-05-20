<%@ Page Language="C#" Inherits="Alex.admin.Admin" %>
<!DOCTYPE html>
<html lang="ru">
<head runat="server">
    <meta charset="UTF-8">
    <title>Панель администратора</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/admin.css">
        
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="js/admin.js"></script>
        
</head>
<body>
	<form id="form1" runat="server">

    <div class="container">

        <!-- Header -->
        <div class="row header">
            <div class="col text">
                <a href="/" class="link button">На главную</a>
                <a href="AddGood.aspx" class="link button add" style="background-color: #009688">Добавить товар</a>
                <a href="Orders.aspx" class="link button add" style="background-color: #fbc02d">Заказы</a>
            </div>
            <div class="col-2 right text">
                <a href="../authorization/Exit.aspx" class="link button">Выйти</a>
            </div>
        </div>
        <!-- Header end -->

        <!-- Title -->
        <div class="row title">
            <div class="col text">
                Панель администратора
            </div>
        </div>
        <!-- Title end -->

        <!-- Body part -->
        <% getItems(); %>
        <!-- Body part end -->

    </div>

            <a id="s" runat="server" style="display: none"></a>
            <input id="id" runat="server" style="display:none" value="test">
            <input id="name" runat="server" style="display:none" value="test">
            <input id="description" runat="server" style="display:none" value="test">
            <input id="price" runat="server" style="display:none" value="test">
            
	</form>
</body>
</html>

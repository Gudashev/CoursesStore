<%@ Page Language="C#" Inherits="Alex.admin.Orders" %>
<!DOCTYPE html>
<html lang="ru">
<head runat="server">
    <meta charset="UTF-8">
    <title>Заказы</title>
        
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/order.css">

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="js/order.js"></script>
</head>
<body>
	<form id="form1" runat="server">

    <div class="container">
        <!-- Header -->
        <div class="row header">
            <div class="col text">
                <a href="./Admin.aspx" class="link button">Панель администратора</a>
            </div>
            <div class="col right text">
                <a href="../authorization/Exit.aspx" class="link button">Выйти</a>
            </div>
        </div>
        <!-- Header end -->

        <!-- Title -->
        <div class="row title">
            <div class="col text">
                Заказы
            </div>
        </div>
        <!-- Title end -->

        <% getOrders(); %>

        <div class="row" style="height: 100px;"></div>
                
    </div>

            <a runat="server" id="del" style="display: none;"></a>
            <input runat="server" id="val" value="test" style="display: none">
	</form>
</body>
</html>

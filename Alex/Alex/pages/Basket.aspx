<%@ Page Language="C#" Inherits="Alex.pages.Basket" %>
<!DOCTYPE html>
<html lang="ru">
<head runat="server">
	<meta charset="UTF-8">
    <title>Корзина</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/basket.css">

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
        
</head>
<body>
	<form id="form1" runat="server">

     <div class="container">

        <!-- Header -->
        <div class="row header">
            <div class="col text">
                <a href="../Index.aspx" class="link button">На главную</a>
            </div>
            <div class="col right text">
                <a href="../authorization/Exit.aspx" class="link button">Выйти</a>
            </div>
        </div>
        <!-- Header end -->

        <!-- Title -->
        <div class="row title">
            <div class="col text">
                Корзина
            </div>
        </div>
        <!-- Title end -->

        <!-- Body part -->
        <% getBasket(); %>
        <!-- Body part end -->
                
        <div class="row">
            <div class="col" style="text-align: center;">
                 <a runat="server" id="order" class="button order" style="color: white">Оформить заказ!</a>   
            </div>
        </div>
                
    </div>
            
	</form>
</body>
</html>

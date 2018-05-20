<%@ Page Language="C#" Inherits="Alex.pages.Business" %>
<!DOCTYPE html>
<html lang="ru">
<head runat="server">
    <meta charset="UTF-8">
	<title>Курсы по бизнесу</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/business.css">

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="js/add.js"></script>
        
</head>
<body>
	<form id="form1" runat="server">

    <div class="container">

        <!-- Header -->
        <div class="row header">
            <% getHeader(); %>
        </div>
        <!-- Header end -->

        <!-- Title -->
        <div class="row title">
            <div class="col text">
                Курсы по бизнесу
            </div>
        </div>
        <!-- Title end -->

        <!-- Body part -->
        <% getItems(); %>
        <!-- End body part-->

    </div>

    <a runat="server" style="display:none" id="add"></a>
    <input runat="server" id="good" type="text" value="test" style="display: none">
            
	</form>
</body>
</html>

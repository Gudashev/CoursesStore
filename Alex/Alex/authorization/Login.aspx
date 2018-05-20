<%@ Page Language="C#" Inherits="Alex.authorization.Login" %>
<!DOCTYPE html>
<html lang="ru">
<head runat="server">
    <meta charset="UTF-8">
	<title>Вход</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/authorization.css">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="js/login.js"></script>
        
</head>
<body>
	<form id="form1" runat="server">

    <div class="container">

        <div class="row justify-content-center">
            <div class="col title">
                <span>Вход</span>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col input-container">
                <div class="form-group">
                    <label for="email">E-mail:</label>
                    <input runat="server" type="text" class="form-control" id="email">
                </div>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col input-container">
                <div class="form-group">
                    <label for="password">Пароль:</label>
                    <input runat="server" type="password" class="form-control" id="password">
                </div>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col entry-container">
                <a runat="server" id="login" href="#" class="entry-link disabled">Войти</a>
            </div>
        </div>

    </div>
            
	</form>
</body>
</html>

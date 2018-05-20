<%@ Page Language="C#" Inherits="Alex.authorization.Registration" %>
<!DOCTYPE html>
<html lang="ru">
<head runat="server">
    <meta charset="UTF-8">
	<title>Регистрация</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/authorization.css">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="js/registration.js"></script>
        
</head>
<body>
	<form id="form1" runat="server">

     <div class="container">

        <div class="row">
            <div class="col title">
                <span>Регистрация</span>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col input-container">
                <div class="form-group">
                    <label for="name">Ваше имя:</label>
                    <input runat="server" type="text" class="form-control" id="name">
                </div>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col input-container">
                <div class="form-group">
                    <label for="last_name">Ваша фамилия:</label>
                    <input runat="server" type="text" class="form-control" id="last_name">
                </div>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col input-container">
                <div class="form-group">
                    <label for="patronymic">Ваше отчество:</label>
                    <input runat="server" type="text" class="form-control" id="patronymic">
                </div>
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
                    <input runat="server" type="text" class="form-control" id="password">
                </div>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col entry-container">
                <a runat="server" id="registration" href="#" class="entry-link disabled">Зарегистрироваться</a>
            </div>
        </div>

    </div>
            
	</form>
</body>
</html>

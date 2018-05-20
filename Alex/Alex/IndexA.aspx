<%@ Page Language="C#" Inherits="Alex.Index" %>
<!DOCTYPE html>
<html lang="ru">
<head runat="server">
    <meta charset="UTF-8">
	<title>Главная</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="pages/css/index.css">
        
</head>
<body>
	<form id="form1" runat="server">

    <div class="container">

        <!-- Header -->
        <div class="row header">
            <% getHeader(); %>
        </div>
        <!-- Header end -->

        <div class="row">
            <div class="col text-center">
                <span class="main-text">The fast сourses</span>
            </div>
        </div>

        <div class="row">
            <div class="col text-center sub-text-container center">
                <span class="sub-text">
                    Мы собрали самые лучшие программы для роста ваших показателей в бизнесе.
                </span>
            </div>
        </div>

        <div class="row padding-20">
            <div class="col">
                <a href="pages/English.aspx">
                    <img class="image shadow" src="content/index/images/tree.jpg">
                </a>
            </div>
            <div class="col">
                <a href="pages/Business.aspx">
                    <img class="image shadow" src="content/index/images/gears.jpg">
                </a>
            </div>
        </div>

        <div class="row">
            <div class="col text-center">
                <a class="link image-text" href="pages/English.aspx">Иностранные языки</a>
            </div>
            <div class="col text-center">
                <a class="link image-text" href="pages/Business.aspx">Курсы по бизнесу</a>
            </div>
        </div>

    </div>
            
	</form>
</body>
</html>

<%@ Page Language="C#" Inherits="Alex.admin.AddGood" %>
<!DOCTYPE html>
<html lang="ru">
<head runat="server">
	<meta charset="UTF-8">
    <title>Добавить товар</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
        
    <link rel="stylesheet" href="../authorization/css/authorization.css">
    <link rel="stylesheet" href="css/file.css">

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script src="js/add.js"></script>
        
</head>
<body>
	<form id="form1" runat="server">

     <div class="container">

        <div class="row justify-content-center">
            <div class="col title">
                <span>Добавить товар</span>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col input-container">
                <div class="form-group">
                    <label for="name">Название:</label>
                    <input runat="server" type="text" class="form-control" id="name">
                </div>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col input-container">
                <div class="form-group">
                    <label for="description">Описание:</label>
                    <textarea runat="server" class="form-control" rows="5" id="description"></textarea>
                </div>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col input-container">
                <div class="form-group">
                    <label for="type">Тип продукта:</label>
                    <select runat="server" class="form-control" id="type">
                        <option>Курс иностранного языка</option>
                        <option>Бизнес-курс</option>
                    </select>
                </div>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col input-container">
                <div class="form-group">
                    <label for="price">Цена:</label>
                    <input runat="server" type="text" class="form-control" id="price">
                </div>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col input-container">

                <div class="custom-file-upload">
                    <label for="file">Фотография:</label>
                    <input runat="server" type="file" id="file" accept="image/*" name="myfiles[]" readonly/>
                </div>

            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col input-container entry-container" style="margin-top: 20px">
                <a id="add" runat="server" href="#" class="entry-link disabled">Добавить товар</a>
            </div>
        </div>

    </div>

    <script src="js/file.js"></script>
            
	</form>
</body>
</html>

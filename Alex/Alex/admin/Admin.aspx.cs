using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Alex.algorithms;

namespace Alex.admin
{

    public partial class Admin : System.Web.UI.Page
    {

        public void Page_Load(){
            s.ServerClick += saveChanges;//Подключаем обработчик для кнопки сахранения изменений 
        }

        public void saveChanges(object sendler, EventArgs args){  // Метод, который сохраняет изменения, внесенные администратором
            Handlers.changeItem(id.Value, name.Value, description.Value, price.Value);  // Передаем данные для изменения
        }
        
        public void getItems(){  // Метод отвечает за генерацию товаров на странице с возможностью редактирования
            Response.Write("<div class='row' style='padding: 20px;'>");  // Пишем в aspx начальную строчку
            int count = 0;
            List<string[]> dataBase = CSVReader.read("db/goods.csv");  // Читаем базу данных из файла
            foreach (string[] item in dataBase)
            {
                if (count % 3 == 0 && count != 0)  // Если это каждый 3 выведенный на страницу товар
                    Response.Write("</div><div class='row'>");
                Response.Write(String.Format(@"
                    <div id='{0}' class='col-4 item'>
                        <div style='text-align: center'>
                            <img class='image' src='../content/{5}/images/{1}'>
                        </div>
                        <div class='form-group'>
                            <label for='name{0}'>Название:</label>
                            <input type='text' class='form-control' id='name{0}' value='{2}'>
                        </div>
                        <div class='form-group'>
                            <label for='desc{0}'>Описание:</label>
                            <textarea class='form-control' id='desc{0}' rows'5'>{3}</textarea>
                        </div>
                        <div class='form-group'>
                            <label for='price{0}'>Цена:</label>
                            <input type='number' class='form-control price' id='price{0}' value='{4}'>
                        </div>
                        <div style='text-align: center;'>
                            <a id='change-{0}' class='link button add save' style='background-color: #fbc02d'>Сохранить изменения</a>
                        </div>
                    </div>
                ", "id_" + item[0], item[5], item[2], item[3], item[4], item[1].Equals("eng") ? "english": "business"));  // Тут генерируем разметку 1 товара
                count++;  // Увеличиваем счетчик сгенерированных товаров
            }
            Response.Write("</div>");  // Корректно завершаем генерацию разметки
        }

    }
}

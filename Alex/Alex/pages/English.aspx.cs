using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Alex.algorithms;

namespace Alex.pages
{

    public partial class English : System.Web.UI.Page
    {

        public void Page_Load(){
            add.ServerClick += onClick;
        }

        public void onClick(object sendler, EventArgs args){
            if (Request.Cookies["cookie"] != null){  // Если пользователь авторизован
                Handlers.addGoodToBasket(good.Value, Request.Cookies["cookie"].Value);  // Добавляем товар в корзину пользователя
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Товар добавлен в корзину!')", true);  // Говорим, что товар добавлен
                Response.Redirect("./English.aspx");
            } else {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Сначала авторизуйтесь!')", true);  // Делаем алерт пользователю, что надо войти
            }
        }

        public void getHeader()
        {  // Метод генерирует шапку страницы
            HttpCookie cookie = Request.Cookies["cookie"];  // Пытаемся получить куки пользователя
            if (cookie != null)
            {  // Если куки существует
                if (Handlers.getUserData(cookie.Value)[6].Equals("simple"))
                {  // Если это простой пользователь
                    Response.Write(String.Format(@"
                        <div class='col text'>
                            <a href='/' class='link button'>На главную</a>
                            <a href='../pages/Basket.aspx' class='link button'>Корзина ({0})</a>
                        </div>
                        <div class='col right text'>
                            <a href='../authorization/Exit.aspx' class='link button'>Выйти</a>
                        </div>
                        ", Handlers.getBasketSize(Request.Cookies["cookie"].Value)));
                }
                else
                {  // Иначе это администратор
                    Response.Write(@"
                        <div class='col text'>
                            <a href='/' class='link button'>На главную</a>
                            <a href='../admin/Admin.aspx' class='link button'>Панель администратора</a>
                        </div>
                        <div class='col right text'>
                            <a href='../authorization/Exit.aspx' class='link button'>Выйти</a>
                        </div>
                        ");
                }
            }
            else  // Если у нас нет информации о пользователе
            {
                Response.Write(@"
                    <div class='col right text'>
                        <a href='/' class='link button'>На главную</a>
                        <a href='../authorization/Login.aspx' class='link button'>Войти</a>
                        <a href='../authorization/Registration.aspx' class='link button'>Зарегистрироваться</a>
                    </div>
                ");  // То предлагаем ему зарегистрироваться
            }
        }
        
        public void getItems(){  // Метод берет товары из БД и выводит их на страницу
            Response.Write("<div class='row' style='padding: 20px;'>");  // Пишем в aspx начальную строчку
            int count = 0;
            List<string[]> dataBase = CSVReader.read("db/goods.csv");  // Читаем базу данных из файла
            foreach (string[] item in dataBase){
                if (item[1] != "eng") continue;  // Если это курс не по иностранному, то переходим к сл товару
                if (count % 3 == 0 && count != 0)  // Если это каждый 3 выведенный на страницу товар
                    Response.Write("</div><div class='row'>");
                Response.Write(String.Format(@"
                    <div class='col-4 item'>
                        <a>
                            <img class='image' src='../content/english/images/{1}'>
                        </a><br>
                        <span class='title'>{2}</span><br>
                        <span class='description'>{3}</span>
                        <br><br>
                        <a id='{0}' class='buy shadow'>Купить за {4}Р.</a>
                    </div>
                ", "id_" + item[0], item[5], item[2], item[3], item[4]));  // Тут генерируем разметку 1 товара
                count++;  // Увеличиваем счетчик сгенерированных товаров
            }
            Response.Write("</div>");  // Корректно завершаем генерацию разметки
        }

    }
}

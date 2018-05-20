using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Alex.algorithms;

namespace Alex.pages
{

    public partial class Basket : System.Web.UI.Page
    {

        public void Page_Load(){
            if (Request.Cookies["cookie"] == null){  // Если сюда пытается войти неавторизованный пользователь
                Response.Redirect("/");  // Перенаправляем его на главную
            }
            order.ServerClick += onClick;  // Добавляем событие на кнопку заказа

            if (Handlers.getBasketSize(Request.Cookies["cookie"].Value).Equals("0")){
                order.Visible = false;
            }
        }

        public void onClick(object sendler, EventArgs args){
            Handlers.doOrder(Request.Cookies["cookie"].Value);  // Передаем корзину пользователя в заказ
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Заказ принят в обработку, ждите e-mail'); window.location.reload();", true);
        }

        public void getBasket(){  // Метод, который генерирует разметку для корзины пользователя
            if (Handlers.getBasketSize(Request.Cookies["cookie"].Value) == "0"){  // Если корзина пользователя пуста
                Response.Write("<div class='row'><div class='col' style='text-align: center; font-size: 26pt;'><span>Ваша корзина пуста<span></div></div>");
                return;  // Выходим из метода
            }
            List<string[]> basket = Handlers.getBasket(Request.Cookies["cookie"].Value);  // Загружаем товары из корзины пользователя
            Response.Write("<div class='row' style='padding: 20px;'>");  // Пишем в aspx начальную строчку
            int count = 0;  // Счетчик для перескока на новую строку
            foreach (string[] item in basket){  // Пробегаем каждый товар из корзины
                if (count % 3 == 0 && count != 0)  // Если это каждый 3 выведенный на страницу товар
                    Response.Write("</div><div class='row'>");
                Response.Write(String.Format(@"
                    <div class='col-4 item'>
                        <a href='{0}'>
                            <img class='image' src='../content/{5}/images/{1}'>
                        </a><br>
                        <span class='title'>{2}</span><br>
                        <span class='description'>{3}</span>
                        <br><br>
                        <a id='{0}' class='button shadow'>Цена: {4}Р.</a>
                    </div>
                ", "id_" + item[0], item[5], item[2], item[3], item[4], item[1].Equals("eng") ? "english": "business"));  // Тут генерируем разметку 1 товара
                count++;
            }
            Response.Write("</div>");  // Заканчиваем разметку
        }

    }
}

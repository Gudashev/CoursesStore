using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Alex.algorithms;

namespace Alex.admin
{

    public partial class Orders : System.Web.UI.Page
    {

        public void Page_Load(){
            del.ServerClick += onClick;  // Вешаем событие на кнопку для удаления заказа
        }

        public void onClick(object sendler, EventArgs args){
            Handlers.deleteOrder(val.Value);
            Response.Redirect("./Orders.aspx");
        }

        public void getOrders(){  // Метод для генерации заказов
            List<object[]> orders = Handlers.getOrders();  // Получаем все заказы
            if (orders.Count == 0){  // Если заказов нет
                Response.Write("<div class='row'><div class='col' style='text-align: center; font-size: 26pt;'><span>Новых заказов нет<span></div></div>");
                return;  // Выходим из метода
            }
            int id = 0;
            foreach(object[] order in orders){  // Пробегаем каждый заказ
                Response.Write("<div class='box'>");

                string[] user = (string[]) order[0];
                List<string[]> basket = (List<string[]>) order[1];

                Response.Write(String.Format(@"
                <div class='row'>
                    <div class='col-12'>
                        <div class='row'>
                            <div class='col-4'>
                                <label>Имя:</label>
                                <input type='text' class='form-control' value='{0}' readonly>
                            </div>
                            <div class='col-4'>
                                <label>Фамилия:</label>
                                <input type = 'text' class='form-control' value='{1}' readonly>
                            </div>
                            <div class='col-4'>
                                <label>Отчество:</label>
                                <input type='text' class='form-control' value='{2}' readonly>
                            </div>
                        </div>
                        <div class='row'>
                            <div class='col-12'>
                                <label>E-mail:</label>
                                <input type='text' class='form-control' value='{3}' readonly>
                            </div>
                        </div>
                    </div>
                </div>
                <div class='row box'>
                    <div class='row'>
                ", user[1], user[0], user[2], user[3]));

                int count = 0;  // Количество отрендереных товаров
                foreach (string[] item in basket){
                    if (count % 3 == 0 && count != 0){  // Если пора перескакивать на новую строку
                        Response.Write("</div><div class='row'>");
                    }
                    Response.Write(String.Format(@"
                        <div class='col-4 item'>
                            <a>
                                <img class='image' src='../content/{0}/images/{1}'>
                            </a><br>
                            <span class='title'>{2}</span><br>
                            <span class='title'>За {3}Р</span>
                        </div>
                    ", item[1].Equals("eng") ? "english": "business", item[5], item[2], item[4]));
                    count++;
                }

                Response.Write("</div>");

                Response.Write(String.Format(@"
                    <div class='row'>
                        <div class='col' style='text-align: center;'>
                            <a id='{0}' class='link button compl'>Заказ выполнен!</a>
                        </div>
                    </div>
                </div></div>
                ", "id_" + user[5]));
                id++;
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Alex.algorithms;

namespace Alex
{

    public partial class Index : System.Web.UI.Page
    {
        public void Page_Load()
        {

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
                            <a href='./pages/Basket.aspx' class='link button'>Корзина ({0})</a>
                        </div>
                        <div class='col right text'>
                            <a href='./authorization/Exit.aspx' class='link button'>Выйти</a>
                        </div>
                        ", Handlers.getBasketSize(Request.Cookies["cookie"].Value)));
                }
                else
                {  // Иначе это администратор
                    Response.Write(@"
                        <div class='col text'>
                            <a href='./admin/Admin.aspx' class='link button'>Панель администратора</a>
                        </div>
                        <div class='col right text'>
                            <a href='./authorization/Exit.aspx' class='link button'>Выйти</a>
                        </div>
                        ");
                }
            }
            else  // Если у нас нет информации о пользователе
            {
                Response.Write(@"
                    <div class='col right text'>
                        <a href='./authorization/Login.aspx' class='link button'>Войти</a>
                        <a href='./authorization/Registration.aspx' class='link button'>Зарегистрироваться</a>
                    </div>
                ");  // То предлагаем ему зарегистрироваться
            }
        }
    }
}

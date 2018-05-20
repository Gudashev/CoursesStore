using System;
using System.Web;
using System.Web.UI;
using Alex.algorithms;

namespace Alex.authorization
{

    public partial class Login : System.Web.UI.Page
    {
        public void Page_Load(){
            login.ServerClick += onClick;
        }

        public void onClick(object sendler, EventArgs args){
            string token = Handlers.getToken(email.Value, password.Value);  // Пытаемся получить токен
            if (token != null){  // Если пароль и email совпали
                HttpCookie cookie = new HttpCookie("cookie");  // Создаем новый экземпляр cookie
                cookie.Value = token;  // Пристваем токен cookie
                cookie.Expires = DateTime.Now.AddMinutes(10);  // Время жизни cookie 10 минут
                Response.Cookies.Add(cookie);  // Отправляем cookie пользователю
                Response.Redirect("/");  // Перенаправляем пользователя на главную
            }
        }

    }
}

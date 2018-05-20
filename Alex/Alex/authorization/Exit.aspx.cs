using System;
using System.Web;
using System.Web.UI;

namespace Alex.authorization
{

    public partial class exit : System.Web.UI.Page
    {
        public void Page_Load(){
            HttpCookie cookie = Request.Cookies["cookie"];
            if (cookie != null){  // Если куки существует
                cookie.Expires = DateTime.Now.AddDays(-1);  // Делаем куки просроченым
            }
            Response.Cookies.Add(cookie);  // Отправляем cookie пользователю
            Response.Redirect("/");  // Перенаправляем пользовтеля на главную
        }
    }
}

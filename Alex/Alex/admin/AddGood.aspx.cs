using System;
using System.IO;
using System.Web;
using System.Web.UI;
using Alex.algorithms;

namespace Alex.admin
{

    public partial class AddGood : System.Web.UI.Page
    {
        public void Page_Load(){
            add.ServerClick += onClick;
        }

        public void onClick(object sendler, EventArgs args){
            // todo качать картинку
            string t = "";  // Переменная, которая хранит eng or bus
            if (type.Value.Equals("Курс иностранного языка")){
                t = "eng";
                file.PostedFile.SaveAs(Server.MapPath("") + "/content/english/images/" + Handlers.getNextId() + ".jpg");  // Сохраняем картинку в папку с картинками для ин. язов
            }
            else{
                t = "bus";
                file.PostedFile.SaveAs(Server.MapPath("") + "/content/business/images/" + Handlers.getNextId() + ".jpg");  // Сохраняем картинку в папку с картинками для бизнеса
            }
            Handlers.addGood(t, name.Value, description.Value, price.Value);  // Добавляем новый товар в корзину
            Response.Redirect("Admin.aspx");  // Перенаправляем назад, на страницу администратора
        }

    }
}

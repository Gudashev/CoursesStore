using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using Alex.algorithms;

namespace Alex.authorization
{
    
    public partial class Registration : System.Web.UI.Page
    {

        public void Page_Load(){
            registration.ServerClick += onClick;  // Добавляем на кнопку события нажатия
        }

        public void onClick(object sendler, EventArgs args){
            string[] user = new string[]{
                name.Value, last_name.Value, patronymic.Value, email.Value, password.Value, createMD5(email.Value), "simple", ""};  // Создаем информацию нового пользователя

            List<string[]> users = CSVReader.read("db/users.csv");  // Читаем базу данных
            users.Add(user);  // Добавляем нового пользователя

            CSVWriter.write(users, "db/users.csv");  // Делаем запись в базу данных

            HttpCookie cookie = new HttpCookie("cookie");  // Создаем новый cookie
            cookie.Value = createMD5(email.Value);  // Создаем токен и пишем его в cookie
            cookie.Expires = DateTime.Now.AddMinutes(10);  // Устанавливаем время жизни cookie на 10 минут
            Response.Cookies.Add(cookie);  // Отправляем cookie клиенту
            Response.Redirect("/");  // Переправляем пользователя на главную
        }

        public string createMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

    }
}

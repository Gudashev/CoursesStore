using System;
using System.Collections.Generic;
using System.IO;

namespace Alex.algorithms
{
    public class Handlers
    {

        private static string goodsBasePath = "db/goods.csv";  // Путь до БД с товарами
        private static string userBasePath = "db/users.csv";  // Путь до БД с пользователями
        private static string orderBasePath = "db/orders.csv";  // Путь до БД с заказами

        public static string[] getUserData(string token){  // Метод возвращает данные о пользователе. Поиск идет по токену
            List<string[]> users = CSVReader.read(userBasePath);  // Читаем базу данных с пользователями
            foreach (string[] user in users){  // Пробегаем каждого пользользователя из БД
                if (user[5].Equals(token))  // Если токены совпадают
                    return user;  // Возвращаем этого пользователя
            }
            return null;  // Если в конце концов пользователь не найден, то возвращаем null
        }

        public static string getToken(string email, string password){
            List<string[]> users = CSVReader.read(userBasePath);  // Читаем базу данных с пользователями
            foreach (string[] user in users)
            {  // Пробегаем каждого пользользователя из БД
                if (
                    user[3].Equals(email) &&
                    user[4].Equals(password)
                )  // Если токены совпадают
                    return user[5];  // Возвращаем токен этого пользователя
            }
            return null;  // Если в конце концов пользователь не найден, то возвращаем null
        }

        public static void addGood(string type, string name, string description, string price){  // Метод добавляет новый товар (От админа)
            List<string[]> goods = CSVReader.read(goodsBasePath);  //  Читаем базу данных с товарами
            string[] newGood = new string[] {
                (goods.Count + 1).ToString(),  // id
                type,  // Тип товара (eng or bus)
                name,  // Название товара
                description,  // Описание товара
                price,  // Цена товара
                (goods.Count + 1).ToString() + ".jpg"  // Путь к картинке
            };  // Создаем информацию о новом товаре
            goods.Add(newGood);  // Добавляем новый товар к остальным
            CSVWriter.write(goods, goodsBasePath);  // Сохраняем базу данных с новым товаром
        }

        public static void addGoodToBasket(string id, string token){  // Метод добавляет товар в корзину пользователя
            List<string[]> users = CSVReader.read(userBasePath);  // Читаем базу данных с пользователями
            for (int i = 0; i < users.Count; i++){
                if (users[i][5].Equals(token)){  // Если пользователь с таким токеном найден
                    users[i][7] += " " + id;  // Добавляем товар в корзину пользователя
                    CSVWriter.write(users, userBasePath);  // Записываем изменения в базу данных
                    return;  // Выходим из метода
                }
            }
        }

        public static string getBasketSize(string token){  // Метод возвращает размер корзины
            List<string[]> users = CSVReader.read(userBasePath);  // Читаем базу данных с пользователями
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i][5].Equals(token))
                {
                    if ((users[i][7].Trim().Split(' ')[0]).Equals(""))
                        return "0";
                    return (users[i][7].Trim().Split(' ').Length).ToString();
                }
            }
            Console.WriteLine("null");
            return null;
        }

        public static List<string[]> getBasket(string token){  // Метод возвращает корзину пользователя
            List<string[]> users = CSVReader.read(userBasePath);  // Читаем базу данных с пользователями
            List<string[]> goods = CSVReader.read(goodsBasePath);  //  Читаем базу данных с товарами

            string[] basket = null;  // Корзина пользователя
            for (int i = 0; i < users.Count; i++){
                if (users[i][5].Equals(token)){  // Если токен совпал
                    basket = users[i][7].Trim().Split(' ');
                    break;  // Выходим из цикла
                }
            }

            List<string[]> result = new List<string[]>();  // Коллекция из товаров, которые необходимо вывести на страницу
            for (int i = 0; i < basket.Length; i++){  // Пробегаем корзину
                result.Add(goods[Int32.Parse(basket[i]) - 1]);  // И добавляем в коллекцию те файлы, которые необходимо отобразить
            }

            return result;  // Возвращаем заполненую коллекцию
        }

        public static string getNextId(){  // Метод выдает id для названия следующей фото, когда добавляют фотографию к странице
            List<string[]> goods = CSVReader.read(goodsBasePath);  // Читаем базу данных
            return (goods.Count + 1).ToString();  // Возвращаем последний id + 1
        }

        public static void changeItem(string id, string name, string description, string price){  // Метод изменяет информацию о одном товаре из БД (по id)
            List<string[]> goods = CSVReader.read(goodsBasePath);  //  Читаем базу данных с товарами
            for (int i = 0; i < goods.Count; i++){
                if (goods[i][0].Equals(id)){  // Если id совпадает
                    goods[i][2] = name;  // Устанавливаем новое имя
                    goods[i][3] = description;  // Устанавливаем новое описание
                    goods[i][4] = price;  // Устанавливаем новую цену
                    CSVWriter.write(goods, goodsBasePath);  // Сохраняем изменения в базу данных
                    return;  // Выходим из метода
                }
            }
        }

        public static void doOrder(string token){  // Метод, который передает корзину в заказы
            List<string[]> users = CSVReader.read(userBasePath);  // Читаем базу данных с пользователями
            List<string[]> orders = CSVReader.read(orderBasePath);  // Читаем базу данных с заказами
            for (int i = 0; i < users.Count; i++){
                if (users[i][5].Equals(token)){  // Если пользователь с таким токеном найден
                    string[] order = new string[] {
                        users[i][5],  // Добавляем к заказу token заказчика
                        users[i][7]  // Добавляем к заказу сам заказ (корзину)
                    };
                    orders.Add(order);  // Добавляем заказ ко всем заказам
                    users[i][7] = "";  // Обнуляем корзину пользователя
                    CSVWriter.write(users, userBasePath);  // Сохраняем изменения в БД
                    CSVWriter.write(orders, orderBasePath);  // Сохраняем изменения в БД
                    return;  // Выходим из метода
                }
            }
        }

        public static List<object[]> getOrders(){
            List<string[]> orders = CSVReader.read(orderBasePath);  // Читаем базу данных с заказами
            List<string[]> users = CSVReader.read(userBasePath);  // Читаем базу данных с пользователями
            List<string[]> goods = CSVReader.read(goodsBasePath);  // Читаем базу данных с товарами

            List<object[]> results = new List<object[]>();

            if (orders.Count == 0){
                return results;
            }

            foreach(string[] order in orders){
                if (order[0].Equals("")) continue;
                string[] user = getUserData(order[0]);  // Получаем информацию о пользователе
                string[] temp = order[1].Trim().Split(' ');  // Тут временно храним заказ пользователя
                List<string[]> basket = new List<string[]>();  // Сюда будем записывать информацию о товарах, которые заказал пользователь
                for (int i = 0; i < temp.Length; i++){
                    basket.Add(goods[Int32.Parse(temp[i]) - 1]);  // Добавляем заказанный товар в список
                }
                results.Add(new object[] { user, basket });  // Добавляем данные о заказе в список
            }

            return results;
        }

        public static void deleteOrder(string id){
            List<string[]> orders = CSVReader.read(orderBasePath);  // Читаем базу данных с заказами
            for (int i = 0; i < orders.Count; i++){
                Console.WriteLine(id);
                if (orders[i][0].Equals(id)){
                    orders.RemoveAt(i);
                    break;
                }
            }
            CSVWriter.write(orders, orderBasePath);  // Сохраняем базу данных
        }

    }
}

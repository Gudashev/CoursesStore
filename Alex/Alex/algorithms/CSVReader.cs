using System.Collections.Generic;
using System.IO;

namespace Alex.algorithms
{
    public class CSVReader
    {
        public static List<string[]> read(string path){  // Метод для чтения csv файла из path
            string rowData;  // Переменная, в которую запишем все строки из path
            using (StreamReader reader = new StreamReader(path)){
             rowData = reader.ReadToEnd();
            }
            if (rowData.Equals("")) return new List<string[]>();
            string[] subData = rowData.Trim().Split('\n');  // Делим прочитанные данные по переводу строки
            List<string[]> result = new List<string[]>();  // Коллекция, в которой хранится CSharp представление csv
            for (int i = 0; i < subData.Length; i++){
                result.Add(subData[i].Split(';'));  // Добавляем каждую строку в коллекцию
            }
            return result;  // Возвращаем коллекцию
        }
    }
}

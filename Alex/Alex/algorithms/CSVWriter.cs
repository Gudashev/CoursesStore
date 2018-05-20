using System;
using System.Collections.Generic;
using System.IO;

namespace Alex.algorithms
{
    public class CSVWriter
    {
        public static void write(List<string[]> data, string path){
            string toWrite = "";  // Строка, которую будем записывать в csv

            for (int i = 0; i < data.Count; i++){
                toWrite += string.Join(";", data[i]) + "\n";  // Превращаем массив в строку с разделителем ';'
            }

            using (StreamWriter writer = new StreamWriter(path)){
                if (toWrite.Length != 0)
                    writer.Write(toWrite.Substring(0, toWrite.Length - 1));
                else
                    writer.Write(toWrite);
            }
        }
    }
}

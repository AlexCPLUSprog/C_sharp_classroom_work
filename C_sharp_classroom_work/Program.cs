using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace C_sharp_classroom_work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задача 1. Четырехзначное число задом наперёд
            /* Console.WriteLine("Введите четырехзначное число: ");           
             string input = Console.ReadLine();
             for (int i = input.Length - 1; i >= 0; i--)
             {
                 Console.Write(input[i]);
             }
             Console.WriteLine();*/

            // Задача 2. Шестизначное число, выводимое четными цифрами
            /* string six;
             int tmp;        

             Console.WriteLine("Введите шестизначное число: ");
             six = Console.ReadLine();            

             for (int i = 0; i < six.Length; i++)
             {
                 try
                 {
                     tmp = int.Parse(six[i].ToString());
                     //tmp = (int)input[i];
                     if (tmp % 2 == 0)
                     {
                         Console.WriteLine(tmp);
                     }
                 }
                 catch (Exception)
                 {
                     Console.WriteLine("Некоректный ввод");
                 }   
             }
             Console.WriteLine();*/

            // Задача 3. Работа со временем
            // сделать
            /*  while (true)
              {
                  ConsoleKey key = Console.ReadKey().Key;
                  int keyCode = (int)key;
                  Console.WriteLine($"\t Enum {key}\tKey code {keyCode}");           
              }

              DateTime startTime = DateTime.Now;
              Console.WriteLine(startTime.ToString("yyyy.MM.dd hh:mm:ss:fffff"));
              Console.ReadKey();
              DateTime stopTime = DateTime.Now;
              TimeSpan timeSpan = stopTime - startTime;   
              Console.WriteLine($"\nПрошло {timeSpan.ToString("ss")} секунд и {timeSpan.ToString("fff")} миллисекунд");
              Console.ReadKey();

              do
              {
                  ConsoleKey key = Console.ReadKey().Key;
                  int keyCode = (int)key;
                  if (keyCode == 32)
                  {

                  }

              } while (true);*/

            // Задача 4. Показания счетчика

            // Задача 5.

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DateTime dt= DateTime.Now;

            path += "\\" + dt.ToString("HHmmss") + ".txt";
            Console.WriteLine(path);

            var streamWriter = new StreamWriter(path);
            streamWriter.WriteLine("TEST");
            streamWriter.Close();


        }
    }
}

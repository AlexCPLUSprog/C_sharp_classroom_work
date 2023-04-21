using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace C_sharp_classroom_work
{
    enum Month
    {
        Январь = 1,
        Февраль,
        Март,
        Апрель,
        Май,
        Июнь,
        Июль,
        Август,
        Сентябрь,
        Октябрь,
        Ноябрь,
        Декабрь
    }
    class myMeterReader
    {
        int waterCount;
        public int WaterCount
        {
            get
            {
                return waterCount;
            }
            set
            {
                waterCount = value;
            }
        }
        public myMeterReader(int _number)
        {
            waterCount = _number;
        }
        public string convert2Str()
        {
            string _tmp = waterCount.ToString();
            while (_tmp.Length < 8)
            {
                _tmp = "0" + _tmp;
            }
            return _tmp;
        }
    }
    struct MeterReader
    {
        public myMeterReader Cold;
        public myMeterReader Hot;
    }
    class myCounter
    {
        int _min = 0, _max = 99999999;
        List<MeterReader> myBillList = new List<MeterReader>();
        public myCounter(int _cold, int _hot)
        {
            if (_cold >= _min || _cold <= _max)
            {
                if (_hot >= _min || _hot <= _max)
                {
                    MeterReader myMR02;
                    myMR02.Cold = new myMeterReader(_cold);
                    myMR02.Hot = new myMeterReader(_hot);
                    myBillList.Add(myMR02);
                }
            }
        }
        public bool addMetric(int _cold, int _hot)
        {
            bool result = false;
            int _lastElement = myBillList.Count;
            if (myBillList[_lastElement - 1].Cold.WaterCount <= _cold)
            {
                if (myBillList[_lastElement - 1].Hot.WaterCount <= _hot)
                {
                    MeterReader myMR02;
                    myMR02.Cold = new myMeterReader(_cold);
                    myMR02.Hot = new myMeterReader(_hot);
                    myBillList.Add(myMR02);
                    result = true;
                }

            }
            return result;
        }
        public List<MeterReader> getValues()
        {
            return myBillList;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задача 1. Четырехзначное число задом наперёд
            /* Console.WriteLine("Задание 1.\nВведите четырехзначное число: ");           
             string input = Console.ReadLine();
             for (int i = input.Length - 1; i >= 0; i--)
             {
                 Console.Write(input[i]);
             }
             Console.WriteLine();

            // Задача 2. Шестизначное число, выводимое четными цифрами
             string six;
             int tmp;        

             Console.WriteLine("Задание 2.\nВведите шестизначное число: ");
             six = Console.ReadLine();            

             for (int i = 0; i < six.Length; i++)
             {
                 try
                 {
                     tmp = int.Parse(six[i].ToString());                     
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
            /*Console.WriteLine("Задание 3.");
            ConsoleKeyInfo key;
            Console.WriteLine("Нажмите ENTER, чтобы начать забег по кругу, для выхода нажмите SPACE");
            do
            {
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        {
                            DateTime startTime = DateTime.Now;
                            Console.WriteLine("Время и дата начала: " + startTime.ToString("HH:mm:ss yyyy.MM.dd "));
                            Console.WriteLine("=====Забег по кругу пошел=====");
                            Console.ReadKey();
                            DateTime stopTime = DateTime.Now;
                            TimeSpan timeSpan = stopTime - startTime;
                            Console.WriteLine($"\nПробежал круг за {timeSpan.ToString("ss")} секунд и {timeSpan.ToString("fff")} миллисекунд\n");
                            Console.WriteLine("Еще кружок? Нажмите ENTER для нового забега, либо SPACE, чтобы выйти\n");
                            break;
                        }

                    case ConsoleKey.Spacebar: Console.WriteLine("Закрыли секундомер"); break;

                    default: Console.WriteLine("Неправильная клавиша"); break;

                }
            } while (key.Key != ConsoleKey.Spacebar);*/

            // Задача 4,5. Показания счетчика
            Console.WriteLine("Задание 4.\n");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DateTime dt = DateTime.Now;

            path += "\\" + dt.ToString("Показания счетчиков за dd_MM_yy - HH_mm_ss") + ".txt";
            Console.WriteLine(path);
            var streamWriter = new StreamWriter(path);         

           
            int[,] counterArr = new int[,] { { 12, 10 }, { 13, 11 }, { 14, 13 }, { 15, 21 }, { 16, 22 }, { 17, 23 }, { 18, 24 }, { 19, 25 }, { 20, 24 }, { 21, 25 }, { 22, 26 }, { 23, 27 }, { 24, 28 }, { 25, 28 } };
            int _row = counterArr.GetUpperBound(0);
            int _column = counterArr.Length / _row;
            int _cold = 0, _hot = 0;
            myCounter _meterReader = new myCounter(0, 0);
            int sum = 0;
            int _month = 1;
            string myMonth = Enum.GetName(typeof(Month), _month);
            // bool fail = true;

           /* for (int i = 0; i < _month; i++)
            {
                try
                {
                    Console.WriteLine($"Введите показания счетчиков холодной и горячей воды за {myMonth} -> ");

                    _month++;

                }
                catch (Exception)
                {

                    throw;
                }
            }     */                
           

            _month = 1;

            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _column; j++)
                {
                    if (j % 2 == 0)
                    {
                        _cold = counterArr[i, j];
                        Console.Write("Холодная вода = " + counterArr[i, j] + ", ");                        
                    }
                    else
                    {
                        _hot = counterArr[i, j];
                        Console.Write("Горячая вода = " + counterArr[i, j] + ".\n");                        
                    }
                    sum += counterArr[i, j];
                }
                Console.WriteLine($"Попытка добавить значение холодной воды -> \"{_cold}\" и горячей воды -> \"{_hot}\"");
                if (_meterReader.addMetric(_cold, _hot))
                {
                    Console.WriteLine($"Добавлено значение холодной \"{_cold}\" и горячей \"{_hot}\" воды");
                }
                else
                {
                    Console.WriteLine($"Значения холодной \"{_cold}\" и горячей \"{_hot}\" воды не были добавлены");
                }
                Console.WriteLine();
            }

            
            
            _meterReader.getValues().RemoveAt(0);

            {
                foreach (var item in _meterReader.getValues())
                {
                    myMonth = Enum.GetName(typeof(Month), _month);
                    Console.WriteLine($"За {myMonth} \t Холодная = {item.Cold.convert2Str()}, Горячая = {item.Hot.convert2Str()}");
                    streamWriter.WriteLine($"За {myMonth} \t Холодная = {item.Cold.convert2Str()}, Горячая = {item.Hot.convert2Str()}");
                    _month++;
                }
            }
            streamWriter.WriteLine($"\nИтого: {sum}");
            Console.WriteLine($"\nИтого: {sum}");

            streamWriter.Close();            


        }
    }
}

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
    class MeterReaderCold
    {
        int ColdwaterCount;
        public int ColdWaterCount
        {
            get
            {
                return ColdwaterCount;
            }
            set
            {
                ColdwaterCount = value;
            }
        }
        public MeterReaderCold(int _ColdwaterCount)
        {
            ColdwaterCount = _ColdwaterCount;
        }
        public string convertStrCold()
        {
            string _tmp = ColdwaterCount.ToString();
            while (_tmp.Length < 8)
            {
                _tmp = "0" + _tmp;
            }
            return _tmp;
        }
    }
    class MeterReaderHot
    {
        int HotwaterCount;
        public int HotWaterCount
        {
            get
            {
                return HotwaterCount;
            }
            set
            {
                HotwaterCount = value;
            }
        }
        public MeterReaderHot(int _HotWaterCount)
        {
            HotWaterCount = _HotWaterCount;
        }
        public string convertStrHot()
        {
            string _tmp = HotwaterCount.ToString();
            while (_tmp.Length < 8)
            {
                _tmp = "0" + _tmp;
            }
            return _tmp;
        }
    }
    struct MeterReader
    {
        public MeterReaderCold cold;
        public MeterReaderHot hot;
    }
    class myCounter
    {
        int _min = 0, _max = 99999999;
        List<MeterReader> myList = new List<MeterReader>();

        public myCounter(int _cold, int _hot)
        {
            if (_cold >= _min || _cold <= _max)
            {
                if (_hot >= _min || _hot <= _max)
                {
                    MeterReader mystruct;
                    mystruct.cold = new MeterReaderCold(_cold);
                    mystruct.hot = new MeterReaderHot(_hot);
                    myList.Add(mystruct);
                }
            }
        }
        public bool addMetric(int numcold, int numhot)
        {
            bool result = false;
            int _lastElement = myList.Count;
            if (myList[_lastElement - 1].cold.ColdWaterCount <= numcold)
            {
                if (myList[_lastElement - 1].hot.HotWaterCount <= numhot)
                {
                    MeterReader mystruct;
                    mystruct.cold = new MeterReaderCold(numcold);
                    mystruct.hot = new MeterReaderHot(numhot);
                    myList.Add(mystruct);
                    result = true;
                }

            }
            else
            {
                Console.WriteLine("Показания не могут быть меньше предыдущих");
            }
            return result;
        }
        public List<MeterReader> getValues()
        {
            return myList;
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
             Console.WriteLine();

            // Задача 3. Работа со временем
            Console.WriteLine("Задание 3.");
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

            // Проверка особо пока не выходит, но вдруг еще успею что-нибудь придумать)

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DateTime dt = DateTime.Now;

            path += "\\" + dt.ToString("Показания счетчиков за dd_MM_yy - HH_mm_ss") + ".txt";
            Console.WriteLine(path);
            var streamWriter = new StreamWriter(path);
            
            int[,] counterArr = new int[12, 2];
            int _row = counterArr.GetUpperBound(0);
            int _column = counterArr.Length / _row;
            int _cold = 0, _hot = 0, sumcold = 0, sumhot = 0;
            myCounter _meterReader = new myCounter(0, 0);

            int _month = 1;
            string myMonth = Enum.GetName(typeof(Month), _month);

            _month = 1;

            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _column; j++)
                {
                    if (j % 2 == 0)
                    {
                       
                        Console.Write("Холодная вода = ");
                        counterArr[i, j] = int.Parse(Console.ReadLine());
                        _cold = counterArr[i, j];
                        sumcold += counterArr[i, j];
                    }
                    else
                    {
                       
                        Console.Write("Горячая вода = ");
                        counterArr[i, j] = int.Parse(Console.ReadLine());
                        _hot = counterArr[i, j];
                        sumhot += counterArr[i, j];
                    }

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
                    Console.WriteLine($"За {myMonth} \t Холодная = {item.cold.convertStrCold()}, Горячая = {item.hot.convertStrHot()}");
                    streamWriter.WriteLine($"За {myMonth} \t Холодная = {item.cold.convertStrCold()}, Горячая = {item.hot.convertStrHot()}");
                    _month++;
                }
            }
            streamWriter.WriteLine($"\nИтого:\nХолодная  вода: {sumcold}\nГорячая вода: {sumhot}");
            Console.WriteLine($"\nИтого:\nХолодная  вода: {sumcold}\nГорячая вода: {sumhot}");

            streamWriter.Close();


        }
    }
}

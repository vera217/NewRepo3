using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _3rabota
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string fileData = File.ReadAllText("file.txt");
                List<object> fileObjects = Handler.ParseObjects(fileData);
                PrintObjects(fileObjects);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке файла: {ex.Message}");
            }

            Console.WriteLine("Вывод из строки \n");

            try
            {
                string stringData = "Поступление товаров: 2023.01.05;'яблоки'; 20;\n" +
                                    "Поставщик: ООО 'Фрукты'; Петр Иванов; +799912345670;\n" +
                                    "Акт возврата: 2020.03.01; 'яблоки'; 5; Некачественный товар\n ";
                List<object> stringObjects = Handler.ParseObjects(stringData);
                PrintObjects(stringObjects);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке строки: {ex.Message}");
            }
            Console.WriteLine("Нажмите Enter, чтобы завершить...");
            Console.ReadLine();
        }


        static void PrintObjects(List<object> objects)
        {
            foreach (var obj in objects)
            {
                if (obj is Product product) Console.WriteLine(product.PrintInfo());
                else if (obj is Supplier supplier) Console.WriteLine(supplier.PrintInfo());
                else if (obj is ReturnAct returnAct) Console.WriteLine(returnAct.PrintInfo());
            }
        }

    }
}

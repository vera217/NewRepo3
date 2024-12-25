using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rabota
{
    public class Handler
    {
        public static List<object> ParseObjects(string goods)
        {
            var objects = new List<object>();
            var lines = goods.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var entry in lines)
            {
                try
                {
                    if (entry.StartsWith("Поступление товаров:"))
                    {
                        objects.Add(ParseProduct(entry));
                    }
                    else if (entry.StartsWith("Поставщик:"))
                    {
                        objects.Add(ParseSupplier(entry));
                    }
                    else if (entry.StartsWith("Акт возврата:"))
                    {
                        objects.Add(ParseReturnAct(entry));
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }

            return objects;
        }

        public static Product ParseProduct(string entry)
        {
            try
            {
                var parts = entry.Split(';');

                if (parts.Length < 3)
                {
                    throw new ArgumentException("Недостаточно данных для парсинга поступления товаров. \n");
                }

                string datePart = parts[0].Substring(parts[0].IndexOf(":") + 1).Trim();

                if (!DateTime.TryParseExact(datePart, "yyyy.MM.dd", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    throw new FormatException($"Неверный формат даты: '{datePart}'. Ожидается формат 'yyyy.MM.dd'. \n");
                }

                string quantityPart = parts[2].Trim();

                if (string.IsNullOrEmpty(quantityPart))
                {
                    throw new FormatException("Количество товаров не может быть пустым. Ожидается число.");
                }

                int quantity;
                if (!int.TryParse(quantityPart, out quantity))
                {
                    throw new FormatException($"Неверный формат количества товаров: '{quantityPart}'. Ожидается число. \n");
                }

                return new Product(
                    parsedDate,
                    parts[1].Trim(' ', '\''),
                    quantity
                );
            }
            catch (FormatException ex)
            {
                throw new FormatException($"Ошибка формата: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ошибка при парсинге поступления товаров: {ex.Message}");
            }
        }


        public static Supplier ParseSupplier(string entry)
        {
            try
            {
                var parts = entry.Split(';');

                if (parts.Length < 3)
                {
                    throw new ArgumentException("Недостаточно данных для парсинга поставщика.");
                }

                string phoneNumber = parts[2].Trim();

                if (!phoneNumber.StartsWith("+7"))
                {
                    throw new ArgumentException("Неверный формат номера телефона. Ожидается формат '+7...'. \n");
                }

                return new Supplier(
                    parts[0].Trim(),
                    parts[1].Trim(),
                    phoneNumber
                );
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Неверный формат номера телефона. Ожидается формат '+7...'. \n");

            }
        }


        public static ReturnAct ParseReturnAct(string entry)
        {
            try
            {
                var parts = entry.Split(';');

                if (parts.Length < 4)
                {
                    throw new ArgumentException("Недостаточно данных для парсинга акта возврата.");
                }

                string datePart = parts[0].Substring(parts[0].IndexOf(":") + 1).Trim();

                DateTime parsedDate;
                if (!DateTime.TryParseExact(datePart, new[] { "yyyy.MM.dd" }, null, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    throw new FormatException($"Неверный формат даты: '{datePart}'. Ожидается формат 'yyyy.MM.dd' \n");
                }

                return new ReturnAct(
                    parsedDate,
                    parts[1].Trim(' ', '\''),
                    int.Parse(parts[2].Trim()),
                    parts[3].Trim()
                );
            }
            catch (FormatException ex)
            {
                throw new FormatException($"Неверный формат даты: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ошибка при парсинге акта возврата: {ex.Message}");
            }
        }
    }
}
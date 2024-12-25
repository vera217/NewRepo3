using _3rabota;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace TestProject1
{

    public class UnitTest1
    {
        [Fact]
        public void ParseProduct_InvalidQuantity()
        { 
            string input = "Поступление товаров: 2023.01.05; 'яблоки';";

            Assert.Throws<FormatException>(() => Handler.ParseProduct(input));
        }
        [Fact]
        public void ParseProduct_Good()
        {
            string input = "Поступление товаров: 2023.01.05; 'яблоки'; 50";

            Product real = Handler.ParseProduct(input);

            Product good = new Product(new DateTime(2023, 01, 05), "яблоки", 50);

            Product.Equals(real, good);
        }
        [Fact]
        public void ParseReturnAct_ValidInput_ReturnsCorrect()
        {
            string input = "Акт возврата: 2023.01.06; 'бананы'; 5; Некачественный товар";

            ReturnAct real = Handler.ParseReturnAct(input);

            ReturnAct good = new ReturnAct(new DateTime(2023, 01, 06), "бананы", 50, "Некачественный товар");

            ReturnAct.Equals(real, good);

        }
        public void ParseReturnSupplier_ReturnsCorrectSupplier()
        {
            string input = "Поставщик: ООО 'Фрукты'; Петр Петрович; +799912345670";

            Supplier real = Handler.ParseSupplier(input);

            Supplier good = new Supplier("ООО 'Фрукты'", "Петр Петрович", "+799912345670");

            Supplier.Equals(real, good);

        }


        [Fact]
        public void ParseReturnAct_InvalidDateFormat()
        {
            string input = "Акт возврата: 2020-03-01; 'яблоки'; 5; Некачественный товар;";

            Assert.Throws<FormatException>(() => Handler.ParseReturnAct(input));
        }
        [Fact]
        public void ParseProduct_InvalidQuantityType()
        {
            string input = "Поступление товаров: 2023.01.05; 'яблоки'; двадцать;";

            Assert.Throws<FormatException>(() => Handler.ParseProduct(input));
        }

        [Fact]
        public void ParseSupplier_InvalidPhoneFormat()
        {
            string input = "Поставщик: ООО 'Фрукты'; Петр Иванов; 89991234567;";

            Assert.Throws<ArgumentException>(() => Handler.ParseSupplier(input));
        }


    }
}
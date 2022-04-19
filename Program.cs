using System;
using Abbreviation_of_numbers.Scripts;

namespace Abbreviation_of_numbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ExampleMethod();
        }
        
        private static void ExampleMethod()
        {
            var convertorRussian = new NumberConverter(Language.Russian);
            var convertorEnglish = new NumberConverter(Language.English);
            
            var number = 1_000_000_000_000_000_000d;
            
            var resultRussian = convertorRussian.ConvertNumber(number);
            var resultEnglish = convertorEnglish.ConvertNumber(number);

            Console.WriteLine($"Input value: {number:#,#,#}");
            Console.WriteLine($"Russian Degree Name: {resultRussian}");
            Console.WriteLine($"English Degree Name: {resultEnglish}");
        }
        private static void NumbersList()
        {
            var convertor = new NumberConverter(Language.English);
            var number = (double)123_456;
            for (var i = 0; i < 111; i++)
            {
                var result = convertor.ConvertNumber(number);
                Console.WriteLine($"Incoming number:{number:#,#,#} ---> after: {result}");
                number *= 1034;
            }
        }
    }
}
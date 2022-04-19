using System;

namespace Abbreviation_of_numbers.Scripts
{
    public class NumberConverter
    {
        private const int START_SHORT_NUMBER = 1_000_000;
        private readonly int _massiveLength = DegreeNamesList.EnglishNameDegree.Length - 1;
        private readonly Language _language;

        public NumberConverter(Language language)
        {
            _language = language;
        }

        public string ConvertNumber(double value)
        {
            if (double.IsInfinity(value))
                return "Infinity";
            
            if (value == 0) 
                return "0";

            var isNegative = 1;

            if (value < 0)
            {
                isNegative = -1;
                value *= -1;
            }

            if (value < 999) 
                return $"{value}";
            
            if (value < START_SHORT_NUMBER)
                return $"{value * isNegative:#,#,#} ";
            
            var index = -1;
            while (value >= 1000d)
            {
                if (index >= _massiveLength) 
                    break;

                value /= 1000d;
                index++;
            }
            
            var additionallyText = _language switch
            {
                Language.Russian => DegreeNamesList.RussianNameDegree[index],
                Language.English => DegreeNamesList.EnglishNameDegree[index],
                _ => throw new ArgumentOutOfRangeException()
            };
            return $"{(value * isNegative):#.#} {additionallyText}";
        }
    }
}
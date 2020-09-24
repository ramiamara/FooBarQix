using System;
using FooBarQix.Models;
using FooBarQix.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooBarQix.Repository
{
    // manager class to do the calcule using the interface to implement calculate method
    public class FooBarQixRepository : IFooBarQix
    {
        private readonly IList<FooBarQixEntity> listOfFooBarQix;
        public FooBarQixRepository()
        {
            // list of divisor with values
            listOfFooBarQix = new List<FooBarQixEntity>
            {
                    new FooBarQixEntity { Number = 3, Value = "Foo" },
                    new FooBarQixEntity { Number = 5, Value = "Bar" },
                    new FooBarQixEntity { Number = 7, Value = "Qix" }
            };
        }

        /// <summary>
        /// Replace the number with value of divisor and replace if exist difisor by her value
        /// if number contain 0 => replace on the end 0 by *
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public string Calculate(Entry entry)
        {
            string divisible = Divisible(entry.ANumber);
            string containDivisor = ReplaceDivisor(entry);
            string result = divisible + containDivisor;
            if (!result.Equals("")) return result;

            return entry.ANumber.ToString();
        }

        /// <summary>
        /// if entry.number divisible by listOfFooBarQix => replace divisor number by divisor value string
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        private string Divisible(int entry)
        {
            string result = "";
            foreach (FooBarQixEntity divisor in listOfFooBarQix)
            {
                if (entry % divisor.Number == 0)
                    result += divisor.Value;
            }
            return result;
        }

        /// <summary>
        /// Replace divisors(3,5 and 7) by string values
        /// Replace digit 0 by CharReplaced for exemple '*'
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        private string ReplaceDivisor(Entry entry)
        {
            char[] digits = entry.ANumber.ToString().ToCharArray();
            string result = "";
            string charReplace = "";
            foreach (char digit in digits)
            {
                
                foreach (FooBarQixEntity divisor in listOfFooBarQix)
                {
                    if (digit.ToString().Equals(divisor.Number.ToString()))
                        result += divisor.Value;
                }
                // replace 0 by *
                if (digit.Equals('0')) charReplace += entry.CharReplaced;
            }
            return result + charReplace;
        }
    }
}

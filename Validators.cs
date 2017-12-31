using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4Game
{
    class Validators
    {
        public static bool isNumber(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }
    }
}

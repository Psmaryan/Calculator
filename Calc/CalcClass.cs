using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calc
{
    public class CalcClass
    {
        private static bool IsError06(string s, decimal a, decimal? b)
        {
            if (b != null)
            {
                switch (s)
                {
                    case "+": return (a < -2147483648 || a > 2147483647 || b < -2147483648 || b > 2147483647 || (a + b) < -2147483648 || (a + b) > 2147483647);
                    case "-": return (a < -2147483648 || a > 2147483647 || b < -2147483648 || b > 2147483647 || (a - b) < -2147483648 || (a - b) > 2147483647);
                    case "*": return (a < -2147483648 || a > 2147483647 || b < -2147483648 || b > 2147483647 || (a * b) < -2147483648 || (a * b) > 2147483647);
                    case "/": return (a < -2147483648 || a > 2147483647 || b < -2147483648 || b > 2147483647 || (a / b) < -2147483648 || (a / b) > 2147483647);
                    default: return (a < -2147483648 || a > 2147483647 || b < -2147483648 || b > 2147483647 || (a % b) < -2147483648 || (a % b) > 2147483647);
                }
            }
            else
            {
                return (a < -2147483648 || a > 2147483647);
            }
        }
        public static decimal Add(decimal a, decimal b)
        {
            isError = false;
            if (IsError06("+", a, b))
            {
                _lastError = "Error 06";
                isError = true;
                return 0;
            }
            return (decimal)(a + b);
        }

        public static decimal Sub(decimal a, decimal b)
        {
            isError = false;
            if (IsError06("-", a, b))
            {
                _lastError = "Error 06";
                isError = true;
                return 0;
            }
            return (decimal)(a - b);
        }
        public static decimal Mult(decimal a, decimal b)
        {
            isError = false;
            if (IsError06("*", a, b))
            {
                _lastError = "Error 06";
                isError = true;
                return 0;
            }
            return (decimal)(a * b);
        }
        public static decimal Div(decimal a, decimal b)
        {
            isError = false;
            if (b == 0)
            {
                _lastError = "Error 09";
                isError = true;
                return 0;
            }

            if (IsError06("/", a, b))
            {
                _lastError = "Error 06";
                isError = true;
                return 0;
            }
            return (decimal)(a / b);
        }
        public static decimal Mod(decimal a, decimal b)
        {
            isError = false;
            if (b == 0)
            {
                _lastError = "Error 09";
                isError = true;
                return 0;
            }

            if (IsError06("%", a, b))
            {
                _lastError = "Error 06";
                isError = true;
                return 0;
            }
            return (decimal)(a % b);
        }
        public static decimal ABS(decimal a)
        {
            isError = false;
            if (IsError06("", a, null))
            {
                _lastError = "Error 06";
                isError = true;
                return 0;
            }
            return (decimal)Math.Abs(a);
        }
        public static decimal IABS(decimal a)
        {
            isError = false;
            if (IsError06("", a, null))
            {
                _lastError = "Error 06";
                isError = true;
                return 0;
            }
            return (decimal)(-a);
        }

        public static bool isError = false;
        public static string _lastError = "";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calc;

namespace Analaizer
{
    public class AnalaizerClass
    {
        private struct Steck
        {
            public Steck(byte pr, string val)
            {
                priority = pr;
                value = val;
            }
            public byte priority;
            public string value;
        }

        static AnalaizerClass()
        {
            InputExpression = new System.Collections.ArrayList();
        }

        private static System.Collections.ArrayList InputExpression;
        public static int erposition = -1;
        public static string expression = "";
        public static bool ShowMessage = true;

        public static bool CheckCurrency()
        {
            if (expression.Length > 65536)
            {
                ShowMessage = false;
                erposition = -1;
                expression = "Error 07";
                return false;
            }

            int Count = 0;
            int index = 0;
            foreach (char expr in expression)
            {
                if (expr == '(')
                {
                    ++Count;
                    if (Count > 9)
                    {
                        ShowMessage = false;
                        expression = "Error 01";
                        erposition = index;
                        return false;
                    }
                }

                if (expr == ')')
                {
                    if (Count > 0)
                    {
                        --Count;
                    }
                    else
                    {
                        ShowMessage = false;
                        expression = "Error 01";
                        erposition = index;
                        return false;
                    }
                }

                ++index;
            }

            if (Count != 0)
            {
                ShowMessage = false;
                expression = "Error 01";
                erposition = index - 1;
                return false;
            }
            return true;
        }

        public static string Format()
        {
            expression = expression.Replace(" ", "");
            //int index = 0;
            //foreach (char expr in expression)
            for(int j = 0, n = expression.Length; j < n; j++)
            {
                switch (expression[j])
                {
                    case '-':
                    case '+':
                    case '*':
                    case '/':
                    case '%':
                        {
                            bool left = false;
                            bool right = false;
                            for (int i = 0; i < 10; i++)
                            {
                                if (j > 0)
                                {
                                    if (expression[j - 1].ToString().Equals(i.ToString()))
                                    {
                                        left = true;
                                    }
                                }

                                if (j < expression.Length - 1)
                                {
                                    if (expression[j + 1].ToString().Equals(i.ToString()))
                                    {
                                        right = true;
                                    }
                                }
                            }

                            if (j > 0)
                            {
                                if (expression[j - 1].ToString().Equals(")"))
                                {
                                    left = true;
                                }
                            }

                            if (j < expression.Length - 1)
                            {
                                if (expression[j + 1].ToString().Equals("(") || expression[j + 1].ToString().Equals("m") || expression[j + 1].ToString().Equals("p"))
                                {
                                    right = true;
                                }
                            }

                            if (!left)
                            {
                                ShowMessage = false;
                                expression = "Error 03";
                                erposition = j - 1;
                                return expression;
                            }
                            if (!right)
                            {
                                ShowMessage = false;
                                expression = "Error 03";
                                erposition = j + 1;
                                return expression;
                            }
                        }
                        break;
                    case ',':
                        {
                            bool left = false;
                            bool right = false;

                            for (int i = 0; i < 10; i++)
                            {
                                if (j > 0)
                                {
                                    if (expression[j - 1].ToString().Equals(i.ToString()))
                                    {
                                        left = true;
                                    }
                                }

                                if (j < expression.Length - 1)
                                {
                                    if (expression[j + 1].ToString().Equals(i.ToString()))
                                    {
                                        right = true;
                                    }
                                }
                            }

                            if (!left)
                            {
                                ShowMessage = false;
                                expression = "Error 03";
                                erposition = j - 1;
                                return expression;
                            }
                            if (!right)
                            {
                                ShowMessage = false;
                                expression = "Error 03";
                                erposition = j + 1;
                                return expression;
                            }
                        }
                        break;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        {
                            bool left = false;
                            bool right = false;
                            
                            for (int i = 0; i < 10; i++)
                            {
                                if (j > 0)
                                {
                                    if (expression[j - 1].ToString().Equals(i.ToString()))
                                    {
                                        left = true;
                                    }
                                }
                                else left = true;

                                if (j < expression.Length - 1)
                                {
                                    if (expression[j + 1].ToString().Equals(i.ToString()))
                                    {
                                        right = true;
                                    }
                                }
                                else right = true;
                            }

                            if (j > 0)
                            {
                                if (expression[j - 1].ToString().Equals("(") || expression[j - 1].ToString().Equals("+") || expression[j - 1].ToString().Equals("-") ||
                                    expression[j - 1].ToString().Equals("*") || expression[j - 1].ToString().Equals("/") || expression[j - 1].ToString().Equals("%") ||
                                    expression[j - 1].ToString().Equals("m") || expression[j - 1].ToString().Equals("p") || expression[j - 1].ToString().Equals(","))
                                {
                                    left = true;
                                }
                            }

                            if (j < expression.Length - 1)
                            {
                                if (expression[j + 1].ToString().Equals(")") || expression[j + 1].ToString().Equals("+") || expression[j + 1].ToString().Equals("-") ||
                                    expression[j + 1].ToString().Equals("*") || expression[j + 1].ToString().Equals("/") || expression[j + 1].ToString().Equals("%") ||
                                    expression[j + 1].ToString().Equals(","))
                                {
                                    right = true;
                                }
                            }

                            if (!left)
                            {
                                ShowMessage = false;
                                expression = "Error 03";
                                erposition = j - 1;
                                return expression;
                            }
                            if (!right)
                            {
                                ShowMessage = false;
                                expression = "Error 03";
                                erposition = j + 1;
                                return expression;
                            }
                        }
                        break;
                    case 'm':
                    case 'p':
                        {
                            bool left = false;
                            bool right = false;
                            for (int i = 0; i < 10; i++)
                            {
                                if (j < expression.Length - 1)
                                {
                                    if (expression[j + 1].ToString().Equals(i.ToString()))
                                    {
                                        right = true;
                                    }
                                }
                            }

                            if (j < expression.Length - 1)
                            {
                                if (expression[j + 1].ToString().Equals("("))
                                {
                                    right = true;
                                }
                            }

                            if (j > 0)
                            {
                                if (expression[j - 1].ToString().Equals("(") || expression[j - 1].ToString().Equals("+") || expression[j - 1].ToString().Equals("-") ||
                                    expression[j - 1].ToString().Equals("*") || expression[j - 1].ToString().Equals("/") || expression[j - 1].ToString().Equals("%"))
                                {
                                    left = true;
                                }
                            } else left = true;

                            if (!left)
                            {
                                ShowMessage = false;
                                expression = "Error 03";
                                erposition = j - 1;
                                return expression;
                            }
                            if (!right)
                            {
                                ShowMessage = false;
                                expression = "Error 03";
                                erposition = j + 1;
                                return expression;
                            }

                        }
                        break;
                    case '(':
                        {
                            bool left = false;
                            bool right = false;
                            for (int i = 0; i < 10; i++)
                            {
                                if (j < expression.Length - 1)
                                {
                                    if (expression[j + 1].ToString().Equals(i.ToString()))
                                    {
                                        right = true;
                                    }
                                }
                            }

                            if (j < expression.Length - 1)
                            {
                                if (expression[j + 1].ToString().Equals("(") || expression[j + 1].ToString().Equals("m") || expression[j + 1].ToString().Equals("p"))
                                {
                                    right = true;
                                }
                            }
                            if (j > 0)
                            {
                                if (expression[j - 1].ToString().Equals("(") || expression[j - 1].ToString().Equals("+") || expression[j - 1].ToString().Equals("-") ||
                                    expression[j - 1].ToString().Equals("*") || expression[j - 1].ToString().Equals("/") || expression[j - 1].ToString().Equals("%") ||
                                    expression[j - 1].ToString().Equals("m") || expression[j - 1].ToString().Equals("p"))
                                {
                                    left = true;
                                }
                            }
                            else left = true;

                            if (!left)
                            {
                                ShowMessage = false;
                                expression = "Error 03";
                                erposition = j - 1;
                                return expression;
                            }
                            if (!right)
                            {
                                ShowMessage = false;
                                expression = "Error 03";
                                erposition = j + 1;
                                return expression;
                            }
                        }
                        break;
                    case ')':
                        {
                            bool left = false;
                            bool right = false;
                            for (int i = 0; i < 10; i++)
                            {
                                if (j > 0)
                                {
                                    if (expression[j - 1].ToString().Equals(i.ToString()))
                                    {
                                        left = true;
                                    }
                                }
                            }

                            if (j > 0)
                            {
                                if (expression[j - 1].ToString().Equals(")"))
                                {
                                    left = true;
                                }
                            }
                            if (j < expression.Length - 1)
                            {
                                if (expression[j + 1].ToString().Equals(")") || expression[j + 1].ToString().Equals("+") || expression[j + 1].ToString().Equals("-") ||
                                    expression[j + 1].ToString().Equals("*") || expression[j + 1].ToString().Equals("/") || expression[j + 1].ToString().Equals("%"))
                                {
                                    right = true;
                                }
                            }
                            else right = true;

                            if (!left)
                            {
                                ShowMessage = false;
                                expression = "Error 03";
                                erposition = j - 1;
                                return expression;
                            }
                            if (!right)
                            {
                                ShowMessage = false;
                                expression = "Error 03";
                                erposition = j + 1;
                                return expression;
                            }
                        }
                        break;
                    default:
                        {
                            ShowMessage = false;
                            expression = "Error 02";
                            erposition = j;
                            return expression;
                        }
                        break;
                }

                //++index;
                //End Foreach;
            }

            for (int i = 0, n = expression.Length; i < n; i++)
            {
                if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/' || expression[i] == '%')
                {
                    expression = expression.Insert(i, " ");
                    expression = expression.Insert(i + 2, " ");
                    n += 2;
                    i += 2;
                }
            }

            return expression;
            //End Format;
        }

        public static void CreateStack()
        {
            InputExpression = new System.Collections.ArrayList();
            //expression = "22 12 - 3 * 5 + 5 /";
            string[] IE1 = expression.Split(' ');

            if (IE1.Length > 30)
            {
                expression = "Error 08";
                ShowMessage = false;
                return;
            }
            
            string expression1 = expression.Replace("(", "( ") ;
            expression1 = expression1.Replace(")", " )");
            expression1 = expression1.Replace("m", "m ");
            expression1 = expression1.Replace("p", "p ");
            expression1 = expression1.Replace("  ", " ");

            string[] IE = expression1.Split(' ');

            System.Collections.ArrayList result = new System.Collections.ArrayList();
            List<Steck> listSteck = new List<Steck>();

            foreach (var ie in IE)
            {
                if (ie != "+" && ie != "-" && ie != "*" && ie != "/" && ie != "%" && ie != "m" && ie != "p" && ie != "(" && ie != ")")
                {
                    result.Add(ie);
                }
                else
                {
                    switch (ie[0])
                    {
                        case 'm':
                        case 'p':
                            {
                                if (listSteck.Count <= 0)
                                {
                                    if (ie[0] == 'm')
                                        listSteck.Add(new Steck((byte)5, "m"));
                                    else
                                        listSteck.Add(new Steck((byte)5, "p"));
                                    break;
                                }

                                Steck str = listSteck.Last();
                                int position = listSteck.Count - 1;
                                while (str.priority >= 5 && position >= 0)
                                {
                                    result.Add(str.value);
                                    --position;
                                    if (position >= 0)
                                        str = listSteck[position];

                                    listSteck.RemoveAt(position + 1);
                                }

                                if (ie[0] == 'm')
                                    listSteck.Add(new Steck((byte)5, "m"));
                                else
                                    listSteck.Add(new Steck((byte)5, "p"));

                            }
                            break;

                        case '(':
                            listSteck.Add(new Steck((byte)0, "("));
                            break;
                        case ')':
                            {
                                string str = listSteck.Last().value;
                                int position = listSteck.Count - 1;
                                while (str != "(")
                                {
                                    result.Add(str);
                                    --position;
                                    str = listSteck[position].value;
                                    listSteck.RemoveAt(position + 1);
                                }
                                listSteck.RemoveAt(listSteck.Count - 1);
                            }
                            break;
                        case '+':
                        case '-':
                            {
                                if (listSteck.Count <= 0)
                                {
                                    if (ie[0] == '+')
                                        listSteck.Add(new Steck((byte)2, "+"));
                                    else
                                        listSteck.Add(new Steck((byte)2, "-"));
                                    break;
                                }

                                Steck str = listSteck.Last();
                                int position = listSteck.Count - 1;
                                while (str.priority >= 2 && position >= 0)
                                {
                                    result.Add(str.value);
                                    --position;
                                    if(position >= 0)
                                         str = listSteck[position];

                                    listSteck.RemoveAt(position + 1);
                                }

                                if (ie[0] == '+')
                                    listSteck.Add(new Steck((byte)2, "+"));
                                else
                                    listSteck.Add(new Steck((byte)2, "-"));
                            }
                            break;
                        case '*':
                        case '/':
                        case '%':
                            {
                                if (listSteck.Count <= 0)
                                {
                                    if (ie[0] == '*')
                                        listSteck.Add(new Steck((byte)3, "*"));
                                    else if (ie[0] == '/')
                                        listSteck.Add(new Steck((byte)3, "/"));
                                    else
                                        listSteck.Add(new Steck((byte)3, "%"));
                                    break;
                                }

                                Steck str = listSteck.Last();
                                int position = listSteck.Count - 1;
                                while (str.priority >= 3 && position >= 0)
                                {
                                    result.Add(str.value);
                                    --position;
                                    if (position >= 0)
                                        str = listSteck[position];

                                    listSteck.RemoveAt(position + 1);
                                }

                                if (ie[0] == '*')
                                    listSteck.Add(new Steck((byte)3, "*"));
                                else if (ie[0] == '/')
                                    listSteck.Add(new Steck((byte)3, "/"));
                                else
                                    listSteck.Add(new Steck((byte)3, "%"));
                            }
                            break;
                    }
                }
            }

            for (int i = listSteck.Count - 1; i >= 0; i--)
            {
                result.Add(listSteck[i].value);
            }

            InputExpression = result;
        }

        public static string RunEstimate()
        {
           /* string InputExpression = "2 2 - 33 * 11 - 5 6 + +";
            ICollection<string> listExpression; // = new List<string>();
            listExpression = InputExpression.Split(' ');*/

            List<decimal> res = new List<decimal>();

            foreach (string ie in InputExpression)
            {
                if (!(ie == "+" || ie == "-" || ie == "*" || ie == "/" || ie == "%" || ie == "m" || ie == "p"))
                {
                    decimal r;
                    if (Decimal.TryParse(ie, out r))
                        res.Add(r);
                    else
                    {
                        ShowMessage = false;
                        expression = "Error 07";
                        return expression;
                    }
                }
                else
                {
                    switch (ie[0])
                    {
                        case '+':
                            res[res.Count - 2] = CalcClass.Add(res[res.Count - 2], res[res.Count - 1]);
                            break;
                        case '-':
                            res[res.Count - 2] = CalcClass.Sub(res[res.Count - 2], res[res.Count - 1]);
                            break;
                        case '*':
                            res[res.Count - 2] = CalcClass.Mult(res[res.Count - 2], res[res.Count - 1]);
                            break;
                        case '/':
                            res[res.Count - 2] = CalcClass.Div(res[res.Count - 2], res[res.Count - 1]);
                            break;
                        case '%':
                            res[res.Count - 2] = CalcClass.Mod(res[res.Count - 2], res[res.Count - 1]);
                            break;
                        case 'm':
                            res[res.Count - 1] = CalcClass.IABS(res[res.Count - 1]);
                            break;
                        case 'p':
                            res[res.Count - 1] = (res[res.Count - 1]);
                            break;
                    }

                    if (CalcClass.isError)
                    {
                        expression = CalcClass._lastError;
                        ShowMessage = false;
                        return expression;
                    }

                    if(ie[0] != 'm' && ie[0] != 'p')
                       res.RemoveAt(res.Count - 1);
                }
            }

            expression = res[0].ToString();
            return expression;
        }

        public static string Estimate()
        {
            if (!CheckCurrency())
            {
                if (erposition != -1)
                    return expression + ": position " + (erposition + 1).ToString();
                else
                    return expression;
            }
           
            expression = Format();
            if (!ShowMessage)
            {
                if (erposition != -1)
                    return expression + ": position " + (erposition + 1).ToString();
                else
                    return expression;
            }
            
            CreateStack();

            if (!ShowMessage)
            {
                  return expression;
            }

            expression = RunEstimate();

            return expression;
        }
    }
}

using System;

namespace LabApp2
{
    class Program
    {
        static void InBrackets(ref string expression, int i)
        {
            //делаем объект класса с другого файла
            Calculations calc = new Calculations();
            int sum = 0, sub = 0, mult = 0, div = 0;
            
            //считаем количество знаков вычислений ИМЕННО В ЭТОЙ СКОБКЕ
            for (int j = i + 1; j < expression.Length; j++)
            {
                // если конец нашей скобки то выходим
                if (expression[j] == ')') break;
                
                if (expression[j] == '+') sum++;
                else if (expression[j] == '-') sub++;
                else if (expression[j] == '*') mult++;
                else if (expression[j] == '/') div++;
                
                // если у нас внутри нашей скобки еще скобка то рекурсией в неё уходим
                if (expression[j] == '(')
                    InBrackets(ref expression, j);
            }

            int g = i+1;
            int firstNum = g;
            // вычисляем что у нас есть в скобке сначала умножение\деление
            while (mult != 0 || div != 0)
            {
                if (expression[g] == '*')
                    calc.Mult(ref expression, ref g, ref mult, firstNum);
                else if (expression[g] == '/')
                    calc.Div(ref expression, ref g, ref div, firstNum);
                g++;
            }

            g = i+1;
            firstNum = g;
            // потом вычитание и ложение
            while (sum != 0 || sub != 0)
            {
                if (expression[g] == '(')
                    InBrackets(ref expression, g);
                
                if (expression[g] == '+')
                    calc.Sum(ref expression, ref g, ref sum, firstNum);
                else if (expression[g] == '-')
                    calc.Sub(ref expression, ref g, ref sub, firstNum);
                g++;
            }
            
            //под конец мы удаляем скобки и оставляем только полученный результат
            int brackCl = 0;
            for (int j = i+1; j < expression.Length; j++)
                if (expression[j] == ')')
                {
                    brackCl = j;
                    break;
                }
            expression = expression.Remove(i, 1);
            expression = expression.Remove(brackCl-1, 1);
        }
        static double Calculator(string expression)
        {
            // два объекта класса из двух разных файлов
            // (первый за преобразования между типами переменный
            // второй вычисления проводит)
            Additional addClass = new Additional();
            Calculations calc = new Calculations();
            
            //смотрим сколько у нас скобок(на самом деле чтоб понять если ли они вщ)
            int fullBrackets = 0;
            for (int i = 0; i < expression.Length; i++)
                if (expression[i] == '(') fullBrackets++;

            // делаем операции внутри скобок (тут же проверям что скобки правильно расставлены)
            if (fullBrackets != 0)
            {
                //проверка правильно ли скобки расставлены
                CheckBrackets checkBrackets = new CheckBrackets();
                if (checkBrackets.Check(expression))
                {
                    for (int i = 0; i < expression.Length; i++)
                        if (expression[i] == '(')
                            InBrackets(ref expression, i);
                }
                else 
                    throw new Exception("Brackets incorrectly");
            }
            
            // после того как скобок больше нет мы считаем сколько осталось того, что посчитать
            int sum = 0, sub = 0, mult = 0, div = 0;
            for (int i = 0; i < expression.Length; i++)
                if (expression[i] == '+') sum++;
                else if (expression[i] == '-') sub++;
                else if (expression[i] == '*') mult++;
                else if (expression[i] == '/') div++;
            
            //проверка остались ли умножение и деление
            if(mult != 0 || div != 0)
            {
                int i = 0;
                //число, к которому мы будем возвращаться после вычисления(как бы начало выражения)
                int firstNum = i;
                while(mult != 0 || div != 0)
                {
                    //цикл работает пока у нас еще есть умнож И деление
                    if (expression[i] == '*')
                        calc.Mult(ref expression, ref i, ref mult, firstNum);
                    else if (expression[i] == '/')
                        calc.Div(ref expression, ref i, ref div, firstNum);
                    // чтоб двигались по символам в строке выражения
                    i++;
                }
            }
            
            //остались с=ли вычитание и сложение
            if(sum != 0 || sub != 0)
            {
                int i = 0;
                int firstNum = i;
                while(sum != 0 || sub != 0)
                {
                    if (expression[i] == '+')
                        calc.Sum(ref expression, ref i, ref sum, firstNum);
                    else if (expression[i] == '-')
                        calc.Sub(ref expression, ref i, ref sub, firstNum);
                    i++;
                }
            }
            
            // удаляем знак равенства(который в конце)
            int equal = expression.Length - 1;
            expression = expression.Remove(equal);
            double ResultVal = addClass.StringToDouble(expression);
            
            return ResultVal;
        }
        static void Main(string[] args)
        {
            //string expression = "2+7*(3/9)-5=";
            string expression = "2*(3*4*(2+3))-(2*30)-5=";
            double result = Calculator(expression);
            Console.WriteLine("Result: " + result);
        }
    }
}



/*На вход подаётся математическое выражение. 
Элементы - числа. Операции - "+ - * /". 
Также есть скобочки. Окончанием выражения служит "=". 
Программа должна вывести результат выражения

Пример ввода:
2+7*(3/9)-5=*/

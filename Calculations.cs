namespace LabApp2;

public class Calculations
{
    private Additional addClass = new Additional();
    // сюда будем класть результат одного вычисления(*/+-)
    private double result = 0;
    
    //вычисление суммы 
    public void Sum(ref string expression, ref int i, ref int sum, int firstNum)
    {
        //ищем число стоящее слево от знака
        string num1S = "";
        for (int j = i-1; j >= 0; j--)
        {
            // если встречаемся не с цифрой то выходим
            if (expression[j] == '+' || expression[j] == '-' || expression[j] == '(' || expression[j] == ')')
                break;
            // прибавляем по одной цифре к строке пустой
            num1S += expression[j].ToString();
        }
        // делаем это число задом наперёд(123 -> 321)
        num1S = addClass.CharToString(num1S.Reverse().ToArray());
            
        // второе число ищем
        string num2S = "";
        for (int j = i+1; j < expression.Length; j++)
        {
            if (expression[j] == '+' || expression[j] == '-' || expression[j] == '=' || expression[j] == '(' || expression[j] == ')')
                break;
            num2S += expression[j].ToString();
        }
        // преобразование из строки в дабл
        double num1D = addClass.StringToDouble(num1S);
        double num2D = addClass.StringToDouble(num2S);
                
        // вычисляем что нам нужно
        result = num1D + num2D;
                        
        // создаем строку этого вычисления чтобы её потом изменить в исходном выражении
        string replace = num1S + "+" + num2S;
        // заменяем вычисление на результат
        expression = expression.Replace(replace, addClass.DoubleToString(result));
        result = 0;
                        
        // на одну операцию суммы у нас стало меньше
        sum--;
        // меняем счётчик нашего прохода по выражению на первый элемент результата
        i = firstNum;
    }
    public void Sub(ref string expression, ref int i, ref int sub, int firstNum)
    {
        string num1S = "";
        for (int j = i-1; j >= 0; j--)
        {
            if (expression[j] == '+' || expression[j] == '-' || expression[j] == '(' || expression[j] == ')')
                break;
            num1S += expression[j].ToString();
        }
        num1S = addClass.CharToString(num1S.Reverse().ToArray());
        
        string num2S = "";
        for (int j = i+1; j < expression.Length; j++)
        {
            if (expression[j] == '+' || expression[j] == '-' || expression[j] == '=' || expression[j] == '(' || expression[j] == ')')
                break;
            num2S += expression[j].ToString();
        }
        double num1D = addClass.StringToDouble(num1S);
        double num2D = addClass.StringToDouble(num2S);

        result = num1D - num2D;

        string replace = num1S + "-" + num2S;
        expression = expression.Replace(replace, addClass.DoubleToString(result));
        result = 0;
                        
        sub--;
        i = firstNum;
    }
    public void Mult(ref string expression, ref int i, ref int mult, int firstNum)
    {
        string num1S = "";
        for (int j = i-1; j >= 0; j--)
        {
            if (expression[j] == '*' || expression[j] == '/'
                    || expression[j] == '+' || expression[j] == '-' || expression[j] == '(' || expression[j] == ')')
                break;
            num1S += expression[j].ToString();
        }
        num1S = addClass.CharToString(num1S.Reverse().ToArray());
                        
        string num2S = "";
        for (int j = i+1; j < expression.Length; j++)
        {
            if (expression[j] == '*' || expression[j] == '/'
                    || expression[j] == '+' || expression[j] == '-' || expression[j] == '=' || expression[j] == '(' || expression[j] == ')')
                break;
            num2S += expression[j].ToString();
        }
        double num1D = addClass.StringToDouble(num1S);
        double num2D = addClass.StringToDouble(num2S);
                        
        result = num1D * num2D;
                        
        string replace = num1S + "*" + num2S;
        expression = expression.Replace(replace, addClass.DoubleToString(result));
        result = 0;
        
        mult--;
        i = firstNum;
    }
    public void Div(ref string expression, ref int i, ref int div, int firstNum)
    {
        string num1S = "";
        for (int j = i-1; j >= 0; j--)
        {
            if (expression[j] == '*' || expression[j] == '/'
                    || expression[j] == '+' || expression[j] == '-' || expression[j] == '(' || expression[j] == ')')
                break;
            num1S += expression[j].ToString();
        }
        num1S = addClass.CharToString(num1S.Reverse().ToArray());
                        
        string num2S = "";
        for (int j = i+1; j < expression.Length; j++)
        {
            if (expression[j] == '*' || expression[j] == '/'
                || expression[j] == '+' || expression[j] == '-' || expression[j] == '=' || expression[j] == '(' || expression[j] == ')')
                break;
            num2S += expression[j].ToString();
        }
        if (num2S == "0")
            throw new Exception("It can't be divided by 0");
        
        double num1D = addClass.StringToDouble(num1S);
        double num2D = addClass.StringToDouble(num2S);

        result = num1D / num2D;

        string replace = num1S + "/" + num2S;
        expression = expression.Replace(replace, addClass.DoubleToString(result));
        result = 0;
        
        div--;
        i = firstNum;
    }
}
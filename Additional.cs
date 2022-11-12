namespace LabApp2;

public class Additional
{
    public double StringToDouble(string line)
    {
        return Convert.ToDouble(line);
    }
    public string DoubleToString(double number)
    {
        return Convert.ToString(number);
    }
    public string CharToString(char[] arr)
    {
        string result = "";
        for (int i = 0; i < arr.Length; i++)
        {
            result += arr[i];
        }
        return result;
    }
}
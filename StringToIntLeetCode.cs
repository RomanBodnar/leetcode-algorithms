namespace algorithms.LeetCode;
public class StringToIntLeetCode 
{
    public int MyAtoi(string s) 
    {   

        var trimmed = s.Trim(' ');
        bool isNegative = s.StartsWith('-');
        if(string.IsNullOrEmpty(trimmed)) return 0;
        string result = string.Empty;
        foreach(var c in trimmed)
        {
            if((c >= '0' && c <= '9'))
            {
                result += c;
            }
            else if((c == '+' || c == '-') && trimmed.StartsWith(c))
            {
                result += c;
            }
            else break;
        }
        if(result.IsNullOrEmpty() || !result.Any(c => c >= '0' && c <= '9')) return 0;
       
        if(isNegative)
        {
            if(Int32.MinValue.ToString().Length <= result.Length)
            {
                return Int32.MinValue;
            }
        }
        else
        {
            if(Int32.MaxValue.ToString().Length <= result.Length)
            {
                return Int32.MaxValue - 1;
            }
        }
        return Convert.ToInt32(result);
    }


}
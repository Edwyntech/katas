namespace Katas;

public class FizzBuzz
{
    public string Print(int n)
    {
        var output = string.Empty;

        if (n % 3 == 0)
        {
            output += "Fizz";
        }
        if (n % 5 == 0)
        {
            output += "Buzz";
        }

        if (string.IsNullOrWhiteSpace(output))
        {
            output += n;
        }

        return output;
    }
}
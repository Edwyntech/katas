namespace Katas.LINQ;

public class NewLinq
{
    public IEnumerable<int> Select(IEnumerable<int> list, Func<int, int> func)
    {
        var output = new List<int>();
        foreach (var i in list)
        {
            output.Add(func(i));
        }

        return output;
    }
    
    public IEnumerable<int> Where(IEnumerable<int> list, Func<int, bool> predicate)
    {
        var output = new List<int>();
        foreach (var i in list)
        {
            if (predicate(i))
            {
                output.Add(i);
            }
        }

        return output;
    }
    
    public bool Any(IEnumerable<int> list, Func<int, bool> predicate)
    {
        foreach (var i in list)
        {
            if (predicate(i))
            {
                return true;
            }
        }

        return false;
    }
}
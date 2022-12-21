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
    
    // What can we replace Func<int, bool> with ? => Predicate
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
    
    // To go further
    // How to make the functions usable for any kind of object other than int
}
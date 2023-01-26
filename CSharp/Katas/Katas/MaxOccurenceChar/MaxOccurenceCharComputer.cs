namespace Katas.MaxOccurenceChar;

public class MaxOccurenceCharComputer
{
    public char ComputeMaxOccurenceChar(string input)
    {
        var charGrouped = input.ToCharArray().GroupBy(a => a);
        var maxOccurence = charGrouped.Select(a => a.Count()).Max();
        return charGrouped.FirstOrDefault(a => a.Count() == maxOccurence).Key;
    }
}
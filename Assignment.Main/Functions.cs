
using System.Text;
class Functions
{

    public static void Main(string[] args){
        Console.WriteLine(Map(new List<int>(){1,2,3}, x => x +2));
    }

    private static List<B> Map<A, B>(List<A> list, Func<A, B> f)
    {

        if (list?.Any() != true)
        {
            return new List<B>();
        }
        if (f == null)
        {
            throw new ArgumentNullException("Input function cannot be null.");
        }
        var result = new List<B>(list.Count());
        foreach (var element in list)
        {
            if (element == null) continue;
            result.Add(f(element));
        }
        return result;
    }



    private static B Fold<A, B>(List<A> list, B initial, Func<B, A, B> folder)
    {
        if (list?.Any() != true) return initial;
        if (folder == null)
        {
            throw new ArgumentNullException("Input function cannot be null.");
        }
        if (initial == null)
        {
            throw new ArgumentNullException("Input initial cannot be null.");
        }
        B result = initial;
        foreach (var element in list)
        {
            if (element == null) continue;
            result = folder(result, element);
        }
        return result;
    }

    // Strings are immutable. StringBuilder must be used for string arrays.
    private static string Fold<A>(List<A> list, string initial, Func<string, A, string> folder)
    {
        if (list?.Any() != true) return initial;
        if (folder == null)
        {
            throw new ArgumentNullException("Input function cannot be null.");
        }
        if (initial == null)
        {
            throw new ArgumentNullException("Input initial cannot be null.");
        }
        StringBuilder result = new StringBuilder(initial);
        foreach (var element in list)
        {
            if (element == null) continue;
            result.Append(folder(initial, element));
        }
        return result.ToString();
    }

    private static List<B> Map2<A, B>(List<A> list, Func<A, B> f)
    {
        if (list?.Any() != true)
        {
            return new List<B>();
        }
        if (f == null)
        {
            throw new ArgumentNullException("Input function cannot be null.");
        }
        var result = new List<B>(list.Count());
        var emptyList = new List<A>();
        foreach (var element in list)
        {
            var trick = f(element);
            result.Add(Fold(emptyList, trick, (sum, x) => sum));
        }
        return result;
    }

}

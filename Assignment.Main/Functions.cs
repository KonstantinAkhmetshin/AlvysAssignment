
using System.Text;

namespace Assignment.Main
{
    public class Functions
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Alvys");
        }

        public static List<B> Map<A, B>(List<A> list, Func<A, B> f)
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

        public static B Fold<A, B>(List<A> list, B initial, Func<B, A, B> folder)
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

        // Strings are immutable. In the case of a very large input array memory issues could be faced. StringBuilder must be used for string arrays.
        public static string Fold<A>(List<A> list, string initial, Func<string, A, string> folder)
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

        public static List<B> Map2<A, B>(List<A> list, Func<A, B> f)
        {
            if (list?.Any() != true)
            {
                return new List<B>();
            }
            if (f == null)
            {
                throw new ArgumentNullException("Input function cannot be null.");
            }

            return Fold(list, new List<B>(), (state, element) =>
            {
                state.Add(f(element));
                return state;
            });

            // OR that way 
            // var result = new List<B>(list.Count());
            // var emptyList = new List<A>();
            // foreach (var element in list)
            // {
            //     result.Add(Fold(emptyList, f(element), (state, element) => state));
            // }
            // return result;
        }

    }
}
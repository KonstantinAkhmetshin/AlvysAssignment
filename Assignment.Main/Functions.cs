
using System.Text;

namespace Assignment.Main
{
    public class Functions
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Alvys");
        }

        public static List<B> Map<A, B>(List<A> list, Func<A, B> func)
        {
            if (list?.Any() != true)
            {
                return new List<B>();
            }
            MapAgrsValidator(func);
            var result = new List<B>(list.Count());
            foreach (var element in list)
            {
                if (element == null) continue;
                result.Add(func(element));
            }
            return result;
        }

        public static B Fold<A, B>(List<A> list, B initial, Func<B, A, B> folder)
        {
            if (list?.Any() != true) return initial;
            FoldArgsValidator(initial, folder);
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
            FoldArgsValidator(initial, folder);
            StringBuilder result = new StringBuilder(initial);
            foreach (var element in list)
            {
                if (element == null) continue;
                result.Append(folder(initial, element));
            }
            return result.ToString();
        }

        public static List<B> Map2<A, B>(List<A> list, Func<A, B> func)
        {
            if (list?.Any() != true)
            {
                return new List<B>();
            }
            MapAgrsValidator(func);
            return Fold(list, new List<B>(), (state, element) =>
            {
                state.Add(func(element));
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
        private static void FoldArgsValidator<A,B>(B initial, Func<B, A, B> folder)
        {
            if (folder == null)
            {
                throw new ArgumentNullException("Input function cannot be null.");
            }
            if (initial == null)
            {
                throw new ArgumentNullException("Input initial cannot be null.");
            }
        }

        private static void MapAgrsValidator<A,B>(Func<A, B> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException("Input function cannot be null.");
            }
        }
    }
}
using IntStreamProblem.Containers;
using System;
using System.Threading.Tasks;
using System.Threading;
namespace IntStreamProblem
{
    using Logic;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            IIntContainer lst = new IntContainer();
            Task.Run(() => Utils.Add(lst,TimeSpan.FromMilliseconds(10)));

            while (true)
            {
                var res = Utils.Count01(lst);
                PrintDict01(res);
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
        }

        static void PrintDict01(Dictionary<int,int> d)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"0 - {d[0]}");
            Console.WriteLine($"1 - {d[1]}");
            Console.WriteLine("------------------------------");
        }
    }

    public class Utils
    {
        public static IGenerator _gen;
        public static IGenerator Gen 
        {
            get => _gen = _gen ?? new IntGenerator();
            set => _gen = value ?? throw new ArgumentNullException();
        }
        
        public static void Add(IIntContainer lst, TimeSpan interval)
        {
            while (true)
            {
                lst.Add(Gen.Generate());
                Thread.Sleep(interval);
            }
        }

        public static Dictionary<int, int> Count01(IIntContainer lst)
        {
            var dict01 = new Dictionary<int, int>
            {
                { 0, 0 },
                { 1, 0 }
            };

            foreach (var item in lst.Read())
            {
                if (dict01.ContainsKey(item))
                {
                    dict01[item] += 1;
                }
                else 
                {
                    dict01.Add(item, 1);
                }
            }

            return dict01;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace IntStreamProblem.Logic
{
    public interface IGenerator
    {
        int Generate();
    }


    public class IntGenerator : IGenerator
    {
        private Random _rand { get; set; } = new Random();
        public int Generate() => _rand.Next(0,10);
    }
}

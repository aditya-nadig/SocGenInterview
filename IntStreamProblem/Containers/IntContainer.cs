using System;
using System.Collections.Generic;
using System.Text;

namespace IntStreamProblem.Containers
{
    public interface IIntContainer
    {
        bool Add(int item);
        IEnumerable<int> Read();
    }

    public class IntContainer : IIntContainer
    {
        private List<int> Container { get; set; } = new List<int>();
        private Object lockObject = new object();
        
        public bool Add(int item)
        {
            lock (lockObject)
            {
                Container.Add(item);
            }

            return true;
        }

        public IEnumerable<int> Read()
        {
            lock (lockObject)
            {
                foreach (var item in Container)
                {
                    yield return item;
                }
            }
            
        }
    }
}

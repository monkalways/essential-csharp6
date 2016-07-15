using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter16
{
    interface IPair<T>
    {
        T First { get; }
        T Second { get; }

        T this[PairItem index] { get; }
    }

    public enum PairItem
    {
        First,
        Second
    }

    public class Pair<T> : IPair<T>, IEnumerable<T>
    {
        public Pair(T first, T second)
        {
            First = first;
            Second = second;
        }
        public T First { get; }

        public T Second { get; }

        public T this[PairItem index]
        {
            get
            {
                switch (index)
                {
                    case PairItem.First:
                        return First;
                    case PairItem.Second:
                        return Second;
                    default:
                        throw new NotImplementedException($"The enum {index} has not been implemented");
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return First;
            yield return Second;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter16
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        public BinaryTree(T value)
        {
            Value = value;
        }

        public T Value { get; }
        public Pair<BinaryTree<T>> SubItems { get; set; } 

        public IEnumerator<T> GetEnumerator()
        {
            // Return the item at this node.
            yield return Value;

            if (SubItems != null)
            {
                // Iterate through each of elements in the pair
                foreach (BinaryTree<T> tree in SubItems)
                {
                    if (tree != null)
                    {
                        //Since each element in the pair is a tree
                        // traverse the tree and yield each element
                        foreach (T item in tree)
                        {
                            yield return item;
                        }
                    }
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

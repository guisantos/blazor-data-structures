using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisualDataStructure.Model;

namespace VisualDataStructure.Data
{
    public class StackService
    {
        public LinkedListNode Head { get; set; }
        public int Count { get; private set; }

        public void Add(int value)
        {
            LinkedListNode temp = Head;

            Head = new LinkedListNode(value)
            {
                Next = temp
            };

            Count++;
        }

        public bool Remove()
        {
            if (Count == 0)
            {
                return false;
            }

            if (Count == 1)
            {
                Clear();
                return true;
            }

            Head = Head.Next;
            Count--;
            return true;
        }

        public IEnumerator<LinkedListNode> GetEnumerator()
        {
            LinkedListNode current = Head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisualDataStructure.Data
{
    public class LinkedListService : ICollection<int>
    {
        public LinkedListNode Head { get; set; }
        public LinkedListNode Tail { get; set; }

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(int item)
        {
            AddFirst(item);
        }

        public void AddFirst(int value)
        {
            LinkedListNode temp = Head;

            Head = new LinkedListNode(value)
            {
                Next = temp
            };

            if (Count == 0)
            {
                Tail = Head;
            }

            Count++;
        }

        public void AddLast(int value)
        {
            if (Count == 0)
            {
                AddFirst(value);
                return;
            }

            LinkedListNode current = Head;

            while (current != Tail)
            {
                current = current.Next;
            }

            current.Next = new LinkedListNode(value);
            Tail = current.Next;

            Count++;
        }

        public void RemoveFirst()
        {
            if (Count == 0)
            {
                return;
            }
            else if (Count == 1)
            {
                Clear();
                return;
            }

            Head = Head.Next;
            Count--;
        }

        public void RemoveLast()
        {
            if (Count == 0)
            {
                return;
            }
            else if (Count == 1)
            {
                Clear();
                return;
            }

            LinkedListNode current = Head;

            while (current.Next != Tail)
            {
                current = current.Next;
            }

            current.Next = null;
            Tail = current;

            Count--;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(int item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<int> GetEnumerator()
        {
            LinkedListNode current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool Remove(int item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<int>)this).GetEnumerator();
        }
    }
}

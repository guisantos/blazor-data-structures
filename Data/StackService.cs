using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisualDataStructure.Data
{
    public class StackService : ICollection<int>
    {
        public LinkedListNode Head { get; set; }

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

        public IEnumerator<LinkedListNode> GetList()
        {
            LinkedListNode current = Head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        #region ICollection

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
            LinkedListNode temp = Head;

            Head = new LinkedListNode(item)
            {
                Next = temp
            };

            Count++;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public bool Contains(int item)
        {
            LinkedListNode current = Head;
            while (current != null)
            {
                if (current.Value == item)
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
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
            return Remove();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<int>)this).GetEnumerator();
        }

        #endregion
    }
}

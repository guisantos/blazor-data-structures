using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VisualDataStructure.Model;

namespace VisualDataStructure.Data
{
    public class LinkedListService
    {
        public LinkedListNode Head { get; set; }
        public LinkedListNode Tail { get; set; }
        public int Count { get; private set; }

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

        public int? RemoveFirst()
        {
            if (Count == 0)
            {
                return null;
            }

            int currentHeadValue = Head.Value;

            Head = Head.Next;
            Count--;

            if(Count == 0)
            {
                Clear();
            }

            return currentHeadValue;
        }

        public int? RemoveLast()
        {
            if (Count == 0)
            {
                return null;
            }

            int currentTailValue = Tail.Value;

            if (Count == 1)
            {
                Clear();
                return currentTailValue;
            }

            LinkedListNode current = Head;

            while (current.Next != Tail)
            {
                current = current.Next;
            }

            current.Next = null;
            Tail = current;

            Count--;

            return currentTailValue;
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
            Tail = null;
            Count = 0;
        }
    }
}

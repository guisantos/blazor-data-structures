using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisualDataStructure.Model;

namespace VisualDataStructure.Data
{
    public class QueueService
    {
        public LinkedListNode Head { get; set; }
        public LinkedListNode Tail { get; set; }
        public int Count { get; private set; }

        public void Enqueue(int value)
        {
            LinkedListNode newNode = new LinkedListNode(value);

            if (Count == 0)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                LinkedListNode currentTail = Tail;

                Tail = newNode;
                currentTail.Next = Tail;
            }

            Count++;
        }

        public void Dequeue()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Clear();
                }
                else
                {
                    Head = Head.Next;
                    Count--;
                }
            }
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisualDataStructure.Data
{
    public class LinkedListNode
    {
        public int Value { get; set; }
        public LinkedListNode Next { get; set; }

        public LinkedListNode(int value)
        {
            Value = value;
        }
    }
}
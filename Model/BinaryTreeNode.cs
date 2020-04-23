using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace VisualDataStructure.Model
{
    public class BinaryTreeNode : IComparable<int>
    {
        public int Value { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        public BinaryTreeNode Father { get; set; }

        public BinaryTreeNode(int value)
        {
            Value = value;
        }

        public int CompareTo(int value)
        {
            return Value.CompareTo(value);
        }
    }
}

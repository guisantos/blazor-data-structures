using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using VisualDataStructure.Model;

namespace VisualDataStructure.Data
{
    public class BinaryTreeService
    {
        public BinaryTreeNode Root { get; set; }
        public int Count { get; set; }


        public void Add(int value)
        {
            BinaryTreeNode newNode = new BinaryTreeNode(value);

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                AddToTree(Root, newNode);
            }

            Count++;
        }

        private void AddToTree(BinaryTreeNode head, BinaryTreeNode newNode)
        {
            if (newNode.CompareTo(head.Value) < 0)
            {
                Console.WriteLine("menor");

                if (head.Left == null)
                {
                    newNode.Father = head;
                    head.Left = newNode;
                }
                else
                {
                    AddToTree(head.Left, newNode);
                }
            }
            else
            {
                if (head.Right == null)
                {
                    newNode.Father = head;
                    head.Right = newNode;
                }
                else
                {
                    AddToTree(head.Right, newNode);
                }
            }
        }

        public bool Contains(int value)
        {
            BinaryTreeNode parent;
            return FindWithParents(value, out parent) != null;
        }

        public BinaryTreeNode FindWithParents(int value, out BinaryTreeNode parent)
        {
            BinaryTreeNode current = Root;
            parent = null;

            while (current != null)
            {
                int result = current.CompareTo(value);

                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        public bool Remove(int value)
        {
            BinaryTreeNode current, parent;

            current = FindWithParents(value, out parent);

            if (current == null)
            {
                return false;
            }

            Count--;

            //removed has no right child
            if (current.Right == null)
            {
                if (parent == null)
                {
                    Root = current.Left;
                    Root.Father = null;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Left;
                        if (parent.Left != null)
                        {
                            parent.Left.Father = current.Father;
                        }
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Left;
                        if (parent.Right != null)
                        {
                            parent.Right.Father = current.Father;
                        }
                    }
                }
            }
            //removed has no left child then right child replace it
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (current.Right.Left != null)
                {
                    current.Right.Left.Father = current.Right;
                }

                if (parent == null)
                {
                    Root = current.Right;
                    Root.Father = null;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Right;
                        if (parent.Left != null)
                        {
                            parent.Left.Father = current.Father;
                        }
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Right;
                        if (parent.Right != null)
                        {
                            parent.Right.Father = current.Father;
                        }
                    }
                }
            }
            else
            {
                BinaryTreeNode leftMost = current.Right.Left;
                BinaryTreeNode leftMostParent = current.Right;

                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;

                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                {
                    Root = leftMost;
                    Root.Father = null;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = leftMost;
                        if (parent.Left != null)
                        {
                            parent.Left.Father = leftMost.Father;
                        }
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftMost;
                        if (parent.Right != null)
                        {
                            parent.Right.Father = leftMost.Father;
                        }
                    }
                }
            }

            return true;
        }

        public RenderFragment GetTreeView()
        {
            return builder =>
            {
                PreOrderTraversal(builder, Root);
            };
        }

        public void PreOrderTraversal(RenderTreeBuilder builder, BinaryTreeNode node)
        {
            if (node != null)
            {
                if (node.Father?.Right == node && node.Father?.Left == null)
                {
                    builder.OpenElement(0, "ul");
                }
                else if (node.Father?.Left == node)
                {
                    builder.OpenElement(0, "ul");
                }

                if (node != Root)
                {
                    builder.OpenElement(1, "li");
                }

                builder.OpenElement(0, "a");
                builder.AddAttribute(1, "href", " ");
                //builder.AddAttribute(2, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, () => Remove(node.Value)));
                builder.AddEventPreventDefaultAttribute(3, "onclick", true);
                builder.AddContent(4, node.Value);
                builder.CloseElement();

                PreOrderTraversal(builder, node.Left);
                PreOrderTraversal(builder, node.Right);

                if (node != Root)
                {
                    builder.CloseElement();
                }

                if (node.Father?.Right == node)
                {
                    builder.CloseElement();
                }
                else if (node.Father?.Left == node && node.Father?.Right == null)
                {
                    builder.CloseElement();
                }
            }
        }
    }
}
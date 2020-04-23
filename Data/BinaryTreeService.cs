using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public RenderFragment GetSomeRawHtml()
        {
            return builder =>
            {
                PreOrderTraversal(builder, Root);
            };

            //{
            //    builder.OpenElement(0, "ul");
            //        builder.OpenElement(1, "li");
            //            builder.OpenElement(2, "a");
            //            builder.AddAttribute(2, "href", "#");
            //            builder.AddContent(2, 1);
            //            builder.CloseElement();
            //            builder.OpenElement(3, "ul");
            //                builder.OpenElement(4, "li");
            //                    builder.OpenElement(5, "a");
            //                    builder.AddAttribute(6, "href", "#");
            //                    builder.AddContent(6, 2);
            //                    builder.CloseElement();
            //                builder.CloseElement();
            //                builder.OpenElement(7, "li");
            //                    builder.OpenElement(8, "a");
            //                    builder.AddAttribute(9, "href", "#");
            //                    builder.AddContent(9, 3);
            //                    builder.CloseElement();
            //                builder.CloseElement();
            //            builder.CloseElement();
            //        builder.CloseElement();
            //    builder.CloseElement();
            //};
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

                builder.OpenElement(2, "a");
                builder.AddAttribute(2, "href", "#");
                builder.AddContent(2, node.Value);
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
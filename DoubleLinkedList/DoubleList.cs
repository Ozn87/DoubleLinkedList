using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedList
{
    public class DoubleList<T>
    {
        public DoubleNode<T> Head { get;  set; }
        public DoubleNode<T> Tail { get;  set; }
        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            AddFirst(new DoubleNode<T>(value));
        }

        private void AddFirst(DoubleNode<T> node)
        {
            //save off the head
            DoubleNode<T> temp = Head;
            //point head to new node
            Head = node;

            //insert the rest of the list after the head
            Head.Next = temp;

            //check to see if the list was empty at time of creation
            if (Count == 0)
            {
                Tail = Head;
            }
            else
            {
                //update previous ref of the former head
                temp.Previous = Head;
            }
            Count++;

        }

        public void AddLast(T value)
        {
            AddLast(new DoubleNode<T>(value));
        }

        private void AddLast(DoubleNode<T> node)
        {
            if(Count == 0)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
                Tail=node;
            }
            Count++;
        }


        public void RemoveFirst()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }
            //shift head
            Head = Head.Next;
            Count--;

            if(Count == 0)
            {
                Tail = null;
            }
            else
            {
                Head.Previous = null;
            }

        }

        public void RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            if(Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Previous.Next = null; //null last node
                Tail = Tail.Previous;// shift the tail
            }
            Count--;
        }
    }
}

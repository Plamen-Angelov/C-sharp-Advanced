
using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private int count;

        public int Count 
        {
            
            private set 
            {
                count = value;
            }
            get
            {
                return count;
            }
        }

        public ListNode<T> Head { get; set; }

        public ListNode<T> Tail { get; set; }


        public void AddFirst(T element)
        {
            ListNode<T> newNode = new ListNode<T>(element);

            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                Head.PreveousNode = newNode;
                newNode.NextNode = Head;
                Head = newNode;
            }
            Count++;
        }

        public void AddLast(T element)
        {
            ListNode<T> newNode = new ListNode<T>(element);

            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail.NextNode = newNode;
                newNode.PreveousNode = Tail;
                Tail = newNode;
            }
            Count++;
        }

        public T RemoveFirst()
        {
            IsValidOperation();

            ListNode<T> node = Head;
            ListNode<T> second = node.NextNode;

            if (second == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                second.PreveousNode = null;
                Head = second;
            }

            Count--;

            return node.Value;
        }

        

        public T RemoveLast()
        {
            IsValidOperation();

            ListNode<T> node = Tail;
            ListNode<T> prev = Tail.PreveousNode;

            if (prev == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                prev.NextNode = null;
                Tail = prev;
            }

            Count--;

            return node.Value;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentNode = Head;

            while (currentNode != null)
            {
                action(currentNode.Value);

                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];
            ListNode<T> currentNode = Head;

            for (int i = 0; i < Count; i++)
            {
                arr[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return arr;
        }

        private void IsValidOperation()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("DoublyLinkedList is empty!");
            }
        }
    }
}

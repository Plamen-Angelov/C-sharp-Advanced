using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.AddFirst(5);
            list.AddFirst(3);
            list.AddFirst(2);
            list.AddLast(1);
            list.AddLast(4);
            list.AddLast(8);

            Console.WriteLine(list.Count);
            list.ForEach(Console.Write);
            Console.WriteLine();

            Console.WriteLine(list.RemoveFirst());
            list.RemoveLast();

            Console.WriteLine(list.Count);

            int[] arr = list.ToArray();
            Console.WriteLine(string.Join(' ', arr));
        }
    }
}

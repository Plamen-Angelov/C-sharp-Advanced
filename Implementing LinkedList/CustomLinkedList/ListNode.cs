
namespace CustomDoublyLinkedList
{
    public class ListNode<T>
    {
        public T Value { get; set; }

        public ListNode<T> PreveousNode { get; set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode(T value)
        {
            Value = value;
            PreveousNode = null;
            NextNode = null;
        }
    }
}

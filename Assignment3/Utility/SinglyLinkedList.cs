using Assignment3;
using Assignment3.Utility;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment3.Utility
{
    

    public class SLL<T> : ILinkedListADT<T>
    {
        private Node<T> head;
        private int count;

        public SLL()
        {
            head = null;
            count = 0;
        }

        public void AddFirst(T value)
        {
            Node<T> newNode = new Node<T> { Value = value, Next = head };
            head = newNode;
            count++;
        }

        public void AddLast(T value)
        {
            Node<T> newNode = new Node<T> { Value = value, Next = null };

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            count++;
        }


        public void Add(T value, int index)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException("Index is out of range.");

            if (index == 0)
            {
                AddFirst(value);
                return;
            }
            else if (index == count)
            {
                AddLast(value);
                return;
            }

            Node<T> newNode = new Node<T> { Value = value };

            Node<T> current = head;
            for (int i = 0; i < index - 1; i++)
                current = current.Next;

            newNode.Next = current.Next;
            current.Next = newNode;

            count++;
        }

        public void Replace(T value, int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index is out of range.");

            Node<T> current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            current.Value = value;
        }

        public int Count()
        {
            return count;
        }

        public void RemoveFirst()
        {
            if (head == null)
                throw new CannotRemoveException("Cannot remove from an empty list.");

            head = head.Next;
            count--;
        }

        public void RemoveLast()
        {
            if (head == null)
                return;

            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                Node<T> current = head;
                while (current.Next.Next != null)
                    current = current.Next;

                current.Next = null;
            }

            count--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index is out of range.");

            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            Node<T> current = head;
            for (int i = 0; i < index - 1; i++)
                current = current.Next;

            current.Next = current.Next.Next;
            count--;
        }

        public T GetValue(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index is out of range.");

            Node<T> current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            return current.Value;
        }

        public int IndexOf(T value)
        {
            Node<T> current = head;
            for (int i = 0; i < count; i++)
            {
                if (Equals(current.Value, value))
                    return i;
                current = current.Next;
            }

            return -1;
        }

        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }
    }
}

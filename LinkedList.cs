using System;
using System.Collections.Generic;

namespace HospitalManagementSystem
{
    class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T>? Next { get; set; }

        public LinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }
    }

    class LinkedList<T>
    {
        private LinkedListNode<T>? head;
        private LinkedListNode<T>? tail;
        public int Count { get; private set; }

        public LinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void AddEnd(T data)
        {
            var newNode = new LinkedListNode<T>(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                if (tail != null)
                {
                    tail.Next = newNode;
                    tail = newNode;
                }
            }
            Count++;
        }

        public void Traverse(Action<T> action)
        {
            var current = head;
            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }

        public bool Contains(T data)
        {
            var current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void Remove(T data)
        {
            if (head == null)
                return;

            if (head.Data.Equals(data))
            {
                head = head.Next;
                if (head == null)
                    tail = null;
                Count--;
                return;
            }

            var current = head;
            while (current.Next != null)
            {
                if (current.Next.Data.Equals(data))
                {
                    current.Next = current.Next.Next;
                    if (current.Next == null)
                        tail = current;
                    Count--;
                    return;
                }
                current = current.Next;
            }
        }
        public List<T> ToList()
        {
            List<T> list = new List<T>();
            var current = head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
            return list;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            var current = head;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }
            return array;
        }
    }
}
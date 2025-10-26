using System;
using System.Collections.Generic;

namespace DoublyLinkedListLib
{
    public class DoublyLinkedList<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;
            public Node Prev;

            public Node(T data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }

        private Node head;
        private Node tail;

        // Insertar de forma ordenada ascendente
        public void InsertSorted(T data)
        {
            var newNode = new Node(data);

            if (head == null)
            {
                head = tail = newNode;
                return;
            }

            if (data.CompareTo(head.Data) <= 0)
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
                return;
            }

            var current = head;
            while (current.Next != null && data.CompareTo(current.Next.Data) > 0)
            {
                current = current.Next;
            }

            if (current.Next == null)
            {
                current.Next = newNode;
                newNode.Prev = current;
                tail = newNode;
            }
            else
            {
                newNode.Next = current.Next;
                newNode.Prev = current;
                current.Next.Prev = newNode;
                current.Next = newNode;
            }
        }

        // Helper: añadir al final
        private void AddLast(T data)
        {
            var node = new Node(data);
            if (tail == null)
            {
                head = tail = node;
                return;
            }

            tail.Next = node;
            node.Prev = tail;
            tail = node;
        }

        public void DisplayForward()
        {
            var temp = head;
            while (temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }

        public void DisplayBackward()
        {
            var temp = tail;
            while (temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Prev;
            }
            Console.WriteLine();
        }

        // Reconstruye la lista en orden descendente
        public void SortDescending()
        {
            if (head == null) return;

            var current = head;
            var list = new List<T>();
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }

            list.Sort();
            list.Reverse();

            head = tail = null;
            foreach (var item in list)
                AddLast(item);
        }

        public bool Exists(T data)
        {
            var current = head;
            while (current != null)
            {
                if (current.Data.CompareTo(data) == 0) return true;
                current = current.Next;
            }
            return false;
        }

        public bool RemoveOne(T data)
        {
            var current = head;
            while (current != null)
            {
                if (current.Data.CompareTo(data) == 0)
                {
                    if (current == head)
                    {
                        head = head.Next;
                        if (head != null) head.Prev = null;
                        else tail = null;
                    }
                    else if (current == tail)
                    {
                        tail = tail.Prev;
                        if (tail != null) tail.Next = null;
                        else head = null;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public int RemoveAll(T data)
        {
            int count = 0;
            // Iterate once and remove all occurrences safely:
            var current = head;
            while (current != null)
            {
                var next = current.Next;
                if (current.Data.CompareTo(data) == 0)
                {
                    // Remove current node in-place
                    if (current == head)
                    {
                        head = head.Next;
                        if (head != null) head.Prev = null;
                        else tail = null;
                    }
                    else if (current == tail)
                    {
                        tail = tail.Prev;
                        if (tail != null) tail.Next = null;
                        else head = null;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    count++;
                }
                current = next;
            }
            return count;
        }

        public void ShowModes()
        {
            var counts = new Dictionary<T, int>();
            var current = head;
            while (current != null)
            {
                if (!counts.ContainsKey(current.Data)) counts[current.Data] = 0;
                counts[current.Data]++;
                current = current.Next;
            }

            if (counts.Count == 0)
            {
                Console.WriteLine("No hay elementos.");
                return;
            }

            int max = 0;
            foreach (var kv in counts)
                if (kv.Value > max) max = kv.Value;

            Console.WriteLine("Moda(s):");
            foreach (var kv in counts)
                if (kv.Value == max) Console.WriteLine(kv.Key);
        }

        public void ShowFrequencyGraph()
        {
            var counts = new Dictionary<T, int>();
            var current = head;
            while (current != null)
            {
                if (!counts.ContainsKey(current.Data)) counts[current.Data] = 0;
                counts[current.Data]++;
                current = current.Next;
            }

            Console.WriteLine("Gráfico de frecuencias:");
            foreach (var kv in counts)
                Console.WriteLine($"{kv.Key}: {new string('*', kv.Value)}");
        }
    }   
}

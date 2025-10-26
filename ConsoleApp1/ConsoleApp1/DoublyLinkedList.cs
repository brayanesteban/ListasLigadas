using System;

namespace DoublyLinkedListApp
{
    // Thin wrapper that forwards to the library implementation.
    // Keep this file only if you prefer to use DoublyLinkedList<T> in the console app namespace.
    internal class DoublyLinkedList<T> where T : IComparable<T>
    {
        private readonly DoublyLinkedListLib.DoublyLinkedList<T> impl = new DoublyLinkedListLib.DoublyLinkedList<T>();

        internal void DisplayBackward() => impl.DisplayBackward();
        internal void DisplayForward() => impl.DisplayForward();
        internal bool Exists(T value) => impl.Exists(value);
        internal void InsertSorted(T value) => impl.InsertSorted(value);
        internal int RemoveAll(T value) => impl.RemoveAll(value);
        internal bool RemoveOne(T value) => impl.RemoveOne(value);
        internal void ShowFrequencyGraph() => impl.ShowFrequencyGraph();
        internal void ShowModes() => impl.ShowModes();
        internal void SortDescending() => impl.SortDescending();
    }
}
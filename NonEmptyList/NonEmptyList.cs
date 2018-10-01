using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace NonEmptyList
{
    /// <summary>
    /// A list that can never be empty. Supports most of the IList interface, but makes changes where necessary
    /// (e.g. there's no `clear`, and removal operations all return `bool` and will fail if there is only one element in the list)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NonEmptyList<T> : IEnumerable<T>
    {
        public T Head => xs.First();

        public IEnumerable<T> Tail => xs.Skip(1);

        private IList<T> xs;

        public NonEmptyList(T head, IEnumerable<T> tail = null) =>
            xs = new []{head}.Concat(tail ?? new List<T>()).ToList();


        // List funtionality
        public int Count => xs.Count;
        public bool IsReadOnly => xs.IsReadOnly;
        public int IndexOf(T item) => xs.IndexOf(item);
        public void Insert(int index, T item) => xs.Insert(index, item);
        public void Add(T item) => xs.Add(item);
        public bool Contains(T item) => xs.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => xs.CopyTo(array, arrayIndex);
        public bool Remove(T item) => xs.Count > 1 ? xs.Remove(item) : false;
        public bool RemoveAt(int index)
        {
            if (xs.Count > 1 && index < xs.Count)
            {
                xs.RemoveAt(index);
                return true;
            }
            return false;
        }

        // IEnumerable implementation
        public IEnumerator<T> GetEnumerator() => xs.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => xs.GetEnumerator();
    }
}

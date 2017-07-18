using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    /// <summary>
    /// Base Class
    /// </summary>
    /// <typeparam name="T">Generic</typeparam>
    public abstract class HeapSort<T> where T : IComparable<T>
    {
        protected IList<T> _heap;

        private int _lastNode = -1;

        public int Length => _heap != null ? _heap.Count : 0;

        public HeapSort()
        {
            _heap = new List<T>();
        }

        public HeapSort(int size)
        {
            _heap = new T[size];
        }

        protected void _Swap(int l, int largest)
        {
            T swap = _heap[l];
            _heap[l] = _heap[largest];
            _heap[largest] = swap;
        }

        private void _DoHeapify()
        {
            if (_lastNode != 0)
                for (int i = (_lastNode + 1) / 2 - 1; i >= 0; i--)
                    Heapify(_lastNode + 1, i);
        }

        private void _Remove(int nodeIndex)
        {
            _Swap(nodeIndex, _lastNode);

            if (_heap is List<T>)
                _heap.RemoveAt(_lastNode);

            _lastNode--;

            if (nodeIndex != 0)
                _DoHeapify();
        }

        public void Sort()
        {
            _DoHeapify();

            for (int i = _lastNode; i >= 0; i--)
            {
                // Move current root to end
                if (i != 0)
                    _Swap(0, i);

                Heapify(i, 0);
            }
        }

        public T[] GetArray()
        {
            return _heap is T[] ? _heap as T[] : _heap.ToArray<T>();
        }

        public T PeakTopNode()
        {
            if (_lastNode == -1)
                throw new InvalidOperationException("The heap is empty.");
            return _heap[0];
        }

        public void Add(T node)
        {
            if (object.ReferenceEquals(node, null))
                throw new ArgumentNullException();

            //validate the size
            if ((_heap is List<T>))
            {
                _lastNode++;

                //add the note to the array
                _heap.Add(node);
                _DoHeapify();
            }
            else
            {
                if (_lastNode == _heap.Count)
                    throw new OverflowException("The max size has been reached.");

                _lastNode++;

                //add the note to the array
                _heap[_lastNode] = node;
                _DoHeapify();
            }
        }

        public void Remove(T node)
        {
            if (_lastNode == -1)
                throw new InvalidOperationException("The heap is empty.");
            if (object.ReferenceEquals(node, null))
                throw new ArgumentNullException();

            //find the node
            int nodeIndex = Array.IndexOf<T>(_heap.ToArray<T>(), node);
            _Remove(nodeIndex);

        }

        public void RemoveAt(int nodeIndex)
        {
            if (_lastNode == -1)
                throw new InvalidOperationException("The heap is empty.");
            if (nodeIndex < 0)
                throw new ArgumentOutOfRangeException();
            _Remove(nodeIndex);
        }

        protected abstract void Heapify(int n, int i);

    }
    
}

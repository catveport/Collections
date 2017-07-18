using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public sealed class MinHeapSort<T> : HeapSort<T> where T : IComparable<T>
    {
        protected override void Heapify(int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            // If left child is larger than root
            if (l < n && base._heap[l].CompareTo(base._heap[largest]) < 0)
                largest = l;

            // If right child is larger than largest so far
            if (r < n && base._heap[r].CompareTo(base._heap[largest]) < 0)
                largest = r;

            // If largest is not root
            if (largest != i)
            {
                base._Swap(i, largest);

                // Recursively heapify the affected sub-tree
                Heapify(n, largest);
            }
        }
    }

}

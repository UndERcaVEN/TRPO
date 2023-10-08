using System.Diagnostics;

namespace BinaryMinheap
{
    /// <summary>
    /// Basic binary heap implementation
    /// </summary>
    /// <typeparam name="T">type of heap nodes</typeparam>
    public class MinHeap<T>
        where T : IComparable<T>
    {
        private T[] _array;

        public MinHeap()
        {
            _array = Array.Empty<T>();
        }

        /// <summary>
        /// Returns the count of elements in the heap
        /// </summary>
        public int ElementsCount => _array.Length;

        /// <summary>
        /// Adds the element to the heap
        /// </summary>
        /// <param name="element">element value</param>
        /// <returns>index of the added element</returns>
        public int AddElement(T element)
        {
            Array.Resize(ref _array, ElementsCount + 1);

            int elementIndex = ElementsCount - 1;
            _array[elementIndex] = element;

            while (elementIndex > 0)
            {
                int parentIndex = GetParentIndex(elementIndex);

                if (element.CompareTo(_array[parentIndex]) >= 0) return elementIndex;

                _array.Swap(parentIndex, elementIndex); // swap the elements
                elementIndex = parentIndex;
            }

            return elementIndex;
        }

        /// <summary>
        /// Extracts the minimal element (root) from the heap
        /// </summary>
        /// <returns></returns>
        public T ExtractMin()
        {
            Debug.Assert(ElementsCount > 0); // Caller's responsibility to check if heap is empty

            T result = _array[0];
            _array[0] = _array[^1];
            _array = _array.SkipLast(1).ToArray();
            Reheap();

            return result;
        }

        /// <summary>
        /// Retrieves the minimal (root) element of the heap without dequeueing it
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            Debug.Assert(ElementsCount > 0); // Caller's responsibility to check if heap is empty
            return _array[0];
        }

        /// <summary>
        /// Reheaps the element so that they satisfy the minheap rules
        /// </summary>
        private void Reheap()
        {
            if (ElementsCount == 0)
                return;

            int elementIndex = 0;
            int newIndex = -1;

            while (newIndex != 0)
            {
                newIndex = ReheapWithChildren(elementIndex);
            }
        }

        /// <summary>
        /// Checks if children of a heap node satisfy the minheap requirements in regard to the node
        /// If requirements aren't satisfied, elements are reorganized 
        /// </summary>
        /// <param name="parentIndex"></param>
        /// <returns>new index of the parent element</returns>
        private int ReheapWithChildren(int parentIndex)
        {
            int left = parentIndex * 2 + 1;
            int right = parentIndex * 2 + 2;

            T parent = _array[parentIndex];

            int min = parentIndex;

            if (left < ElementsCount)
                if (_array[left].CompareTo(_array[min]) < 0)
                {
                    min = left;
                }
            if (right < ElementsCount)
                if (_array[right].CompareTo(_array[min]) < 0)
                {
                    min = right;
                }

            if (parent.CompareTo(_array[min]) > 0)
            {
                _array.Swap(min, parentIndex);
                min = ReheapWithChildren(min);
            }

            return min;
        }

        /// <summary>
        /// Calculates the index of the parent element to the given node
        /// </summary>
        /// <param name="childIndex">index of the child element</param>
        /// <returns>parent element index</returns>
        private static int GetParentIndex(int childIndex) => (int)Math.Floor((childIndex - 1) / 2.0);
    }
}

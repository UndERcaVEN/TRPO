using System.Diagnostics;

namespace BinaryTreeTraversal
{
    /// <summary>
    /// Basic binary heap implementation
    /// </summary>
    /// <typeparam name="T">type of heap nodes</typeparam>
    public class BinaryTree<T>
    {
        private T[] _array;

        public BinaryTree()
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
        public void AddElement(T element)
        {
            Array.Resize(ref _array, ElementsCount + 1);

            int elementIndex = ElementsCount - 1;
            _array[elementIndex] = element;
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

        public T ElementAt(int index)
        {
            Debug.Assert(index >= 0);
            return _array[index];
        }

        /// <summary>
        /// Calculates the index of the parent element to the given node
        /// </summary>
        /// <param name="childIndex">index of the child element</param>
        /// <returns>parent element index</returns>
        public int GetParentIndex(int childIndex) => (int)Math.Floor((childIndex - 1) / 2.0);
    }
}

using System.Diagnostics;

namespace BinaryMinheap
{
    public static class Extensions
    {
        /// <summary>
        /// Swaps places of 2 array elements
        /// </summary>
        /// <typeparam name="T">array elements type</typeparam>
        /// <param name="arr">array</param>
        /// <param name="firstIndex">index of the first element</param>
        /// <param name="secondIndex">index of the second element</param>
        public static void Swap<T>(this T[] arr, int firstIndex, int secondIndex)
        {
            // Caller's responsibility to assert indexes are in range of the array
            Debug.Assert(firstIndex >= 0 && secondIndex >= 0); 
            Debug.Assert(firstIndex <= arr.Length && secondIndex <= arr.Length);

            (arr[firstIndex], arr[secondIndex]) = (arr[secondIndex], arr[firstIndex]);
        }
    }
}

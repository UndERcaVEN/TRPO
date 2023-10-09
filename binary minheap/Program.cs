using BinaryMinheap;

internal class Program
{
    private static void Main(string[] args)
    {
        var heap = new MinHeap<int>();

        Console.WriteLine("1 to add a number 2 to dequeue a min number or 3 to peek a min number\n");
        while (true)
        {
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    heap.AddElement(RequestNumber());
                    break;
                case '2':
                    Console.WriteLine(DequeueMinElement(heap));
                    break;
                case '3':
                    Console.WriteLine(heap.Peek());
                    break;
                case 'q':
                    return;
            }
        }
    }

    /// <summary>
    /// Returns the minimal (root) element of the heap dequeueing it from the heap
    /// </summary>
    /// <param name="heap">heap to dequeue from</param>
    /// <returns></returns>
    private static string DequeueMinElement(MinHeap<int> heap)
    {
        if (heap.ElementsCount > 0)
        {
            return $"Min element is: {heap.ExtractMin()}";
        }

        return "Heap is empty!";
    }

    /// <summary>
    /// Requests the user to input a number
    /// </summary>
    /// <returns>received number</returns>
    private static int RequestNumber()
    {
        Console.Write("Enter number: ");
        return int.Parse(Console.ReadLine());
    }
}
namespace BinaryHeap
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rnd = new Random();
            var heap = new BinaryHeap();

            for (int i = 0; i < 100; i++)
            {
                heap.Add(rnd.Next(-100, 101));
            }

            foreach (var item in heap)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}

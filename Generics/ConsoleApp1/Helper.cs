using static System.Reflection.Metadata.BlobBuilder;

namespace ConsoleApp1
{
    public static class Helper
    {
        public static void AddItemToArray<T>(ref T[] array, T item)
        {
            Array.Resize(ref array, array.Length + 1);
            array[^1] = item;
        }

        public static void ShowAllBooksInArray<T>(ref T[] array)
        {
            foreach (T thing in array)
            {
                Console.WriteLine(thing.ToString());
            }
        }
    }
}

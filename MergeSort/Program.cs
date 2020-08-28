using System;
using System.Diagnostics;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var testArray3 = new int[50000000];
       
            RandomFill(testArray3);

            var timer = new Stopwatch();
            timer.Start();
            Sort(ref testArray3);
            timer.Stop();
            
            Console.Write(timer.ElapsedMilliseconds);
        }

        public static void Sort(ref int[] array)
        {
            if (array.Length < 2)
                return;

            var array1 = new int[array.Length / 2];
            var array2 = new int[array.Length - array1.Length];

            for (var i = 0; i < array.Length; i++)
            {
                if (i < array1.Length)
                    array1[i] = array[i];
                else
                {
                    array2[i - array1.Length] = array[i];
                }
            }
            
            
            Sort(ref array1);
            Sort(ref array2);
            array = Merge(array1, array2);
        }
        
        public static int[] Merge (int[] array1, int[] array2)
        {
            if(array1.Length < 1 || array2.Length < 1)
                throw new ArgumentException("Can't merge arrays with lenght < 1");
            
            var resultArray = new int[array1.Length + array2.Length];

            int leftMark = 0, rightMark = 0;
            
            for (int i = 0; i < resultArray.Length; i++)
            {
                if (leftMark >= array1.Length)
                {
                    resultArray[i] = array2[rightMark++];
                    continue;
                }
                
                if (rightMark >= array2.Length)
                {
                    resultArray[i] = array1[leftMark++];
                    continue;
                }

                if (array1[leftMark] <= array2[rightMark])
                {
                    resultArray[i] = array1[leftMark++];
                }
                else
                {
                    resultArray[i] = array2[rightMark++];
                }
            }
            
            
            return resultArray;
        }

        private static void RandomFill(int[] arrays)
        {
            var random = new Random();
            for(var i = 0; i < arrays.Length; i++)
            {
                arrays[i] = random.Next(50);
            }
        }

        private static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
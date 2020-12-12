using System;
using System.Diagnostics;

namespace MultipleKnapsackProblem
{
    class Program
    {
        private static Knapsack[] knapsacks;        //J
        private static Item[] items;        //I


        static void Main(string[] args)
        {
            items = new Item[] {
                new Item(1, 1),
            };

            knapsacks = new Knapsack[]{
                new Knapsack(10),
            };

        }



        private static void Print()
        {
            foreach (Knapsack k in knapsacks)
            {
                Debug.WriteLine($"---Knapsacks---\n\n");
                k.Print();
                Debug.WriteLine($"---------------\n\n\n");
            }
        }
    }
}

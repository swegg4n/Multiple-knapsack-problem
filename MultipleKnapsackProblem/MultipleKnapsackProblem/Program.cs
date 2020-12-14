using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultipleKnapsackProblem
{
    static class Program
    {
        public static Knapsack[] Knapsacks { get; private set; }     //J
        public static Item[] Items { get; private set; }      //I
        public static List<Item> UnusedItems { get; set; } = new List<Item>();


        private static Random random = new Random(0);


        private static int numberOfItems = 40;
        private static int numberOfKnapsacks = 3;

        private static int w_min = 1;   //min weight
        private static int w_max = 10;  //max weight
        private static int p_min = 1;   //min value
        private static int p_max = 10; //max value
        private static int W_min = 10;  //knapsack min weight capacity
        private static int W_max = 30; //knapsack max weight capacity



        static void Main(string[] args)
        {

            int id = 0;

            Items = new Item[numberOfItems];
            for (int i = 0; i < Items.Length; i++)
                Items[i] = new Item(id++, random.Next(w_min, w_max + 1), random.Next(p_min, p_max + 1));

            Knapsacks = new Knapsack[numberOfKnapsacks];
            for (int i = 0; i < Knapsacks.Length; i++)
                Knapsacks[i] = new Knapsack(random.Next(W_min, W_max));

            foreach (Item i in Items)
                UnusedItems.Add(i);


            PrintInitialState();

            GreedyAlgorithm.FillKnapsacks();
            NeighborhoodSearch.Solution localOptimalSolution = NeighborhoodSearch.ImprovingSearch(new NeighborhoodSearch.Solution(Knapsacks, UnusedItems), 100);
            Knapsacks = localOptimalSolution.Knapsacks;
            UnusedItems = localOptimalSolution.UnusedItems;

            NeighborhoodSearch.Print();


            Console.ReadKey();
        }


        private static void PrintInitialState()
        {
            Console.WriteLine("------------------------------");

            ConsoleTable table = new ConsoleTable("Item nr.", "Weight", "Value");
            table.Options.EnableCount = false;

            foreach (Item i in Items)
                table.AddRow(i.Id, i.Weight, i.Value);
            table.Write(Format.MarkDown);

            int id = 0;
            foreach (Knapsack k in Knapsacks)
                Console.WriteLine($"Knapsack #{id++} - Weight Capacity: {k.WeightCapacity}");

            Console.WriteLine("------------------------------\n\n");
        }

        public static void PrintKnapsacks()
        {
            int id = 0;

            Console.WriteLine($"---Knapsacks---\n\n");

            foreach (Knapsack k in Knapsacks)
                k.Print(id++);

            Console.WriteLine($"---------------\n\n\n");
        }

    }
}

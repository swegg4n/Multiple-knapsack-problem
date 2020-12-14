using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleKnapsackProblem
{
    static class GreedyAlgorithm
    {

        public static void FillKnapsacks()
        {
            Item[] items = Program.Items;
            Knapsack[] knapsacks = Program.Knapsacks;

            for (int i = 0; i < items.Length - 1; i++)
            {
                if (items[i].RelativeBenefit > items[i + 1].RelativeBenefit)
                {
                    foreach (Knapsack k in knapsacks)
                    {
                        if (k.TryAddItem(items[i]) == true)
                        {
                            Program.UnusedItems.Remove(items[i]);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Knapsack k in knapsacks)
                    {
                        if (k.TryAddItem(items[i + 1]) == true)
                        {
                            Program.UnusedItems.Remove(items[i+1]);
                            break;
                        }
                    }
                }

            }

            Print(items, knapsacks);
        }

        public static void Print(Item[] items, Knapsack[] knapsacks)
        {
            Console.WriteLine("-------Greedy Algorithm-------");
            int totalKnapsacksValue = knapsacks.Sum(v => v.TotalValue);
            int totalItemsValue = items.Sum(v => v.Value);
            Console.WriteLine($"Total value in all knapsacks: {totalKnapsacksValue}");
            Console.WriteLine($"Total value of all items: {totalItemsValue}");
            Console.WriteLine($"#Unused items: {Program.UnusedItems.Count}");
            Console.WriteLine("------------------------------\n\n");
        }
    }

}

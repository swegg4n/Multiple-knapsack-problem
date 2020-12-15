using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleKnapsackProblem
{
    static class NeighborhoodSearch
    {

        public class Solution
        {
            public Solution(Knapsack[] knapsacks, List<Item> unusedItems)
            {
                this.Knapsacks = new Knapsack[knapsacks.Length];
                for (int i = 0; i < knapsacks.Length; i++)
                    this.Knapsacks[i] = new Knapsack(knapsacks[i]);

                this.UnusedItems = unusedItems;
            }

            public Knapsack[] Knapsacks { get; }
            public List<Item> UnusedItems { get; }


            public int TotalCost
            {
                get { return Knapsacks.Sum(i => i.TotalValue); }
            }
        }



        public static Solution ImprovingSearch(Solution startSolution)
        {
            List<Solution> neighbors = GetNeighbors(startSolution);

            Solution bestSolution = startSolution;

            foreach (Solution s in neighbors)
            {
                if (s.TotalCost > bestSolution.TotalCost)
                {
                    bestSolution = s;
                }
            }

            if (bestSolution == startSolution)
                return bestSolution;

            return ImprovingSearch(bestSolution);
        }


        private static List<Solution> GetNeighbors(Solution baseSolution)
        {
            List<Solution> neighborhood = new List<Solution>();

            for (int i = 0; i < baseSolution.Knapsacks.Length; i++)
            {
                for (int j = 0; j < baseSolution.Knapsacks[i].Items.Count; j++)
                {
                    Solution neighbor = new Solution(baseSolution.Knapsacks, baseSolution.UnusedItems);

                    foreach (Item unused in neighbor.UnusedItems)
                    {
                        neighbor.Knapsacks[i].RemoveItem(neighbor.Knapsacks[i].Items[j]);

                        if (neighbor.Knapsacks[i].TryAddItem(unused))
                        {
                            if (neighbor.TotalCost >= baseSolution.TotalCost)
                            {
                                neighborhood.Add(neighbor);
                            }
                        }
                        neighbor = new Solution(baseSolution.Knapsacks, baseSolution.UnusedItems);
                        //try to Swap bagitem with unused -> if possible: add solution to neigborhood
                    }
                }
            }

            return neighborhood;
        }


        public static void Print()
        {
            Console.WriteLine("-------Improving Search-------");
            int totalKnapsacksValue = Program.Knapsacks.Sum(v => v.TotalValue);
            int totalItemsValue = Program.Items.Sum(v => v.Value);
            Console.WriteLine($"Total value in all knapsacks: {totalKnapsacksValue}");
            Console.WriteLine($"Total value of all items: {totalItemsValue}");
            Console.WriteLine($"#Unused items: {Program.UnusedItems.Count}");
            Console.WriteLine("------------------------------\n\n");
        }

        // unused: [a, b, c]

        // starting solution (x(0)) : [i, j] [k] [l, m, n] [o, p] [q, r]

        //Determine all points in neighborhood N(x^(t))     -       swap from unused to bag?



        // c(x^(t)) -> konstaden av vår solution vid djup t.

        //Neigborhood inehåller alla närliggande solutions

        //loopa igenom alla Neighborhoods och om vår starting solution har bättre värde än alla andra neighborhood solutions -> break (best local soluton found)

        // annars -> välj det neighborhood men bäst value. - repeat
    }
}


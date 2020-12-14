using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MultipleKnapsackProblem
{
    public class Knapsack
    {
        public int WeightCapacity { get; }  //W
        public List<Item> Items { get; } = new List<Item>();   //⊆I

        public int TotalWeight { get { return Items.Sum(i => i.Weight); } }
        public int TotalValue { get { return Items.Sum(i => i.Value); } }



        public Knapsack(int capacity)
        {
            this.WeightCapacity = capacity;
        }
        public Knapsack(Knapsack baseKnapsack)
        {
            this.WeightCapacity = baseKnapsack.WeightCapacity;
            this.Items = new List<Item>();

            foreach (Item i in baseKnapsack.Items)
                Items.Add(i);
        }



        /// <summary>
        /// Tries to add an item to the knapsack
        /// </summary>
        /// <returns>If the item was added or not</returns>
        public bool TryAddItem(Item item)
        {
            if (TotalWeight + item.Weight > WeightCapacity)
                return false;

            Items.Add(item);
            return true;
        }
        public void RemoveItem(Item item)
        {
            if (Items.Contains(item))
                Items.Remove(item);
        }


        public void Print(int id)
        {
            Console.WriteLine($"Knapsack #{id}:");

            ConsoleTable table = new ConsoleTable("Item nr.", "Weight", "Value");
            table.Options.EnableCount = false;

            foreach (Item i in Items)
                table.AddRow(i.Id, i.Weight, i.Value);
            table.Write(Format.MarkDown);

            Console.WriteLine($"Total weight: {TotalWeight} (/{WeightCapacity})");
            Console.WriteLine($"Total value: {TotalValue}");

            Console.WriteLine("\n");
        }
    }

}

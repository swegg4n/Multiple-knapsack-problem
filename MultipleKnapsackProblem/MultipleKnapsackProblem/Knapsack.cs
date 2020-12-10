using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleKnapsackProblem
{
    public class Knapsack
    {
        public int Capacity { get; }
        public List<Item> Items { get; set; } = new List<Item>();


        public Knapsack(int capacity)
        {
            this.Capacity = capacity;
        }

    }

}

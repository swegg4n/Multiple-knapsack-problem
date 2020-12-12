using System.Collections.Generic;
using System.Diagnostics;

namespace MultipleKnapsackProblem
{
    public class Knapsack
    {
        public int WeightCapacity { get; }  //W
        public List<Item> Items { get; set; } = new List<Item>();   //⊆I


        public Knapsack(int capacity)
        {
            this.WeightCapacity = capacity;
        }


        public void Print()
        {


            Debug.WriteLine("");
        }
    }

}

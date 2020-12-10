namespace MultipleKnapsackProblem
{
    public class Item
    {
        public Item(int weight, int value)
        {
            this.Weight = weight;
            this.Value = value;
        }

        public int Weight { get; }
        public int Value { get; }
    }

}

namespace MultipleKnapsackProblem
{
    public class Item
    {
        public Item(int weight, int value)
        {
            this.Weight = weight;
            this.Value = value;
        }

        public int Weight { get; }      //w
        public int Value { get; }       //p


        public float RelativeBenefit { get { return (float)Value / (float)Weight; } }   //b
    }

}

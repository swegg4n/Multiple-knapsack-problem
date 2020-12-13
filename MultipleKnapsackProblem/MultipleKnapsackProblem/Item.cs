namespace MultipleKnapsackProblem
{
    public class Item
    {
        public Item(int id, int weight, int value)
        {
            this.Id = id;
            this.Weight = weight;
            this.Value = value;
        }

        public int Id { get; }

        public int Weight { get; }      //w
        public int Value { get; }       //p


        public float RelativeBenefit { get { return (float)Value / (float)Weight; } }   //b
    }

}

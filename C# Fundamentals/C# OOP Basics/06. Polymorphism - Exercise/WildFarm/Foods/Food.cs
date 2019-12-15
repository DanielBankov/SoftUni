namespace WildFarm.Foods
{
    public abstract class Food : IFood
    {
        private int quantity;

        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; }
    }
}

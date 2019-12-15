namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const char asteriskSymbol = '*';
        private const int point = 1;

        public FoodAsterisk()
            : base(asteriskSymbol, point)
        { }
    }
}

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char dollarSymbol = '$';
        private const int point = 2;

        public FoodDollar() 
            : base(dollarSymbol, point)
        { }
    }
}

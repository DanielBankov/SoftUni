namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char hashSymbol = '#';
        private const int point = 3;
        public FoodHash(Wall wall) 
            : base(wall, hashSymbol, point)
        { }
    }
}

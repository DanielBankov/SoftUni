namespace FoodShortage
{
    public interface IBuy
    {
        string Name { get; set; }
        int Food { get; set; }

        void BuyFood();
    }
}

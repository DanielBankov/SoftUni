namespace Animals
{
    public abstract class Animal
    {
        public Animal(string name, string favoriteFood)
        {
            Name = name;
            FavouriteFood = favoriteFood;
        }

        public string Name { get; protected set; }
        public string FavouriteFood { get; protected set; }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {FavouriteFood}";
        }
    }
}

namespace Ferrari
{
    public interface IFerari
    {
        string Model { get;}
        string Driver { get; }

        string Breaks();
        string Gas();
    }
}

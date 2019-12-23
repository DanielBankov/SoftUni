namespace SOLID_Exercise.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string layoutType);
    }
}

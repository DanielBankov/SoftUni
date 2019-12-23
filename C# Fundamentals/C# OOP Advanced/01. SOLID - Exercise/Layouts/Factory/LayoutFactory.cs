namespace SOLID_Exercise.Layouts.Factory
{
    using Contracts;
    using System;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            string lowerCaseLayoutType = layoutType.ToLower();

            //TODO: take types with reflection
            switch (lowerCaseLayoutType)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}

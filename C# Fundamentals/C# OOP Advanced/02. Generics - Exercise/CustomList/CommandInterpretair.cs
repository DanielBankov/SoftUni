namespace CustomList
{
    using System;

    public class CommandInterpretair
    {
        private BoxList<string> boxList;

        public CommandInterpretair()
        {
             boxList = new BoxList<string>();
        }

        public void Command(string[] args)
        {

            switch (args[0])
            {
                case "Add":
                    boxList.Add(args[1]);
                    break;
                case "Remove":
                    boxList.Remove(int.Parse(args[1]));
                    break;
                case "Contains":
                    Console.WriteLine(boxList.Contains(args[1]));
                    break;
                case "Swap":
                    boxList.Swap(int.Parse(args[1]), int.Parse(args[2]));
                    break;
                case "Greater":
                    Console.WriteLine(boxList.CountGreaterThan(args[1]));
                    break;
                case "Max":
                    Console.WriteLine(boxList.Max());
                    break;
                case "Min":
                    Console.WriteLine(boxList.Min());
                    break;
                case "Print":
                    Console.WriteLine(boxList);
                    break;
            }
        }
    }
}

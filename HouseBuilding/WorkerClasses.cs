using HouseBuilding;
using HouseParts;
using Interfaces;

namespace WorkerClasses
{
    public class Worker : IWorker
    {
        public virtual IPart Work(object obj)
        {
            try
            {
                if (!(obj is House))
                    throw new ArgumentException("Object type isn't House");

                IPart part = new PartChecker().GetAvailablePart();

                if (part == null)
                {
                    Console.WriteLine("House-building is over");
                    return null;
                }

                part.Counter++; 
                return part;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }

    public class TeamLeader
    {
        public void MakeReport(IPart part)
        {
            if (part == null)
                return;
            Console.WriteLine("{0} has been built for the house", part.Name);
            new PartChecker().PercentReport();
        }

        public void DrawHouse()
        {
            Console.WriteLine("   /\\   ");
            Console.WriteLine("  /  \\  ");
            Console.WriteLine(" /____\\ ");
            Console.WriteLine("|      |");
            Console.WriteLine("|[+] [+]");
            Console.WriteLine("|      |");
            Console.WriteLine("|[+] [+]");
            Console.WriteLine("|______|");
        }

    }
}

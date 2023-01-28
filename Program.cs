using AI.Lib;

namespace AI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var rain = new Symbol("rain");
            var hagrid = new Symbol("hagrid");
            var dumbledore = new Symbol("dumbledore");
            var notrain = new Not(rain);

            var knowledge = new And(
                new Implication(new Not(rain), hagrid),
                new Or(hagrid, dumbledore),
                new Not(new And(hagrid, dumbledore)),
                dumbledore
                );

         var modelChecker = ModelChecker.ModelCheck(knowledge, notrain);
            Console.WriteLine(modelChecker);
        }
    }
}
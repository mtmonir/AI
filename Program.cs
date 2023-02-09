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
           

            var knowledge = new And(
                new Implication(new Not(rain), hagrid),
                new Or(hagrid, dumbledore),
                new Not(new And(hagrid, dumbledore)),
                dumbledore
                );

            Console.WriteLine(knowledge.formula()); 
            var modelChecker = ModelChecker.ModelCheck(knowledge, rain);
            Console.WriteLine(modelChecker);
            var newkno = new And(new Not(rain), hagrid);
            var nd = new Dictionary<string, bool>();
            nd.Add("hagrid", true);
            nd.Add("rain", false);
            Console.WriteLine(newkno.evaluate(nd));
        }
    }
}
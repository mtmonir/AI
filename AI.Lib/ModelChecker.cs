using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.Lib
{
    public class ModelChecker
    {
        public static bool ModelCheck(Sentence knowledge, Sentence query)
        {
            Console.WriteLine("Just Checking...");
            var count = 0;

            bool CheckAll(Sentence knowledgeall, Sentence queryall, HashSet<string> symbolsre, Dictionary<string, bool> model)
            {

                if (symbolsre.Count == 0)
                {
                    if (knowledge.evaluate(model))
                    {
                        return query.evaluate(model);
                    }
                    return true;
                }
                else
                {
                    var remaining = new HashSet<string>(symbolsre);
                    var p = remaining.First();
                    remaining.Remove(p);

                    var modelTrue = new Dictionary<string, bool>(model);
                    modelTrue[p] = true;

                    var modelFalse = new Dictionary<string, bool>(model);
                    modelFalse[p] = false;

                    return CheckAll(knowledge, query, remaining, modelTrue) && CheckAll(knowledge, query, remaining, modelFalse);
                }
            }

            var symbols = new HashSet<string>(knowledge.symbols());
            symbols.UnionWith(query.symbols());
           

            return CheckAll(knowledge, query, symbols, new Dictionary<string, bool>());
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AI.Lib
{
    public class Or : Sentence
    {
        private List<Sentence> disjuncts;

        public Or(params Sentence[] disjuncts)
        {
            this.disjuncts = new List<Sentence>(disjuncts);
            foreach (var disjunct in disjuncts)
            {
                Sentence.validate(disjunct);
            }
        }

        public override bool Equals(object other)
        {
            var otherOr = other as Or;
            return otherOr != null && disjuncts.SequenceEqual(otherOr.disjuncts);
        }

        public override int GetHashCode()
        {
            return ("or", disjuncts.Select(disjunct => disjunct.GetHashCode()).ToArray()).GetHashCode();
        }

        public override string ToString()
        {
            var disjunctsString = string.Join(", ", disjuncts);
            return $"Or({disjunctsString})";
        }

        public override bool evaluate(Dictionary<string, bool> model)
        {
            return disjuncts.Any(disjunct => disjunct.evaluate(model));
        }

        public override string formula()
        {
            if (disjuncts.Count == 1)
            {
                return disjuncts[0].formula();
            }
            return string.Join(" âˆ¨ ", disjuncts.Select(disjunct => Sentence.parenthesize(disjunct.formula())));
        }

        public override HashSet<string> symbols()
        {
            var symbols = new HashSet<string>();
            foreach (var disjunct in disjuncts)
            {
                symbols.UnionWith(disjunct.symbols());
            }
            return symbols;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.Lib
{
    public class And : Sentence
    {
        List<Sentence> conjuncts;
        public And(params Sentence[] conjuncts)
        {
        foreach (var conjunct in conjuncts)
            {
                Sentence.validate(conjunct);
            }
            this.conjuncts = conjuncts.ToList();
        }

        public override bool Equals(object other)
        {
            if (other is And)
            {
                return conjuncts.SequenceEqual((other as And).conjuncts);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ("and", conjuncts.Select(conjunct => conjunct.GetHashCode()).ToArray()).GetHashCode();
            //var h = new HashCode();
            //h.Add("and");
            //foreach (var conjunct in conjuncts)
            //{
            //    h.Add(conjunct.GetHashCode());
            //}
            //return h.ToHashCode();
        }

        public override string ToString()
        {
            var conjunctions = string.Join(", ", conjuncts.Select(c => c.ToString()));
            return $"And({conjunctions})";
        }

        public void add(Sentence conjunct)
        {
            Sentence.validate(conjunct);
            conjuncts.Add(conjunct);
        }

        public override bool evaluate(Dictionary<string, bool> model)
        {
            return conjuncts.All(conjunct => conjunct.evaluate(model));
        }

        public override string formula()
        {
            if (conjuncts.Count == 1)
            {
                return conjuncts[0].formula();
            }
            return string.Join(" ∧ ", conjuncts.Select(c => Sentence.parenthesize(c.formula())));
        }

        public override HashSet<string> symbols()
        {
            var symbols = new HashSet<string>();
            foreach (var conjunct in conjuncts)
            {
                symbols.UnionWith(conjunct.symbols());
            }
            return symbols;
        }
    }

}

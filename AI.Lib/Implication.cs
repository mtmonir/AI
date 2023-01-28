using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AI.Lib
{
    public class Implication : Sentence
    {
        private Sentence antecedent;
        private Sentence consequent;

        public Implication(Sentence antecedent, Sentence consequent)
        {
            Sentence.validate(antecedent);
            Sentence.validate(consequent);
            this.antecedent = antecedent;
            this.consequent = consequent;
        }

        public override bool Equals(object other)
        {
            if (other is Implication)
            {
                var o = (Implication)other;
                return this.antecedent.Equals(o.antecedent) && this.consequent.Equals(o.consequent);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return ("implies", this.antecedent.GetHashCode(), this.consequent.GetHashCode()).GetHashCode();
        }

        public override string ToString()
        {
            return "Implication(" + this.antecedent + ", " + this.consequent + ")";
        }

        public override bool evaluate(Dictionary<string, bool> model)
        {
            return (!this.antecedent.evaluate(model)) || this.consequent.evaluate(model);
        }

        public override string formula()
        {
            var antecedent = Sentence.parenthesize(this.antecedent.formula());
            var consequent = Sentence.parenthesize(this.consequent.formula());
            return antecedent + " => " + consequent;
        }

        public override HashSet<String> symbols()
        {
            var symbols = new HashSet<String>();
            symbols.UnionWith(this.antecedent.symbols());
            symbols.UnionWith(this.consequent.symbols());
            return symbols;
        }
    }

}

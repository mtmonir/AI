using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AI.Lib
{
    public class Biconditional : Sentence
    {
        private Sentence left;
        private Sentence right;

        public Biconditional(Sentence left, Sentence right)
        {
            Sentence.validate(left);
            Sentence.validate(right);
            this.left = left;
            this.right = right;
        }

        public override bool Equals(object other)
        {
            return (other is Biconditional)
                    && this.left == ((Biconditional)other).left
                    && this.right == ((Biconditional)other).right;
        }

        public override int GetHashCode()
        {
            return ("biconditional", this.left.GetHashCode(), this.right.GetHashCode()).GetHashCode();
        }

        public override string ToString()
        {
            return "Biconditional(" + this.left + ", " + this.right + ")";
        }

        public bool evaluate(Dictionary<string, bool> model)
        {
            return (this.left.evaluate(model)
                     && this.right.evaluate(model))
                    || (!this.left.evaluate(model)
                        && !this.right.evaluate(model));
        }

        public string formula()
        {
            string left = Sentence.parenthesize(this.left.ToString());
            string right = Sentence.parenthesize(this.right.ToString());
            return left + " <=> " + right;
        }

        public HashSet<string> symbols()
        {
            HashSet<string> leftSymbols = this.left.symbols();
            HashSet<string> rightSymbols = this.right.symbols();
            leftSymbols.UnionWith(rightSymbols);
            return leftSymbols;
        }

    }
}

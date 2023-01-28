using System;
using System.Collections.Generic;
using System.Text;

namespace AI.Lib
{
    public class Not : Sentence
    {
        public Sentence operand;
        public Not(Sentence operand)
        {
            Sentence.validate(operand);
            this.operand = operand;
        }
        public override bool Equals(object other)
        {
            return other is Not && this.operand == ((Not)other).operand;
        }
        public override int GetHashCode()
        {
            return (("not", this.operand.GetHashCode())).GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("Not({0})", operand);
        }
        public override bool evaluate(Dictionary<string, bool> model)
        {
            return !this.operand.evaluate(model);
        }
        public override string formula()
        {
            return "¬" + Sentence.parenthesize(this.operand.formula());
        }
        public override HashSet<string> symbols()
        {
            return this.operand.symbols();
        }
    }
}

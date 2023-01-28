using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AI.Lib
{
    public class Symbol : Sentence
    {
        public string name;
        public Symbol(string name)
        {
            this.name = name;
        }
        public override bool Equals(object other)
        {
            return other is Symbol && this.name == ((Symbol)other).name;
        }
        public override int GetHashCode()
        {
            return (("symbol", this.name)).GetHashCode();
        }
        public override string ToString()
        {
            return name;
        }
        public override bool evaluate(Dictionary<string, bool> model)
        {
            try
            {
                if ((bool)model[this.name])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (KeyNotFoundException)
            {
                throw new Exception(string.Format("variable {0} not in model", this.name));
            }
        }
        public override string formula()
        {
            return this.name;
        }
        public override HashSet<string> symbols()
        {
            return new HashSet<string> { this.name };
        }
    }
}

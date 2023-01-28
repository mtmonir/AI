using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AI.Lib
{
    public class Sentence
    {
        public virtual bool evaluate(Dictionary<string, bool> model)
        {
            throw new Exception("nothing to evaluate");
        }
        public virtual string formula()
        {
            return "";
        }
        public virtual HashSet<string> symbols()
        {
            return new HashSet<string>();
        }
        public static void validate(Sentence sentence)
        {
            if (!(sentence is Sentence))
            {
                throw new Exception("must be a logical sentence");
            }
        }
        public static string parenthesize(string s)
        {
            bool balanced(string s2)
            {
                int count = 0;
                for (int i = 0; i < s2.Length; i++)
                {
                    if (s2[i] == '(')
                    {
                        count++;
                    }
                    else if (s2[i] == ')')
                    {
                        if (count <= 0)
                        {
                            return false;
                        }
                        count--;
                    }
                }
                return count == 0;
            }
            if (string.IsNullOrEmpty(s) || s.All(char.IsLetter) || (s[0] == '(' && s[s.Length - 1] == ')' && balanced(s.Substring(1, s.Length - 2))))
            {
                return s;
            }
            else
            {
                return "(" + s + ")";
            }
        }
    }
}

/// <summary>
///     All that is open must be closed - 5 kyu - O(N)
///     Your challenge in this kata is to write a function to validate that a supplied string is balanced.
///     You must determine if all that is open is then closed, and nothing is closed which is not already open!
///     You will be given a string to validate, and a second string, where each pair of characters defines an opening and closing sequence that needs balancing.
///     
///     In this case '(' opens a section, and ')' closes a section
///     ("(Sensei says yes!)", "()")       => true
///     ("(Sensei says no!", "()")         => false
/// 
///     In this case '(' and '[' open a section, while ')' and ']' close a section
///     ("(Sensei [says] yes!)", "()[]")   => true
///     ("(Sensei [says) no!]", "()[]")    => false
/// 
///     In this case a single quote (') both opens and closes a section
///     ("Sensei says 'yes'!", "''")       => true
///     ("Sensei say's no!", "''")         => false
/// 
/// </summary>

using System.Collections.Generic;

namespace CodeWars
{
    public class AllOpenMustClosed
    {
        public static bool IsBalanced(string s, string caps)
        {
            var pairs = new Dictionary<char, char>();
            for (int i = 0; i < caps.Length; i+= 2)
            {
                pairs.Add(caps[i], caps[i + 1]);
            }

            var stack = new Stack<int>(s.Length);

            foreach (char c in s)
            {
                if (pairs.ContainsKey(c))
                {
                    if ((c == '"' || c == '\'' || c == '-' ||  c == '@') && stack.Count > 0 && stack.Peek() == c)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }
                else if (pairs.ContainsValue(c))
                {
                    if (stack.Count == 0) return false;

                    if (pairs[(char)stack.Pop()] != c)
                    {
                        return false;
                    }

                }
            }

            return stack.Count == 0;
        }
    }
}
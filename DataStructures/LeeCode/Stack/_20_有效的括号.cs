using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Stack;

namespace LeeCode.Stack
{
    /// <summary>
    /// https://leetcode-cn.com/problems/valid-parentheses/
    /// </summary>
    public class _20_有效的括号
    {
        /// <summary>
        /// 使用栈
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            MyStack<char> stack = new MyStack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' ||
                    s[i] == '{' ||
                    s[i] == '[')
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (stack.IsEmpty()) return false;
                    var left = stack.Pop();
                    if (left == '(' && s[i] == ')'
                        || left == '[' && s[i] == ']'
                        || left == '{' && s[i] == '}')
                    {
                        continue;
                    }

                    return false;
                }
            }

            return stack.IsEmpty();

     
        }
        
        /// <summary>
        /// 使用字典加栈
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid2(string s)
        {
            MyStack<char> stack = new MyStack<char>();
            Dictionary<char, char> dic = new Dictionary<char, char>()
            {
                {'(',')'},
                {'[',']'},
                {'{','}'}
            };
            for (int i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (stack.IsEmpty()) return false;
                    if (s[i] != dic[stack.Pop()]) return false;
                }
            }

            return stack.IsEmpty();

     
        }
    }
}
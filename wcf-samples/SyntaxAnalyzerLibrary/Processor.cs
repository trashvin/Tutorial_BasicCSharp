using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalyzerLibrary
{
    public class Processor
    {
        public int ParseCode(string code)
        {
            int result = 0;
            List<char> closingChars = new List<char>
            {
                ')',']','}','>'
            };
            List<char> openingChars = new List<char>
            {
                '(','[','{','<'
            };

            bool isCorrupted = false;
            Stack<char> codeStack = new Stack<char>();

            char lastChar = '_';
            foreach (var codeChar in code)
            {

                if (openingChars.Contains(codeChar))
                {
                    codeStack.Push(codeChar);
                }
                else
                {
                    char poppedValue = codeStack.Pop();

                    if (openingChars.IndexOf(poppedValue) != closingChars.IndexOf(codeChar))
                    {
                        isCorrupted = true;
                        lastChar = codeChar;
                        break;
                    }
                }
            }
            if (isCorrupted)
            {
                result = GetCharacterScore(lastChar);
            }

            return result;

        }

        private int GetCharacterScore(char corruptedChar)
        { // ]
            Dictionary<char, int> scoreMap = new Dictionary<char, int>();
            scoreMap.Add(')', 5);
            scoreMap.Add(']', 57);
            scoreMap.Add('}', 1197);
            scoreMap.Add('>', 25137);

            try
            {
                return scoreMap[corruptedChar];
            }
            catch
            {
                return 0;
            }
        }
    }
}

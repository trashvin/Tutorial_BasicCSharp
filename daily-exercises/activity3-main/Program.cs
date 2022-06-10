using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace activity3_main
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid argument number.");
                Console.WriteLine("End of Program");
                Console.ReadLine();
                return;
            }

            string fileName = args[0];
            List<string> codeLines = new List<string>();

            Console.WriteLine("Reading syntaxtic code from the file .....");
            codeLines = ReadFromFile(fileName);

            Console.WriteLine("Computing the syntaxtic score .....");
            int score = GetSyntaxScore(codeLines);

            Console.WriteLine($"Syantaxtic Score : {score}");

            Console.WriteLine("End of Program");
            Console.ReadLine();
        }

        private static int GetSyntaxScore(List<string> codeLines)
        {
            int scoreAccumulator = 0;
            List<char> closingChars = new List<char>
            {
                ')',']','}','>'
            };
            List<char> openingChars = new List<char>
            {
                '(','[','{','<'
            };

            // string is composed of array of char
            foreach (var codeLine in codeLines)
            {
                bool isCorrupted = false;
                Stack<char> codeStack = new Stack<char>();

                char lastChar = '_';
                foreach(var code in codeLine)
                {
                    
                    if (openingChars.Contains(code))
                    {
                        codeStack.Push(code);
                    }
                    else
                    {
                        char poppedValue = codeStack.Pop();

                        // if [ == ]  if ( == )  if < == >

                        if (openingChars.IndexOf(poppedValue) != closingChars.IndexOf(code))
                        {
                            isCorrupted = true;
                            lastChar = code;
                            break;
                        }
                    }
                }

                if (isCorrupted)
                {
                    scoreAccumulator += GetCharacterScore(lastChar);
                }
            }

            return scoreAccumulator;
        }

        private static int GetCharacterScore(char corruptedChar)
        { // ]
            Dictionary<char, int> scoreMap = new Dictionary<char, int>();
            scoreMap.Add(')', 3);
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

        private static List<string> ReadFromFile(string fileName)
        {
            List<string> data = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string tempLine = string.Empty;

                while((tempLine = reader.ReadLine())!=null)
                {
                    data.Add(tempLine);
                }

            }

            return data;
        }
    }
}

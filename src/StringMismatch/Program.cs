using System;

namespace StringMismatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string inputSring = "abcadb";
            //string inputSring = "abc";
            string loopedString = "";
            int maxCount = 0;
            for (int i = 0; i < inputSring.Length; i++)
            {
                char currentChar = inputSring[i];
                if (!loopedString.Contains(currentChar))
                {
                    loopedString += currentChar;
                }
                else
                {
                    if (loopedString.Length >= (i-1))
                        maxCount = loopedString.Substring(0, i).Length;
                }
            }

            Console.WriteLine(maxCount);
            Console.ReadLine();
        }
    }
}

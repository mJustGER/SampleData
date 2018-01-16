using SampleData.Generator;
using System;

namespace SampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            TextGenerator tg = new TextGenerator();
            tg.PunctuationMark = true;


            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(tg.getSentence());
            }
            

            


            Console.ReadLine();
        }
    }
}

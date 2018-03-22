using SampleData.Generator;
using SampleData.Library;
using System;

namespace SampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            ITextGenerator tg = new TextGenerator();
            tg.GetHeadline();


            //TextGenerator tg = new TextGenerator();
            //tg.PunctuationMark = true;


            //for (int i = 0; i < 50; i++)
            //{
            //    Console.WriteLine(tg.getSentence());
            //}



            Console.WriteLine(tg.GetHeadline());



            Console.ReadLine();
        }
    }
}

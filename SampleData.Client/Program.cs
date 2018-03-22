using SampleData.Generator;
using SampleData.Library;
using System;

namespace SampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            ITextGenerator tg = new TextGenerator(-3, true, true);

            for (int i = 0; i < 15; i++) Console.WriteLine(tg.GetHeadline());
            for (int i = 0; i < 15; i++) Console.WriteLine(tg.getSentence());




            Console.ReadLine();
        }
    }
}

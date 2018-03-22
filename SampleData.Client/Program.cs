using SampleData.Generator;
using System;

namespace SampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            ITextGenerator tg = new TextGenerator(-3, true, true);
            Console.WriteLine(tg.GetHeadline());
            
            Console.ReadLine();
        }
    }
}

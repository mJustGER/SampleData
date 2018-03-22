# SampleData






``` csharp
using SampleData.Generator;
using System;

namespace SampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            ITextGenerator tg = new TextGenerator(3, true);
            Console.WriteLine(tg.GetHeadline());
            
            Console.ReadLine();
        }
    }
}
 
 // ## will generate something like this, depends on your parameters: ##

 // Example 1:  Ad tortor lacinia malesuada dis urna quis ante
 // Example 2: Gubergren posuere dolor amet Gget nam
 // Example 3: Dictumst dolores Duo elementum Dation Dit imperdiet

```


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
            ITextGenerator tg = new TextGenerator(-3, true, true);
            Console.WriteLine(tg.GetHeadline());
            
            Console.ReadLine();
        }
    }
 }
 
 // ## will generate something like this, depends on your parameters: ##

 // Ad tortor lacinia malesuada dis urna quis ante
 // Gubergren posuere dolor amet Gget nam
 // Dictumst dolores Duo elementum Dation Dit imperdiet

```


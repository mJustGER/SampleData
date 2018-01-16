using System;
using System.Collections.Generic;
using System.Text;

namespace SampleData.Generator
{
    public abstract class Generator
    {
        public Random rnd { get; } = new Random();

        public int delta { get; set; } = 3;


    }
}

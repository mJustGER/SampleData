using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text;

namespace SampleData.Generator
{
    public abstract class Generator
    {
        protected List<string> GeneratorWords = new List<string>();

        protected Random rnd { get; } = new Random();
         
        /// <summary>
        /// Defines the deviation of length.
        /// </summary>
        private int _delta;

        public int Delta
        {
            get { return rnd.Next((_delta * -1), _delta); }
            set { _delta = value; }
        }
         
        protected void LoadRessources(string resourceName)
        {
            Assembly assem = Assembly.GetAssembly(typeof(Generator));
            System.IO.Stream fs = assem.GetManifestResourceStream(resourceName);

            ResourceReader obj = new ResourceReader(fs);
            IDictionaryEnumerator dict = obj.GetEnumerator();

            while (dict.MoveNext())
                GeneratorWords.Add(dict.Value.ToString());
        }

    }
}

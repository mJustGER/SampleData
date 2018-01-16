using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SampleData.Generator
{
    public class TextGenerator : Generator
    {

        /// <summary>
        /// Defines the average length of the headline.
        /// </summary>
        public int HeadLineLength { get; set; } = 7;

        /// <summary>
        /// Defines the average sentence length.
        /// </summary>
        public int RecordLength { get; set; } = 14;

        /// <summary>
        /// Enable or disable the chars {, !, ?, ', '', "" } in sentences.
        /// </summary>
        public bool PunctuationMark { get; set; } = false;

        /// <summary>
        /// Defines a set of words based on "Lorem Ipsum" for generating texts.  
        /// </summary>
        string[] Words { get; } = { "a", "ac", "accumsan", "adipiscing", "aenean", "aliquam", "aliquet", "amet", "ante", "arcu", "at", "auctor", "augue", "bibendum", "blandit", "commodo", "condimentum", "congue", "consectetur", "consequat", "convallis", "cras", "curabitur", "cursus", "dapibus", "diam", "dictum", "dictumst", "dignissim", "dis", "dolor", "donec", "dui", "duis", "efficitur", "egestas", "eget", "eleifend", "elementum", "elit", "enim", "erat", "eros", "est", "et", "etiam", "eu", "euismod", "ex", "facilisis", "fames", "faucibus", "felis", "fermentum", "feugiat", "finibus", "fringilla", "fusce", "habitant", "habitasse", "hac", "hendrerit", "iaculis", "id", "imperdiet", "in", "integer", "interdum", "ipsum", "lacinia", "lacus", "laoreet", "lectus", "leo", "libero", "ligula", "lobortis", "lorem", "luctus", "maecenas", "magna", "magnis", "malesuada", "massa", "mattis", "mauris", "maximus", "metus", "mi", "molestie", "mollis", "montes", "morbi", "mus", "nam", "nascetur", "natoque", "nec", "neque", "netus", "nibh", "nisi", "nisl", "non", "nulla", "nullam", "nunc", "odio", "orci", "ornare", "parturient", "pellentesque", "penatibus", "pharetra", "phasellus", "placerat", "platea", "porta", "porttitor", "posuere", "potenti", "praesent", "pretium", "primis", "proin", "pulvinar", "purus", "quam", "quis", "quisque", "rhoncus", "ridiculus", "risus", "rutrum", "sagittis", "sapien", "scelerisque", "sed", "sem", "semper", "senectus", "sit", "sodales", "sollicitudin", "suscipit", "suspendisse", "tellus", "tempor", "tempus", "tincidunt", "tortor", "tristique", "turpis", "ullamcorper", "ultrices", "ultricies", "urna", "ut", "varius", "vehicula", "vel", "velit", "venenatis", "vestibulum", "vitae", "vivamus", "viverra", "volutpat", "vulputate" };

        public string getHeadline()
        {
            List<string> ls = new List<string>();
            ls = Words.OrderBy(x => rnd.Next()).Take(HeadLineLength).ToList();

            ls = AddUpperCase(ls);


            return ls.Aggregate((a, b) => a + " " + b);
        }

        public string getSentence()
        {
            List<string> ls = new List<string>();
            ls = Words.OrderBy(x => rnd.Next()).Take(RecordLength).ToList();
            ls = AddUpperCase(ls);

            if (PunctuationMark)
            {
                ls = addPunctuationMark(ls);
            }

            return getString(ls);
        }


        private string getString(List<string> ls)
        {
            string text = ls.Aggregate((a, b) => a + " " + b);

            string result = Regex.Replace(text, @"\s([\,|\.|\?|\!|\'])", @"$1");
            result = Regex.Replace(result, @"""\s(\w+)\s""", @"""$1""");

            return result;

        }


        /// <summary>
        /// Adds punctuation mark to the text.
        /// </summary>
        /// <param name="ls">A List of string with or without commata</param>
        /// <returns>List of strings that contains commata</returns>
        private List<string> addPunctuationMark(List<string> ls)
        {
            // add comata
            if (rnd.Next(1, 3) == 2)
            {
                int cPos = rnd.Next(3, ls.Count() - 3);
                ls.Insert(cPos, ",");
            }

            // add apostroph
            if (rnd.Next(1, 4) == 3)
            {
                int aPos = rnd.Next(2, ls.Count() - 2);
                ls.Insert(aPos, "'");
            }

            // add quotation marks
            if (rnd.Next(1, 5) == 2)
            {
                int qPos = rnd.Next(2, ls.Count() - 2);
                ls.Insert(qPos, "\"");
                ls.Insert(qPos + 2, "\"");
            }

            // add . ? or ! at the end
            switch (rnd.Next(0, 7))
            {
                case 3:
                    ls.Add("!");
                    break;

                case 5:
                    ls.Add("?");
                    break;

                default:
                    ls.Add(".");
                    break;
            }


            return ls;
        }



        private List<string> AddUpperCase(List<string> s)
        {

            char[] a = s[0].ToCharArray();
            a[0] = char.ToUpper(a[0]);
            s[0] = new string(a);

            for (int i = 0; i < s.Count(); i++)
            {
                if (rnd.Next(0, 4) == 2)
                {
                    char[] b = s[i].ToCharArray();
                    b[0] = char.ToUpper(a[0]);
                    s[i] = new string(b);
                }
            }

            return s;
        }

    }
}

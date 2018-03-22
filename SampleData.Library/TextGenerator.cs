using SampleData.Library;
using SampleData.Library.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SampleData.Generator
{
    public sealed class TextGenerator : Generator, ITextGenerator
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
        /// List for internal use to store words.
        /// </summary>
        private List<string> ls { get; set; }

        /// <summary>
        /// Enable or disable upper words in sentences.
        /// </summary>
        public bool AddUpperCases { get; set; } = true;

        /// <summary>
        /// Enable or disable the chars {, !, ?, ', '', "" } in sentences.
        /// </summary>
        public bool PunctuationMark { get; set; } = false;


        public TextGenerator(int delta, bool addUpperCases, bool punctuationMark = false)
        {
            // if given deltaValue is negative than invert this value.
            base.Delta = delta >= 0 ? delta : delta * -1;
             
            this.AddUpperCases = addUpperCases;
            this.PunctuationMark = punctuationMark;
             
            base.LoadRessources("SampleData.Library.resources.LorenIpsum.resources");
            ls = new List<string>();
        }

        public string GetHeadline()
        {
            ls = base.GeneratorWords.OrderBy(x => rnd.Next()).Take(HeadLineLength + base.Delta).ToList();
            ls = AddUpperCase(ls);

            return ls.Aggregate((a, b) => a + " " + b);
        }

        public string getSentence()
        {
            ls = base.GeneratorWords.OrderBy(x => rnd.Next()).Take(RecordLength).ToList();

            // covert rand words to upper case
            if (AddUpperCases) ls = AddUpperCase(ls);

            // add rand punctuationmark to sentence
            if (PunctuationMark) ls = addPunctuationMark(ls);

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

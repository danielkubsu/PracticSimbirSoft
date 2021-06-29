using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimbirSoft_Test
{
    class WordWorker
    {
        /// <summary>
        /// Number words
        /// and quantity
        /// </summary>
        public string[] site { get; private set; }

        public WordWorker(string[] sites)
        {
            site = sites;
        }

        public void ProgWork()
        {
            for(int i = 0; i < site.Length; i++) 
            {
                Console.WriteLine("Words of - " + site[i]);
                Console.WriteLine("//////////////////////////////");
                string text = readText(site[i]);
                
                if(text == null) 
                {
                    Console.WriteLine("Bad respons from site, may be wrong");
                    break;
                }
                var result = Calc(text);
                result.Remove("");
                foreach (var pair in result)
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                Console.WriteLine("//////////////////////////////");
            }
                
        }

        static Dictionary<string, int> Calc(string site)
        {
            var res = new Dictionary<string, int>();

            foreach (var word in site.Split
                (' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t').Skip(1)) 
            {
                var count = 0;
                res.TryGetValue(word, out count);
                res[word] = count + 1;
            }

            return res;
        }


        public string readText(string site)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            try 
            {
                HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(site);
                return document.DocumentNode.InnerText;
            }
            catch (Exception e) 
            {
                Console.WriteLine("Error : " + e.ToString());
                return null;
            }
        }
    }
}

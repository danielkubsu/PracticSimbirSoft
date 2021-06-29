using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace SimbirSoft_Test
{
    public class FileWorker
    {
        /// <summary>
        /// Read file CurrentSite.txt
        /// else generate file and test data
        /// </summary>
        /// <returns></returns>
        public string[] ReadFile()
        {
            string[] readText;
            string[] tempReadText;
            // Get the current directory
            string directory = Directory.GetCurrentDirectory();
            string site = "CurrentSite.txt";
            string path = directory + @"\" + site;
            if (!File.Exists(path))
            {
                Console.WriteLine("File CurrentSite not exists, ");
                string[] createText = { "https://www.google.com/", "https://www.youtube.com/", "https://mail.ru/" };
                File.WriteAllLines(path, createText);
            }

            tempReadText = File.ReadAllLines(path);
            readText = CheckUrl(tempReadText);
            if (readText == null)
            {
                System.Environment.Exit(-1);
            }
            return readText;
        }

        private string[] CheckUrl(string[] checkurl)
        {
            List<string> tempReadTextCheck = new List<string>();
            string pattern = @"^(http|http(s)?://)+([\w-]+\.)+(\[\?%&=]*)?";
            for (int i = 0; i < checkurl.Length; i++)
            {
                if (Regex.IsMatch(checkurl[i], pattern, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine(" url acces");
                    tempReadTextCheck.Add(checkurl[i]);
                }
                else
                {
                    Console.WriteLine(" error url");
                    Console.WriteLine(" string {0}", checkurl[i]);
                }
            }
            return tempReadTextCheck.ToArray();
        }
    }
}

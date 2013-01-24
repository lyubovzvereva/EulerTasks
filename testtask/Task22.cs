using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task22
    {
        private string alphabetString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        	
        private Dictionary<char, int> alphabet = new Dictionary<char, int>();
        private List<string> names;
        public Task22()
        {
            CreateAlphabet();
            ReadData();
        }
        public long CalculateValues()
        {
            return names.Select((t, i) => (i + 1)*CalculateNameScore(t)).Sum();
        }

        private long CalculateNameScore(string name)
        {
            return name.Aggregate<char, long>(0, (current, t) => current + alphabet[t]);
        }
        private void CreateAlphabet()
        {
            for(int i=0;i<alphabetString.Length;i++)
            {
                alphabet.Add(alphabetString[i], i + 1);
            }
        }
        private void ReadData()
        {
            string text = File.ReadAllText("task22.txt");
            List<string> words = text.Split(',').ToList();
            var result = words.Select(word => word.Substring(1, word.Length - 2)).ToList();
            names = result.OrderBy(x=>x).ToList();
        }
    }
}

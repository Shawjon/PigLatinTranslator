using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatinTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool yesNo = true;
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            while (yesNo == true)
            {
                Console.Write("Enter a line to be translated: ");
                string sentence = Console.ReadLine();
                sentence = sentence.ToLower();
                string pigSentence = getPigLatin(sentence);
                Console.WriteLine(pigSentence);

                Console.Write("Continue? (y/n): ");
                string entry = Console.ReadLine();
                while (entry.ToLower() != "n" || entry.ToLower() != "y" || entry.ToLower() != "no" || entry.ToLower() != "yes")
                {
                    if (entry.ToLower() == "n" || entry.ToLower() == "no")
                    {
                        yesNo = false;
                        ///entry = "n";
                        break;
                    }
                    else if (entry.ToLower() == "y" || entry.ToLower() == "yes")
                    {
                        yesNo = true;
                        ///entry = "y";
                        break;
                    }
                    else
                    {
                        Console.Write("That is not a valid answer, Continue? (y/n): ");
                        entry = Console.ReadLine();
                    }


                }
            }
        }
        public static string MoveFirstToLast(string word)
        {

            if (Regex.IsMatch(word, @"^(\b[a|e|i|o|u]([A-z]*?))$"))
            {

                return word;
            }
            else
            {
                string newword = string.Format("{1}{0}", word.Substring(0, word.Length - (word.Length - 1)), word.Substring(1, word.Length - 1));
                word = newword;
                word = MoveFirstToLast(word);
                return word;
            }

        }
        static string getPigLatin(string sentence)
        {

            string[] sentenceBroken = sentence.Split(' ');
            string FinalSentence = "";
            foreach (string word in sentenceBroken)
            {
                if (!Regex.IsMatch(word, @"^(\b[a|e|i|o|u]([A-z]*?))$"))///will check if first letter is NOT a vowel 
                {
                    FinalSentence += (MoveFirstToLast(word) + "ay ");
                    ///FinalSentence += word;
                    ///removes first letter and adds it to the end
                }
                else
                {
                    FinalSentence += (word + "way ");
                    
                    ///if no,  add "way " to the end
                }

                
            }
            return FinalSentence;
        
        }
    }
}

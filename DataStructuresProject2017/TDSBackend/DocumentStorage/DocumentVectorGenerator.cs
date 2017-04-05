using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSBackend.DocumentCleaning;

namespace TDSBackend.DocumentStorage
{
    public static class DocumentVectorGenerator
    {
        //Map which holds each word that appears in all documents and their index position
        private static Dictionary<string, int> termMap = new Dictionary<string, int>();

        //index position of next word to add to the termMap
        private static int termIndex = 0;

        //Stop word hashset
        private static HashSet<string> stopWords = new HashSet<string>();

        public static void PrintTermMap()
        {
            //Quick way to print out the termMap for testing
            foreach (KeyValuePair<string, int> p in termMap)
            {
                Console.WriteLine("{0}, {1}", p.Key, p.Value);
            }
        }

        public static DocumentVector GenerateDocumentVector(string input, string documentLocation)
        {
            //Used to generate a document vector given an input string
            //Clean the string
            input = StringCleaner.clean(input);
            //Splits the string into individual words
            string[] words = input.Split(' ');

            //Creates the term vector used when creating the document vector
            SparseVector termVector = new SparseVector();
            for (int i = 0; i < words.Length; i++)
            {
                //If the term is a stop word dont add it, otherwise add it
                if (!stopWords.Contains(words[i]))
                {
                    //Check if the current word is in the overall termMap
                    int currentWordIndex = GetTermIndex(words[i]);

                    //Adds the current word to the term vector
                    //Note that if the word is already in the vector then the value is incremented by 1, if not the value for that word is set to 1
                    termVector.AddElement(currentWordIndex, 1);
                }
            }

            //Create a new document vector
            return new DocumentVector(documentLocation, termVector);
        }

        public static DocumentVector GenerateInputVector(string input)
        {
            //Used to generate a document vector for user input
            //Clean the string
            input = StringCleaner.clean(input);
            //Splits the string into individual words
            string[] words = input.Split(' ');

            //Creates the term vector used when creating the document vector
            SparseVector termVector = new SparseVector();
            for (int i = 0; i < words.Length; i++)
            {
                //Since this is user input we don't want to add it to the map if it isnt there. So only add it to the vector if it exists in at least one other document
                if (!stopWords.Contains(words[i]) && termMap.ContainsKey(words[i]))
                {
                    //Only adds the word if it exists in at least one other document
                    int currentWordIndex = termMap[words[i]];
                    //Adds the current word to the term vector
                    //Note that if the word is already in the vector then the value is incremented by 1, if not the value for that word is set to 1
                    termVector.AddElement(currentWordIndex, 1);
                }
            }
            //Create a new document vector
            return new DocumentVector(null, termVector);
            //**NOTE** NEED TO GET THE DOCUMENT LOCATION/FILE FROM WORD CLEANER
        }

        private static int GetTermIndex(string term)
        {
            if (termMap.ContainsKey(term))
            {
                //If the word is already in the termMap, return the index
                return termMap[term];
            }
            else
            {
                //If the word is not already in the termMap, insert it and give it an index onen above the previous entry
                termMap.Add(term, termIndex);
                int currentTermIndex = termIndex;
                termIndex++;
                return currentTermIndex;
            }
        }
        
        public static void PopulateStopWordsSet(string location)
        {
            string filePath = System.IO.Directory.GetParent(location) + "\\StopWords.txt";
            try
            {
                //Extract text from the file, create a document vector for the document, add it to the index
                string text = System.IO.File.ReadAllText(filePath);
                string[] words = text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    stopWords.Add(words[i]);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Could not read stop words file at location: " + filePath);
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}

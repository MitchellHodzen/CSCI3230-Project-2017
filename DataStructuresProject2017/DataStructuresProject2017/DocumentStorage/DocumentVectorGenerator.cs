using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject2017.DocumentStorage
{
    public static class DocumentVectorGenerator
    {
        //Map which holds each word that appears in all documents and their index position
        private static Dictionary<string, int> termMap = new Dictionary<string, int>();
        //index position of next word to add to the termMap
        private static int termIndex = 0;

        public static void PrintTermMap()
        {
            //Quick way to print out the termMap for testing
            foreach (KeyValuePair<string, int> p in termMap)
            {
                Console.WriteLine("{0}, {1}", p.Key, p.Value);
            }
        }

        public static DocumentVector GenerateDocumentVector(string cleaninput)
        {
            //Used to generate a document vector given a single clean string

            //Splits the clean string into individual words
            string[] words = cleaninput.Split(' ');

            //Creates the term vector used when creating the document vector
            SparseVector termVector = new SparseVector();
            for (int i = 0; i < words.Length; i++)
            {
                //Check if the current word is in the overall termMap
                int currentWordIndex = GetTermIndex(words[i]);

                //Adds the current word to the term vector
                //Note that if the word is already in the vector then the value is incremented by 1, if not the value for that word is set to 1
                termVector.AddElement(currentWordIndex, 1);
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
    }
}

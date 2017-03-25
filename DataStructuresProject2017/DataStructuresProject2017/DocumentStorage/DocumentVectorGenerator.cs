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
            //Creates a temporary dictionary which keeps track of the words in the current document and their frequency
            Dictionary<int, int> tempDict = new Dictionary<int, int>();

            for (int i = 0; i < words.Length; i++)
            {
                //Check if the current word is in the overall termMap
                int currentWordIndex;
                if (termMap.ContainsKey(words[i]))
                {
                    //If the word is already in the termMap, set the current word index to that words index
                    currentWordIndex = termMap[words[i]];
                }
                else
                {
                    //If the word is not already in the termMap, insert it and give it an index onen above the previous entry
                    termMap.Add(words[i], termIndex);
                    currentWordIndex = termIndex;
                    termIndex++;
                }

                //Check if the current word has been added to this particular document
                if (tempDict.ContainsKey(currentWordIndex))
                {
                    //If the current word has already been added to this particular document, increment the frequency of that word by 1
                    tempDict[currentWordIndex] = tempDict[currentWordIndex] + 1;
                }
                else
                {
                    //If the current word has not already been added to this particular document, insert it with a frequency of 1
                    tempDict.Add(currentWordIndex, 1);
                }

            }

            //Create a new document vector
            return new DocumentVector(null, new SparseVector(tempDict));
            //**NOTE** NEED TO GET THE DOCUMENT LOCATION/FILE FROM WORD CLEANER
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject2017.DocumentStorage
{
    /*A sparse vector which contains information about the words that appear in the document and their frequency
    This information is held in a multidimentional array where the first index position represents a word
    which appears in the document and the second index position represents the frequency of that word in the document.
    It is a sparse vector because it only contains information about which words are present in a particular document,
    all other words not present in that document are understood to have a frequency of 0.*/

    public class SparseVector
    {
        //Internal array which contains all word frequency information about the document
        //internalArray[Word Index][Word Freqency]
        private int[][] internalArray;

        public SparseVector(Dictionary<int, int> docInput)
        {
            GenerateVector(docInput);
        }
        private void GenerateVector(Dictionary<int, int> docInput)
        {
            //Using the word frequency dictionary the internalArray is populated with words and their frequency
            internalArray = new int[docInput.Count()][];
            for (int i = 0; i < internalArray.Length; i++)
            {
                internalArray[i] = new int[2];
                internalArray[i][0] = docInput.ElementAt(i).Key;
                internalArray[i][1] = docInput.ElementAt(i).Value;
            }
        }

        public int[] GetNonZeroIndexPositions()
        {
            //Returns an array which holds the values in the first index position of the internal array
            int[] termArray = new int[internalArray.Length];
            for (int i = 0; i < termArray.Length; i++)
            {
                termArray[i] = internalArray[i][0];
            }
            return termArray;
        }

        public void PrintVector()
        {
            //Quick way to print out the vector, for testing
            for (int i = 0; i < internalArray.Length; i++)
            {
                Console.WriteLine(internalArray[i][0] + " " + internalArray[i][1]);
            }
        }
    }
}

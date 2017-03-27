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
        //internalMap<Word Index, Word Freqency>
        private Dictionary<int, int> internalMap = new Dictionary<int, int>();

        public int[] GetNonZeroIndexPositions()
        {
            //Returns an array which holds the values of all keys in the internal map
            int[] termArray = new int[internalMap.Count()];
            for (int i = 0; i < internalMap.Count(); i++)
            {
                termArray[i] = internalMap.ElementAt(i).Key;
            }
            return termArray;
        }

        public void AddElement(int indexPosition, int value)
        {
            //Check if the current index already has a value 
            if (internalMap.ContainsKey(indexPosition))
            {
                //If the index already has a value, increment that value by the passed in value
                internalMap[indexPosition] = internalMap[indexPosition] + value;
            }
            else
            {
                //If the index does not already have a value, insert that index with a value of the passed in value
                internalMap.Add(indexPosition, value);
            }
        }

        public void PrintVector()
        {
            //Quick way to print out the vector, for testing
            foreach (KeyValuePair<int, int> p in internalMap)
            {
                Console.WriteLine("{0}, {1}", p.Key, p.Value);
            }
        }
    }
}

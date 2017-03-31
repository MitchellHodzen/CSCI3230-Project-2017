using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TDSBackend.DocumentStorage
{
    /*A sparse vector which contains information about the words that appear in the document and their frequency
    This information is held in a map where the key represents a word which appears in the document and the value
    represents the frequency of that word in the document.
    It is a sparse vector because it only contains information about which words are present in a particular document,
    all other words not present in that document are understood to have a frequency of 0.*/

    public class SparseVector
    {
        public static double DotProduct(SparseVector v1, SparseVector v2)
        {
            //Calculates the dot product of two vectors v1 and v2
            int[] indexes = v1.GetNonZeroIndexPositions();
            double temp = 0;
            double dotProduct = 0;
            for (int i = 0; i < indexes.Length; i++)
            {
                temp = v1.GetValueAtIndex(indexes[i]) * v2.GetValueAtIndex(indexes[i]);
                dotProduct += temp;
            }
            return dotProduct;
        }

        public static double Norm(SparseVector vector)
        {
            //Returns the norm of the given vector
            int[] indexes = vector.GetNonZeroIndexPositions();
            double norm = 0;
            for (int i = 0; i < indexes.Length; i++)
            {
                norm += vector.GetValueAtIndex(indexes[i]) * vector.GetValueAtIndex(indexes[i]);
            }
            return Math.Sqrt(norm);
        }

        public static double CosineSimilarity(SparseVector v1, SparseVector v2)
        {
            //Calculate the cosine similarity of two sparse vectors
            return SparseVector.DotProduct(v1, v2) / (SparseVector.Norm(v1) * SparseVector.Norm(v2));
        }
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

        public int GetValueAtIndex(int index)
        {
            //If the vector contains a value at that index, return the value. If not return 0
            int value = 0;
            if (internalMap.TryGetValue(index, out value))
            {
                return value;
            }
            return value;
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

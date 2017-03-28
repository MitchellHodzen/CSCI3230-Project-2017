using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSBackend.DocumentStorage;

namespace TDSBackend.Indexing {

        /***************************************************************************** 
         *  This index class will create an dictionary of words and corresponding    *
         *  documents associated with that word. This will allow for fast retrevial  *
         *  of documents when a word is searched.                                    *
        ******************************************************************************/

    public class Index {
        
        private static Dictionary<int, List<int>> index;

        public Index() {
            index = new Dictionary<int, List<int>>();
        }

        //Method to populate the index | O(nk) for n documents with max length k
        private void populateIndex(List<DocumentVector> list) {

            //Loop through list of vectors and populate index
            for (int i = 0; i < list.Count; i++) //loop through list index
            {
                int[] words = list.ElementAt(i).GetDocumentTerms();
                for (int j = 0; j < words.Length; j++) //loop through array of words
                {
                    if (index.ContainsKey(j))
                    {
                        index[j].Add(i);
                    }
                    else
                    {
                        index.Add(j, new List<int>() { i });
                    }
                }
            }
        }//end of populateIndex

        //Method to get values per key
        public List<int> getDocuments(int key) {
            return index[key];
        }//end of getDocuments
    }
}//end of Index.cs
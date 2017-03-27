using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject2017.Indexing {
    
    public class Index {

        /* This index class will create an dictionary of words and corresponding
            documents associated with that word. This will allow for fast retrevial
            of documents when a word is searched. */
        
        private static Dictionary<int, int> index;

        public Index(){
            index = = new Dictionary<int, int>();
        }

        //Method to populate the index
        private void populateIndex(List<int> arg) {

            //Loop through list of vectors and populate index
            for (int i = 0; i < arg.Count; i++)
            {
                int[] words = DocumentVector.getDocumentTerms();
                for (int j = 0; j < words.Count ; j++)
                {
                    index.Add(i,words[j]);
                }
                
            }
        }

        //Method to get values per key
        public void getDocuments(int arg) {
            return index[arg];
        }

        public static void Main(string[] args)
        {
           //Test index.cs
        }

        
    }
}
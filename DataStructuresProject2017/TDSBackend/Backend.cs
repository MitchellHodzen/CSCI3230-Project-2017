using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSBackend.DocumentStorage;
using TDSBackend.Indexing;
using TDSBackend.DocumentSimilarity;

namespace TDSBackend
{
    public class Backend
    {
        public Backend(string location)
        {
            Index index = new Index();
            //Read each file in the given directory and create a document vector for it
            string[] filePaths = System.IO.Directory.GetFiles(location);
            List<DocumentVector> dlist = new List<DocumentVector>();
            for (int i = 0; i < filePaths.Length; i++)
            {
                try
                {
                    //Here we would also add it to the index
                    string text = System.IO.File.ReadAllText(filePaths[i]);
                    DocumentVector dv = DocumentVectorGenerator.GenerateDocumentVector(text, filePaths[i]);
                    dlist.Add(dv);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Could not read file at location: " + filePaths[i]);
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }

            //Populate the index
            index.populateIndex(dlist);
            DocumentSimilarityCalculator.SetIndex(index);
        }
        public Dictionary<DocumentVector, double> GetSortedSimilarityList(string input)
        {
            DocumentVector inputVector = DocumentVectorGenerator.GenerateInputVector(input);
            return DocumentSimilarityCalculator.GetDocumentSimilarityMap(inputVector);
        }
    }
}

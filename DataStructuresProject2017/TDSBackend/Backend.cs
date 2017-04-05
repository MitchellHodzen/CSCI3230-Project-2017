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
            DocumentVectorGenerator.PopulateStopWordsSet(location);
            //Read each file in the given directory and create a document vector for it
            string[] filePaths = System.IO.Directory.GetFiles(location);
            for (int i = 0; i < filePaths.Length; i++)
            {
                try
                {
                    //Extract text from the file, create a document vector for the document, add it to the index
                    string text = System.IO.File.ReadAllText(filePaths[i]);
                    DocumentVector dv = DocumentVectorGenerator.GenerateDocumentVector(text, filePaths[i]);
                    index.indexPopulate(dv);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Could not read file at location: " + filePaths[i]);
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }

            DocumentSimilarityCalculator.SetIndex(index);
        }

        public List<KeyValuePair<DocumentVector, double>> GetSortedSimilarityList(string input)
        {
            //Generate a document vector from the given input
            DocumentVector inputVector = DocumentVectorGenerator.GenerateInputVector(input);

            //Finds document similarity to each applicable document in the index, sorts them, then returns them
            Dictionary<DocumentVector, double> outputDictionary = DocumentSimilarityCalculator.GetDocumentSimilarityMap(inputVector);
            List<KeyValuePair<DocumentVector, double>> outputList = outputDictionary.ToList();
            outputList.Sort((v1, v2) => v1.Value.CompareTo(v2.Value));
            return outputList;
        }
    }
}

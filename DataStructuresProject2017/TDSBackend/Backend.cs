using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSBackend.DocumentStorage;
using TDSBackend.Indexing;
using TDSBackend.DocumentSimilarity;
using System.Threading;

namespace TDSBackend
{
    public class Backend
    {
        static object PopulateIndexLock = new object();
        public Backend(string location)
        {
            string[] filePaths = System.IO.Directory.GetFiles(location);

            //Preprocessing threads
            int threadCount = Environment.ProcessorCount;
            Thread[] threads = new Thread[threadCount - 1]; //We will use the main thread to process data, so we only need 3 more
            string[][] paths = new string[threadCount][];

            int totalPassed = 0;
            int docsPerThread = filePaths.Length / threadCount;
            for (int i = 0; i < threadCount; i++)
            {
                int startIndex = i * docsPerThread;
                int arrayLength = docsPerThread;
                totalPassed += docsPerThread;
                if (i + 1 == threadCount && (filePaths.Length - totalPassed) != 0)
                {
                    arrayLength += filePaths.Length - totalPassed;
                }
                paths[i] = filePaths.Skip(startIndex).Take(arrayLength).ToArray();
                System.Diagnostics.Debug.WriteLine(paths[i].Length);
            }
            //End Preprocess Threads

            Index index = new Index();
            DocumentVectorGenerator.PopulateStopWordsSet(location);

            //Read each file in the given directory and create a document vector for it
            ProcessDocumentArray(filePaths, index);
            //for (int i = 0; i < filePaths.Length; i++)
            //{
            //    try
            //    {
            //        //Extract text from the file, create a document vector for the document, add it to the index
            //        string text = System.IO.File.ReadAllText(filePaths[i]);
            //        DocumentVector dv = DocumentVectorGenerator.GenerateDocumentVector(text, filePaths[i]);
            //        index.indexPopulate(dv);
            //    }
            //    catch (Exception e)
            //    {
            //        System.Diagnostics.Debug.WriteLine("Could not read file at location: " + filePaths[i]);
            //        System.Diagnostics.Debug.WriteLine(e.Message);
            //    }
            //}

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
        private void ProcessDocumentArray(string[] filePaths, Index index)
        {
            for (int i = 0; i < filePaths.Length; i++)
            {
                try
                {
                    //Extract text from the file, create a document vector for the document, add it to the index
                    string text = System.IO.File.ReadAllText(filePaths[i]);
                    DocumentVector dv = DocumentVectorGenerator.GenerateDocumentVector(text, filePaths[i]);
                    lock (PopulateIndexLock)
                    {
                        index.indexPopulate(dv);
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Could not read file at location: " + filePaths[i]);
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
        }
    }
}

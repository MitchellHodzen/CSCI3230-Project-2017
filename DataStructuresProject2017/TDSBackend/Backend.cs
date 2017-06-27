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
        private static readonly object PopulateIndexLock = new object();
        Index index;

        public Backend(string location)
        {
            string[] filePaths = System.IO.Directory.GetFiles(location);
            index = new Index();
            DocumentVectorGenerator.PopulateStopWordsSet(location);

            //Preprocessing threads
            int threadCount = Environment.ProcessorCount;
            Thread[] threads = new Thread[threadCount]; 
            string[][] paths = new string[threadCount][];
            //Separate the files into 4 relatively even sections for each thread
            int totalPassed = 0;
            int docsPerThread = filePaths.Length / threadCount;
            for (int i = 0; i < threadCount; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(ProcessDocumentArray));
                int startIndex = i * docsPerThread;
                int arrayLength = docsPerThread;
                totalPassed += docsPerThread;
                if (i + 1 == threadCount && (filePaths.Length - totalPassed) != 0)
                {
                    arrayLength += filePaths.Length - totalPassed;
                }
                paths[i] = filePaths.Skip(startIndex).Take(arrayLength).ToArray();
            }
            //End Preprocess Threads

            //Read each file in the given directory and create a document vector for it

            //Sending a section of documents to each thread 
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start(paths[i]);
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
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
        private void ProcessDocumentArray(object arg)
        {
            string[] filePaths = (string[])arg;
            for (int i = 0; i < filePaths.Length; i++)
            {
                try
                {
                    //Extract text from the file, create a document vector for the document, add it to the index
                    string text = System.IO.File.ReadAllText(filePaths[i]);
                    DocumentVector dv = DocumentVectorGenerator.GenerateDocumentVector(text, filePaths[i]);
                    //System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.Name);
                    lock (Backend.PopulateIndexLock)
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

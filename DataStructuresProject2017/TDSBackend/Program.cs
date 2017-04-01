using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSBackend.DocumentStorage;
using TDSBackend.Indexing;
using TDSBackend.DocumentSimilarity;
using TDSBackend.DocumentCleaning;
using System.IO;

namespace TDSBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            //PUT TEST CODE HERE
            //Test String cleaner
            string resourcePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources";
            Backend backend = new Backend(resourcePath);


            StringCleaner testClean = new StringCleaner();
            try
            {
                string text = File.ReadAllText(@"C:\Users\Dalton\Documents\visual studio 2015\Projects\ConsoleApplication2\ConsoleApplication2\testfile.txt");
                System.Diagnostics.Debug.WriteLine(testClean.clean(text));

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("The file could not be read.");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            
            //Test dot product
            SparseVector v1 = new SparseVector();
            v1.AddElement(0, 1);
            v1.AddElement(2, 3);
            SparseVector v2 = new SparseVector();
            v2.AddElement(0, 5);
            v2.AddElement(1, 3);
            Console.WriteLine("The dot product of v1 and v2 is: " + SparseVector.DotProduct(v1, v2));

            //Test norm
            Console.WriteLine("The norm of v1 is: " + SparseVector.Norm(v1));

            //Test cosine similarity
            Console.WriteLine("The cosine simlarity of v1 and v2 is: " + SparseVector.CosineSimilarity(v1, v2));

            //Test document vector similarity
            Console.WriteLine("Document Similarity test:");

            String input = "The brown cow jumped over the moon";
            Console.WriteLine("Input: " + input);
            Dictionary<DocumentVector, double> similarityMap = backend.GetSortedSimilarityList(input);
            foreach (KeyValuePair<DocumentVector, double> k in similarityMap)
            {
                Console.WriteLine("Document: " + k.Key + ". Similarity: " + k.Value);
            }
            Console.ReadLine();
        }
    }
}

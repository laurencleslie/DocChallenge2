using System;
using System.IO;

namespace DocumentMerger2
{
    class Program
    {
        static void Main(string[] args)
        {
            String nc = "";
            int count;

            if (args.Length < 3)
            {
                Console.WriteLine("Document Merger");
                Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as command line arguments.");
            }
            else
            {
                count= args.Length;
                for(int i=0; i<args.Length-1; i++)
                {
                    Console.WriteLine("File to merge: "+args[i]);
                    while (!File.Exists(args[i]))
                    {
                        Console.WriteLine("File "+args[i] +" not found. Please enter valid files.");
                        Console.ReadLine();
                        sw.Close();
                    }
                    try
                    {
                       nc += System.IO.File.ReadAllText(args[i]);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        Environment.Exit(0);
                    }
                }
                Console.WriteLine("New File: "+args[count-1]);
                try
                {
                    using (StreamWriter sw = new StreamWriter(args[count- 1]))
                    {
                        sw.WriteLine(nc);
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine("Exception " e.Message);
                    Console.WriteLine("exiting")
                }
                finally
                {
                    sw.Close();

                }
            }
            Console.WriteLine("Your new file "+ args[args.Length - 1] + " has been created!");
            Console.ReadLine();
        }
    }

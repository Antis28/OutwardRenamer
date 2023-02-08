using System;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;

namespace Ranamer
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            try
            {
                Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        private static void Start()
        {
            Console.WriteLine("Hello");


            var currentPath = Environment.CurrentDirectory;
            currentPath = @"P:\_TEST\";
            ScanDirs(currentPath);
        }

        private static void ScanDirs(string currentPath)
        {
            var dirs = Directory.GetDirectories(currentPath);
            if (dirs.Length > 0)
            {
                foreach (string dir in dirs)
                {
                    ScanDirs(dir);
                }
            }
            RenameAllExts(currentPath);
        }

        private static void RenameAllExts(string currentPath)
        {
            Console.WriteLine(new String('-',80));
            Console.WriteLine($"Directory {currentPath} processing..");
            remEnvc(currentPath);
            remCharc(currentPath);
            remLegacyc(currentPath);
            remMapc(currentPath);
            remWorldc(currentPath);
            Console.WriteLine(new String('*', 80));
        }

        private static void remEnvc(string destinationPath)
        {
            var oldExtTemplate = "*.envc";
            var newExt = "deenvc";
            var files = new DirectoryInfo(destinationPath).GetFiles(oldExtTemplate);
            Rename(newExt, destinationPath, files);
        }
        private static void remCharc(string destinationPath)
        {
            var oldExtTemplate = "*.charc";
            var newExt = "defedc";
            var files = new DirectoryInfo(destinationPath).GetFiles(oldExtTemplate);
            Rename(newExt, destinationPath, files);
        }
        private static void remLegacyc(string destinationPath)
        {
            var oldExtTemplate = "*.legacyc";
            var newExt = "defedc";
            var files = new DirectoryInfo(destinationPath).GetFiles(oldExtTemplate);
            Rename(newExt, destinationPath, files);
        }
        private static void remMapc(string destinationPath)
        {
            var oldExtTemplate = "*.mapc";
            var newExt = "defedc";
            var files = new DirectoryInfo(destinationPath).GetFiles(oldExtTemplate);
            Rename(newExt, destinationPath, files);
        }
        private static void remWorldc(string destinationPath)
        {
            var oldExtTemplate = "*.worldc";
            var newExt = "defedc";
            var files = new DirectoryInfo(destinationPath).GetFiles(oldExtTemplate);
            Rename(newExt, destinationPath, files);
        }


        private static void Rename(string newExt, string destinationPath, FileInfo[] files)
        {
            foreach (var oldNameExt in files)
            {
                string old = oldNameExt.FullName;
                var newNameExt = Path.ChangeExtension(oldNameExt.Name, newExt);
                var newPath = Path.Combine(destinationPath, newNameExt);
                if (File.Exists(newPath))
                {
                    File.Delete(newPath);
                }

                oldNameExt.MoveTo(newPath);

                if (!File.Exists(old))
                {
                    Console.WriteLine($"File {newNameExt} successfully renamed.");
                }

            }
        }
    }
}

namespace _05._Slicing_File
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        private const int bufferSize = 4096;
        public static void Main()
        {
           

            string sourceFilePath = "../Resources/sliceMe.mp4";
            string destination= "";
            int parts = 5;

            Slice(sourceFilePath, destination, parts);


            List<string> files = new List<string>();

            for (int i = 0; i < parts; i++)
            {
                files.Add($"Part-{i}.mp4");
            }

            Assemble(files, destination);
        }

        public static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.') + 1);

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }
            string assembledFile = $"{destinationDirectory}Assembled.{extension}";

            if (!destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }
            using (FileStream writer = new FileStream(assembledFile, FileMode.Create))
            {
                byte[] buffer = new byte[4096];

                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    { 
                        while ((reader.Read(buffer, 0, bufferSize)) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }
        }

        public static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);


                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;

                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    string currentPart = destinationDirectory + $"Part-{i}.{extension}";

                    using (FileStream writer = new FileStream(currentPart, FileMode.Create))
                    {
                        byte[] buffer = new byte[bufferSize];

                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPieceSize += bufferSize;

                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}

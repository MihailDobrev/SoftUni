namespace Logger.Models
{
    using System;
    using System.IO;

    public class LogFile : ILogFile
    {
        const string DefaultPath = "./Data/";
        public string Path { get; }
        public int Size { get; private set; }


        public LogFile(string fileName)
        {
            Path = DefaultPath + fileName;
            InitializeFile();
            Size = 0;
        }

        private void InitializeFile()
        {
            Directory.CreateDirectory(DefaultPath);
            File.AppendAllText(this.Path, "");
        }

        public void WriteToFile(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog + Environment.NewLine);

            int addedSize = 0;
            for (int i = 0; i < errorLog.Length; i++)
            {
                if (char.IsLetter(errorLog[i]))
                {
                    addedSize += errorLog[i];
                }            
            }

            Size += addedSize;
        }
    }
}

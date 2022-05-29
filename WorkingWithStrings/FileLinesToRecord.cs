namespace WorkingWithStrings
{
    public class FileLinesToRecord
    {
        private string _pathFileMail;

        public FileLinesToRecord(string path)
        {
            if (!File.Exists(path))
                File.Create(path);
            _pathFileMail = path;
        }

        public void WriteLineToFile(List<string> line)
        {
            if (line.Count() == 0)
                throw new ArgumentException("Пустой список!");
            File.WriteAllText(_pathFileMail, string.Empty);
            File.WriteAllLines(_pathFileMail, line);
        }
    }
}

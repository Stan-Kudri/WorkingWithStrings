namespace WorkingWithStrings.TXT
{
    public class FileLinesToRecordTxt
    {
        private string _pathFileMail;

        public FileLinesToRecordTxt(string path)
        {
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

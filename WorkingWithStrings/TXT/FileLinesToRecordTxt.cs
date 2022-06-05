using WorkingWithStrings.Interface;

namespace WorkingWithStrings.TXT
{
    public class FileLinesToRecordTxt : IFileToRecord
    {
        private readonly string _pathFileMail;

        public FileLinesToRecordTxt(string path)
        {
            _pathFileMail = path;
        }

        public void WriteLineToFile(List<UserData> line)
        {
            if (line.Count() == 0)
                throw new ArgumentException("Пустой список!");

            File.WriteAllText(_pathFileMail, string.Empty);
            File.WriteAllLines(_pathFileMail, line.Select(x => x.Email).ToArray());
        }
    }
}

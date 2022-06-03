using CsvHelper;
using System.Globalization;

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

        public void WriteLineToFile(List<UserData> line)
        {
            if (line.Count() == 0)
                throw new ArgumentException("Пустой список!");

            using (var file = new StreamWriter(_pathFileMail, false, System.Text.Encoding.Default))
            {
                using (var csv = new CsvWriter(file, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(line);
                }
            }
        }
    }
}

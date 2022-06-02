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

        public void WriteLineToFile(List<string> line)
        {
            if (line.Count() == 0)
                throw new ArgumentException("Пустой список!");
            var mail = new List<Email>();

            foreach (var dateItem in line)
            {
                mail.Add(new Email(dateItem));
            }

            using (var file = new StreamWriter(_pathFileMail, false, System.Text.Encoding.Default))
            {
                using (var csv = new CsvWriter(file, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(mail);
                }
            }
        }
    }
}

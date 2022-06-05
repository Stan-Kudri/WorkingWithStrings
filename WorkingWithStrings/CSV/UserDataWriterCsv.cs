using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using WorkingWithStrings.Interface;

namespace WorkingWithStrings
{
    public class UserDataWriterCsv : IFileToRecord
    {
        private readonly string _pathFileMail;

        public UserDataWriterCsv(string path)
        {
            _pathFileMail = path;
        }

        public void Write(List<UserData> line)
        {
            if (line.Count() == 0)
                throw new ArgumentException("Пустой список!");

            using (var file = File.OpenWrite(_pathFileMail))
            {
                using (var writer = new StreamWriter(file, System.Text.Encoding.UTF8))
                {
                    var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = "#", Encoding = System.Text.Encoding.UTF8 };
                    using (var csv = new CsvWriter(writer, config))
                    {
                        foreach (var record in line)
                        {
                            csv.WriteField(record.Email);
                            csv.NextRecord();
                        }
                    }
                }
            }
        }
    }
}

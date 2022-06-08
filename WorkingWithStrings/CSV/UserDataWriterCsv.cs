using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using WorkingWithStrings.Interface;

namespace WorkingWithStrings
{
    public class UserDataWriterCsv : IUserDataWriter
    {
        private readonly string _pathFile;

        public UserDataWriterCsv(string path)
        {
            _pathFile = path;
        }

        public void WriteMail(List<UserData> line)
        {
            if (line.Count() == 0)
                throw new ArgumentException("Пустой список!");

            using (var file = File.OpenWrite(_pathFile))
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

        public void WriteAllData(List<string> data)
        {
            var userData = new List<UserData>(ListConversion(data));

            using (var file = new StreamWriter(_pathFile, false, System.Text.Encoding.UTF8))
            {
                var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = "#", Encoding = System.Text.Encoding.UTF8 };
                using (var csv = new CsvWriter(file, config))
                {
                    csv.WriteRecords(userData);
                }
            }
        }

        private List<UserData> ListConversion(List<string> data)
        {
            var userData = new List<UserData>();

            foreach (var dateItem in data)
            {
                userData.Add(FromString(dateItem, "#"));
            }
            return userData;
        }

        private static UserData FromString(string data, string separator = ",")
        {
            var array = data.Split(separator);

            var dateStr = array[0];
            var mailStr = array[1].Replace(" ", "");

            return new UserData(dateStr, mailStr);
        }
    }
}

using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using WorkingWithStrings.Interface;

namespace WorkingWithStrings
{
    public class UserDataReaderCsv : IMailFinder
    {
        private readonly string _path;

        public UserDataReaderCsv(string path)
        {
            if (!File.Exists(path))
                throw new FieldAccessException("Нет файла!");
            _path = path;
        }

        public List<UserData> SearchMailInFile()
        {
            var mail = new List<UserData>();

            using (var reader = new StreamReader(_path, System.Text.Encoding.UTF8))
            {
                var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = "#", Encoding = System.Text.Encoding.UTF8 };
                using (var csv = new CsvReader(reader, config))
                {
                    mail = csv.GetRecords<UserData>().ToList();
                }
            }

            return mail;
        }
    }
}
